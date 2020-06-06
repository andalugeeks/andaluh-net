using Andaluh.Extensions;
using Andaluh.Rules.Base;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Andaluh.Rules
{
    internal class VRules : RuleBundle
    {
        private static readonly Regex pattern_v = new Regex("(?i)v");
        private static readonly Regex pattern_nv = new Regex("(?i)nv");

        private static readonly Dictionary<string, string> V_RULES_EXCEPT = new Dictionary<string, string>()
        {
            {"vis", "bî"},
            {"ves", "bêh"},
        };

        protected override IEnumerable<Rule> Rules => new[]
        {
           new Rule(pattern_nv, nv_rules_replacer),
            new Rule(pattern_v, v_rules_replacer, V_RULES_EXCEPT)
        };

        private string nv_rules_replacer(Match match, string text, int bias) =>
           (match.Value[0].IsUpperCase() ? "M" : "m") + (match.Value[1].IsUpperCase() ? "B" : "b");

        private string v_rules_replacer(Match match, string text, int bias) =>
            match.Value[0].IsUpperCase() ? "B" : "b";

        public VRules() : base()
        { }
    }
}
