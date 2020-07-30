﻿using Andaluh.Extensions;
using Andaluh.Rules;

namespace Andaluh
{
    public static class EPA
    {
        public static string Transcribe(this string text) =>
            text.IsNullOrEmpty() ? string.Empty : new EPAEngine().Transcribe(text);

        public static string ToAndaluh(this string text) => text.Transcribe();
    }
}