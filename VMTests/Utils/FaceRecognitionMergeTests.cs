using System;
using System.Collections.Generic;
using System.Linq;
using VMUtils.FaceRecognition;
using VM.Model;
using Xunit;

namespace VMTests.Utils
{
    public class FaceRecognitionMergeTests
    {
        [Fact]
        public void CompareSourceWithTarget_WhenThereIsANewScenarioPresent_ReturnTrue()
        {
            var faceRecoMerge = new FaceRecognitionMerge();
            Assert.Equal(true, faceRecoMerge.CompareSourceWithTarget(SourceHelper(Guid.Parse("5a297b94-a5c0-485e-a109-086fd24e55c7")), OneAddedScenarioHelper(Guid.Parse("5a297b94-a5c0-485e-a109-086fd24e55c7"))));
        }

        [Fact]
        public void CompareSourceWithTarget_WhenBothAreTheSame_ReturnFalse()
        {
            var faceRecoMerge = new FaceRecognitionMerge();
            Assert.Equal(false, faceRecoMerge.CompareSourceWithTarget(SourceHelper(Guid.Parse("5a297b94-a5c0-485e-a109-086fd24e55c7")), SourceHelper(Guid.Parse("5a297b94-a5c0-485e-a109-086fd24e55c7"))));
        }

        [Fact]
        public void CompareSourceWithTarget_WhenTheScenarioHasChanged_ReturnsTrue()
        {
            var faceRecoMerge = new FaceRecognitionMerge();
            Assert.Equal(true, faceRecoMerge.CompareSourceWithTarget(SourceHelper(Guid.Parse("5a297b94-a5c0-485e-a109-086fd24e55c7")), TargetScenarioChangedHelper(Guid.Parse("5a297b94-a5c0-485e-a109-086fd24e55c7"))));
            Assert.Equal(true, faceRecoMerge.CompareSourceWithTarget(SourceHelper(Guid.Parse("5a297b94-a5c0-485e-a109-086fd24e55c7")), TargetScenarioChangedHelperSameAnswerCount(Guid.Parse("5a297b94-a5c0-485e-a109-086fd24e55c7"))));
        }

        [Fact]
        public void MergeFiles_WhenTargetContainsScenarioThatSourceDoesNotHave_ScenarioShouldBePresentInMergedObject()
        {
            //Arrange
            var faceRecoMerge = new FaceRecognitionMerge();

            //Act
            var mergedScenario = faceRecoMerge.MergeFiles(SourceHelper(Guid.Parse("5a297b94-a5c0-485e-a109-086fd24e55c7")),
                OneAddedScenarioHelper(Guid.Parse("5a297b94-a5c0-485e-a109-086fd24e55c7")));
            //Assert
            Assert.Equal(true, mergedScenario.FaceRecognitionScenarios.Exists(x => x.Id == Guid.Parse("5aa89b94-a5c0-485e-a109-086fd24e55c7")));
            Assert.Equal(true, mergedScenario.FaceRecognitionScenarios.Exists(x => x.Id == Guid.Parse("5a297b94-a5c0-485e-a109-086fd24e55c7")));
            Assert.Equal(2, mergedScenario.FaceRecognitionScenarios.Count);
            Assert.Equal(new DateTime(2015, 01, 09), mergedScenario.FaceRecognitionScenarios.FirstOrDefault(x => x.Id == Guid.Parse("5a297b94-a5c0-485e-a109-086fd24e55c7")).LastModified);
            Assert.Equal("new.png", mergedScenario.FaceRecognitionScenarios.FirstOrDefault(x => x.Id == Guid.Parse("5a297b94-a5c0-485e-a109-086fd24e55c7")).ImageName);
        }

        [Fact]
        public void MergeFiles_WhenSourceContainsScenarioThatTargetDoesNotHave_ScenarioShouldBePresentInMergedObject()
        {
            //Arrange
            var faceRecoMerge = new FaceRecognitionMerge();

            //Act
            var mergedScenario = faceRecoMerge.MergeFiles(SourceWithNewScenarioHelper(Guid.Parse("5a297b94-a5c0-485e-a109-086fd24e55c7")),
                OneAddedScenarioHelper(Guid.Parse("5a297b94-a5c0-485e-a109-086fd24e55c7")));
            //Assert
            Assert.Equal(true, mergedScenario.FaceRecognitionScenarios.Exists(x => x.Id == Guid.Parse("5aa89b94-a5c0-485e-a109-086fd24e55c7")));
            Assert.Equal(true, mergedScenario.FaceRecognitionScenarios.Exists(x => x.Id == Guid.Parse("9cdc60bd-d749-4b53-9c96-56e7e6c7114f")));
            Assert.Equal(3, mergedScenario.FaceRecognitionScenarios.Count);
        }


