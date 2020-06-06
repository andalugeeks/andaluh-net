using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Andaluh.SentenceMethods
{
    internal class TokenEvaluator
    {
        private Regex EscapeStringsPattern = new Regex(@"(?i)(http[^ ]+)|(@\w+)|(#\w+)");

        public enum TranscriptionTypes { Exception, Escaped, Standard }
        List<Token> Tokens;

        public TokenEvaluator(string text)
        {
            Tokens = new List<Token>();

            AddEscapedStrings(text);
            AddExceptions(text);

            if (Tokens.Count == 0)
                Tokens.Add(Token.GetStandardToken(text, 0));
            else
                FillGaps(text);

            ReplaceExceptions();
        }

        private void ReplaceExceptions()
        {
            foreach (var token in Tokens.Where(x => x.Transcription == TranscriptionTypes.Exception))
                token.Value = SentenceExceptions.Exceptions[token.Value];
        }

        internal IEnumerable<object> GetWordsToTransliterate() =>
            Tokens.Where(x => x.Transcription == TranscriptionTypes.Standard);

        internal string Compile() => string.Join("", Tokens.Select(x => x.Value));

        private void FillGaps(string text)
        {
            Tokens = Tokens.OrderBy(x => x.StartIndex).ToList();

            var gaps = new List<Token>();

            if (Tokens[0].StartIndex > 0) gaps.Add(Token.GetStandardToken(text[0..Tokens[0].StartIndex], 0));

            for (int i = 0; i < Tokens.Count - 1; i++)
            {
                var gapText = text[Tokens[i].EndIndex..Tokens[i + 1].StartIndex];
                if (gapText.Length == 0) continue;

                gaps.Add(Token.GetStandardToken(gapText, Tokens[i].EndIndex));
            }

            foreach (var gap in gaps)
                Tokens.Insert(GetTokenBefore(gap), gap);
        }



        private int GetTokenBefore(Token gap)
        {
            for (int i = 0; i < Tokens.Count; i++)
                if (Tokens[i].StartIndex > gap.StartIndex) return i;

            return Tokens.Count;
        }

        private void AddExceptions(string text)
        {
            var exceptions = new Regex($"(?i)({string.Join('|', SentenceExceptions.Exceptions.Keys)})");
            var matches = exceptions.Matches(text).Where(x => x.Success);

            foreach (var match in matches)
                Tokens.Add(Token.GetExceptionToken(text, match.Index));
        }

        private void AddEscapedStrings(string text)
        {
            var matches = EscapeStringsPattern.Matches(text).Where(x => x.Success);

            foreach (var match in matches)
                Tokens.Add(Token.GetEscapedToken(match));
        }
    }
}
