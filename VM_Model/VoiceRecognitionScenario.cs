using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM_Model
{
    public class VoiceRecognitionScenario
    {
        public Guid Id { get; set; }

        [Required]
        public string AudioPath { get; set; }

        [Required, MaxLength(20)]
        public string Answer { get; set; }

        [Required]
        public string Author { get; set; }

        public string CopyrightDisclaimer { get; set; }
    }
}
