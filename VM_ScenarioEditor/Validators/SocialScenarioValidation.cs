using System;
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

        public static ValidationObject ValidateSegment(VideoSegment segment)
        {
            var validationObject = new ValidationObject { ErrorMessages = new List<string>() };

            if (segment.Description == "")
            {
                validationObject.ErrorMessages.Add("Description cannot be blank");
            }

            if (segment.Id == Guid.Empty)
            {
                validationObject.ErrorMessages.Add("Id cannot be blank");
            }

            if (segment.PlayOrder == 0)
            {
                validationObject.ErrorMessages.Add("Play order cannot be set as 0");
            }

            if (segment.PlayOrder < 0)
            {
                validationObject.ErrorMessages.Add("Play order cannot be a negative number");
            }

            if (segment.VideoPath == "")
            {
                validationObject.ErrorMessages.Add("Video path must be set");
            }

            if (validationObject.ErrorMessages.Count > 0)
            {
                validationObject.HasErrors = true;
            }

            return validationObject;
        }
    }
}
