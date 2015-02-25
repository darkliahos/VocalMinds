using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VM_Model
{
    /// <summary>
    /// These are scenarios that are exclusivly in use for the social simulator
    /// </summary>
    public class ImportedSocialScenarios
    {
        [Required]
        public DateTime Creation { get; set; }

        [Required]
        public DateTime LastModified { get; set; }

        [Required]
        public int LastWrittenProcessId { get; set; }

        /// <summary>
        /// Lock Flag to stop writing to a locked out file
        /// </summary>
        [Required]
        public bool IsCurrentlyLocked { get; set; }

        public List<SocialScenario> SocialScenario { get; set; }
    }
}
