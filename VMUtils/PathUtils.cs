using System.IO;
using System.Reflection;

namespace VMUtils
{
    public static class PathUtils
    {
        /// <summary>
        /// Merges the passed in path with the assembly path
        /// </summary>
        /// <param name="endOfPath"></param>
        /// <returns></returns>
        public static string CombineResultingPathWithAssemblyPath(string endOfPath)
        {
            string assemblyPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            //Note: Path.Combine did not work here, so the path has been manually concatenated
            return string.Concat(assemblyPath, endOfPath);
        }
    }
}
