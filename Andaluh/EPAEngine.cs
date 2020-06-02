using Andaluh.Rules;
using System;

namespace Andaluh
{
    internal static class EPAEngine
    {
        private static readonly (string Name, Func<string, string> Method)[] transliterationMethodsOrder =
        {
            ("h_rules", EPARules.h_rules),
            ("x_rules", EPARules.x_rules),
            ("ch_rules", EPARules.ch_rules),
            ("gj_rules", EPARules.gj_rules),
            ("v_rules", EPARules.v_rules),
            ("ll_rules", EPARules.ll_rules),
            ("l_rules", EPARules.l_rules),
            ("psico_pseudo_rules", EPARules.psico_pseudo_rules),
            ("vaf_rules", EPARules.vaf_rules),
            ("word_ending_rules", EPARules.word_ending_rules),
            ("digraph_rules", EPARules.digraph_rules),
            ("exception_rules", EPARules.exception_rules),
            ("word_interaction_rules", EPARules.word_interaction_rules)
        };

        public static string Transcribe(string text)
        {
            foreach (var rule in transliterationMethodsOrder)
                text = rule.Method(text);

            return text;
        }
    }
}
