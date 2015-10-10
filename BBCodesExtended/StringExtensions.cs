/*
 * User: elijah
 * Date: 3/15/2012
 * Time: 2:04 PM
 */
using System;

namespace BBCodesExtended
{
    /// <summary>
    /// Random crap, used in the BBCodeParser
    /// </summary>
    static class StringExtensions
    {
        /// <summary>
        /// Returns the number of times that the specified char is found
        /// </summary>
        /// <param name="s"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static int CountOf(this string s, char c)
        {
            int count = 0;
            foreach (char c2 in s)
                if (c2 == c)
                    count += 1;
            return count;
        }

        /// <summary>
        /// Remove HTML tags from string using char array.
        /// </summary>
        public static string StripHtmlTags(this string source)
        {
            char[] array = new char[source.Length];
            int arrayIndex = 0;
            bool inside = false;

            for (int i = 0; i < source.Length; i++)
            {
                char let = source[i];
                if (let == '<')
                {
                    inside = true;
                    continue;
                }
                if (let == '>')
                {
                    inside = false;
                    continue;
                }
                if (!inside)
                {
                    array[arrayIndex] = let;
                    arrayIndex++;
                }
            }
            return new string(array, 0, arrayIndex);
        }

        public static string ReplaceCarriageReturn(this string source)
        {
            var clean = source;
            clean = clean.Replace("\r", string.Empty);
            clean = clean.Replace("\r", string.Empty);
            clean = clean.Replace("\n", string.Empty);
            return clean;
        }
    }
}
