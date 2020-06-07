using System;
using System.Linq;
using System.Text.RegularExpressions;
using static Andaluh.SentenceMethods.TokenEvaluator;

namespace Andaluh.SentenceMethods
{
    internal class Token
    {
        public string Value { get; set; }
        public int StartIndex { get; set; }
        public int EndIndex { get; set; }
        public TranscriptionTypes Transcription { get; set; }

        private Token(string value, int position, TranscriptionTypes transcription)
        {
            Value = value;
            StartIndex = position;
            EndIndex = StartIndex + value.Length;
            Transcription = transcription;
        }

        public static Token GetEscapedToken(Match match) => 
            new Token(match.Value, match.Index, TranscriptionTypes.Escaped);

        public static Token GetExceptionToken(Match match) =>
            new Token(match.Value, match.Index, TranscriptionTypes.Exception);

        public static Token GetStandardToken(string str, int position) =>
            new Token(str, position, TranscriptionTypes.Standard);

        public override string ToString() => $"{StartIndex}, {EndIndex}, {Value}";

        internal void Copy(Token newToken)
        {
            Value = newToken.Value;
            StartIndex = newToken.StartIndex;
            EndIndex = newToken.EndIndex;
        }
    }
}
