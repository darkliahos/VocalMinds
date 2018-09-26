using System;
using System.Collections.Generic;

namespace VM.Model
{
    public class ImportedFaceRecognitionScenario
    {
        public DateTime Creation { get; set; }

        public DateTime LastModified { get; set; }

        public int LastWrittenProcessId { get; set; }

        /// <summary>
        /// Lock Flag to stop writing to a locked out file
        /// </summary>
        public bool IsCurrentlyLocked { get; set; }

        public List<FaceRecognitionScenario> FaceRecognitionScenarios { get; set; }
    }
}
