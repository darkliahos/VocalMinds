using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NSubstitute;
using VMUtils;
using VMUtils.Interfaces;
using VM_Model;
using Xunit;

namespace VMTests.Utils
{
    public class SocialSimulatorFileProcessorTests
    {
        [Fact]
        public async Task LoadScenariosFromFile_WhenScenariosArePresent_LoadSocialSimulatorScenarios()
        {
            //Arrange
            var importer = Substitute.For<IImporter<ImportedSocialScenarios>>();
            importer.LoadFile("").Returns(new ImportedSocialScenarios
            {
                Creation = new DateTime(2014, 12, 03),
                SocialScenario = new List<SocialScenario>
                {
                    new SocialScenario
                    {
                        Author = "Fred",
                        FriendlyName = "Walk out",
                        Id = Guid.Parse("daa1f333-46ed-417d-b0ae-f45adf29fd15"),
                        Imported = new DateTime(2014,03,03),
                    }
                }
            });
            var fp = new SocialSimulatorFileProcessor(importer, string.Empty);
            //Act
            List<SocialScenario> vrs = await Task.FromResult<List<SocialScenario>>(fp.LoadScenarioFromFile());
            //Assert
            Assert.Equal("Walk out", vrs[0].FriendlyName);
            Assert.Equal("Fred", vrs[0].Author);
            Assert.Equal(Guid.Parse("daa1f333-46ed-417d-b0ae-f45adf29fd15"), vrs[0].Id);
        }

        [Fact]
        public async Task LoadScenariosFromFile_WhenNothingIsPresent_LoadsNothing()
        {
            //Arrange
            var importer = Substitute.For<IImporter<ImportedSocialScenarios>>();
            importer.LoadFile("").Returns(new ImportedSocialScenarios()
            {
                Creation = new DateTime(2014, 12, 03),
                SocialScenario = new List<SocialScenario>
                {
                }
            });
            var fp = new SocialSimulatorFileProcessor(importer, string.Empty);
            //Act
            List<SocialScenario> vrs = await Task.FromResult<List<SocialScenario>>(fp.LoadScenarioFromFile());
            //Assert
            Assert.Equal(0, vrs.Count);
        }
    }
}
