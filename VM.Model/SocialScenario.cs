using System;
using System.Collections.Generic;

namespace VM.Model
{
    public class SocialScenario
    {
        public Guid Id { get; set; }
        
        public string FriendlyName { get; set; }

        public List<VideoSegment> VideoSegment { get; set; }

        public DateTime Imported { get; set; }

        public string Author { get; set; }
    }
}
