using System.Text;

namespace VMUtils.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Allows the substitution of a string through out the string
        /// </summary>
        /// <param name="originalStr"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        /// <param name="subsituteStr"></param>
        /// <returns></returns>
        public static string SubsituteString(this string originalStr, int index, int length, string subsituteStr)
        {
            return new StringBuilder(originalStr).Remove(index, length).Insert(index, subsituteStr).ToString();
        }
    }
}
