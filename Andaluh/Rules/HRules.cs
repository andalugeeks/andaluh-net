using Andaluh.Extensions;
using Andaluh.Rules.Base;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Andaluh.Rules
{
    internal class HRules : RuleBundle
    {
        private static readonly Regex pattern_aha = new Regex("(?i)([aá]h[aáeéíuú]|aho(?!rr|ra|ri)|ehe|ehi(?!sto)|oho|ih[ií]|uhu)");
        private static readonly Regex pattern_h_general = new Regex("(?i)(?<!c)(h)([aáeéiíoóuú])");
        private static readonly Regex pattern_h_hua = new Regex("(?i)(?<!c)(h)(ua)");
        private static readonly Regex pattern_h_hue = new Regex("(?i)((?<!c)(h)(u)(e|é))|((?<!c)(h)(u)(i))");

        private readonly Dictionary<string, string> H_RULES_EXCEPT = new Dictionary<string, string>()
        {
            {"haz", "âh"},
            {"hez", "êh"},
            {"hoz", "ôh"},
            {"oh", "ôh"},
            {"yihad", "yihá"},
            {"h", "h"}, // Keep an isolated h as-is
        
        };

        protected override IEnumerable<Rule> Rules => new[]
        {
            new Rule(RuleConstants.pattern_begin_lh, exceptuar_patron),
            new Rule(pattern_h_hua, h_hua_rules_replacer),
            new Rule(pattern_h_hue, h_hue_rules_replacer),
            new Rule(pattern_aha, exceptuar_patron),
            new Rule(pattern_h_general, h_rules_replacer, H_RULES_EXCEPT)
        };

        private string exceptuar_patron(Match match, string text, int bias)
        {
            var palabra = text.GetWholeWord(match.Index + bias);
            if (!H_RULES_EXCEPT.ContainsKey(palabra))
                H_RULES_EXCEPT.Add(palabra, palabra);

            return match.Value;
        }

        private string h_hue_rules_replacer(Match match, string text, int bias)
        {
            string g_correct_capitalization = match.Value[0].KeepCase('g');
            var result = g_correct_capitalization + match.Value.Substring(1);

            AddTransliteratedWordAsExceptionForGueGui(match, text, bias, result);

            return result;
        }

        private void AddTransliteratedWordAsExceptionForGueGui(Match match, string text, int bias, string result)
        {
            var palabra = text.GetWholeWord(match.Index + bias);
            var newWord = palabra.Replace(match.Value, result).ToLower();
            if (!DelayedAfterRuleDynamicRuleExceptions.ContainsKey(newWord))
                DelayedAfterRuleDynamicRuleExceptions.Add(newWord, newWord);
        }

        private string h_hua_rules_replacer(Match match, string text, int bias)
        {
            string g_correct_capitalization = match.Value[0].IsUpperCase() ? "G" : "g";
            return g_correct_capitalization + match.Value.Substring(1);
        }

        private string h_rules_replacer(Match match, string text, int bias)
        {
            var undetermined_vocal = match.Value[1].ToString();
            return match.Value[0].ToLower() == 'h' ?
                match.Value[0].IsUpperCase() ? undetermined_vocal.ToUpper() : undetermined_vocal : string.Empty;
        }

        public HRules(Dictionary<string, string> dynamicRuleExceptions) : base(dynamicRuleExceptions)
        { }
    }
}
