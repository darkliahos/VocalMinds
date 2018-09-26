using System.Collections.Generic;

namespace VM.Model
{
    public class ValidationObject
    {
        public bool HasErrors { get; set; }

        public List<string> ErrorMessages { get; set; }
    }
}