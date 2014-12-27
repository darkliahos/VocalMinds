using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VM_Model
{
    public class ImportedFaceRecognitionScenario
    {
        [Required]
        public DateTime Creation { get; set; }

        [Required]
        public DateTime LastModified { get; set; }

        public List<FaceRecognitionScenario> FaceRecognitionScenarios { get; set; }
    }
}
