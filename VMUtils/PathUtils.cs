using System;
using System.IO;
using System.Reflection;

namespace VMUtils
{
    public static class PathUtils
    {
        private const string ImageContentPath = @"\Content\FaceRecognitionImages\";
        private const string contentPath = @"\Content\";

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

        /// <summary>
        /// Gets the full Image path
        /// </summary>
        /// <param name="image">the name of the image</param>
        /// <returns></returns>
        public static string GetFullImagePath(string image)
        {
            string facecontentPath = String.Concat(ImageContentPath, image);
            return CombineResultingPathWithAssemblyPath(facecontentPath);
        }

        /// <summary>
        /// Gets the  root content path
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static string GetRootContentFolder(string item)
        {
            string facecontentPath = String.Concat(contentPath, item);
            return CombineResultingPathWithAssemblyPath(facecontentPath);
        }
    }
}
