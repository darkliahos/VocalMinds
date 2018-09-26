using System;
using System.Collections.Generic;

namespace VM.Model
{
    public class VoiceRecognitionScenario
    {
        public Guid Id { get; set; }

        /// <summary>
        /// A user Identifiable title
        /// </summary>
        public string QuestionTitle { get; set; }

        public string AudioPath { get; set; }

        public List<string> Answers { get; set; }

        public string Author { get; set; }

        public string CopyrightDisclaimer { get; set; }

        public DateTime LastModified { get; set; }


    }
}
