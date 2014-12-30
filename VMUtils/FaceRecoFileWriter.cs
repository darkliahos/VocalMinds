using System;
using System.Data;
using System.Diagnostics;
using VMUtils.Exceptions;
using VMUtils.Extensions;
using VMUtils.Interfaces;
using VM_Model;

namespace VMUtils
{
    public class FaceRecoFileWriter : IFileWriter<ImportedFaceRecognitionScenario>
    {


        private static ISerialiser<ImportedFaceRecognitionScenario> _serialiser;
        private readonly IExporter<ImportedFaceRecognitionScenario> _exporter;
        private readonly IImporter<ImportedFaceRecognitionScenario> _importer;
        private readonly IFileProcessor<FaceRecognitionScenario, ImportedFaceRecognitionScenario> _processor;
        private static string _faceRecopath;

        public FaceRecoFileWriter(ISerialiser<ImportedFaceRecognitionScenario> serialiser, IExporter<ImportedFaceRecognitionScenario> exporter, IImporter<ImportedFaceRecognitionScenario> importer, IFileProcessor<FaceRecognitionScenario,ImportedFaceRecognitionScenario> processor, string path)
        {
            _serialiser = serialiser;
            _exporter = exporter;
            _importer = importer;
            _processor = processor;
            _faceRecopath = path;
        }

        public void Save(ImportedFaceRecognitionScenario inputObject)
        {
            var loadScenarioFromFile = _processor.RefreshScenarioObject();

            if (loadScenarioFromFile != null)
            {
                if (loadScenarioFromFile.IsCurrentlyLocked)
                {
                    throw new FileLockedException("File is currently locked for editing");
                }
                
                if (loadScenarioFromFile.LastWrittenProcessId != Process.GetCurrentProcess().Id &&
                    loadScenarioFromFile.LastModified.IsTimeWithinXSeconds(30))
                {
                    //TODO: What do we do in this situation? See Issue #23
                }
                LockFile();
                inputObject.LastModified = DateTime.UtcNow;
                inputObject.IsCurrentlyLocked = true;
                inputObject.LastWrittenProcessId = Process.GetCurrentProcess().Id;
                _exporter.WriteToFile(inputObject, _faceRecopath);
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