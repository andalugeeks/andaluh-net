using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Andaluh.Extensions
{
    public static class MatchCollectionExtensions
    {
        public static bool Any(this MatchCollection matches) => matches.Count != 0;
        public static IEnumerable<Match> Where(this MatchCollection matches, Func<Match, bool> func)
        {
            foreach (Match match in matches)
                if (func(match)) yield return match;
        }
    }
}
