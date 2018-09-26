using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMUtils.FaceRecognition;
using VMUtils.Interfaces;
using VMUtils.VoiceRecognition;
using VM.Model;
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
                var matchingFaceRecos = frs.Where(fr => fr.ImageName == fileName);
                result.AddRange(matchingFaceRecos.Select(faceRecognitionScenario => faceRecognitionScenario.QuestionTitle));
            }

            if (type == ContentType.Sound)
            {
                var vrs = Task.FromResult<List<VoiceRecognitionScenario>>(_voiceProcessor.LoadScenarioFromFile()).Result;
                var audioMatchingScenarios = vrs.Where(fr => fr.AudioPath == fileName);
                result.AddRange(audioMatchingScenarios.Select(voiceRecognitionScenario => voiceRecognitionScenario.QuestionTitle));
            }

            if (type == ContentType.Video)
            {
                var vs = Task.FromResult<List<SocialScenario>>(_videoProcessor.LoadScenarioFromFile()).Result;
                var matchingVidRecos = (from socialScenario in vs from segment in socialScenario.VideoSegment  select socialScenario).ToList();
                result.AddRange(matchingVidRecos.Select(voiceRecognitionScenario => voiceRecognitionScenario.FriendlyName));
            }

            return result;
        }
    }
}
