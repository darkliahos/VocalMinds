using System.ComponentModel.DataAnnotations;

namespace VM_Model
{
    public class Response
    {
        [Required, MaxLength(20)]
        public string Answer { get; set; }

        [Required]
        public string ResponseType { get; set; }

        /// <summary>
        /// The Next video that will be played or action to be taken if this response is given
        /// Select 0 for End Video
        /// </summary>
        [Required]
        public int SocialSimulatorAction { get; set; }
    }
}