using System.Text.RegularExpressions;

namespace Andaluh
{
    internal class EPARules
    {
        /// <summary>
        /// Replacement rules for /ks/ with EPA VAF
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        internal static string XRules(string text)
        {
            //todo add chihuahua

            return text;
        }

        /// <summary>
        /// Rotating /l/ with /r/
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        internal static string LRules(string text)
        {
            string patternLower = "[l][bcçÇgsdfghkmpqrtxz]";
            string patternUpper = "[L][bcçÇgsdfghkmpqrtxz]";

            var res = Regex.Replace(text, patternLower, "r");

            return Regex.Replace(res, patternUpper, "R");
        }

        /// <summary>
        /// Replacing /ʎ/ (digraph ll) with Greek Y for /ʤ/ sound (voiced postalveolar affricate)
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        internal static string LLRules(string text)
        {
            string patternLower = "[l][l]";
            string patternUpper = "[L][Ll]";

            var res = Regex.Replace(text, patternLower, "y");

            return Regex.Replace(res, patternUpper, "Y");
        }

        /// <summary>
        /// Replacement rules for /∫/ (voiceless postalveolar fricative)
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        internal static string CHRules(string text)
        {
            string patternLower = "ch";
            string patternUpper = "Ch";

            var res = Regex.Replace(text, patternLower, "x");

            return Regex.Replace(res, patternUpper, "X");
        }

        /// <summary>
        /// Replacing all /v/ (Voiced labiodental fricative) with /b/
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        internal static string VRules(string text)
        {
            //todo 
            string patternLower = @"\b\w*v\w*\b";
            var res =Regex.Replace(text, patternLower, "B");

            return text;
        }

        /// <summary>
        /// Supress mute /h/
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        internal static string HRules(string text)
        {
            //todo 
            return text;
        }
    }
}
