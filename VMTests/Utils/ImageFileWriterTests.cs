using NSubstitute;
using VMUtils;
using VM_Model;
using Xunit;

namespace VMTests.Utils
{
    public class ImageFileWriterTests
    {
        [Fact(Skip = "Need to seperate out the file writer before executing the test")]
        public void Lock_LocksFile_WhenFileIsUnlocked()
        {
            var serialiser = Substitute.For < ISerialiser<ImportedFaceRecognitionScenario>>();
            ImageFileWriter ifw = new ImageFileWriter(serialiser);
            Assert.DoesNotThrow(ifw.LockFile);
        }
    }
}
