using VM.Model;

namespace VM_ScenarioEditor
{
    public static class SocialSimulatorFormState
    {
        /// <summary>
        /// Are we editing State object?
        /// </summary>
        public static bool EditingState { get; set; }

        /// <summary>
        /// The in memory Social Scenario
        /// </summary>
        public static SocialScenario SocialScenario { get; set; }
    }
}
