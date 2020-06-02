using Andaluh.Extensions;
using Andaluh.Rules.Base;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Andaluh.Rules
{
    internal class VAFRules : RuleBundle
    {
        private static readonly Regex pattern_vaf = new Regex("(?i)(c(?=[eiéíêî])|z|s)([aeiouáéíóúÁÉÍÓÚâêîôûÂÊÎÔÛ])");

        protected override IEnumerable<Rule> Rules => new[]
        {
           new Rule(pattern_vaf, vaf_rules_replacer)
        };

        private string vaf_rules_replacer(Match match, string text, int bias)
        {
            string vaf_correct_capitalization = match.Value[0].IsUpperCase() ? Constants.VAF_mayus : Constants.VAF;
            return vaf_correct_capitalization + match.Value[1];
        }

        public VAFRules() : base()
        { }
    }
}
