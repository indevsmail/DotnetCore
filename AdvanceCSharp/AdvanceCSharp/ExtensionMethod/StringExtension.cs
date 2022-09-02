using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdvanceCSharp.ExtensionMethod
{
    public static class StringExtension
    {
        /// <summary>
        /// This System.String extension method check if a string axist in string array.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="strArr"></param>
        /// <returns></returns>
        public static bool IsExist(this string input, string[] strArr)
        {
            if (string.IsNullOrEmpty(input))
                return false;
            return strArr.Any(input.Contains);
        }
    }
}
