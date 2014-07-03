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
            IImporter importer = Substitute.For<IImporter>();
            importer.LoadFile("").Returns(new ImportedScenarios
                                              {
                                                  Creation = new DateTime(2000,01,02),
                                                  FaceRecognitionScenarios = new List<FaceRecognitionScenario>
                                                                                 {
                                                                                     new FaceRecognitionScenario
                                                                                         {
                                                                                             Answer = "Happy",
                                                                                             Author = "Micheal Jackson",
                                                                                             CopyrightDisclaimer = "1999",
                                                                                             Id = Guid.Parse("53f0fad3-46ed-417d-b0ae-f45adf29fd15"),
                                                                                         }
                                                                                 }
                                              });
            FileProcessor fp = new FileProcessor(importer, string.Empty);
            //Act
            //NOTE TO READER: This is an await because we intend to use threading when loading scenarios
            List<FaceRecognitionScenario> frs = await Task.FromResult<List<FaceRecognitionScenario>>(fp.GetImportedFRScenariosFromFile());
            //Assert
            Assert.Equal("Happy", frs[0].Answer);
            Assert.Equal("Micheal Jackson", frs[0].Author);
            Assert.Equal("1999", frs[0].CopyrightDisclaimer);
            Assert.Equal(Guid.Parse("53f0fad3-46ed-417d-b0ae-f45adf29fd15"), frs[0].Id);
        }
    }
}
