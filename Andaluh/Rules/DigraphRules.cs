using Andaluh.Extensions;
using Andaluh.Rules.Base;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Andaluh.Rules
{
    internal class DigraphRules : RuleBundle
    {
        private static readonly Regex pattern_digraph_special_1 = new Regex("(?i)([aeiouáéíóú])([lr])s(t)");
        private static readonly Regex pattern_digraph_special_2 = new Regex("(?i)(tr|p)([ao])(?:ns|st)([bcçdfghjklmnpqstvwxyz])");
        private static readonly Regex pattern_digraph_special_3 = new Regex("(?i)([aeiouáéíóú])([bdnr])(s)([bcçdfghjklmnpqstvwxyz])");
        private static readonly Regex pattern_digraph_special_4 = new Regex("(?i)([aeiouáéíóú])[djrstxz](l)");
        private static readonly Regex pattern_digraph_general = new Regex("(?i)([aeiouáéíóú])(" + string.Join("|", Constants.DIGRAPHS) + ")");

        protected override IEnumerable<Rule> Rules => new[]
        {
            new Rule(pattern_digraph_special_1, digraph_special1_rules_replacer),
            new Rule(pattern_digraph_special_2, digraph_special2_rules_replacer),
            new Rule(pattern_digraph_special_3, digraph_special3_rules_replacer),
            new Rule(pattern_digraph_special_4, digraph_special4_rules_replacer),
            new Rule(pattern_digraph_general, digraph_general_rules_replacer)
        };

        private string digraph_special1_rules_replacer(Match match, string text, int bias) =>
            match.Value[1] switch
            {
                'l' => match.Value[0] + "rtt",
                'r' => match.Value[0] + "rtt",
                _ => match.Value
            };

        private string digraph_special2_rules_replacer(Match match, string text, int bias)
        {
            string init_char = match.Groups[1].Value;
            char vowel_char = match.Groups[2].Value[0];
            char cons_char = match.Groups[0].Value[^1];

            return cons_char.ToLower() == 'l' ?
                 init_char + vowel_char.apply_repl_rules() + cons_char + "-" + cons_char :
                 init_char + vowel_char.apply_repl_rules() + cons_char + cons_char;
        }

        private string digraph_special3_rules_replacer(Match match, string text, int bias)
        {
            var vowel_char = match.Value[0].ToString();
            var cons_char = match.Value[1].ToString();
            var s_char = match.Value[2];
            var digraph_char = match.Value[^1];

            return cons_char.ToLower() == "r" && s_char.ToLower() == 's' ?
                vowel_char + cons_char + digraph_char + digraph_char :
                vowel_char.apply_repl_rules() + digraph_char + digraph_char;
        }

        private string digraph_special4_rules_replacer(Match match, string text, int bias)
        {
            var vowel_char = match.Value[0].ToString();
            var digraph_char = match.Value[^1];

            return vowel_char.apply_repl_rules() + digraph_char + "-" + digraph_char;
        }

        private string digraph_general_rules_replacer(Match match, string text, int bias)
        {
            var suffix = text.GetSuffix(match, bias);
            var vowel_Circum = match.Value[0].GetVowelCircumflex().ToString();
            var digraph_char = match.Value[2];

            if (suffix.IsNullOrEmpty() && match.Groups[2].Value.ToLower() == "xy") return match.Value;
            return suffix.IsNullOrEmpty() ? vowel_Circum : vowel_Circum + digraph_char + digraph_char;
        }

        public DigraphRules() : base()
        { }
    }
}
