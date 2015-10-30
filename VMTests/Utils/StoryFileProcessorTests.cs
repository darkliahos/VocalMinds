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
    public class StoryFileProcessorTests
    {
        [Fact]
        public async Task LoadScenarioFromFile_WhenScenariosArePresent_LoadsStory()
        {
            // Arrange
            Guid storyId = new Guid();
            var importer = Substitute.For<IImporter<Story>>();
            importer.LoadFile("").Returns(new Story
            {
                StoryId = storyId,
                Title = "The Fat Dalek",
                Pages = new List<Page>
                {
                    new Page{Image = "P1", PageNumber = 1, Text = "No Density"},
                    new Page{Image = "P2", PageNumber = 2, Text = "You shall not pass"},
                }
            });
            // Act
            var sp = new StoryFileProcessor(importer, string.Empty);
            Story story = await Task.FromResult<Story>(sp.LoadScenarioFromFile());

            // Assert
            Assert.Equal("The Fat Dalek", story.Title);
            Assert.Equal(storyId, story.StoryId);
            Assert.Equal("No Density", story.Pages[0].Text);
            Assert.Equal("P1", story.Pages[0].Image);
            Assert.Equal(1, story.Pages[0].PageNumber);
            Assert.Equal("You shall not pass", story.Pages[1].Text);
            Assert.Equal("P2", story.Pages[1].Image);
            Assert.Equal(2, story.Pages[1].PageNumber);
        }
    }
}
