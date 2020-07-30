using System.Collections.Generic;

namespace Andaluh.Rules.Base
{
    internal abstract class RuleBundle
    {
        protected readonly Dictionary<string, string> DynamicRuleExceptions;
        protected Dictionary<string, string> DelayedAfterRuleDynamicRuleExceptions;
        protected abstract IEnumerable<Rule> Rules { get; }

        public RuleBundle(Dictionary<string, string> dynamicRuleExceptions = null)
        {
            DynamicRuleExceptions = dynamicRuleExceptions;
        }
        public string Execute(string text)
        {
            foreach (var rule in Rules)
            {
                DelayedAfterRuleDynamicRuleExceptions = new Dictionary<string, string>();
                text = rule.Execute(DynamicRuleExceptions, text);
                UpdateDynamicRulesAfterCurrentRule();
            }

            return text;
        }

        private void UpdateDynamicRulesAfterCurrentRule()
        {
            foreach (var exception in DelayedAfterRuleDynamicRuleExceptions)
            {
                if (!DynamicRuleExceptions.ContainsKey(exception.Key))
                    DynamicRuleExceptions.Add(exception.Key, exception.Value);
                else DynamicRuleExceptions[exception.Key] = exception.Value;
            }
        }

    }
}
