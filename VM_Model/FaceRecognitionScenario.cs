using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace VM_Model
{
    public class FaceRecognitionScenario
    {
        public FaceRecognitionScenario(Guid id, List<string> answers, string imageName, string title)
        {
            ImageName = imageName;
            Answers = answers;
            QuestionTitle = title;
            Id = id;
        }

        public FaceRecognitionScenario()
        {
            
        }

        /// <summary>
        /// A user Identifiable title
        /// </summary>
        [Required]
        public string QuestionTitle { get; set; }

        /// <summary>
        /// System Identifier
        /// </summary>
        public Guid Id { get; set; }

        [Required]
        public string ImageName { get; set; }

        public List<string> Answers { get; set; }

        public string CopyrightDisclaimer { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public DateTime LastModified { get; set; }
    }
}
