using System.Collections.Generic;
using VM_ScenarioEditor;

namespace VMUtils.Interfaces
{
    public interface IContentPathUtils
    {
        /// <summary>
        /// Merges the passed in path with the assembly path
        /// </summary>
        /// <param name="endOfPath"></param>
        /// <returns></returns>
        string CombineResultingPathWithAssemblyPath(string endOfPath);

        /// <summary>
        /// Gets the full Image path
        /// </summary>
        /// <param name="image">the name of the image</param>
        /// <returns></returns>
        string GetFullImagePath(string image);

        /// <summary>
        /// Gets Full Sound Path
        /// </summary>
        /// <param name="sound"></param>
        /// <returns></returns>
        string GetFullSoundPath(string sound);

        /// <summary>
        /// Gets Full Video Path
        /// </summary>
        /// <param name="video"></param>
        /// <returns></returns>
        string GetFullVideoPath(string video);

        /// <summary>
        /// Gets the  root content path
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        string GetRootContentFolder(string item);

        /// <summary>
        /// Gets All sub directories in selected path
        /// </summary>
        /// <param name="path"></param>
        /// <returns>A list of folders names if the folder specified exists</returns>
        List<string> GetSubDirectoryList(string path);

        /// <summary>
        /// Gets all files in directory specified
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        List<string> GetFilesInDirectory(string path);

        /// <summary>
        /// Gets target folder based on file extension
        /// </summary>
        /// <param name="file">Source file</param>
        /// <returns></returns>
        string GetTargetFolder(string file);

        ContentType? GetContentType(string file);
    }
}