using System;
using System.Collections.Generic;
using System.Text;

namespace Andaluh.Extensions
{
    public static class RuleRelatedExtensions
    {
        public static string apply_repl_rules(this string vocal) => Constants.REPL_RULES[vocal];
        public static string apply_repl_rules(this char v) => apply_repl_rules(v.ToString());
    }
}
