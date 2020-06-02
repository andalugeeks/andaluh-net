namespace Andaluh.Extensions
{
    internal static class CharExtensions
    {
        public static char ToLower(this char c) => c.ToString().ToLower()[0];
        public static char ToUpper(this char c) => c.ToString().ToUpper()[0];

        public static char GetVowelTilde(this char vowel)
        {
            var i = Constants.VOWELS_ALL_NOTILDE.IndexOf(vowel);
            // If no tilde, replace with circumflex
            if (i != -1) return Constants.VOWELS_ALL_TILDE[i];

            if (Constants.VOWELS_ALL_TILDE.Contains(vowel)) return vowel;

            return '#';
        }

        public static char GetVowelCircumflex(this char vowel)
        {

            var i = Constants.VOWELS_ALL_NOTILDE.IndexOf(vowel);

            if (i != -1) return Constants.VOWELS_ALL_NOTILDE[i + 5];

            if (Constants.VOWELS_ALL_TILDE.Contains(vowel)) return vowel;

            return '#';
        }

        public static bool IsUpperCase(this char c) => c.ToString().IsUpperCase();
    }
}