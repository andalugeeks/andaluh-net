using Andaluh.Extensions;
using Andaluh.Rules.Base;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Andaluh.Rules
{
    internal class XRules : RuleBundle
    {
        private static readonly Regex pattern_x_starting = new Regex("(?i)([xX])([aáeéiíoóuú])");
        private static readonly Regex pattern_x = new Regex("(?i)([aeiouáéíóú])(x)([aeiouáéíóúy])");

        protected override IEnumerable<Rule> Rules => new[]
        {
            new Rule(pattern_x, x_rules_replacer),
            new Rule(pattern_x_starting, x_starting_rules_replacer)
        };

        private static string x_starting_rules_replacer(Match match, string text, int bias)
        {
            string VAF_correct_capitalization = match.Value[0].IsUpperCase() ? Constants.VAF_mayus : Constants.VAF;
            return VAF_correct_capitalization + match.Value[1];
        }

        public static string x_rules_replacer(Match match, string text, int bias)
        {
            string VAF_correct_capitalization = match.Value[1].IsUpperCase() ? Constants.VAF_mayus : Constants.VAF;
            return match.Value[0].GetVowelCircumflex() + VAF_correct_capitalization + VAF_correct_capitalization + match.Value[2];
        }

        public XRules() : base()
        { }
    }
}
