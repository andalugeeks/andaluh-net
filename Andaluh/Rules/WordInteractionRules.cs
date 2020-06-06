using Andaluh.Extensions;
using Andaluh.Rules.Base;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Andaluh.Rules
{
    internal class WordInteractionRules : RuleBundle
    {
        private static readonly Regex pattern_word_interaction = new Regex(@"(?i)((\bdel\b)|(\bel\b))(\s)([bcçdfghjklmnñpqstvwxyz])");

        protected override IEnumerable<Rule> Rules => new[]
        {
           new Rule(pattern_word_interaction, word_interaction_rules_replacer)
        };

        private static string word_interaction_rules_replacer(Match match, string text, int bias)=>
            match.Value[0].ToLower() == 'd' ?
            match.Value[0..2] + (match.Value[2].IsUpperCase() ? "R" : "r") + match.Value[3..] :
            match.Value[0] + (match.Value[1].IsUpperCase() ? "R" : "r") + match.Value[2..];

        public WordInteractionRules() : base()
        { }
    }
}
