using System;
using VMUtils.Exceptions;
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
            var loadScenarioFromFile = _fpi.LoadFrsObject();

            if (loadScenarioFromFile != null)
            {
                if (loadScenarioFromFile.IsCurrentlyLocked)
                {
                    throw new FileLockedException("File is currently locked for editing");
                }

                //TODO: Need more checks such as File Modification

                _fei.WriteToFile(inputObject, FaceRecopath);
            }

        }

        public void LockFile()
        {
            throw new NotImplementedException();
        }

        public bool UnlockFile()
        {
            throw new NotImplementedException();
        }
    }
}