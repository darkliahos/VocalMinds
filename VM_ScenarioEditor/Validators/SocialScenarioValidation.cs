using System.Collections.Generic;
using VM_Model;

namespace VM_ScenarioEditor.Validators
{
    public static class SocialScenarioValidation
    {
        public static ValidationObject ValidateSegmentResponse(Response response)
        {
            var validationObject = new ValidationObject {ErrorMessages = new List<string>()};
            if (response.Answer == "")
            {
                validationObject.ErrorMessages.Add("Answer should not be blank");
            }

            if (response.SocialSimulatorAction == 0)
            {
                validationObject.ErrorMessages.Add("Next Segment is invalid");
            }

            if (validationObject.ErrorMessages.Count > 0)
            {
                validationObject.HasErrors = true;
            }

            return validationObject;
        }

        public static ValidationObject ValidateScenario()
        {
            var validationObject = new ValidationObject { ErrorMessages = new List<string>() };

            if (SocialSimulatorFormState.SocialScenario.Author == "")
            {
                validationObject.ErrorMessages.Add("Author cannot be blank");
            }

            if (SocialSimulatorFormState.SocialScenario.FriendlyName == "")
            {
                validationObject.ErrorMessages.Add("Description cannot be blank");
            }

            if (validationObject.ErrorMessages.Count > 0)
            {
                validationObject.HasErrors = true;
            }

            return validationObject;
        }
    }
}
