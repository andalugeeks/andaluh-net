using Andaluh.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Andaluh.Rules.Base
{
    internal class Rule
    {
        private Regex Pattern { get; }
        private Func<Match, string, int, string> Replacer { get; }
        private Dictionary<string, string> Exceptions { get; }

        private Dictionary<string, string> DynamicRuleExceptions;

        public Rule(Regex pattern, Func<Match, string, int, string> replacer, Dictionary<string, string> exceptions = default)
        {
            Pattern = pattern;
            Replacer = replacer;
            Exceptions = exceptions;
        }

        public string Execute(Dictionary<string, string> dynamicRuleExceptions, string text)
        {
            DynamicRuleExceptions = dynamicRuleExceptions;

            if (Exceptions?.Count() > 0 || DynamicRuleExceptions?.Count() > 0) text = ReplaceExceptions(text);

            return ReplaceMany(text);
        }

       
        private string ReplaceMany(string text)
        {
            var matches = Pattern?.Matches(text);
            if (matches?.Any() != true) return text;

            var bias = 0;

            foreach (Match match in matches.Where(x => x.Success))
            {
                if (NotException(match, text, bias))
                {
                    var newText = Replacer(match, text, bias);
                    text = text.ReplaceFirst(match, newText, bias);
                    bias += newText.Length - match.Value.Length;
                }

            }
            return text;
        }

        private bool NotException(Match match, string text, int bias) => !IsException(text.GetWholeWord(match.Index + bias));

        private bool IsException(string palabra) =>
            Exceptions?.ContainsKey(palabra.ToLower()) == true ||
            DynamicRuleExceptions?.ContainsKey(palabra.ToLower()) == true;

        private string ReplaceExceptions(string text) => text.ReplaceWordsByDictionary(DynamicRuleExceptions).ReplaceWordsByDictionary(Exceptions);
    }
}
