using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM_Model
{
    public class VideoScenario
    {
        public Guid Id { get; set; }
        
        public string FriendlyName { get; set; }

        public List<VideoSegment> VideoSegment { get; set; }

        public DateTime Imported { get; set; }

        public string Author { get; set; }
    }
}
