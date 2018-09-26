using System;
using System.Collections.Generic;

namespace VM.Model
{
    public class FaceRecognitionScenario
    {
        /// <summary>
        /// A user Identifiable title
        /// </summary>
        public string QuestionTitle { get; set; }

        /// <summary>
        /// System Identifier
        /// </summary>
        public Guid Id { get; set; }

        public string ImageName { get; set; }

        public List<string> Answers { get; set; }

        public string CopyrightDisclaimer { get; set; }

        public string Author { get; set; }

        public DateTime LastModified { get; set; }
    }
}
