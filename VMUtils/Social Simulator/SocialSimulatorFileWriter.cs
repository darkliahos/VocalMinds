using System;
using System.Diagnostics;
using VMUtils.Exceptions;
using VMUtils.Extensions;
using VMUtils.Interfaces;
using VM_Model;

namespace VMUtils
{
    public class SocialSimulatorFileWriter:IFileWriter<ImportedSocialScenarios>
    {
        private readonly IExporter<ImportedSocialScenarios> _exporter;
        private readonly IFileProcessor<SocialScenario, ImportedSocialScenarios> _processor;
        private readonly string _path;
        private readonly IMerge<ImportedSocialScenarios> _merge;

        public SocialSimulatorFileWriter(IExporter<ImportedSocialScenarios> exporter, IFileProcessor<SocialScenario, ImportedSocialScenarios> processor, string path, IMerge<ImportedSocialScenarios> merge)
        {
            _exporter = exporter;
            _processor = processor;
            _path = path;
            _merge = merge;
        }

        public void Save(ImportedSocialScenarios inputObject)
        {
            var loadScenarioFromFile = _processor.RefreshScenarioObject();

            if (inputObject != null && loadScenarioFromFile != null)
            {
                if (loadScenarioFromFile.LastWrittenProcessId != Process.GetCurrentProcess().Id &&
                    loadScenarioFromFile.LastModified.IsTimeWithinXSeconds(30))
                {
                    _merge.MergeFiles(loadScenarioFromFile, inputObject);
                }

                LockFile();
                inputObject.LastModified = DateTime.UtcNow;
                inputObject.IsCurrentlyLocked = true;
                inputObject.LastWrittenProcessId = Process.GetCurrentProcess().Id;
                _exporter.WriteToFile(inputObject, _path);
                UnlockFile();
                
            }
        }

        public void LockFile()
        {
            var loadScenarioFromFile = _processor.LoadScenarioObject();
            var processId = Process.GetCurrentProcess().Id;

            if (loadScenarioFromFile.IsCurrentlyLocked && loadScenarioFromFile.LastWrittenProcessId != processId)
            {
                throw new FileLockedException("File has already be locked by" + loadScenarioFromFile.LastWrittenProcessId);
            }
            loadScenarioFromFile.IsCurrentlyLocked = true;
            loadScenarioFromFile.LastWrittenProcessId = processId;
            _exporter.WriteToFile(loadScenarioFromFile, _path);
        }

        public void UnlockFile()
        {
            var loadScenarioFromFile = _processor.RefreshScenarioObject();
            var processId = Process.GetCurrentProcess().Id;

            if (loadScenarioFromFile.IsCurrentlyLocked && loadScenarioFromFile.LastWrittenProcessId == processId)
            {
                loadScenarioFromFile.IsCurrentlyLocked = false;
                _exporter.WriteToFile(loadScenarioFromFile, _path);
            }
            else
            {
                throw new FileFailedToUnlockedException("Could not unlock file");
            }
        }
    }
}
