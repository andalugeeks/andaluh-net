using Andaluh.Extensions;
using Andaluh.Rules.Base;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Andaluh.Rules
{
    internal class LRules : RuleBundle
    {
        private static readonly Regex pattern_l = new Regex("(?i)(l)([bcçgsdfghkmpqrtxz])");

        private readonly Dictionary<string, string> L_RULES_EXCEPT = new Dictionary<string, string>();

        protected override IEnumerable<Rule> Rules => new[]
        {
            new Rule(RuleConstants.pattern_begin_lh, exceptuar_patron),
            new Rule(pattern_l, l_rules_replacer, L_RULES_EXCEPT)
        };

        private string exceptuar_patron(Match match, string text, int bias)
        {
            var palabra = text.GetWholeWord(match.Index + bias);
            if (!L_RULES_EXCEPT.ContainsKey(palabra))
                L_RULES_EXCEPT.Add(palabra, palabra);

            return match.Value;
        }

        private string l_rules_replacer(Match match, string text, int bias) =>
            match.Value[0].KeepCase('r') + match.Value[1];

        public LRules() : base()
        { }
    }
}
