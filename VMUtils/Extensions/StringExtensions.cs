using System;
using System.Text;

namespace VMUtils.Extensions
{
    public static class StringExtensions
    {
        public static string SubsituteString(this string originalStr, int index, int length, string subsituteStr)
        {
            return new StringBuilder(originalStr).Remove(index, length).Insert(index, subsituteStr).ToString();
        }
    }
}
