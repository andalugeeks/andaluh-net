using Andaluh.Extensions;
using Andaluh.Rules.Base;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Andaluh.Rules
{
    internal class WordEndingRules : RuleBundle
    {
        private static readonly Regex pattern_intervowel_d_end_exceptions = new Regex(@"(?i)[áéíóú][^aeiouáéíóú]\b");
        private static readonly Regex pattern_intervowel_d_end = new Regex(@"(?i)([aií])(d)([oa])(s?)\b");
        private static readonly Regex pattern_eps_end = new Regex("(?i)(e)(ps)");
        private static readonly Regex pattern_d_end = new Regex(@"(?i)([aeiouáéíóú])(d)\b");
        private static readonly Regex pattern_s_end = new Regex(@"(?i)([aeiouáéíóú])(s)\b");
        private static readonly Regex pattern_const_end = new Regex(@"(?i)([aeiouáâçéíóú])([bcfgjkprtxz]\b)");
        private static readonly Regex pattern_l_end = new Regex(@"(?i)([aeiouáâçéíóú])l\b");
        private static readonly Regex pattern_vocal_tilde = new Regex("(?i)á|é|í|ó|ú");

        private static readonly Dictionary<string, string> WORDEND_D_INTERVOWEL_RULES_EXCEPT = new Dictionary<string, string>()
        {
            // Ending with -ado
            {"fado", "fado"},
            {"cado", "cado"},
            {"nado", "nado"},
            {"priado", "priado"},
            // Ending with -ada
            {"fabada", "fabada"},
            {"fabadas", "fabadas"},
            {"fada", "fada"},
            {"ada", "ada"},
            {"lada", "lada"},
            {"rada", "rada"},
            // Ending with -adas
            {"adas", "adas"},
            {"radas", "radas"},
            {"nadas", "nadas"},
            // Ending with -ido
            {"aikido", "aikido"},
            {"bûççido", "bûççido"},
            {"çido", "çido"},
            {"cuido", "cuido"},
            {"cupido", "cupido"},
            {"descuido", "descuido"},
            {"despido", "despido"},
            {"eido", "eido"},
            {"embido", "embido"},
            {"fido", "fido"},
            {"hido", "hido"},
            {"ido", "ido"},
            {"infido", "infido"},
            {"laido", "laido"},
            {"libido", "libido"},
            {"nido", "nido"},
            {"nucleido", "nucleido"},
            {"çonido", "çonido"},
            {"çuido", "çuido"},
        };

        private static readonly Dictionary<string, string> WORDEND_D_RULES_EXCEPT = new Dictionary<string, string>()
        {
            {"çed", "çêh"},
        };

        private static readonly Dictionary<string, string> WORDEND_S_RULES_EXCEPT = new Dictionary<string, string>()
        {
            {"bies", "biêh"},
            {"bis", "bîh"},
            {"blues", "blû"},
            {"bus", "bûh"},
            {"dios", "diôh"},
            {"dos", "dôh"},
            {"gas", "gâh"},
            {"gres", "grêh"},
            {"gris", "grîh"},
            {"luis", "luîh"},
            {"mies", "miêh"},
            {"mus", "mûh"},
            {"os", "ô"},
            {"pis", "pîh"},
            {"plus", "plûh"},
            {"pus", "pûh"},
            {"ras", "râh"},
            {"res", "rêh"},
            {"tos", "tôh"},
            {"tres", "trêh"},
            {"tris", "trîh"},
        };

        private static readonly Dictionary<string, string> WORDEND_CONST_RULES_EXCEPT = new Dictionary<string, string>()
        {
            {"al", "al"},
            {"del", "del"},
            {"dél", "dél"},
            {"el", "el"},
            {"él", "él"},
            {"tal", "tal"},
            {"bil", "bîl"},
            // TODO, uir = huir. Maybe better to add the exceptions on h_rules?
            {"por", "por"},
            {"uir", "huîh"},
            // sic, tac
            {"çic", "çic"},
            {"tac", "tac"},
            {"yak", "yak"},
            {"stop", "êttôh"},
            {"bip", "bip"},
        };


        protected override IEnumerable<Rule> Rules => new[]
        {
            new Rule(pattern_intervowel_d_end, intervowel_d_end_rules_replacer, WORDEND_D_INTERVOWEL_RULES_EXCEPT),
            new Rule(pattern_eps_end, eps_end_rules_replacer),
            new Rule(pattern_d_end, d_end_rules_replacer, WORDEND_D_RULES_EXCEPT),
            new Rule(pattern_s_end, s_end_rules_replacer, WORDEND_S_RULES_EXCEPT),
            new Rule(pattern_l_end, const_end_rules_replacer, WORDEND_CONST_RULES_EXCEPT),
            new Rule(pattern_const_end, const_end_rules_replacer, WORDEND_CONST_RULES_EXCEPT)
        };

        private bool contain_vocal_tilde(string text) => pattern_vocal_tilde.Match(text).Success;
        private bool contain_vocal_tilde(char c) => contain_vocal_tilde(c.ToString());

        private string intervowel_d_end_rules_replacer(Match match, string text, int bias)
        {
            var prefix = text.GetPrefix(match, bias);
            
            if (pattern_intervowel_d_end_exceptions.IsMatch(prefix)) return match.Value;

            var firstVowel = match.Value[0];
            var lastVowel = match.Value[2];


            if (contain_vocal_tilde(prefix)) return match.Value;

            switch (match.Value)
            {
                case "ada":
                    return firstVowel.KeepCase('á');
                case "adas":
                    return firstVowel.GetVowelCircumflex() + firstVowel.KeepCase('h');
                case "ado":
                    return firstVowel + lastVowel.ToString();
                case "ados":
                case "idos":
                case "ídos":
                    return firstVowel.GetVowelTilde() + lastVowel.GetVowelCircumflex().ToString();
                case "ido":
                case "ído":
                    return firstVowel.KeepCase('í') + lastVowel;
                default:
                    return match.Value;
            }
        }

        private string eps_end_rules_replacer(Match match, string text, int bias) =>
            !contain_vocal_tilde(text.GetPrefix(match, bias)) ? match.Value : "ê";

        private string d_end_rules_replacer(Match match, string text, int bias)
        {
            var palabra = text.GetWholeWord(match.Index + bias);

            string prefix = text.GetPrefix(match, bias);

            string suffix = match.Value;

            var vocalCandidata = suffix[0];
            if (contain_vocal_tilde(prefix))
                return vocalCandidata.apply_repl_rules();

            char[] vocalesValidas = { 'a', 'e', 'A', 'E', 'á', 'é', 'Á', 'É' };

            var vocalToStress = vocalesValidas.FirstOrDefault(x => x == vocalCandidata);

            return vocalToStress != default ? apply_stressed_rules(vocalCandidata.ToString()) :
                apply_stressed_rules(vocalCandidata.ToString()) + vocalCandidata.KeepCase('h');
        }

        private string apply_stressed_rules(string vocal) => Constants.STRESSED_RULES[vocal];
        private string apply_stressed_rules(char v) => apply_stressed_rules(v.ToString());

        private string s_end_rules_replacer(Match match, string text, int bias)
        {
            var suffixFirstChar = match.Value[0];
            return contain_vocal_tilde(suffixFirstChar) ?
                suffixFirstChar.apply_repl_rules() + suffixFirstChar.KeepCase('h') :
                suffixFirstChar.apply_repl_rules();
        }

        private string const_end_rules_replacer(Match match, string text, int bias)
        {
            var suffixFirstChar = match.Value[0];

            var prefix = text.GetPrefix(match, bias);

            if (contain_vocal_tilde(prefix)) return suffixFirstChar.apply_repl_rules();

            return suffixFirstChar != 'í' && suffixFirstChar != 'ú' && contain_vocal_tilde(suffixFirstChar) ?
                suffixFirstChar.apply_repl_rules() :
                suffixFirstChar.apply_repl_rules() + suffixFirstChar.KeepCase('h');
        }

        public WordEndingRules() : base()
        { }
    }
}