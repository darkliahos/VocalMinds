using System.Collections.Generic;
using System.Linq;

namespace VMUtils.Extensions
{
    public static class StringListExtensions
    {
        /// <summary>
        /// Replaces string with another within a list
        /// </summary>
        /// <param name="stringList"></param>
        /// <param name="stringToReplace"></param>
        /// <param name="replacementString"></param>
        public static List<string> ReplaceStringInList(this List<string> stringList, string stringToReplace,
            string replacementString)
        {
            return stringList.Select(str => str.Replace(stringToReplace, replacementString)).ToList();
        }
    }
}
