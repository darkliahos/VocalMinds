using System.Collections.Generic;
using System.Threading.Tasks;
using VM_Model;

namespace VMUtils
{
    public interface IFileProcessor
    {
        List<FaceRecognitionScenario> GetImportedFRScenariosFromFile();
        Task<VoiceRecognitionScenario> GetVRScenariosFromFile();
        Task<VideoScenario> GetVidWScenariosFromFile();
    }
}