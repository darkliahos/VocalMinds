using System;
using System.Diagnostics;
using VMUtils.Exceptions;
using VMUtils.Extensions;
using VMUtils.Interfaces;
using VM_Model;

namespace VMUtils.FaceRecognition
{
    public class FaceRecognitionFileWriter : IFileWriter<ImportedFaceRecognitionScenario>
    {


        private readonly IExporter<ImportedFaceRecognitionScenario> _exporter;
        private readonly IFileProcessor<FaceRecognitionScenario, ImportedFaceRecognitionScenario> _processor;
        private static string _faceRecopath;
        private readonly IMerge<ImportedFaceRecognitionScenario> _merge;

        public FaceRecognitionFileWriter(IExporter<ImportedFaceRecognitionScenario> exporter, IFileProcessor<FaceRecognitionScenario, ImportedFaceRecognitionScenario> processor, string path, IMerge<ImportedFaceRecognitionScenario> merge)
        {
            _exporter = exporter;
            _processor = processor;
            _faceRecopath = path;
            _merge = merge;
        }

        public void Save(ImportedFaceRecognitionScenario inputObject)
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
                _exporter.WriteToFile(inputObject, _faceRecopath);
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
            _exporter.WriteToFile(loadScenarioFromFile, _faceRecopath);
        }

        public void UnlockFile()
        {
            var loadScenarioFromFile = _processor.RefreshScenarioObject();
            var processId = Process.GetCurrentProcess().Id;

            if (loadScenarioFromFile.IsCurrentlyLocked && loadScenarioFromFile.LastWrittenProcessId == processId)
            {
                loadScenarioFromFile.IsCurrentlyLocked = false;
                _exporter.WriteToFile(loadScenarioFromFile, _faceRecopath);
            }
            else
            {
                throw new FileFailedToUnlockedException("Could not unlock file");
            }

        }
    }
}