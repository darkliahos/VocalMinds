using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace VM_Model
{
    public class FaceRecognitionScenario
    {
        public FaceRecognitionScenario(Guid id, string answer, Image image)
        {
            Image = image;
            Answer = answer;
            Id = id;
        }

        public Guid Id { get; set; }

        public Image Image { get; set; }

        public string Answer { get; set; }

        public string CopyrightDisclaimer { get; set; }

        public string Author { get; set; }


    }
}
