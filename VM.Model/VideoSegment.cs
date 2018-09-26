using System;
using System.Collections.Generic;

namespace VM.Model
{
    public class VideoSegment
    {
        /// <summary>
        /// For Unique Identification - As this should not change
        /// </summary>
        public Guid Id { get; set; }

        public string Description { get; set; }

        public int PlayOrder { get; set; }

        public List<Response> Responses { get; set; }
    }
}