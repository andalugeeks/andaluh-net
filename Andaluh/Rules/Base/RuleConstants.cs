using System.Text.RegularExpressions;

namespace Andaluh.Rules.Base
{
    public static class RuleConstants
    {
        public static readonly Regex pattern_begin_lh = new Regex(@"(?i)\b[aáeéiíoóuú](lh)[aáeéiíoóuú]");
    }
}