        private ImportedFaceRecognitionScenario SourceWithNewScenarioHelper(Guid guid)
        {
            return new ImportedFaceRecognitionScenario
            {
                Creation = new DateTime(2014, 03, 03),
                FaceRecognitionScenarios = new List<FaceRecognitionScenario>
               {
                   new FaceRecognitionScenario
                   {
                       Author = "F",
                       Answers = new List<string>
                       {
                           "a",
                           "b"
                       },
                       CopyrightDisclaimer = "FFF",
                       ImageName = "a.png",
                       Id = Guid.Parse("9cdc60bd-d749-4b53-9c96-56e7e6c7114f"),
                       LastModified = new DateTime(2010,02,02),
                       QuestionTitle = "FA"
                   },
                                      new FaceRecognitionScenario
                   {
                       Author = "F",
                       Answers = new List<string>
                       {
                            "Dead",
                            "Fred",
                       },
                       CopyrightDisclaimer = "1994 Fred Inc",
                       ImageName = "Fred.png",
                       Id = guid,
                       LastModified = new DateTime(1985,02,02),
                       QuestionTitle = "Nervous Breakdown"
                   }
               },
                IsCurrentlyLocked = false,
                LastModified = new DateTime(2014, 03, 03),
                LastWrittenProcessId = 3030
            };
        }


        private ImportedFaceRecognitionScenario SourceHelper(Guid guid)
        {
            return new ImportedFaceRecognitionScenario
            {
                Creation = new DateTime(2014, 03, 03),
                FaceRecognitionScenarios = new List<FaceRecognitionScenario>
               {
                   new FaceRecognitionScenario
                   {
                       Author = "F",
                       Answers = new List<string>
                       {
                           "a",
                           "b"
                       },
                       CopyrightDisclaimer = "FFF",
                       ImageName = "a.png",
                       Id = guid,
                       LastModified = new DateTime(2010,02,02),
                       QuestionTitle = "FA"
                   }
               },
                IsCurrentlyLocked = false,
                LastModified = new DateTime(2014, 03, 03),
                LastWrittenProcessId = 3030
            };
        }

        private ImportedFaceRecognitionScenario TargetScenarioChangedHelper(Guid guid)
        {
            return new ImportedFaceRecognitionScenario
            {
                Creation = new DateTime(2014, 03, 03),
                FaceRecognitionScenarios = new List<FaceRecognitionScenario>
               {
                   new FaceRecognitionScenario
                   {
                       Author = "F",
                       Answers = new List<string>
                       {
                           "a",
                           "b",
                           "c"
                       },
                       CopyrightDisclaimer = "FFF",
                       ImageName = "a.png",
                       Id = guid,
                       LastModified = new DateTime(2014,02,02),
                       QuestionTitle = "FA"
                   }
               },
                IsCurrentlyLocked = false,
                LastModified = new DateTime(2014, 03, 03),
                LastWrittenProcessId = 3030
            };
        }

        private ImportedFaceRecognitionScenario TargetScenarioChangedHelperSameAnswerCount(Guid guid)
        {
            return new ImportedFaceRecognitionScenario
            {
                Creation = new DateTime(2014, 03, 03),
                FaceRecognitionScenarios = new List<FaceRecognitionScenario>
               {
                   new FaceRecognitionScenario
                   {
                       Author = "F",
                       Answers = new List<string>
                       {
                           "abra",
                           "b",
                       },
                       CopyrightDisclaimer = "FFF",
                       ImageName = "a.png",
                       Id = guid,
                       LastModified = new DateTime(2014,02,02),
                       QuestionTitle = "FA"
                   }
               },
                IsCurrentlyLocked = false,
                LastModified = new DateTime(2014, 03, 03),
                LastWrittenProcessId = 3030
            };
        }

        private ImportedFaceRecognitionScenario OneAddedScenarioHelper(Guid guid)
        {
            return new ImportedFaceRecognitionScenario
            {
                Creation = new DateTime(2014, 03, 03),
                FaceRecognitionScenarios = new List<FaceRecognitionScenario>
               {
                   new FaceRecognitionScenario
                   {
                       Author = "F",
                       Answers = new List<string>
                       {
                           "b",
                           "c"
                       },
                       CopyrightDisclaimer = "NTU",
                       ImageName = "new.png",
                       Id = guid,
                       LastModified = new DateTime(2015,01,09),
                       QuestionTitle = "FAL"
                   },
                  new FaceRecognitionScenario
                   {
                       Author = "F",
                       Answers = new List<string>
                       {
                           "a",
                           "b"
                       },
                       CopyrightDisclaimer = "FFF",
                       ImageName = "a.png",
                       Id = Guid.Parse("5aa89b94-a5c0-485e-a109-086fd24e55c7"),
                       LastModified = new DateTime(2010,02,02),
                       QuestionTitle = "FA"
                   },
               },
                IsCurrentlyLocked = false,
                LastModified = new DateTime(2014, 03, 03),
                LastWrittenProcessId = 3030
            };
        }
    }
}
