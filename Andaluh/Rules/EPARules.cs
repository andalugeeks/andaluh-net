using Andaluh.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Andaluh.Rules
{
    internal class EPARules
    {
        private static readonly Regex pattern_h_general = new Regex("(?i)(?<!c)(h)([aáeéiíoóuú])");
        private static readonly Regex pattern_h_hua = new Regex("(?i)(?<!c)(h)(ua)");
        private static readonly Regex pattern_h_hue = new Regex("(?i)(?<!c)(h)(u)(e)");
        private static readonly Regex pattern_x_starting = new Regex("(?i)([xX])([aáeéiíoóuú])");
        private static readonly Regex pattern_x = new Regex("(?i)([aeiouáéíóú])(x)([aeiouáéíóú])");
        private static readonly Regex pattern_ch = new Regex("(?i)ch");
        private static readonly Regex pattern_gj = new Regex("(?i)(g(?=[eiéí])|j)([aeiouáéíóú])");
        private static readonly Regex pattern_gue_gui = new Regex("(?i)(g)u([eiéí])");
        private static readonly Regex pattern_guue_guui = new Regex("(?i)(g)(ü)([eiéí])");
        private static readonly Regex pattern_guen = new Regex("(?i)(b)(uen)");
        private static readonly Regex pattern_guel_gues = new Regex("(?i)([sa])?(?<!m)(b)(ue)([ls])");
        private static readonly Regex pattern_v = new Regex("(?i)v");
        private static readonly Regex pattern_nv = new Regex("(?i)nv");
        private static readonly Regex pattern_ll = new Regex("(?i)ll");
        private static readonly Regex pattern_l = new Regex("(?i)(l)([bcçgsdfghkmpqrtxz])");
        private static readonly Regex pattern_psico_pseudo = new Regex("(?i)p(sic|seud)");
        private static readonly Regex pattern_vaf = new Regex("(?i)(c(?=[eiéíêî])|z|s)([aeiouáéíóúÁÉÍÓÚâêîôûÂÊÎÔÛ])");
        private static readonly Regex pattern_intervowel_d_end = new Regex("(?i)([aiíÍ])(d)([oa])(s?)\\b");
        private static readonly Regex pattern_eps_end = new Regex("(?i)(e)(ps)");
        private static readonly Regex pattern_d_end = new Regex("(?i)([aeiouáéíóú])(d)\\b");
        private static readonly Regex pattern_s_end = new Regex("(?i)([aeiouáéíóú])(s)\\b");
        private static readonly Regex pattern_const_end = new Regex("(?i)([aeiouáâçéíóú])([bcfgjkprtxz]\\b)");
        private static readonly Regex pattern_l_end = new Regex("(?i)([aeiouáâçéíóú])(l\\b)");
        private static readonly Regex pattern_digraph_special_1 = new Regex("(?i)([aeiouáéíóú])([lr])s(t)");
        private static readonly Regex pattern_digraph_special_2 = new Regex("(?i)(tr|p)([ao])(?:ns|st)([bcçdfghjklmnpqstvwxyz])");
        private static readonly Regex pattern_digraph_special_3 = new Regex("(?i)([aeiouáéíóú])([bdnr])(s)([bcçdfghjklmnpqstvwxyz])");
        private static readonly Regex pattern_digraph_special_4 = new Regex("(?i)([aeiouáéíóú])[djrstxz](l)");
        private static readonly Regex pattern_digraph_general = new Regex("(?i)([aeiouáéíóú])(" + string.Join("|", Constants.DIGRAPHS) + ")");
        private static readonly Regex pattern_word_interaction = new Regex("(?i)(l\\b)(\\s)([bcçdfghjklmnñpqstvwxyz])");
        private static readonly Regex pattern_vocal_tilde = new Regex("(?i)á|é|í|ó|ú");

        public static readonly Dictionary<string, string> H_RULES_EXCEPT = new Dictionary<string, string>()
        {
            {"haz", "âh"},
            {"hez", "êh"},
            {"hoz", "ôh"},
            {"oh", "ôh"},
            {"yihad", "yihá"},
            {"h", "h"}, // Keep an isolated h as-is
        
        };

        public static readonly Dictionary<string, string> GJ_RULES_EXCEPT = new Dictionary<string, string>()
        {
            {"gin", "yin"},
            {"jazz", "yâh"},
            {"jet", "yêh"},
        };

        public static readonly Dictionary<string, string> GUE_GUI_DYNAMIC_RULES_EXCEPT = new Dictionary<string, string>();

        public static readonly Dictionary<string, string> V_RULES_EXCEPT = new Dictionary<string, string>()
        {
            {"vis", "bî"},
            {"ves", "bêh"},
        };

        public static readonly Dictionary<string, string> LL_RULES_EXCEPT = new Dictionary<string, string>()
        {
            {"grill", "grîh"},
        };

        public static readonly Dictionary<string, string> WORDEND_D_RULES_EXCEPT = new Dictionary<string, string>()
        {
            {"çed", "çêh"},
        };

        public static readonly Dictionary<string, string> WORDEND_S_RULES_EXCEPT = new Dictionary<string, string>()
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

        public static readonly Dictionary<string, string> WORDEND_CONST_RULES_EXCEPT = new Dictionary<string, string>()
        {
            {"al", "al"},
            {"cual", "cuâ"},
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

        public static readonly Dictionary<string, string> WORDEND_D_INTERVOWEL_RULES_EXCEPT = new Dictionary<string, string>()
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

        public static readonly Dictionary<string, string> ENDING_RULES_EXCEPTION = new Dictionary<string, string>()
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

        public static bool check_exception(Dictionary<string, string> diccionario, string text) =>
            diccionario.ContainsKey(text.ToLower());

        public static string h_hue_rules_replacer(Match match, string text, int bias)
        {
            string g_correct_capitalization = match.Value[0].IsUpperCase() ? "G" : "g";
            var result = g_correct_capitalization + match.Value.Substring(1);

            AddTransliteratedWordAsExceptionForGueGui(match, text, bias, result);

            return result;
        }

        private static void AddTransliteratedWordAsExceptionForGueGui(Match match, string text, int bias, string result)
        {
            var palabra = text.GetWholeWord(match.Index + bias);
            var newWord = palabra.Replace(match.Value, result).ToLower();
            if (!GUE_GUI_DYNAMIC_RULES_EXCEPT.ContainsKey(newWord))
                GUE_GUI_DYNAMIC_RULES_EXCEPT.Add(newWord, newWord);
        }

        public static string h_hua_rules_replacer(Match match, string text, int bias)
        {
            string g_correct_capitalization = match.Value[0].IsUpperCase() ? "G" : "g";
            return g_correct_capitalization + match.Value.Substring(1);
        }

        public static string h_rules_replacer(Match match, string text, int bias)
        {
            var undetermined_vocal = match.Value[1].ToString();
            return match.Value[0].ToLower() == 'h' ?
                match.Value[0].IsUpperCase() ? undetermined_vocal.ToUpper() : undetermined_vocal : string.Empty;
        }

        private static readonly Rule[] hRules =
        {
            new Rule(pattern_h_hua, h_hua_rules_replacer),
            new Rule(pattern_h_hue, h_hue_rules_replacer),
            new Rule(pattern_h_general, h_rules_replacer, H_RULES_EXCEPT)
        };

        public static string h_rules(string text) => RuleExecutor(hRules, text);


        private static string x_starting_rules_replacer(Match match, string text, int bias)
        {
            string VAF_correct_capitalization = match.Value[0].IsUpperCase() ? Constants.VAF_mayus : Constants.VAF;
            return VAF_correct_capitalization + match.Value[1];
        }

        public static string x_rules_replacer(Match match, string text, int bias)
        {
            string VAF_correct_capitalization = match.Value[1].IsUpperCase() ? Constants.VAF_mayus : Constants.VAF;
            return match.Value[0].GetVowelCircumflex() + VAF_correct_capitalization + VAF_correct_capitalization + match.Value[2];
        }

        private static readonly Rule[] xRules =
        {
            new Rule(pattern_x, x_rules_replacer),
            new Rule(pattern_x_starting, x_starting_rules_replacer)
        };

        public static string x_rules(string text) => RuleExecutor(xRules, text);

        public static string ch_rules_replacer(Match match, string text, int bias) =>
             match.Value[0].IsUpperCase() ? "X" : "x";

        public static string ch_rules(string text) => new Rule(pattern_ch, ch_rules_replacer).Execute(text);

        public static string gj_rules_replacer(Match match, string text, int bias)
        {
            string x_correct_capitalization = match.Value[0].IsUpperCase() ? Constants.VVF_mayus : Constants.VVF;
            return x_correct_capitalization + match.Value[1];
        }

        public static string gue_gui_rules_replacer(Match match, string text, int bias) =>
            match.Value[0].ToString() + match.Value[2].ToString();

        public static string guue_guui_rules_replacer(Match match, string text, int bias)
        {
            string u_correct_capitalization = match.Value[1].IsUpperCase() ? "U" : "u";
            return match.Value[0] + u_correct_capitalization + match.Value.Substring(2);
        }

        public static string guen_rules_replacer(Match match, string text, int bias) =>
            (match.Value[0].IsUpperCase() ? "G" : "g") + match.Value.Substring(1);

        public static string guel_gues_rules_replacer(Match match, string text, int bias)
        {
            string g_correct_capitalization = match.Value[1].IsUpperCase() ? "G" : "g";
            return match.Value[0] + g_correct_capitalization + match.Value.Substring(2);
        }

        private static readonly Rule[] gjRules =
        {
            new Rule(pattern_gj, gj_rules_replacer, GJ_RULES_EXCEPT),
            new Rule(pattern_gue_gui, gue_gui_rules_replacer, GUE_GUI_DYNAMIC_RULES_EXCEPT),
            new Rule(pattern_guue_guui, guue_guui_rules_replacer),
            new Rule(pattern_guen, guen_rules_replacer),
            new Rule(pattern_guel_gues, guel_gues_rules_replacer)
        };
        public static string gj_rules(string text) => RuleExecutor(gjRules, text);

        public static string nv_rules_replacer(Match match, string text, int bias) =>
            (match.Value[0].IsUpperCase() ? "M" : "m") + (match.Value[1].IsUpperCase() ? "B" : "b");

        public static string v_rules_replacer(Match match, string text, int bias) =>
            match.Value[0].IsUpperCase() ? "B" : "b";

        private static readonly Rule[] vRules =
        {
            new Rule(pattern_nv, nv_rules_replacer),
            new Rule(pattern_v, v_rules_replacer, V_RULES_EXCEPT)
        };

        public static string v_rules(string text) => RuleExecutor(vRules, text);

        public static string ll_rules_replacer(Match match, string text, int bias) =>
            match.Value[0].IsUpperCase() ? "Y" : "y";

        public static string ll_rules(string text) => new Rule(pattern_ll, ll_rules_replacer, LL_RULES_EXCEPT).Execute(text);

        public static string l_rules_replacer(Match match, string text, int bias) => match.Value[0].KeepCase('r') + match.Value[1];

        public static string l_rules(string text) => new Rule(pattern_l, l_rules_replacer).Execute(text);

        public static string psico_pseudo_rules_replacer(Match match, string text, int bias)
        {
            var undetermined_consonant = match.Value[1];
            if (match.Value[0].ToLower() == 'p')
            {
                var undetermined_correct_capitalization = match.Value[1].IsUpperCase() ? undetermined_consonant.ToUpper() : undetermined_consonant;
                return undetermined_correct_capitalization + match.Value.Substring(2);
            }
            else return "";
        }

        public static string psico_pseudo_rules(string text) => new Rule(pattern_psico_pseudo, psico_pseudo_rules_replacer).Execute(text);

        public static string vaf_rules_replacer(Match match, string text, int bias)
        {
            string vaf_correct_capitalization = match.Value[0].IsUpperCase() ? Constants.VAF_mayus : Constants.VAF;
            return vaf_correct_capitalization + match.Value[1];
        }

        public static string vaf_rules(string text) => new Rule(pattern_vaf, vaf_rules_replacer).Execute(text);

        public static bool contain_vocal_tilde(string text) => pattern_vocal_tilde.Match(text).Success;
        public static bool contain_vocal_tilde(char c) => contain_vocal_tilde(c.ToString());

        public static string intervowel_d_end_rules_replacer(Match match, string text, int bias)
        {
            var firstVowel = match.Value[0];
            var lastVowel = match.Value[2];

            if (contain_vocal_tilde(firstVowel)) return match.Value;

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

        public static string eps_end_rules_replacer(Match match, string text, int bias) =>
            !contain_vocal_tilde(text.GetPrefix(match, bias)) ? match.Value : "ê";

        public static string d_end_rules_replacer(Match match, string text, int bias)
        {
            var palabra = text.GetWholeWord(match.Index + bias);

            string prefix = text.GetPrefix(match, bias);

            string suffix = match.Value;

            var vocalCandidata = suffix[0];
            if (contain_vocal_tilde(prefix))
                return apply_repl_rules(vocalCandidata);

            char[] vocalesValidas = { 'a', 'e', 'A', 'E', 'á', 'é', 'Á', 'É' };

            var vocalToStress = vocalesValidas.FirstOrDefault(x => x == vocalCandidata);

            return vocalToStress != default ? apply_stressed_rules(vocalCandidata.ToString()) :
                apply_stressed_rules(vocalCandidata.ToString()) + vocalCandidata.KeepCase('h');
        }

        private static string apply_repl_rules(string vocal) => Constants.REPL_RULES[vocal];
        private static string apply_repl_rules(char v) => apply_repl_rules(v.ToString());

        private static string apply_stressed_rules(string vocal) => Constants.STRESSED_RULES[vocal];
        private static string apply_stressed_rules(char v) => apply_stressed_rules(v.ToString());

        public static string s_end_rules_replacer(Match match, string text, int bias)
        {
            var suffixFirstChar = match.Value[0];
            return contain_vocal_tilde(suffixFirstChar) ?
                apply_repl_rules(suffixFirstChar) + suffixFirstChar.KeepCase('h') :
                apply_repl_rules(suffixFirstChar);
        }

        public static string const_end_rules_replacer(Match match, string text, int bias)
        {
            var suffixFirstChar = match.Value[0];

            var prefix = text.GetPrefix(match, bias);

            if (contain_vocal_tilde(prefix)) return apply_repl_rules(suffixFirstChar);

            return contain_vocal_tilde(suffixFirstChar) ?
                apply_repl_rules(suffixFirstChar) :
                apply_repl_rules(suffixFirstChar) + suffixFirstChar.KeepCase('h');
        }

        private static readonly Rule[] wordEndingRules =
        {
            new Rule(pattern_intervowel_d_end, intervowel_d_end_rules_replacer, WORDEND_D_INTERVOWEL_RULES_EXCEPT),
            new Rule(pattern_eps_end, eps_end_rules_replacer),
            new Rule(pattern_d_end, d_end_rules_replacer, WORDEND_D_RULES_EXCEPT),
            new Rule(pattern_s_end, s_end_rules_replacer, WORDEND_S_RULES_EXCEPT),
            new Rule(pattern_const_end, const_end_rules_replacer, WORDEND_CONST_RULES_EXCEPT),
            new Rule(pattern_l_end, const_end_rules_replacer, WORDEND_CONST_RULES_EXCEPT)
        };

        public static string word_ending_rules(string text) => RuleExecutor(wordEndingRules, text);

        public static string digraph_special1_rules_replacer(Match match, string text, int bias) =>
            match.Value[1] switch
            {
                'l' => match.Value[0] + "rtt",
                'r' => match.Value[0] + "rtt",
                _ => match.Value
            };

        public static string digraph_special2_rules_replacer(Match match, string text, int bias)
        {
            string init_char = match.Groups[1].Value;
            char vowel_char = match.Groups[2].Value[0];
            char cons_char = match.Groups[0].Value[^1]; //match.group(0).charAt(match.group(0).length() - 1);

            return cons_char.ToLower() == 'l' ?
                 init_char + apply_repl_rules(vowel_char) + cons_char + "-" + cons_char :
                 init_char + apply_repl_rules(vowel_char) + cons_char + cons_char;
        }

        public static string digraph_special3_rules_replacer(Match match, string text, int bias)
        {
            var vowel_char = match.Value[0].ToString();
            var cons_char = match.Value[1].ToString();
            var s_char = match.Value[2];
            var digraph_char = match.Value[^1];

            return cons_char.ToLower() == "r" && s_char.ToLower() == 's' ?
                vowel_char + cons_char + digraph_char + digraph_char :
                apply_repl_rules(vowel_char) + digraph_char + digraph_char;
        }

        public static string digraph_special4_rules_replacer(Match match, string text, int bias)
        {
            var vowel_char = match.Value[0].ToString();
            var digraph_char = match.Value[^1];

            return apply_repl_rules(vowel_char) + digraph_char + "-" + digraph_char;
        }

        public static string digraph_general_rules_replacer(Match match, string text, int bias)
        {
            var suffix = text.GetSuffix(match, bias);
            var vowel_Circum = match.Value[0].GetVowelCircumflex().ToString();
            var digraph_char = match.Value[2];

            return suffix.IsNullOrEmpty() ? vowel_Circum : vowel_Circum + digraph_char + digraph_char;
        }

        private static readonly Rule[] digraphRules =
        {
            new Rule(pattern_digraph_special_1, digraph_special1_rules_replacer),
            new Rule(pattern_digraph_special_2, digraph_special2_rules_replacer),
            new Rule(pattern_digraph_special_3, digraph_special3_rules_replacer),
            new Rule(pattern_digraph_special_4, digraph_special4_rules_replacer),
            new Rule(pattern_digraph_general, digraph_general_rules_replacer)
        };

        public static string digraph_rules(string text) => RuleExecutor(digraphRules, text);

        public static string exception_rules(string text) => text.ReplaceWordsByDictionary(ENDING_RULES_EXCEPTION);

        public static string word_interaction_rules_replacer(Match match, string text, int bias)
        {
            var rightCapitalization = match.Value[0].IsUpperCase() ? "R" : "r";
            return rightCapitalization + match.Value.Substring(1);
        }

        public static string word_interaction_rules(string text) => new Rule(pattern_word_interaction, word_interaction_rules_replacer).Execute(text);

        private static string RuleExecutor(IEnumerable<Rule> rules, string text)
        {
            foreach (var rule in rules)
                text = rule.Execute(text);

            return text;
        }
    }
}