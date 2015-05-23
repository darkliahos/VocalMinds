using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using VMUtils;
using VMUtils.ContentWizard;
using VMUtils.Interfaces;
using VM_FormUtils;
using VM_Model;
using VM_ScenarioEditor;
using Xunit;

namespace VMTests.Utils
{
    public class WizardContentFinderTests
    {
        [Fact]
        public void ContentIsBeingUsedBy_WhenContentIsNotBeingUsedByAnything()
        {
            // Arrange
            var pathUtil = Substitute.For<IContentPathUtils>();
            var faceProcessor = Substitute.For<IFileProcessor<FaceRecognitionScenario, ImportedFaceRecognitionScenario>>();
            var voiceProcessor = Substitute.For<IFileProcessor<VoiceRecognitionScenario, ImportedVoiceRecognitionScenario> >();
            voiceProcessor.LoadScenarioFromFile().Returns(new List<VoiceRecognitionScenario>());
            var videoProcessor = Substitute.For<IFileProcessor<SocialScenario, ImportedSocialScenarios>>();
            var contentWizardFinder = new WizardContentFinder(pathUtil, faceProcessor, voiceProcessor, videoProcessor);
            // Act
            var list = contentWizardFinder.ContentIsBeingUsedBy("FileOne", ContentType.Sound);
            // Assert
            Assert.Empty(list);
        }

        [Fact]
        public void ContentIsBeingUsedBy_WhenContentIsBeingUsedByVoiceRecoScenario()
        {
            // Arrange
            var pathUtil = Substitute.For<IContentPathUtils>();
            var faceProcessor = Substitute.For<IFileProcessor<FaceRecognitionScenario, ImportedFaceRecognitionScenario>>();
            var voiceProcessor = Substitute.For<IFileProcessor<VoiceRecognitionScenario, ImportedVoiceRecognitionScenario>>();
            voiceProcessor.LoadScenarioFromFile().Returns(new List<VoiceRecognitionScenario> { new VoiceRecognitionScenario { AudioPath = "FileOne" } });
            var videoProcessor = Substitute.For<IFileProcessor<SocialScenario, ImportedSocialScenarios>>();
            var contentWizardFinder = new WizardContentFinder(pathUtil, faceProcessor, voiceProcessor, videoProcessor);
            // Act
            var list = contentWizardFinder.ContentIsBeingUsedBy("FileOne", ContentType.Sound);
            // Assert
            Assert.Equal(1, list.Count);
        }

        [Fact]
        public void ContentIsBeingUsedBy_WhenContentIsBeingUsedByFaceRecoScenario()
        {
            // Arrange
            var pathUtil = Substitute.For<IContentPathUtils>();
            var faceProcessor = Substitute.For<IFileProcessor<FaceRecognitionScenario, ImportedFaceRecognitionScenario>>();
            faceProcessor.LoadScenarioFromFile().Returns(new List<FaceRecognitionScenario> { new FaceRecognitionScenario() { ImageName = "FileOne" } });
            var voiceProcessor = Substitute.For<IFileProcessor<VoiceRecognitionScenario, ImportedVoiceRecognitionScenario>>();
            var videoProcessor = Substitute.For<IFileProcessor<SocialScenario, ImportedSocialScenarios>>();
            var contentWizardFinder = new WizardContentFinder(pathUtil, faceProcessor, voiceProcessor, videoProcessor);
            // Act
            var list = contentWizardFinder.ContentIsBeingUsedBy("FileOne", ContentType.Image);
            // Assert
            Assert.Equal(1, list.Count);
        }

        [Fact]
        public void ContentIsBeingUsedBy_WhenContentIsBeingUsedByVideoRecoScenario()
        {
            // Arrange
            var pathUtil = Substitute.For<IContentPathUtils>();
            var faceProcessor = Substitute.For<IFileProcessor<FaceRecognitionScenario, ImportedFaceRecognitionScenario>>();
            var voiceProcessor = Substitute.For<IFileProcessor<VoiceRecognitionScenario, ImportedVoiceRecognitionScenario>>();
            var videoProcessor = Substitute.For<IFileProcessor<SocialScenario, ImportedSocialScenarios>>();
            videoProcessor.LoadScenarioFromFile().Returns(new List<SocialScenario> { new SocialScenario { VideoSegment = new List<VideoSegment> { new VideoSegment { VideoPath = "FileOne" } } } });
            var contentWizardFinder = new WizardContentFinder(pathUtil, faceProcessor, voiceProcessor, videoProcessor);
            // Act
            var list = contentWizardFinder.ContentIsBeingUsedBy("FileOne", ContentType.Video);
            // Assert
            Assert.Equal(1, list.Count);
        }

        [Fact]
        public void ContentIsBeingUsedBy_WhenContentIsBeingUsedByVideoRecoScenarioAndAnotherScenario_ReturnOnlyVideoScenario()
        {
            // Arrange
            var pathUtil = Substitute.For<IContentPathUtils>();
            var faceProcessor = Substitute.For<IFileProcessor<FaceRecognitionScenario, ImportedFaceRecognitionScenario>>();
            faceProcessor.LoadScenarioFromFile().Returns(new List<FaceRecognitionScenario> { new FaceRecognitionScenario() { ImageName = "zz" } });
            var voiceProcessor = Substitute.For<IFileProcessor<VoiceRecognitionScenario, ImportedVoiceRecognitionScenario>>();
            var videoProcessor = Substitute.For<IFileProcessor<SocialScenario, ImportedSocialScenarios>>();
            videoProcessor.LoadScenarioFromFile().Returns(new List<SocialScenario> { new SocialScenario { VideoSegment = new List<VideoSegment> { new VideoSegment { VideoPath = "FileOne" } } } });
            var contentWizardFinder = new WizardContentFinder(pathUtil, faceProcessor, voiceProcessor, videoProcessor);
            // Act
            var list = contentWizardFinder.ContentIsBeingUsedBy("FileOne", ContentType.Video);
            // Assert
            Assert.Equal(1, list.Count);
        }
    }
}
