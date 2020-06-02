using Andaluh.Extensions;
using Andaluh.Rules.Base;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Andaluh.Rules
{
    internal class PsicoPseudoRules : RuleBundle
    {
        private static readonly Regex pattern_psico_pseudo = new Regex("(?i)p(sic|seud)");

        protected override IEnumerable<Rule> Rules => new[]
        {
           new Rule(pattern_psico_pseudo, psico_pseudo_rules_replacer)
        };

        private string psico_pseudo_rules_replacer(Match match, string text, int bias)
        {
            var undetermined_consonant = match.Value[1];
            if (match.Value[0].ToLower() == 'p')
            {
                var undetermined_correct_capitalization = match.Value[1].IsUpperCase() ? undetermined_consonant.ToUpper() : undetermined_consonant;
                return undetermined_correct_capitalization + match.Value.Substring(2);
            }
            else return "";
        }

        public PsicoPseudoRules() : base()
        { }
    }
}
