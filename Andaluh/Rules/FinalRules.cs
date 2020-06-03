using Andaluh.Extensions;
using Andaluh.Rules.Base;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Andaluh.Rules
{
    internal class FinalRules : RuleBundle
    {
        private static readonly Regex pattern_ador = new Regex(@"(?i)\w+(adôh|edôh|idá)");
        private static readonly Regex pattern_dura = new Regex(@"(?i)\w+(dura|dero|dera|dora)");

        private readonly Dictionary<string, string> ADOR_RULES_EXCEPT = new Dictionary<string, string>()
        {
            { "arrededôh", "arrededôh" },
            { "pômmodênnidá", "pômmodênnidá" }
        };

        protected override IEnumerable<Rule> Rules => new[]
        {
           new Rule(pattern_ador, FinalesAdor, ADOR_RULES_EXCEPT),
           new Rule(pattern_dura, FinalesDura, null)
        };

        private string FinalesAdor(Match match, string text, int bias)=>
            match.Groups[0].Value[0..^match.Groups[1].Length] + match.Groups[1].Value[0] + match.Groups[1].Value[2..];
        private string FinalesDura(Match match, string text, int bias)
        {
            var prefijo = match.Groups[0].Value[0..^4];
            var vocalAcentuada = match.Groups[1].Value[1].KeepCase(match.Groups[1].Value[1].GetVowelTilde());
            var final = match.Groups[1].Value[2..4];

            return prefijo + vocalAcentuada + final;
        }

        public FinalRules() : base()
        { }
    }
}
