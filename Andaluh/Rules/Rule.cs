using Andaluh.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Andaluh.Rules
{
    internal class Rule
    {
        public Regex Pattern { get; }
        public Func<Match, string, int, string> Replacer { get; }
        public Dictionary<string, string> Exceptions { get; }

        public Rule(Regex pattern, Func<Match, string, int, string> replacer, Dictionary<string, string> exceptions = default)
        {
            Pattern = pattern;
            Replacer = replacer;
            Exceptions = exceptions;
        }

        public string Execute(string text)
        {
            if (Exceptions != default) text = ReplaceExceptions(text);

            return ReplaceMany(text);
        }

        private string ReplaceMany(string text)
        {
            var matches = Pattern.Matches(text);
            if (!matches.Any()) return text;

            var bias = 0;

            foreach (Match match in matches)
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

        private bool NotException(Match match, string text, int bias)
        {
            if (Exceptions == default) return true;
            else return !IsException(text.GetWholeWord(match.Index + bias));
        }

        private bool IsException(string palabra) => Exceptions?.ContainsKey(palabra.ToLower()) == true;

        private string ReplaceExceptions(string text) => text.ReplaceWordsByDictionary(Exceptions);
    }
}
