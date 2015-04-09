using System;
using System.Collections.Generic;
using VM_Model;
using VM_ScenarioEditor;
using VM_ScenarioEditor.Validators;
using Xunit;

namespace VM_ScenarioEditorTest
{
    public class SocialScenarioValidationTests
    {
        [Fact]
        public void ValidateSegmentResponse_WhenValidObject_ReturnsNoerrors()
        {
            // Arrange
            var response = new Response{Answer = "A", ResponseType = ResponseType.Negative, SocialSimulatorAction = 444};

            // Act
            var result = SocialScenarioValidation.ValidateSegmentResponse(response);

            // Assert
            Assert.Equal(false, result.HasErrors);
            Assert.Equal(0, result.ErrorMessages.Count);
        }

        [Fact]
        public void ValidateSegmentResponse_WhenMissingAnswer_ReturnsErrors()
        {
            // Arrange
            var response = new Response { Answer = "", ResponseType = ResponseType.Negative, SocialSimulatorAction = 444 };

            // Act
            var result = SocialScenarioValidation.ValidateSegmentResponse(response);

            // Assert
            Assert.Equal(true, result.HasErrors);
            Assert.Equal(1, result.ErrorMessages.Count);
        }

        [Fact]
        public void ValidateSegmentResponse_WhenMissingSegmentNo_ReturnsErrors()
        {
            // Arrange
            var response = new Response { Answer = "Ducktape", ResponseType = ResponseType.Negative, SocialSimulatorAction = 0 };

            // Act
            var result = SocialScenarioValidation.ValidateSegmentResponse(response);

            // Assert
            Assert.Equal(true, result.HasErrors);
            Assert.Equal(1, result.ErrorMessages.Count);
        }

        [Fact]
        public void ValidateSegmentResponse_WhenMissingBoth_ReturnsErrors()
        {
            // Arrange
            var response = new Response { Answer = "", ResponseType = ResponseType.Negative, SocialSimulatorAction = 0 };

            // Act
            var result = SocialScenarioValidation.ValidateSegmentResponse(response);

            // Assert
            Assert.Equal(true, result.HasErrors);
            Assert.Equal(2, result.ErrorMessages.Count);
        }

        [Fact]
        public void ValidateScenario_WhenValidObject_ReturnsNoerrors()
        {
            // Arrange
            SocialSimulatorFormState.SocialScenario = new SocialScenario
            {
                Author = "G",
                FriendlyName = "F",
                VideoSegment = new List<VideoSegment>
                {
                    new VideoSegment {Description = "D", Id = Guid.NewGuid(), Responses = new List<Response>()}
                }
            };
            SocialSimulatorFormState.SocialScenario.VideoSegment[0].Responses.Add(new Response { Answer = "A", ResponseType = ResponseType.Negative, SocialSimulatorAction = 444 });

            // Act
            var result = SocialScenarioValidation.ValidateScenario();

            // Assert
            Assert.Equal(false, result.HasErrors);
            Assert.Equal(0, result.ErrorMessages.Count);
        }

        [Fact]
        public void ValidateScenario_WhenMissingAuthor_ReturnsErrors()
        {
            // Arrange
            SocialSimulatorFormState.SocialScenario = new SocialScenario
            {
                Author = "",
                FriendlyName = "F",
                VideoSegment = new List<VideoSegment>
                {
                    new VideoSegment {Description = "D", Id = Guid.NewGuid(), Responses = new List<Response>()}
                }
            };
            SocialSimulatorFormState.SocialScenario.VideoSegment[0].Responses.Add(new Response { Answer = "A", ResponseType = ResponseType.Negative, SocialSimulatorAction = 444 });

            // Act
            var result = SocialScenarioValidation.ValidateScenario();

            // Assert
            Assert.Equal(true, result.HasErrors);
            Assert.Equal(1, result.ErrorMessages.Count);
        }

        [Fact]
        public void ValidateScenario_WhenMissingDescription_ReturnsErrors()
        {
            // Arrange
            SocialSimulatorFormState.SocialScenario = new SocialScenario
            {
                Author = "S",
                FriendlyName = "",
                VideoSegment = new List<VideoSegment>
                {
                    new VideoSegment {Description = "D", Id = Guid.NewGuid(), Responses = new List<Response>()}
                }
            };
            SocialSimulatorFormState.SocialScenario.VideoSegment[0].Responses.Add(new Response{Answer = "A", ResponseType = ResponseType.Negative, SocialSimulatorAction = 444});
             
            // Act
            var result = SocialScenarioValidation.ValidateScenario();

            // Assert
            Assert.Equal(true, result.HasErrors);
            Assert.Equal(1, result.ErrorMessages.Count);
        }

