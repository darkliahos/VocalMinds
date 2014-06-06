using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM_Model
{
    public class VoiceRecognitionScenario
    {
        public Guid Id { get; set; }

        public string AudioPath { get; set; }

        public string Answer { get; set; }

        public string Author { get; set; }

        public string CopyrightDisclaimer { get; set; }
    }
}
