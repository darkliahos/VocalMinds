using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using VMUtils.Interfaces;
using VM_Model;

namespace VMUtils.FaceRecognition
{
    public class FaceRecognitionMerge : IMerge<ImportedFaceRecognitionScenario>
    {
        public bool CompareSourceWithTarget(ImportedFaceRecognitionScenario source, ImportedFaceRecognitionScenario target)
        {
            if (source.FaceRecognitionScenarios.Count != target.FaceRecognitionScenarios.Count)
            {
                return true;
            }

            foreach (var faceRecognitionScenario in source.FaceRecognitionScenarios)
            {
                var newScenarioMatch = target.FaceRecognitionScenarios.First(x => x.Id == faceRecognitionScenario.Id);

                if (newScenarioMatch.ImageName != faceRecognitionScenario.ImageName)
                {
                    return true;
                }

                if (newScenarioMatch.QuestionTitle != faceRecognitionScenario.QuestionTitle)
                {
                    return true;
                }

                if (newScenarioMatch.CopyrightDisclaimer != faceRecognitionScenario.CopyrightDisclaimer)
                {
                    return true;
                }

                if (newScenarioMatch.Author != faceRecognitionScenario.Author)
                {
                    return true;
                }

                if (newScenarioMatch.Answers.Count != faceRecognitionScenario.Answers.Count)
                {
                    return true;
                }

                if (newScenarioMatch.Answers.Any(answers => !faceRecognitionScenario.Answers.Contains(answers)))
                {
                    return true;
                }

            }

            return false;
        }

        public ImportedFaceRecognitionScenario MergeFiles(ImportedFaceRecognitionScenario source,
            ImportedFaceRecognitionScenario target)
        {
            var mergedObject = new ImportedFaceRecognitionScenario
            {
                Creation = source.Creation,
                LastModified = DateTime.Now,
                IsCurrentlyLocked = true,
                LastWrittenProcessId = Process.GetCurrentProcess().Id,
                FaceRecognitionScenarios = new List<FaceRecognitionScenario>()
            };

            foreach (var scenario in target.FaceRecognitionScenarios)
            {
                if (!source.FaceRecognitionScenarios.Exists(x => x.Id == scenario.Id))
                {
                    mergedObject.FaceRecognitionScenarios.Add(scenario);
                }
                else
                {
                    var sourceObject = source.FaceRecognitionScenarios.First(x => x.Id == scenario.Id);
                    mergedObject.FaceRecognitionScenarios.Add(scenario.LastModified > sourceObject.LastModified
                        ? scenario
                        : sourceObject);
                }
            }

            foreach (var sourceScenario in source.FaceRecognitionScenarios.Where(sourceScenario => !mergedObject.FaceRecognitionScenarios.Exists(x => x.Id == sourceScenario.Id)))
            {
                mergedObject.FaceRecognitionScenarios.Add(sourceScenario);
            }

            return mergedObject;
        }
    }
}