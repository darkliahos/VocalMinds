using System;
using System.Collections.Generic;
using System.Web.Http;
using VM_Model;

namespace VM.Main.Api.Controllers
{
    public class ImageController : ApiController
    {
        public FaceRecognitionScenario Get(string id)
        {
            return new FaceRecognitionScenario
            {
                Id = Guid.Parse(id),
                Answers = new List<string>
                {
                    "A", "B", "C", "D"
                }
            };
        }
    }
}
