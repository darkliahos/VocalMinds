using System;
using System.Collections.Generic;
using System.Diagnostics;
using NSubstitute;
using NSubstitute.Core;
using VMUtils;
using VMUtils.Exceptions;
using VMUtils.FaceRecognition;
using VMUtils.Interfaces;
using VM_Model;
using Xunit;

namespace VMTests.Utils
{
    public class FaceRecognitionFileWriterTests
    {

        private IMerge<ImportedFaceRecognitionScenario> merge;
        private IExporter<ImportedFaceRecognitionScenario> exporter;
        private IFileProcessor<FaceRecognitionScenario, ImportedFaceRecognitionScenario> processor;

        public FaceRecognitionFileWriterTests()
        {
            merge = Substitute.For<IMerge<ImportedFaceRecognitionScenario>>();
            exporter = Substitute.For<IExporter<ImportedFaceRecognitionScenario>>();
            processor = Substitute.For<IFileProcessor<FaceRecognitionScenario, ImportedFaceRecognitionScenario>>();
        }

        [Fact]
        public void Lock_LocksFile_WhenFileIsUnlocked()
        {
            //Arrange

            processor.LoadScenarioObject().Returns(LockObjectHelper);
            
            //Act
            var ifw = new FaceRecognitionFileWriter(exporter, processor, "Testpath", merge);
            
            //Assert
            Assert.DoesNotThrow(ifw.LockFile);
            exporter.ReceivedWithAnyArgs(1).WriteToFile(Arg.Any<ImportedFaceRecognitionScenario>(), Arg.Any<string>());
        }

        [Fact]
        public void Lock_LocksFile_WhenFileIsLockedByTheSameProcessId()
        {
            //Arrange
            processor.LoadScenarioObject().Returns(LockAlreadyLockedObjectHelper);

            //Act
            var ifw = new FaceRecognitionFileWriter(exporter, processor, "Testpath", merge);

            //Assert
            Assert.DoesNotThrow(ifw.LockFile);
            exporter.ReceivedWithAnyArgs(1).WriteToFile(Arg.Any<ImportedFaceRecognitionScenario>(), Arg.Any<string>());
        }


        [Fact]
        public void Lock_DoesLocksFile_WhenFileIsLocked()
        {
            //Arrange
            processor.LoadScenarioObject().Returns(LockedObjectHelper);

            //Act
                        var ifw = new FaceRecognitionFileWriter(exporter, processor, "Testpath", merge);

            //Assert
            Assert.Throws<FileLockedException>(() => ifw.LockFile());
            exporter.ReceivedWithAnyArgs(0).WriteToFile(Arg.Any<ImportedFaceRecognitionScenario>(), Arg.Any<string>());
        }

        [Fact]
        public void Unlock_DoesUnlocksFile_WhenFileIsLocked()
        {
            //Arrange
            processor.RefreshScenarioObject().Returns(LockAlreadyLockedObjectHelper);

            //Act
                        var ifw = new FaceRecognitionFileWriter(exporter, processor, "Testpath", merge);

            //Assert
            Assert.DoesNotThrow(ifw.UnlockFile);
            exporter.ReceivedWithAnyArgs(1).WriteToFile(Arg.Any<ImportedFaceRecognitionScenario>(), Arg.Any<string>());
        }

        [Fact]
        public void Unlock_DoesNotUnlocksFile_WhenFileIsLockedBySomeoneElse()
        {
            //Arrange
            processor.RefreshScenarioObject().Returns(LockedObjectHelper);

            //Act
                        var ifw = new FaceRecognitionFileWriter(exporter, processor, "Testpath", merge);

            //Assert
            Assert.Throws<FileFailedToUnlockedException>(() => ifw.UnlockFile());
            exporter.ReceivedWithAnyArgs(0).WriteToFile(Arg.Any<ImportedFaceRecognitionScenario>(), Arg.Any<string>());
        }

        [Fact]
        public void Unlock_DoesNotUnlocksFile_WhenFileIsAlreadyUnlocked()
        {
            //Arrange
            processor.RefreshScenarioObject().Returns(LockObjectHelper);

            //Act
                        var ifw = new FaceRecognitionFileWriter(exporter, processor, "Testpath", merge);

            //Assert
            Assert.Throws<FileFailedToUnlockedException>(() => ifw.UnlockFile());
            exporter.ReceivedWithAnyArgs(0).WriteToFile(Arg.Any<ImportedFaceRecognitionScenario>(), Arg.Any<string>());
        }

        [Fact]
        public void Save_Errors_WhenScenarioIsBlank()
        {
                        var ifw = new FaceRecognitionFileWriter(exporter, processor, "Testpath", merge);
            Assert.Throws<FileSaveException>(()=> ifw.Save(null));
            exporter.ReceivedWithAnyArgs(0).WriteToFile(Arg.Any<ImportedFaceRecognitionScenario>(), Arg.Any<string>());
        }

        [Fact]
        public void Save_WritesToFile_WhenScenarioIsPopulated()
        {
            processor.RefreshScenarioObject().Returns(LockAlreadyLockedObjectHelper);
            processor.LoadScenarioObject().Returns(LockObjectHelper);
                        var ifw = new FaceRecognitionFileWriter(exporter, processor, "Testpath", merge);
            var i = new List<FaceRecognitionScenario>
            {
                new FaceRecognitionScenario
                {
                    Answers = new List<string>(),
                    Author = "Lunn",
                    CopyrightDisclaimer = "2014",
                    Id = Guid.Parse("22e52bbe-3a1f-4256-8ca6-499232a4e972"),
                    ImageName = "ad.png",
                    LastModified = new DateTime(2014, 03, 04),
                    QuestionTitle = "FaceTime",
                }
            };
            var ifrs = new ImportedFaceRecognitionScenario
            {
                Creation = new DateTime(2014, 04, 05),
                IsCurrentlyLocked = false,
                LastModified = new DateTime(2014, 04, 05),
                LastWrittenProcessId = 399,
                FaceRecognitionScenarios = i,
            };

            Assert.DoesNotThrow(()=> ifw.Save(ifrs));
            exporter.ReceivedWithAnyArgs(3).WriteToFile(Arg.Any<ImportedFaceRecognitionScenario>(), Arg.Any<string>());
        }

        private ImportedFaceRecognitionScenario LockObjectHelper(CallInfo callInfo)
        {
            return new ImportedFaceRecognitionScenario
            {
                Creation = DateTime.UtcNow,
                LastWrittenProcessId = Process.GetCurrentProcess().Id,
                IsCurrentlyLocked = false,
                LastModified = DateTime.UtcNow.AddDays(-3)
            };
        }

        private ImportedFaceRecognitionScenario LockAlreadyLockedObjectHelper(CallInfo callInfo)
        {
            return new ImportedFaceRecognitionScenario
            {
                Creation = DateTime.UtcNow,
                LastWrittenProcessId = Process.GetCurrentProcess().Id,
                IsCurrentlyLocked = true,
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
