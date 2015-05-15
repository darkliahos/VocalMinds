using System.Collections.Generic;
using System.Text.RegularExpressions;
using VMUtils.Interfaces;
using VM_Model;
using VM_ScenarioEditor;

namespace VMUtils.Validators
{
    public class ContentWizardValidator
    {
        private readonly IConfiguration _configuration;

        public ContentWizardValidator(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Validates Selected File to see whether or not it is suitable to be used for that entity
        /// </summary>
        /// <param name="selectedFile"></param>
        /// <param name="contentType"></param>
        /// <returns></returns>
        public ValidationObject ValidateSelection(string selectedFile, ContentType contentType)
        {
            var validationObject = new ValidationObject {ErrorMessages = new List<string>()};
            if (selectedFile == "")
            {
                validationObject.ErrorMessages.Add("No File has been selected");
            }

            if (GetFileExtension(selectedFile) != contentType)
            {
                validationObject.ErrorMessages.Add("Selected file is not the correct type");
            }

            if (validationObject.ErrorMessages.Count > 0)
            {
                validationObject.HasErrors = true;
            }

            return validationObject;
        }

        private ContentType GetFileExtension(string selectedFile)
        {
            if(ValidateExtension(_configuration.ReadSetting("SupportedImgExt"), selectedFile))
            {
                return ContentType.Image;
            }
            if (ValidateExtension(_configuration.ReadSetting("SupportedAudExt"), selectedFile))
            {
                return ContentType.Sound;
            }
            if (ValidateExtension(_configuration.ReadSetting("SupportedVidExt"), selectedFile))
            {
                return ContentType.Video;
            }
            return ContentType.Other;
        }

        private bool ValidateExtension(string extensiondecider, string fileName)
        {
            string matchExtention = @"(.*?)(" + extensiondecider + ")$";

            if (Regex.IsMatch(fileName, matchExtention))
            {
                return true;
            }
            return false;
        }
    }
}
