using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM_Model
{
    public class ImportedScenarios
    {
        public DateTime Creation { get; set; }

        public DateTime LastModified { get; set; }

        public List<VideoScenario> VideoScenarios { get; set; }

        public List<FaceRecognitionScenario> FaceRecognitionScenarios { get; set; }

        public List<VoiceRecognitionScenario> VoiceRecognitionScenarios { get; set; }
    }
}
