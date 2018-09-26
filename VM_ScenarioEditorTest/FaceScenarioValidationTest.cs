using System;
using System.Collections.Generic;
using VM.Model;
using VM_ScenarioEditor;
using Xunit;

namespace VM_ScenarioEditorTest
{
    public class FaceScenarioValidationTest
    {
        [Fact]
        public void Validation_WhenScenarioNameIsBlank_ThenReturnErrors()
        {
            var faceRecognitionScenario = new FaceRecognitionScenario
            {
                Answers = new List<string>
                {
                    "Sonic 2",
                    "Sonic 3"
                },
                ImageName = @"greenzone.mp3",
                Author = "Darkliahos",
                CopyrightDisclaimer = "Copyright 2015",
                Id = new Guid(),
                LastModified = DateTime.Now,
                QuestionTitle = ""
            };

            var expectedValidationObject = faceRecognitionScenario.Validation();
            Assert.Equal(1, expectedValidationObject.ErrorMessages.Count);
            Assert.Equal(true, expectedValidationObject.HasErrors);
            Assert.Equal("Question Title should not be blank", expectedValidationObject.ErrorMessages[0]);
        }

        [Fact]
        public void Validation_WhenThereAreNoAnswers_ThenReturnErrors()
        {
            var faceRecognitionScenario = new FaceRecognitionScenario
            {
                Answers = new List<string>(),
                ImageName = @"greenzone.mp3",
                Author = "Darkliahos",
                CopyrightDisclaimer = "Copyright 2015",
                Id = new Guid(),
                LastModified = DateTime.Now,
                QuestionTitle = "No Answers here"
            };

            var expectedValidationObject = faceRecognitionScenario.Validation();
            Assert.Equal(1, expectedValidationObject.ErrorMessages.Count);
            Assert.Equal(true, expectedValidationObject.HasErrors);
            Assert.Equal("Please add answers to this scenario", expectedValidationObject.ErrorMessages[0]);
        }

        [Fact]
        public void Validation_WhenOneOrMoreOfTheAnswersAreBlank_ThenReturnErrors()
        {
            var faceRecognitionScenario = new FaceRecognitionScenario
            {
                Answers = new List<string>
                {
                    "Today",
                    "I break",
                    "",
                    "Things"
                },
                ImageName = @"greenzone.mp3",
                Author = "Darkliahos",
                CopyrightDisclaimer = "Copyright 2015",
                Id = new Guid(),
                LastModified = DateTime.Now,
                QuestionTitle = "No Answers here"
            };

            var expectedValidationObject = faceRecognitionScenario.Validation();
            Assert.Equal(1, expectedValidationObject.ErrorMessages.Count);
            Assert.Equal(true, expectedValidationObject.HasErrors);
            Assert.Equal("One or more of the answers are blank", expectedValidationObject.ErrorMessages[0]);
        }

        [Fact]
        public void Validation_WhenPathIsInvalid_ThenReturnErrors()
        {
            var faceRecognitionScenario = new FaceRecognitionScenario
            {
                Answers = new List<string>
                {
                    "Sonic 2",
                    "Sonic 3"
                },
                ImageName = @"",
                Author = "Darkliahos",
                CopyrightDisclaimer = "Copyright 2015",
                Id = new Guid(),
                LastModified = DateTime.Now,
                QuestionTitle = "Stupid Path"
            };

            var expectedValidationObject = faceRecognitionScenario.Validation();
            Assert.Equal(1, expectedValidationObject.ErrorMessages.Count);
            Assert.Equal(true, expectedValidationObject.HasErrors);
            Assert.Equal("Path cannot be empty or null", expectedValidationObject.ErrorMessages[0]);
        }

        [Fact]
        public void Validation_WhenScenarioContainingTwoErrors_ThenReturnMultipleErrors()
        {
            var faceRecognitionScenario = new FaceRecognitionScenario
            {
                Answers = new List<string>(),
                ImageName = @"",
                Author = "Darkliahos",
                CopyrightDisclaimer = "Copyright 2015",
                Id = new Guid(),
                LastModified = DateTime.Now,
                QuestionTitle = "Stupid Path"
            };

            var expectedValidationObject = faceRecognitionScenario.Validation();
            Assert.Equal(2, expectedValidationObject.ErrorMessages.Count);
            Assert.Equal(true, expectedValidationObject.HasErrors);
            Assert.Equal("Please add answers to this scenario", expectedValidationObject.ErrorMessages[0]);
            Assert.Equal("Path cannot be empty or null", expectedValidationObject.ErrorMessages[1]);
        }

        [Fact]
        public void Validation_WhenScenarioIsWellFormed_ThenReturnNoErrors()
        {
            var faceRecognitionScenario = new FaceRecognitionScenario
            {
                Answers = new List<string>
                {
                    "Sonic 2",
                    "Sonic 3"
                },
                ImageName = @"greenzone.mp3",
                Author = "Darkliahos",
                CopyrightDisclaimer = "Copyright 2015",
                Id = new Guid(),
                LastModified = DateTime.Now,
                QuestionTitle = "Stupid Path"
            };

            var expectedValidationObject = faceRecognitionScenario.Validation();
            Assert.Equal(0, expectedValidationObject.ErrorMessages.Count);
            Assert.Equal(false, expectedValidationObject.HasErrors);

        }
    }
}
