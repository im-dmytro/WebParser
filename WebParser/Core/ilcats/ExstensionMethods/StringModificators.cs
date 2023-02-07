using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebParser.Core.ilcats.ExstensionMethods
{
    static class StringModificators
    {
        public static int ExtractrtHrefParam(this string href, string hrefParam)
        {
            string pattern = hrefParam + "=([^&]+)";
            Match match = Regex.Match(href, pattern);
            return match.Success ? Int32.Parse(match.Groups[1].Value) : 0;

        }
    }
}
