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
    }
}
