using Andaluh.Extensions;
using Andaluh.Rules.Base;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Andaluh.Rules
{
    internal class FinalRules : RuleBundle
    {
        private static readonly Regex pattern_ador = new Regex(@"(?i)(adôh|edôh|idá)\b");
        private static readonly Regex pattern_dura = new Regex(@"(?i)(\w)(dura|durâ|duro|dero|durô|derô|dera|dora|derâ|dorâ)\b");
        private static readonly Regex pattern_deder = new Regex(@"(?i)(b|d)(eder)([aeiouáâçéíóú])\b");

        private readonly Dictionary<string, string> ADOR_RULES_EXCEPT = new Dictionary<string, string>()
        {
            { "arrededôh", "arrededôh" },
            { "pômmodênnidá", "pômmodênnidá" }
        };

        protected override IEnumerable<Rule> Rules => new[]
        {
           new Rule(pattern_ador, FinalesAdor, ADOR_RULES_EXCEPT),
           new Rule(pattern_dura, FinalesDura, null),
           new Rule(pattern_deder, FinalesDeder, null)
        };

        private string FinalesAdor(Match match, string text, int bias) =>
            match.Groups[0].Value[0..^match.Groups[1].Length] + match.Groups[1].Value[0] + match.Groups[1].Value[2..];
        private string FinalesDura(Match match, string text, int bias)
        {
            var charBefore = match.Groups[1].Value;
            if (charBefore == "n" || charBefore == "r") return match.Groups[0].Value;

            var prefijo = match.Groups[0].Value[^3];
            var vocalAcentuada = prefijo.KeepCase(prefijo.GetVowelTilde());
            var final = match.Groups[0].Value[3..5];

            return charBefore + vocalAcentuada + final;
        }

        private string FinalesDeder(Match match, string text, int bias)
        {
            var prefijo = match.Groups[0].Value.Substring(0, match.Groups[0].Value.IndexOf(match.Groups[1].Value));
            var reemplazo = match.Groups[2].Value.KeepCase("eér");

            return prefijo + match.Groups[1].Value + reemplazo + match.Groups[3].Value;
        }

        public FinalRules() : base()
        { }
    }
}
