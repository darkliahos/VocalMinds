using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VM_Model
{
    public class VideoSegment
    {
        [Required]
        public string Description { get; set; }

        [Required]
        public int PlayOrder { get; set; }

        [Required]
        public string VideoPath { get; set; }

        public List<Response> Responses { get; set; }
    }
}