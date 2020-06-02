using Andaluh.Extensions;
using Andaluh.Rules;

namespace Andaluh
{
    public static class EPA
    {
        public static string Transcribe(this string text, string vaf = "VAF", string vvf = "VVF") =>
            text.IsNullOrEmpty() ? string.Empty : EPAEngine.Transcribe(text);

        public static string ToAndaluh(this string text) => text.Transcribe();
    }
}