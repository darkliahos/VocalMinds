using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NSubstitute;
using VMUtils.Interfaces;
using VMUtils.VoiceRecognition;
using VM.Model;
using Xunit;

namespace VMTests.Utils
{
    public class VoiceRecognitionFileProcessorTests
    {
        [Fact]
        public async Task LoadScenarioFromFile_WhenScenariosArePresent_LoadsVoiceRecognitionScenarios()
        {
            //Arrange
            var importer = Substitute.For<IImporter<ImportedVoiceRecognitionScenario>>();
            importer.LoadFile("").Returns(new ImportedVoiceRecognitionScenario
            {
                Creation = new DateTime(2014, 12, 03),
                VoiceRecognitionScenarios = new List<VoiceRecognitionScenario>
                {
                    new VoiceRecognitionScenario
                    {
                        Answers = new List<string>{"Angry", "Peeved"},
                        AudioPath = @"C:\temp\audiofile.mp3",
                        Author = "Pooman",
                        CopyrightDisclaimer = "No Idea",
                        Id = Guid.Parse("daa1f333-46ed-417d-b0ae-f45adf29fd15"),
                    }
                }
            });
            var fp = new VoiceRecognitionFileProcessor(importer, string.Empty);
            //Act
            List<VoiceRecognitionScenario> vrs = await Task.FromResult<List<VoiceRecognitionScenario>>(fp.LoadScenarioFromFile());
            //Assert
            Assert.Equal("Angry", vrs[0].Answers.First());
            Assert.Equal(@"C:\temp\audiofile.mp3", vrs[0].AudioPath);
            Assert.Equal("Pooman", vrs[0].Author);
            Assert.Equal("No Idea", vrs[0].CopyrightDisclaimer);
            Assert.Equal(Guid.Parse("daa1f333-46ed-417d-b0ae-f45adf29fd15"), vrs[0].Id);
        }

        [Fact]
        public async Task LoadScenarioFromFile_WhenScenariosArePresent_LoadsNothing()
        {
            //Arrange
            var importer = Substitute.For<IImporter<ImportedVoiceRecognitionScenario>>();
            importer.LoadFile("").Returns(new ImportedVoiceRecognitionScenario
            {
                Creation = new DateTime(2014, 12, 03),
                VoiceRecognitionScenarios = new List<VoiceRecognitionScenario>()
            });
            var fp = new VoiceRecognitionFileProcessor(importer, string.Empty);
            //Act
            List<VoiceRecognitionScenario> vrs = await Task.FromResult<List<VoiceRecognitionScenario>>(fp.LoadScenarioFromFile());
            //Assert
            Assert.Equal(0, vrs.Count);
        }
    }
}
