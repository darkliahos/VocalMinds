using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMUtils.FaceRecognition;
using VMUtils.Interfaces;
using VMUtils.VoiceRecognition;
using VM_Model;
using VM_ScenarioEditor;

namespace VMUtils.ContentWizard
{
    public class WizardContentFinder
    {
        private readonly IContentPathUtils _contentPathUtils;
        private readonly IFileProcessor<FaceRecognitionScenario, ImportedFaceRecognitionScenario> _faceProcessor;
        private readonly IFileProcessor<VoiceRecognitionScenario, ImportedVoiceRecognitionScenario> _voiceProcessor;
        private readonly IFileProcessor<SocialScenario, ImportedSocialScenarios> _videoProcessor;

        public WizardContentFinder(IContentPathUtils contentPathUtils, IFileProcessor<FaceRecognitionScenario, ImportedFaceRecognitionScenario> faceProcessor, IFileProcessor<VoiceRecognitionScenario, ImportedVoiceRecognitionScenario> voiceProcessor, IFileProcessor<SocialScenario, ImportedSocialScenarios> videoProcessor)
        {
            _contentPathUtils = contentPathUtils;
            _faceProcessor = faceProcessor;
            _voiceProcessor = voiceProcessor;
            _videoProcessor = videoProcessor;
        }

        public WizardContentFinder()
        {
            
        }

        public List<string> ContentIsBeingUsedBy(string fileName, ContentType type)
        {
            var result = new List<string>();
            if (type == ContentType.Image)
            {
                var frs = Task.FromResult<List<FaceRecognitionScenario>>(_faceProcessor.LoadScenarioFromFile()).Result;
                result.AddRange(frs.Select(fr => fr.ImageName));
            }

            if (type == ContentType.Sound)
            {
                var vrs = Task.FromResult<List<VoiceRecognitionScenario>>(_voiceProcessor.LoadScenarioFromFile()).Result;
                result.AddRange(vrs.Select(fr => fr.AudioPath));
            }

            if (type == ContentType.Video)
            {
                var vs = Task.FromResult<List<SocialScenario>>(_videoProcessor.LoadScenarioFromFile()).Result;
                result.AddRange(from vidScenario in vs from segment in vidScenario.VideoSegment select segment.VideoPath);
            }

            return result;
        }
    }
}
