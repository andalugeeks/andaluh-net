using Andaluh.Rules;
using Andaluh.Rules.Base;
using Andaluh.SentenceMethods;
using System.Collections.Generic;

namespace Andaluh
{
    internal class EPAEngine
    {
        public readonly Dictionary<string, string> DynamicRuleExceptions = new Dictionary<string, string>();

        private RuleBundle[] perWordRules => new RuleBundle[]
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
            new FinalRules()
        };

        private RuleBundle[] perSentenceRules => new RuleBundle[]
        {
            new WordInteractionRules()
        };

        public string Transcribe(string text)
        {
            var tokenizedString = new TokenEvaluator(text);

            foreach (Token word in tokenizedString.GetWordsToTransliterate())
                foreach (var rule in perWordRules)
                    word.Value = rule.Execute(word.Value);
            

            var transliteratedText = tokenizedString.Compile();

            foreach (var rule in perSentenceRules)
                transliteratedText = rule.Execute(transliteratedText);

            return transliteratedText;
        }
    }
}
