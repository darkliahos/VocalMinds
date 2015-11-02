using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using VMUtils;
using VMUtils.Interfaces;
using VM_ScenarioEditor;

namespace VM_FormUtils
{
    /// <summary>
    /// Vocal Minds Specific Path Handler
    /// NOTE: Only for Windows Path currently
    /// </summary>
    public class ContentPhysicalPathUtils : IContentPathUtils
    {
        private const string ImageContentPath = @"\Content\Images\";
        private const string SoundContentPath = @"\Content\Sounds\";
        private const string VideoContentPath = @"\Content\Videos\";
        private const string StoryImageContentPath = @"\Content\StoryContent\Images\";
        private const string ContentPath = @"\Content\";

        /// <summary>
        /// Merges the passed in path with the assembly path
        /// </summary>
        /// <param name="endOfPath"></param>
        /// <returns></returns>
        public string CombineResultingPathWithAssemblyPath(string endOfPath)
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
        public string GetFullImagePath(string image)
        {
            string facecontentPath = String.Concat(ImageContentPath, image);
            return CombineResultingPathWithAssemblyPath(facecontentPath);
        }

        /// <summary>
        /// Gets Full Sound Path
        /// </summary>
        /// <param name="sound"></param>
        /// <returns></returns>
        public string GetFullSoundPath(string sound)
        {
            string facecontentPath = String.Concat(SoundContentPath, sound);
            return CombineResultingPathWithAssemblyPath(facecontentPath);
        }

        /// <summary>
        /// Gets Full Video Path
        /// </summary>
        /// <param name="video"></param>
        /// <returns></returns>
        public string GetFullVideoPath(string video)
        {
            string videoContentPath = String.Concat(VideoContentPath, video);
            return CombineResultingPathWithAssemblyPath(videoContentPath);
        }

        /// <summary>
        /// Gets Full Story Image Path
        /// </summary>
        /// <param name="storyImage"></param>
        /// <returns></returns>
        public string GetFullStoryImagesPath(string storyImage)
        {
            string storyImagePath = String.Concat(StoryImageContentPath, storyImage);
            return CombineResultingPathWithAssemblyPath(storyImagePath);
        }

        /// <summary>
        /// Gets the  root content path
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public string GetRootContentFolder(string item)
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

        /// <summary>
        /// Gets All sub directories in selected path
        /// </summary>
        /// <param name="path"></param>
        /// <returns>A list of folders names if the folder specified exists</returns>
        public List<string> GetSubDirectoryList(string path)
        {
            if (!Directory.Exists(path))
            {
                throw new ArgumentException("Your Content Folder has not been set up correctly");
            }
            return new List<string>(Directory.GetDirectories(path));
        }

        /// <summary>
        /// Gets all files in directory specified
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public List<string> GetFilesInDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                throw new ArgumentException("Your Content Folder has not been set up correctly");
            }
            return new List<string>(Directory.GetFiles(path));
        }

        /// <summary>
        /// Gets target folder based on file extension
        /// </summary>
        /// <param name="file">Source file</param>
        /// <returns></returns>
        public string GetTargetFolder(string file)
        {
            ContentType contentType = GetContentType(file);

            switch (contentType)
            {
                case ContentType.Image:
                    return GetRootContentFolder("Images");
                case ContentType.Sound:
                    return GetRootContentFolder("Sounds");
                case ContentType.Video:
                    return GetRootContentFolder("Videos");
                default:
                    throw new NotSupportedException("File Type Unsupported");
            }
        }

        public ContentType GetContentType(string file)
        {
            if (DetermineFileType(file, "SupportedImgExt"))
            {
                return ContentType.Image;
            }

            if (DetermineFileType(file, "SupportedAudExt"))
            {
                return ContentType.Sound;
            }

            if (DetermineFileType(file, "SupportedVidExt"))
            {
                return ContentType.Video;
            }
                return ContentType.Other;
        }

        private bool DetermineFileType(string file, string configName)
        {
            var configuration = new AppConfiguration();
            var imageList = configuration.ReadStringListSettings(configName, '|');

            return imageList.Any(file.EndsWith);
        }
    }
}
