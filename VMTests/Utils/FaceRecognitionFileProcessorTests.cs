using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NSubstitute;
using VMUtils.FaceRecognition;
using VMUtils.Interfaces;
using VM.Model;
using Xunit;

namespace VMTests.Utils
{
    public class FaceRecognitionFileProcessorTests
    {
        [Fact]
        public async Task LoadScenarioFromFile_WhenScenariosArePresent_LoadsFaceRecognitionScenario()
        {
            //Arrange
            var importer = Substitute.For<IImporter<ImportedFaceRecognitionScenario>>();
            importer.LoadFile("").Returns(new ImportedFaceRecognitionScenario
            {
                Creation = new DateTime(2000, 01, 02),
                LastModified = new DateTime(2014, 12, 27),
                FaceRecognitionScenarios = new List<FaceRecognitionScenario>
                                                                                 {
                                                                                     new FaceRecognitionScenario
                                                                                         {
                                                                                             Answers = new List<string>{"Angry", "Peeved"},
                                                                                             Author = "Tester",
                                                                                             CopyrightDisclaimer = "1999",
                                                                                             Id = Guid.Parse("53f0fad3-46ed-417d-b0ae-f45adf29fd15"),
                                                                                             ImageName = "angry.png",
                                                                                             QuestionTitle = "Angry Face",
                                                                                         }
                                                                                 }
            });
            var fp = new FaceRecognitionFileProcessor(importer, string.Empty);
            //Act
            //NOTE TO READER: This is an await because we intend to use threading when loading scenarios
            List<FaceRecognitionScenario> frs = await Task.FromResult<List<FaceRecognitionScenario>>(fp.LoadScenarioFromFile());
            //Assert
            Assert.Equal("Angry", frs[0].Answers.First());
            Assert.Equal("Tester", frs[0].Author);
            Assert.Equal("angry.png", frs[0].ImageName);
            Assert.Equal("Angry Face", frs[0].QuestionTitle);
            Assert.Equal("1999", frs[0].CopyrightDisclaimer);
            Assert.Equal(Guid.Parse("53f0fad3-46ed-417d-b0ae-f45adf29fd15"), frs[0].Id);
        }

        [Fact]
        public async Task LoadScenarioFromFile_WhenNoScenariosLoaded_LoadsNoScenarios()
        {
            //Arrange
            var importer = Substitute.For<IImporter<ImportedFaceRecognitionScenario>>();
            importer.LoadFile("").Returns(new ImportedFaceRecognitionScenario
            {
                Creation = new DateTime(2000, 01, 02),
                LastModified = new DateTime(2014, 12, 27),
                FaceRecognitionScenarios = new List<FaceRecognitionScenario>()
            });
            var fp = new FaceRecognitionFileProcessor(importer, string.Empty);
            //Act
            //NOTE TO READER: This is an await because we intend to use threading when loading scenarios
            List<FaceRecognitionScenario> frs = await Task.FromResult<List<FaceRecognitionScenario>>(fp.LoadScenarioFromFile());
            //Assert
            Assert.Equal(0, frs.Count);
        }
    }
}
