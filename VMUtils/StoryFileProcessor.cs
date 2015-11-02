using System;
using System.Collections.Generic;
using VMUtils.Interfaces;
using VM_Model;

namespace VMUtils
{
    public class StoryFileProcessor
    {
        private readonly IImporter<List<Story>> _importer;
        private readonly string _path;
        private readonly List<Story> _story;

        public StoryFileProcessor(IImporter<List<Story>> importer, string path)
        {
            _importer = importer;
            _path = path;
            _story = _importer.LoadFile(_path);
        }

        public List<Story> LoadScenarioFromFile()
        {
            return _story;
        }
    }
}