using Andaluh.Extensions;
using Andaluh.Rules.Base;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Andaluh.Rules
{
    internal class ChRules : RuleBundle
    {
        private static readonly Regex pattern_ch = new Regex("(?i)ch");

        protected override IEnumerable<Rule> Rules => new[]
        {
           new Rule(pattern_ch, ch_rules_replacer)
        };

        private string ch_rules_replacer(Match match, string text, int bias) =>
               match.Value[0].IsUpperCase() ? "X" : "x";

        public ChRules() : base()
        { }
    }
}
