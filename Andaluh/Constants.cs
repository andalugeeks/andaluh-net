using System.Collections.Generic;

namespace Andaluh
{
    internal static class Constants
    {
        // EPA character for Voiceless alveolar fricative /s/ https://en.wikipedia.org/wiki/Voiceless_alveolar_fricative
        public static readonly string VAF = "ç";
        public static readonly string VAF_mayus = "Ç";

        // EPA character for Voiceless velar fricative /x/ https://en.wikipedia.org/wiki/Voiceless_velar_fricative
        public static readonly string VVF = "h";
        public static readonly string VVF_mayus = "H";

        //This is our list of word delimiters.
        public static readonly char[] CARACTERES_NO_PALABRA = { ' ', ',', '.', ';', ':', '-', '_', '?', '¿', '(', ')', '"', '\'', '\n', '\r', '[', ']', '¡', '!' };

        // Digraphs producers. (vowel(const(const that triggers the general digraph rule
        public static readonly string[] DIGRAPHS = {
            "bb", "bc", "bç", "bÇ", "bd", "bf", "bg", "bh", "bm", "bn", "bp", "bq", "bt", "bx", "by", "cb", "cc",
            "cç", "cÇ", "cd", "cf", "cg", "ch", "cm", "cn", "cp", "cq", "ct", "cx", "cy",
            "db", "dc", "dç", "dÇ", "dd", "df", "dg", "dh", "dl", "dm", "dn", "dp", "dq", "dt", "dx", "dy",
            "fb", "fc", "fç", "fÇ", "fd", "ff", "fg", "fh", "fm", "fn", "fp", "fq", "ft", "fx", "fy",
            "gb", "gc", "gç", "gÇ", "gd", "gf", "gg", "gh", "gm", "gn", "gp", "gq", "gt", "gx", "gy",
            "jb", "jc", "jç", "jÇ", "jd", "jf", "jg", "jh", "jl", "jm", "jn", "jp", "jq", "jr", "jt", "jx", "jy",
            "lb", "lc", "lç", "lÇ", "ld", "lf", "lg", "lh", "ll", "lm", "ln", "lp", "lq", "lr", "lt", "lx", "ly",
            "mm", "mn",
            "nm", "nn",
            "pb", "pc", "pç", "pÇ", "pd", "pf", "pg", "ph", "pm", "pn", "pp", "pq", "pt", "px", "py",
            "rn",
            "sb", "sc", "sç", "sÇ", "sd", "sf", "sg", "sh", "sk", "sl", "sm", "sn", "sñ", "sp", "sq", "sr", "st", "sx", "sy",
            "tb", "tc", "tç", "tÇ", "td", "tf", "tg", "th", "tl", "tm", "tn", "tp", "tq", "tt", "tx", "ty",
            "xb", "xc", "xç", "xÇ", "xd", "xf", "xg", "xh", "xl", "xm", "xn", "xp", "xq", "xr", "xt", "xx", "xy",
            "zb", "zc", "zç", "zÇ", "zd", "zf", "zg", "zh", "zl", "zm", "zn", "zp", "zq", "zr", "zt", "zx", "zy"
        };

        public static readonly Dictionary<string, string> REPL_RULES = new Dictionary<string, string>()
        {
            {"a", "â"}, {"A", "Â"}, {"á", "â"}, {"Á", "Â"},
            {"e", "ê"}, {"E", "Ê"}, {"é", "ê"}, {"É", "Ê"},
            {"i", "î"}, {"I", "Î"}, {"í", "î"}, {"Í", "Î"},
            {"o", "ô"}, {"O", "Ô"}, {"ó", "ô"}, {"Ó", "Ô"},
            {"u", "û"}, {"U", "Û"}, {"ú", "û"}, {"Ú", "Û"}
        };

        public static readonly Dictionary<string, string> STRESSED_RULES = new Dictionary<string, string>()
        {
            {"a", "á"}, {"A", "Á"}, {"á", "á"}, {"Á", "Á"},
            {"e", "é"}, {"E", "É"}, {"é", "é"}, {"É", "É"},
            {"i", "î"}, {"I", "Î"}, {"í", "î"}, {"Í", "Î"},
            {"o", "ô"}, {"O", "Ô"}, {"ó", "ô"}, {"Ó", "Ô"},
            {"u", "û"}, {"U", "Û"}, {"ú", "û"}, {"Ú", "Û"},
        };

        // Useful to calculate the circumflex equivalents.
        public static readonly string VOWELS_ALL_NOTILDE = "aeiouâêîôûAEIOUÂÊÎÔÛ";

        public static readonly string VOWELS_ALL_TILDE = "áéíóúâêîôûÁÉÍÓÚÂÊÎÔÛ";

    }
}
