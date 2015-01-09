using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VM_Model
{
    public class VoiceRecognitionScenario
    {
        public Guid Id { get; set; }

        /// <summary>
        /// A user Identifiable title
        /// </summary>
        [Required]
        public string QuestionTitle { get; set; }

        [Required]
        public string AudioPath { get; set; }

        public List<string> Answers { get; set; }

        [Required]
        public string Author { get; set; }

        public string CopyrightDisclaimer { get; set; }

        [Required]
        public DateTime LastModified { get; set; }


    }
}
