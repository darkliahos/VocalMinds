using System;
using NSubstitute;
using NSubstitute.Core;
using VMUtils;
using VMUtils.Exceptions;
using VMUtils.Interfaces;
using VM_Model;
using Xunit;

namespace VMTests.Utils
{
    public class ImageFileWriterTests
    {
        [Fact]
        public void Lock_LocksFile_WhenFileIsUnlocked()
        {
            //Arrange
            var serialiser = Substitute.For <ISerialiser<ImportedFaceRecognitionScenario>>();
            var exporter = Substitute.For<IExporter<ImportedFaceRecognitionScenario>>();
            var importer = Substitute.For<IImporter<ImportedFaceRecognitionScenario>>();
            var processor = Substitute.For<IFileProcessor<FaceRecognitionScenario,ImportedFaceRecognitionScenario>>();
            processor.LoadScenarioObject().Returns(LockObjectHelper);
            
            //Act
            var ifw = new FaceRecoFileWriter(serialiser, exporter, importer, processor, "Testpath");
            
            //Assert
            Assert.DoesNotThrow(ifw.LockFile);
            exporter.ReceivedWithAnyArgs(1).WriteToFile(Arg.Any<ImportedFaceRecognitionScenario>(), Arg.Any<string>());
        }

        [Fact]
        public void Lock_DoesLocksFile_WhenFileIsLocked()
        {
            //Arrange
            var serialiser = Substitute.For<ISerialiser<ImportedFaceRecognitionScenario>>();
            var exporter = Substitute.For<IExporter<ImportedFaceRecognitionScenario>>();
            var importer = Substitute.For<IImporter<ImportedFaceRecognitionScenario>>();
            var processor = Substitute.For<IFileProcessor<FaceRecognitionScenario, ImportedFaceRecognitionScenario>>();
            processor.LoadScenarioObject().Returns(LockedObjectHelper);

            //Act
            var ifw = new FaceRecoFileWriter(serialiser, exporter, importer, processor, "Testpath");

            //Assert
            Assert.Throws<FileLockedException>(() => ifw.LockFile());
            exporter.ReceivedWithAnyArgs(0).WriteToFile(Arg.Any<ImportedFaceRecognitionScenario>(), Arg.Any<string>());
        }

        private ImportedFaceRecognitionScenario LockObjectHelper(CallInfo callInfo)
        {
            return new ImportedFaceRecognitionScenario
            {
                Creation = DateTime.UtcNow,
                LastWrittenProcessId = 200,
                IsCurrentlyLocked = false,
                LastModified = DateTime.UtcNow.AddDays(-3)
            };
        }

        private ImportedFaceRecognitionScenario LockedObjectHelper(CallInfo callInfo)
        {
            return new ImportedFaceRecognitionScenario
            {
                Creation = DateTime.UtcNow,
                LastWrittenProcessId = 0,
                IsCurrentlyLocked = true,
                LastModified = DateTime.UtcNow.AddDays(-3)
            };
        }
    }
}
