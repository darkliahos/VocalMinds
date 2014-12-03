using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using VMUtils;
using VM_Model;
using Xunit;

namespace VMTests.Utils
{
    public class FileProcessorTests
    {
        [Fact]
        public async Task GetImportedFRScenariosFromFile_WhenHit_LoadsFaceRecognitionScenario()
        {
            //Arrange
            var importer = Substitute.For<IImporter>();
            importer.LoadFile("").Returns(new ImportedScenarios
                                              {
                                                  Creation = new DateTime(2000,01,02),
                                                  FaceRecognitionScenarios = new List<FaceRecognitionScenario>
                                                                                 {
                                                                                     new FaceRecognitionScenario
                                                                                         {
                                                                                             Answer = "Happy",
                                                                                             Author = "Dr Fart",
                                                                                             CopyrightDisclaimer = "1999",
                                                                                             Id = Guid.Parse("53f0fad3-46ed-417d-b0ae-f45adf29fd15"),
                                                                                         }
                                                                                 }
                                              });
            var fp = new FileProcessor(importer, string.Empty);
            //Act
            //NOTE TO READER: This is an await because we intend to use threading when loading scenarios
            List<FaceRecognitionScenario> frs = await Task.FromResult<List<FaceRecognitionScenario>>(fp.GetImportedFRScenariosFromFile());
            //Assert
            Assert.Equal("Happy", frs[0].Answer);
            Assert.Equal("Dr Fart", frs[0].Author);
            Assert.Equal("1999", frs[0].CopyrightDisclaimer);
            Assert.Equal(Guid.Parse("53f0fad3-46ed-417d-b0ae-f45adf29fd15"), frs[0].Id);
        }

        [Fact]
        public async Task GetImportedVRScenariosFromFile_WhenHit_LoadsVoiceRecognitionScenarios()
        {
            //Arrange
            var importer =  Substitute.For<IImporter>();
            importer.LoadFile("").Returns(new ImportedScenarios
            {
                Creation = new DateTime(2014,12,03),
                VoiceRecognitionScenarios = new List<VoiceRecognitionScenario>
                {
                    new VoiceRecognitionScenario
                    {
                        Answer = "Suicidal",
                        AudioPath = @"C:\temp\audiofile.mp3",
                        Author = "Pooman",
                        CopyrightDisclaimer = "No Idea",
                        Id = Guid.Parse("daa1f333-46ed-417d-b0ae-f45adf29fd15"),
                    }
                }
            });
            var fp = new FileProcessor(importer, string.Empty);
            //Act
            List<VoiceRecognitionScenario> vrs = await Task.FromResult<List<VoiceRecognitionScenario>>(fp.GetVRScenariosFromFile());
            //Assert
            Assert.Equal("Suicidal", vrs[0].Answer);
            Assert.Equal(@"C:\temp\audiofile.mp3", vrs[0].AudioPath);
            Assert.Equal("Pooman", vrs[0].Author);
            Assert.Equal("No Idea", vrs[0].CopyrightDisclaimer);
            Assert.Equal(Guid.Parse("daa1f333-46ed-417d-b0ae-f45adf29fd15"), vrs[0].Id);
        }
    }
}
