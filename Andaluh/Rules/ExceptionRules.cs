using Andaluh.Extensions;
using Andaluh.Rules.Base;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Andaluh.Rules
{
    internal class ExceptionRules : RuleBundle
    {
        private static readonly Dictionary<string, string> ENDING_RULES_EXCEPTION = new Dictionary<string, string>()
        {
            // Exceptions to digraph rules with nm
            {"biêmmandao", "bienmandao"},
            {"biêmmeçabe", "bienmeçabe"},
            {"buêmmoço", "buenmoço"},
            {"çiêmmiléçima", "çienmiléçima"},
            {"çiêmmiléçimo", "çienmiléçimo"},
            {"çiêmmilímetro", "çienmilímetro"},
            {"çiêmmiyonéçima", "çienmiyonéçima"},
            {"çiêmmiyonéçimo", "çienmiyonéçimo"},
            {"çiêmmirmiyonéçima", "çienmirmiyonéçima"},
            {"çiêmmirmiyonéçimo", "çienmirmiyonéçimo"},
            // Exceptions to l rules
            {"marrotadôh", "mârrotadôh"},
            {"marrotâh", "mârrotâh"},
            {"mirrayâ", "mîrrayâ"},
            // Exceptions to psico pseudo rules
            {"herôççiquiatría", "heroçiquiatría"},
            {"herôççiquiátrico", "heroçiquiátrico"},
            {"farmacôççiquiatría", "farmacoçiquiatría"},
            {"metempçícoçî", "metemçícoçî"},
            {"necróçico", "necróççico"},
            {"pampçiquîmmo", "pamçiquîmmo"},
            // Other exceptions
            {"antîççerôttármico", "antiçerôttármico"},
            {"eclampçia", "eclampçia"},
            {"pôttoperatorio", "pôççoperatorio"},
            {"çáccrito", "çánccrito"},
            {"manbîh", "mambîh"},
            {"cômmelináçeo", "commelináçeo"},
            {"dîmmneçia", "dînneçia"},
            {"todo", "tó"},
            {"todito", "toito"},
            {"todô", "tôh"},
            {"toda", "toa"},
            {"todâ", "toâ"},
            // Other exceptions monosyllables
            {"as", "âh"},
            {"clown", "claun"},
            {"crack", "crâh"},
            {"down", "daun"},
            {"es", "êh"},
            {"ex", "êh"},
            {"ir", "îh"},
            {"miss", "mîh"},
            {"muy", "mu"},
            {"ôff", "off"},
            {"os", "ô"},
            {"para", "pa"},
            {"ring", "rin"},
            {"rock", "rôh"},
            {"spray", "êppray"},
            {"sprint", "êpprín"},
            {"wa", "gua"},
        };

        protected override IEnumerable<Rule> Rules => new[]
        {
           new Rule(null, null, ENDING_RULES_EXCEPTION)
        };

        public ExceptionRules() : base()
        { }
    }
}
