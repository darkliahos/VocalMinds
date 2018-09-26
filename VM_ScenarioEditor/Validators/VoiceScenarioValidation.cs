using System.Collections.Generic;
using VM.Model;

namespace VM_ScenarioEditor
{
    public static class VoiceScenarioValidation
    {
        public static ValidationObject Validation(this VoiceRecognitionScenario vs)
        {
            var validationObject = new ValidationObject {ErrorMessages = new List<string>()};
            if (string.IsNullOrEmpty(vs.QuestionTitle))
            {
                validationObject.ErrorMessages.Add("Question Title should not be blank");
            }

            if (vs.Answers.Count < 1)
            {
                validationObject.ErrorMessages.Add("Please add answers to this scenario");
            }
            else
            {
                foreach (var ans in vs.Answers)
                {
                    if (string.IsNullOrEmpty(ans))
                    {
                        validationObject.ErrorMessages.Add("One or more of the answers are blank");
                        break;
                    }
                }
            }

            if (string.IsNullOrWhiteSpace(vs.AudioPath))
            {
                validationObject.ErrorMessages.Add("Path cannot be empty or null");
            }


            if (validationObject.ErrorMessages.Count > 0)
            {
                validationObject.HasErrors = true;
            }

            return validationObject;
        }
    }
}
