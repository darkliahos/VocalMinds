using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VM_Model;

namespace VM_ScenarioEditor.Validators
{
    public class SocialScenarioValidation
    {
        public ValidationObject ValidateSegmentResponse(Response response)
        {
            var validationObject = new ValidationObject {ErrorMessages = new List<string>()};
            if (response.Answer == "")
            {
                validationObject.HasErrors = true;
                validationObject.ErrorMessages.Add("Answer should not be blank");
            }

            if (response.SocialSimulatorAction == 0)
            {
                validationObject.ErrorMessages.Add("Next Segment is invalid");
            }

            return validationObject;
        }
    }
}
