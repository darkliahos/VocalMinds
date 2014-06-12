using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public FaceRecognitionScenario()
        {
            
        }

        public Guid Id { get; set; }

        [Required]
        public Image Image { get; set; }

        [Required, MaxLength(20)]
        public string Answer { get; set; }

        public string CopyrightDisclaimer { get; set; }

        [Required]
        public string Author { get; set; }


    }
}
