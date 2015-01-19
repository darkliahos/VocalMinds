using System;
using System.Diagnostics;
using VMUtils.Exceptions;
using VMUtils.Extensions;
using VMUtils.Interfaces;
using VM_Model;

namespace VMUtils.VoiceRecognition
{
    public class VoiceRecognitionFileWriter : IFileWriter<ImportedVoiceRecognitionScenario>
    {
        private readonly IExporter<ImportedVoiceRecognitionScenario> _exporter;
        private readonly IFileProcessor<VoiceRecognitionScenario, ImportedVoiceRecognitionScenario> _processor;
        private readonly string _voiceRecopath;
        private readonly IMerge<ImportedVoiceRecognitionScenario> _merge;

        public VoiceRecognitionFileWriter(IExporter<ImportedVoiceRecognitionScenario> exporter, IFileProcessor<VoiceRecognitionScenario, ImportedVoiceRecognitionScenario> processor, string voiceRecopath, IMerge<ImportedVoiceRecognitionScenario> merge)
        {
            _exporter = exporter;
            _processor = processor;
            _voiceRecopath = voiceRecopath;
            _merge = merge;
        }

        public void Save(ImportedVoiceRecognitionScenario inputObject)
        {
            var loadScenarioFromFile = _processor.RefreshScenarioObject();

            if (inputObject != null && loadScenarioFromFile != null)
            {
                if (loadScenarioFromFile.LastWrittenProcessId != Process.GetCurrentProcess().Id &&
                    loadScenarioFromFile.LastModified.IsTimeWithinXSeconds(30))
                {
                    if (_merge.CompareSourceWithTarget(loadScenarioFromFile, inputObject))
                    {
                        // #23 - Auto merge functionality
                        _merge.MergeFiles(loadScenarioFromFile, inputObject);
                    }
                }
                LockFile();
                inputObject.LastModified = DateTime.UtcNow;
                inputObject.IsCurrentlyLocked = true;
                inputObject.LastWrittenProcessId = Process.GetCurrentProcess().Id;
                _exporter.WriteToFile(inputObject, _voiceRecopath);
                UnlockFile();
            }
            else
            {
                throw new FileSaveException("File save exception");
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
            _exporter.WriteToFile(loadScenarioFromFile, _voiceRecopath);
        }

        public void UnlockFile()
        {
            var loadScenarioFromFile = _processor.RefreshScenarioObject();
            var processId = Process.GetCurrentProcess().Id;

            if (loadScenarioFromFile.IsCurrentlyLocked && loadScenarioFromFile.LastWrittenProcessId == processId)
            {
                loadScenarioFromFile.IsCurrentlyLocked = false;
                _exporter.WriteToFile(loadScenarioFromFile, _voiceRecopath);
            }
            else
            {
                throw new FileFailedToUnlockedException("Could not unlock file");
            }
        }
    }
}