using System;
using System.Collections.Generic;
using VMUtils.FaceRecognition;
using VM_Model;
using Xunit;

namespace VMTests.Utils
{
    public class FaceRecognitionMergeTests
    {
        [Fact]
        public void CompareSourceWithTarget_WhenThereIsANewScenarioPresent_ReturnTrue()
        {
            var faceRecoMerge = new FaceRecognitionMerge();
            Assert.Equal(true, faceRecoMerge.CompareSourceWithTarget(SourceHelper(Guid.Parse("5a297b94-a5c0-485e-a109-086fd24e55c7")), OneAddedScenarioHelper()));
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

        private ImportedFaceRecognitionScenario OneAddedScenarioHelper()
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
                       ImageName = "a.png",
                       Id = new Guid(),
                       LastModified = new DateTime(2012,02,02),
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
                       Id = new Guid(),
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
