namespace VM.Model
{
    /// <summary>
    /// Stores information about each individual page
    /// </summary>
    public class Page
    {
        /// <summary>
        /// The Page number
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// The Text associated with the page
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// The Image name relating to this page
        /// </summary>
        public string Image { get; set; }

    }
}