using System.Collections.Generic;

namespace VM_Model
{
    public class VideoSegment
    {
        public int PlayOrder { get; set; }

        public string VideoPath { get; set; }

        public List<Response> Responses { get; set; }
    }
}