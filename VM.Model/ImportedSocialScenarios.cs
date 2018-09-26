using System;
using System.Collections.Generic;

namespace VM.Model
{
    /// <summary>
    /// These are scenarios that are exclusivly in use for the social simulator
    /// </summary>
    public class ImportedSocialScenarios
    {
        public DateTime Creation { get; set; }

        public DateTime LastModified { get; set; }

        public int LastWrittenProcessId { get; set; }

        /// <summary>
        /// Lock Flag to stop writing to a locked out file
        /// </summary>
        public bool IsCurrentlyLocked { get; set; }

        public List<SocialScenario> SocialScenario { get; set; }
    }
}
