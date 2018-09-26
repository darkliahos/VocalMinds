namespace VM.Model
{
    public class Response
    {
        public string Answer { get; set; }

        public ResponseType ResponseType { get; set; }

        /// <summary>
        /// The Next video that will be played or action to be taken if this response is given
        /// Select 0 for End Video
        /// </summary>
        public int SocialSimulatorAction { get; set; }
    }
}