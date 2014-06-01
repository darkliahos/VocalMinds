using System.Drawing;

namespace Project
{
    public class FaceRecognition
    {
        public int Id { get; set; }
        public string Emotion { get; set; }
        public Image ImageAssociated { get; set; }

        public FaceRecognition(int id, string emotion, Image imageAssociated)
        {
            Id = id;
            Emotion = emotion;
            ImageAssociated = imageAssociated;
        }
    }
}