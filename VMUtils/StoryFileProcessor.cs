using System;
using VMUtils.Interfaces;
using VM_Model;

namespace VMUtils
{
    public class StoryFileProcessor
    {
        private readonly IImporter<Story> _importer;
        private readonly string _path;
        private readonly Story _story;

        public StoryFileProcessor(IImporter<Story> importer, string path)
        {
            _importer = importer;
            _path = path;
            _story = _importer.LoadFile(_path);
        }

        public Story LoadScenarioFromFile()
        {
            return _story;
        }
    }
}