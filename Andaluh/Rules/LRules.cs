using Andaluh.Extensions;
using Andaluh.Rules.Base;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Andaluh.Rules
{
    internal class LRules : RuleBundle
    {
        private static readonly Regex pattern_l = new Regex("(?i)(l)([bcçgsdfghkmpqrtxz])");

        protected override IEnumerable<Rule> Rules => new[]
        {
            new Rule(pattern_l, l_rules_replacer)
        };

        private string l_rules_replacer(Match match, string text, int bias) =>
            match.Value[0].KeepCase('r') + match.Value[1];


        public LRules() : base()
        { }
    }
}
