using System;
using System.Data;
using System.Diagnostics;
using VMUtils.Exceptions;
using VMUtils.Extensions;
using VMUtils.Interfaces;
using VM_Model;

namespace VMUtils
{
    public class ImageFileWriter : IFileWriter<ImportedFaceRecognitionScenario>
    {
        private static ISerialiser<ImportedFaceRecognitionScenario> _serialiser;
        static readonly string FaceRecopath = PathUtils.GetRootContentFolder("facerecoscenarios.js");
        private readonly FaceRecognitionProcessor _fpi;
        private readonly FaceRecognitionExporter _fei;

        public ImageFileWriter(ISerialiser<ImportedFaceRecognitionScenario> serialiser)
        {
            _serialiser = serialiser;
            _fpi = new FaceRecognitionProcessor(new FaceRecognitionImporter(_serialiser), FaceRecopath);
            _fei = new FaceRecognitionExporter(_serialiser);
        }

        public void Save(ImportedFaceRecognitionScenario inputObject)
        {
            var loadScenarioFromFile = _fpi.RefreshFrsObject();

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
                _fei.WriteToFile(inputObject, FaceRecopath);
                UnlockFile();
            }

        }

        public void LockFile()
        {
            var loadScenarioFromFile = _fpi.LoadFrsObject();
            var processId = Process.GetCurrentProcess().Id;

            if (loadScenarioFromFile.IsCurrentlyLocked && loadScenarioFromFile.LastWrittenProcessId != processId)
            {
                throw new FileLockedException("File has already be locked by" + loadScenarioFromFile.LastWrittenProcessId);
            }
            loadScenarioFromFile.IsCurrentlyLocked = true;
            loadScenarioFromFile.LastWrittenProcessId = processId;
            _fei.WriteToFile(loadScenarioFromFile, FaceRecopath);
        }

        public void UnlockFile()
        {
            var loadScenarioFromFile = _fpi.RefreshFrsObject();
            var processId = Process.GetCurrentProcess().Id;

            if (loadScenarioFromFile.IsCurrentlyLocked && loadScenarioFromFile.LastWrittenProcessId == processId)
            {
                loadScenarioFromFile.IsCurrentlyLocked = false;
                _fei.WriteToFile(loadScenarioFromFile, FaceRecopath);
            }
            else
            {
                throw new FileFailedToUnlockedException("Could not unlock file");
            }

        }
    }
}