using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VMEntities
{
    public class FaceRecognitionScenario
    {
        /// <summary>
        /// A user Identifiable title
        /// </summary>
        [Required]
        public string QuestionTitle { get; set; }

        [Required]
        public byte[] Image { get; set; }

        public List<FaceRecognitionScenariosAnswer> Answers { get; set; }

        public string CopyrightDisclaimer { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public DateTime LastModified { get; set; }
    }
}