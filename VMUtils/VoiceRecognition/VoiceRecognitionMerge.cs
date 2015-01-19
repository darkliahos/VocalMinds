using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using VMUtils.Interfaces;
using VM_Model;

namespace VMUtils.VoiceRecognition
{
    public class VoiceRecognitionMerge : IMerge<ImportedVoiceRecognitionScenario>
    {
        public bool CompareSourceWithTarget(ImportedVoiceRecognitionScenario source, ImportedVoiceRecognitionScenario target)
        {
            if (source.VoiceRecognitionScenarios.Count != target.VoiceRecognitionScenarios.Count)
            {
                return true;
            }

            foreach (var voiceRecognitionScenario in source.VoiceRecognitionScenarios)
            {
                var newScenarioMatch = target.VoiceRecognitionScenarios.First(x => x.Id == voiceRecognitionScenario.Id);

                if (newScenarioMatch.AudioPath != voiceRecognitionScenario.AudioPath)
                {
                    return true;
                }

                if (newScenarioMatch.QuestionTitle != voiceRecognitionScenario.QuestionTitle)
                {
                    return true;
                }

                if (newScenarioMatch.CopyrightDisclaimer != voiceRecognitionScenario.CopyrightDisclaimer)
                {
                    return true;
                }

                if (newScenarioMatch.Author != voiceRecognitionScenario.Author)
                {
                    return true;
                }

                if (newScenarioMatch.Answers.Count != voiceRecognitionScenario.Answers.Count)
                {
                    return true;
                }

                if (newScenarioMatch.Answers.Any(answers => !voiceRecognitionScenario.Answers.Contains(answers)))
                {
                    return true;
                }

            }

            return false;
        }

        public ImportedVoiceRecognitionScenario MergeFiles(ImportedVoiceRecognitionScenario source,
            ImportedVoiceRecognitionScenario target)
        {
            var mergedObject = new ImportedVoiceRecognitionScenario
            {
                Creation = source.Creation,
                LastModified = DateTime.Now,
                IsCurrentlyLocked = true,
                LastWrittenProcessId = Process.GetCurrentProcess().Id,
                VoiceRecognitionScenarios = new List<VoiceRecognitionScenario>()
            };

            foreach (var scenario in target.VoiceRecognitionScenarios)
            {
                if (!source.VoiceRecognitionScenarios.Exists(x => x.Id == scenario.Id))
                {
                    mergedObject.VoiceRecognitionScenarios.Add(scenario);
                }
                else
                {
                    var sourceObject = source.VoiceRecognitionScenarios.First(x => x.Id == scenario.Id);
                    mergedObject.VoiceRecognitionScenarios.Add(scenario.LastModified > sourceObject.LastModified
                        ? scenario
                        : sourceObject);
                }
            }

            foreach (var sourceScenario in source.VoiceRecognitionScenarios.Where(sourceScenario => !mergedObject.VoiceRecognitionScenarios.Exists(x => x.Id == sourceScenario.Id)))
            {
                mergedObject.VoiceRecognitionScenarios.Add(sourceScenario);
            }

            return mergedObject;
        }
    }
}