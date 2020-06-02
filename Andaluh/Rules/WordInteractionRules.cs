using Andaluh.Extensions;
using Andaluh.Rules.Base;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Andaluh.Rules
{
    internal class WordInteractionRules : RuleBundle
    {
        private static readonly Regex pattern_word_interaction = new Regex(@"(?i)(l\b)(\s)([bcçdfghjklmnñpqstvwxyz])");

        protected override IEnumerable<Rule> Rules => new[]
        {
           new Rule(pattern_word_interaction, word_interaction_rules_replacer)
        };

        private static string word_interaction_rules_replacer(Match match, string text, int bias)
        {
            var rightCapitalization = match.Value[0].IsUpperCase() ? "R" : "r";
            return rightCapitalization + match.Value.Substring(1);
        }

        public WordInteractionRules() : base()
        { }
    }
}
