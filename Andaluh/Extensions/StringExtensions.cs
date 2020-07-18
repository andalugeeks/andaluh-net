using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Andaluh.Extensions
{
    internal static class StringExtensions
    {
        public static string ReplaceWordsByDictionary(this string text, Dictionary<string, string> exceptions)
        {
            if (exceptions == null) return text;

            foreach (var exception in exceptions)
            {
                var allWords = new Regex(@"\w+");

                foreach (Match word in allWords.Matches(text))
                {
                    if (word.Value == exception.Key.ToLower()) text = text.Replace(word.Value, exception.Value.ToLower());
                    if (word.Value == exception.Key.ToUpper()) text = text.Replace(word.Value, exception.Value.ToUpper());
                    if (word.Value == exception.Key.Capitalize()) text = text.Replace(word.Value, exception.Value.Capitalize());
                }
            }

            return text;
        }

        public static string ReplaceFirst(this string text, Match match, string replace, int bias = 0) =>
            text.Substring(0, match.Index + bias) + replace + text.Substring(match.Index + bias + match.Value.Length);

        public static bool IsUpperCase(this string str) => str.ToUpper() == str;

        public static bool IsLowerCase(this string str) => str.ToLower() == str;

        public static bool IsCapitalized(this string word) => IsUpperCase(word[0].ToString()) && IsLowerCase(word.Substring(1));

        static string Capitalize(this string word) => word[0].ToString().ToUpper() + word.Substring(1).ToLower();

        public static string GetWholeWord(this string text, int index)
        {
            var startIndex = text.GetWordStartIndex(index);
            var endIndex = text.GetWordEndIndex(index);

            return text.Substring(startIndex, endIndex - startIndex);
        }

        public static int GetWordStartIndex(this string text, int index)
        {
            if (index >= text.Length) index = text.Length - 1;
            for (int i = index; i > 0; i--)
                if (Constants.CARACTERES_NO_PALABRA.Any(c => c == text[i])) return i + 1;

            return 0;
        }


        public static int GetWordEndIndex(this string text, int index)
        {
            if (index >= text.Length) return text.Length;

            for (int i = index; i < text.Length; i++)
                if (Constants.CARACTERES_NO_PALABRA.Any(c => c == text[i])) return i;

            return text.Length;
        }
        
        public static string GetPrefix(this string text, Match match, int bias)
        {
            var matchIndex = match.Index + bias;
            var startIndex = text.GetWordStartIndex(matchIndex);

            return text.Substring(startIndex, matchIndex - startIndex);
        }

        public static string GetSuffix(this string text, Match match, int bias)
        {
            var matchIndex = match.Index + bias;

            var endIndex = text.GetWordEndIndex(matchIndex);

            return text.Substring(matchIndex + match.Value.Length, endIndex - matchIndex - match.Value.Length);
        }

        public static string KeepCase(this string word, string replacement_word)
        {
            replacement_word = replacement_word.ToLower();

            if (IsLowerCase(word)) return replacement_word;
            if (IsUpperCase(word)) return replacement_word.ToUpper();
            if (IsCapitalized(word)) return Capitalize(replacement_word);
            return replacement_word;
        }

        public static string KeepCase(this char c, char replacement_c) => c.ToString().KeepCase(replacement_c.ToString());

        public static string ReplaceFirstKeepingCase(this string text, string search, string replacement_word)
        {
            int startIndex, endIndex;
            startIndex = text.IndexOf(search);
            endIndex = GetWordEndIndex(text, startIndex);

            var stringBefore = text.Substring(0, startIndex);
            var stringAfter = text.Substring(endIndex);

            var casedReplacementWord = KeepCase(search, replacement_word);

            return stringBefore + casedReplacementWord + stringAfter;
        }

        public static bool IsNullOrEmpty(this string str) => str == null || str.Trim().Length == 0;
    }
}