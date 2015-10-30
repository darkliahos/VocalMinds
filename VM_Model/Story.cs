using System;
using System.Collections.Generic;

namespace VM_Model
{
    /// <summary>
    /// Format to store a Story
    /// </summary>
    public class Story
    {
        /// <summary>
        /// A unique ID for a story
        /// </summary>
        public Guid StoryId { get; set; }

        /// <summary>
        /// The Title for the story
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// A List of pages
        /// </summary>
        public List<Page> Pages { get; set; }
    }
}
