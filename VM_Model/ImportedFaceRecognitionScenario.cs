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

        [Required]
        public int LastWrittenProcessId { get; set; }

        /// <summary>
        /// Lock Flag to stop writing to a locked out file
        /// </summary>
        [Required]
        public bool IsCurrentlyLocked { get; set; }

        public List<FaceRecognitionScenario> FaceRecognitionScenarios { get; set; }
    }
}
