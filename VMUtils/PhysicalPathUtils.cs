using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace VMUtils
{
    /// <summary>
    /// Vocal Minds Specific Path Handler
    /// NOTE: Only for Windows Path currently
    /// </summary>
    public static class PhysicalPathUtils
    {
        private const string ImageContentPath = @"\Content\Images\";
        private const string SoundContentPath = @"\Content\Sounds\";
        private const string VideoContentPath = @"\Content\Videos\";
        public const string ContentPath = @"\Content\";

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
        /// Gets Full Sound Path
        /// </summary>
        /// <param name="sound"></param>
        /// <returns></returns>
        public static string GetFullSoundPath(string sound)
        {
            string facecontentPath = String.Concat(SoundContentPath, sound);
            return CombineResultingPathWithAssemblyPath(facecontentPath);
        }

        /// <summary>
        /// Gets Full Video Path
        /// </summary>
        /// <param name="video"></param>
        /// <returns></returns>
        public static string GetFullVideoPath(string video)
        {
            string facecontentPath = String.Concat(VideoContentPath, video);
            return CombineResultingPathWithAssemblyPath(facecontentPath);
        }

        /// <summary>
        /// Gets the  root content path
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static string GetRootContentFolder(string item)
        {
            try
            {
                string facecontentPath = String.Concat(ContentPath, item);
                return CombineResultingPathWithAssemblyPath(facecontentPath);
            }
            catch (Exception)
            {
                //TODO Logging
                throw;
            }

        }

        public static List<string> GetSubDirectoryList(string path)
        {
            if (!Directory.Exists(path))
            {
                throw new ArgumentException("Your Content Folder has not been set up correctly");
            }
            return new List<string>(Directory.GetDirectories(path));
        }
    }
}
