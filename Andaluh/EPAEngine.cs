using Andaluh.Rules;
using Andaluh.Rules.Base;
using System.Collections.Generic;

namespace Andaluh
{
    internal class EPAEngine
    {
        public readonly Dictionary<string, string> DynamicRuleExceptions = new Dictionary<string, string>();

        private RuleBundle[] rulesOrder => new RuleBundle[]
        {
            new HRules(DynamicRuleExceptions),
            new XRules(),
            new ChRules(),
            new GJRules(DynamicRuleExceptions),
            new VRules(),
            new LLRules(),
            new LRules(),
            new PsicoPseudoRules(),
            new VAFRules(),
            new WordEndingRules(),
            new DigraphRules(),
            new ExceptionRules(),
            new WordInteractionRules(),
            new FinalRules()
        };

        public string Transcribe(string text)
        {
            foreach (var rule in rulesOrder)
                text = rule.Execute(text);

            return text;
        }
    }
}
