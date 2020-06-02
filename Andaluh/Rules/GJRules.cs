using Andaluh.Extensions;
using Andaluh.Rules.Base;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Andaluh.Rules
{
    internal class GJRules : RuleBundle
    {
        private static readonly Regex pattern_gj = new Regex("(?i)(g(?=[eiéí])|j)([aeiouáéíóú])");
        private static readonly Regex pattern_gue_gui = new Regex("(?i)(g)u([eiéí])");
        private static readonly Regex pattern_guue_guui = new Regex("(?i)(g)(ü)([eiéí])");
        private static readonly Regex pattern_guen = new Regex("(?i)(b)(uen)");
        private static readonly Regex pattern_guel_gues = new Regex("(?i)([sa])?(?<!m)(b)(ue)([ls])");

        public static readonly Dictionary<string, string> GJ_RULES_EXCEPT = new Dictionary<string, string>()
        {
            {"gin", "yin"},
            {"jazz", "yâh"},
            {"jet", "yêh"},
        };

        protected override IEnumerable<Rule> Rules => new[]
        {
            new Rule(pattern_gj, gj_rules_replacer, GJ_RULES_EXCEPT),
            new Rule(pattern_gue_gui, gue_gui_rules_replacer), //DynamicRuleExceptions
            new Rule(pattern_guue_guui, guue_guui_rules_replacer),
            new Rule(pattern_guen, guen_rules_replacer),
            new Rule(pattern_guel_gues, guel_gues_rules_replacer)
        };


        private string gj_rules_replacer(Match match, string text, int bias)
        {
            string x_correct_capitalization = match.Value[0].IsUpperCase() ? Constants.VVF_mayus : Constants.VVF;
            return x_correct_capitalization + match.Value[1];
        }

        private string gue_gui_rules_replacer(Match match, string text, int bias) =>
            match.Value[0].ToString() + match.Value[2].ToString();

        private string guue_guui_rules_replacer(Match match, string text, int bias)
        {
            string u_correct_capitalization = match.Value[1].IsUpperCase() ? "U" : "u";
            return match.Value[0] + u_correct_capitalization + match.Value.Substring(2);
        }

        private string guen_rules_replacer(Match match, string text, int bias) =>
            (match.Value[0].IsUpperCase() ? "G" : "g") + match.Value.Substring(1);

        private string guel_gues_rules_replacer(Match match, string text, int bias)
        {
            string g_correct_capitalization = match.Value[1].IsUpperCase() ? "G" : "g";
            return match.Value[0] + g_correct_capitalization + match.Value.Substring(2);
        }

        public GJRules(Dictionary<string, string> dynamicRuleExceptions) : base(dynamicRuleExceptions)
        { }
    }
}
