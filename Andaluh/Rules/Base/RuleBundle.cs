using System.Collections.Generic;

namespace Andaluh.Rules.Base
{
    internal abstract class RuleBundle
    {
        protected readonly Dictionary<string, string> DynamicRuleExceptions;
        protected abstract IEnumerable<Rule> Rules { get; }

        public RuleBundle(Dictionary<string, string> dynamicRuleExceptions = null)
        {
            DynamicRuleExceptions = dynamicRuleExceptions;
        }
        public string Execute(string text)
        {
            foreach (var rule in Rules)
                text = rule.Execute(DynamicRuleExceptions, text);

            return text;
        }
    }
}
