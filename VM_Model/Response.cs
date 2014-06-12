using System.ComponentModel.DataAnnotations;

namespace VM_Model
{
    public class Response
    {
        [Required, MaxLength(20)]
        public string Answer { get; set; }

        [Required]
        public string ResponseType { get; set; }
    }
}