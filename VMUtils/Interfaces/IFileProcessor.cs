using System.Collections.Generic;
using VM_Model;

namespace VMUtils.Interfaces
{
    public interface IFileProcessor
    {
        List<FaceRecognitionScenario> GetFRScenariosFromFile();
        List<VoiceRecognitionScenario> GetVRScenariosFromFile();
        List<VideoScenario> GetVidWScenariosFromFile();
    }
}