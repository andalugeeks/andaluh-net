using Andaluh.Extensions;
using Andaluh.Rules.Base;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Andaluh.Rules
{
    internal class LLRules : RuleBundle
    {
        private static readonly Regex pattern_ll = new Regex("(?i)ll");

        private static readonly Dictionary<string, string> LL_RULES_EXCEPT = new Dictionary<string, string>()
        {
            {"grill", "grîh"},
        };

        protected override IEnumerable<Rule> Rules => new[]
        {
            new Rule(pattern_ll, ll_rules_replacer, LL_RULES_EXCEPT)
        };

        private static string ll_rules_replacer(Match match, string text, int bias) =>
            match.Value[0].IsUpperCase() ? "Y" : "y";

        public LLRules() : base()
        { }
    }
}