        [Fact]
        public void ValidateScenario_WhenMissingBothAuthorAndDescription_ReturnsErrors()
        {
            // Arrange
            SocialSimulatorFormState.SocialScenario = new SocialScenario
            {
                Author = "",
                FriendlyName = "",
                VideoSegment = new List<VideoSegment>
                {
                    new VideoSegment {Description = "D", Id = Guid.NewGuid(), Responses = new List<Response>()}
                }
            };
            SocialSimulatorFormState.SocialScenario.VideoSegment[0].Responses.Add(new Response { Answer = "A", ResponseType = ResponseType.Negative, SocialSimulatorAction = 444 });

            // Act
            var result = SocialScenarioValidation.ValidateScenario();
            // Assert
            Assert.Equal(true, result.HasErrors);
            Assert.Equal(2, result.ErrorMessages.Count);
        }

        [Fact]
        public void ValidateSegment_WhenValidObject_ReturnErrors()
        {
            // Arrange
            var segment = new VideoSegment {Description = "D", Id = Guid.NewGuid(), PlayOrder = 3, VideoPath = "C"};

            // Act
            var result = SocialScenarioValidation.ValidateSegment(segment);
            // Assert
            Assert.Equal(false, result.HasErrors);
            Assert.Equal(0, result.ErrorMessages.Count);
        }

        [Fact]
        public void ValidateSegment_WhenMissingDescription_ReturnsNoErrors()
        {
            // Arrange
            var segment = new VideoSegment { Description = "", Id = Guid.NewGuid(), PlayOrder = 3, VideoPath = "C" };

            // Act
            var result = SocialScenarioValidation.ValidateSegment(segment);
            // Assert
            Assert.Equal(true, result.HasErrors);
            Assert.Equal(1, result.ErrorMessages.Count);
        }

        [Fact]
        public void ValidateSegment_WhenMissingId_ReturnErrors()
        {
            // Arrange
            var segment = new VideoSegment { Description = "s", Id = Guid.Empty, PlayOrder = 3, VideoPath = "C" };

            // Act
            var result = SocialScenarioValidation.ValidateSegment(segment);
            // Assert
            Assert.Equal(true, result.HasErrors);
            Assert.Equal(1, result.ErrorMessages.Count);
        }

        [Fact]
        public void ValidateSegment_WhenMissingPlayOrder_ReturnErrors()
        {
            // Arrange
            var segment = new VideoSegment { Description = "s", Id = Guid.NewGuid(), PlayOrder = 0, VideoPath = "C" };

            // Act
            var result = SocialScenarioValidation.ValidateSegment(segment);
            // Assert
            Assert.Equal(true, result.HasErrors);
            Assert.Equal(1, result.ErrorMessages.Count);
        }

        [Fact]
        public void ValidateSegment_WhenPlayOrderIsNegativeNumber_ReturnErrors()
        {
            // Arrange
            var segment = new VideoSegment { Description = "s", Id = Guid.NewGuid(), PlayOrder = -3, VideoPath = "C" };

            // Act
            var result = SocialScenarioValidation.ValidateSegment(segment);
            // Assert
            Assert.Equal(true, result.HasErrors);
            Assert.Equal(1, result.ErrorMessages.Count);
        }

        [Fact]
        public void ValidateSegment_WhenMissingVideoPath_ReturnErrors()
        {
            // Arrange
            var segment = new VideoSegment { Description = "s", Id = Guid.NewGuid(), PlayOrder = 4, VideoPath = "" };

            // Act
            var result = SocialScenarioValidation.ValidateSegment(segment);
            // Assert
            Assert.Equal(true, result.HasErrors);
            Assert.Equal(1, result.ErrorMessages.Count);
        }

        [Fact]
        public void ValidateSegment_WhenAllAreBroken_ReturnErrors()
        {
            // Arrange
            var segment = new VideoSegment { Description = "", Id = Guid.Empty, PlayOrder = 0, VideoPath = "" };

            // Act
            var result = SocialScenarioValidation.ValidateSegment(segment);
            // Assert
            Assert.Equal(true, result.HasErrors);
            Assert.Equal(4, result.ErrorMessages.Count);
        }
    }
}
