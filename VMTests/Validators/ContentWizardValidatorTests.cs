using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using VMUtils.Interfaces;
using VMUtils.Validators;
using VM_ScenarioEditor;
using Xunit;

namespace VMTests.Validators
{
    public class ContentWizardValidatorTests
    {
        [Fact]
        public void ValidateSelection_WhenFileNameIsBlankReturnErrors()
        {
            // Arrange
            const string fileName = "";
            var fakeConfig = Substitute.For<IConfiguration>();
            fakeConfig.ReadSetting("SupportedAudExt").Returns(".mp3|.wav");
            fakeConfig.ReadSetting("SupportedImgExt").Returns(".jpg|.png|.bmp|.gif");
            fakeConfig.ReadSetting("SupportedVidExt").Returns(".mp4|.wmv|.flv|.avi");
            var contentwizardValidator = new ContentWizardValidator(fakeConfig);

            // Act
            var result = contentwizardValidator.ValidateSelection(fileName, ContentType.Image);

            // Assert
            Assert.Equal(2, result.ErrorMessages.Count);
        }

        [Fact]
        public void ValidateSelection_WhenFileNameAndContentTypeIsPopulatedCorrectlyReturnNoErrors()
        {
            // Arrange
            const string fileName = "fred.jpg";
            var fakeConfig = Substitute.For<IConfiguration>();
            fakeConfig.ReadSetting("SupportedAudExt").Returns(".mp3|.wav");
            fakeConfig.ReadSetting("SupportedImgExt").Returns(".jpg|.png|.bmp|.gif");
            fakeConfig.ReadSetting("SupportedVidExt").Returns(".mp4|.wmv|.flv|.avi");
            var contentwizardValidator = new ContentWizardValidator(fakeConfig);

            // Act
            var result = contentwizardValidator.ValidateSelection(fileName, ContentType.Image);

            // Assert
            Assert.Equal(0, result.ErrorMessages.Count);
            Assert.Equal(false, result.HasErrors);
        }

        [Fact]
        public void ValidateSelection_WhenFileNameIsPopulatedCorrectlyButContentWizardIsntReturnErrors()
        {
            // Arrange
            const string fileName = "fred.wav";
            var fakeConfig = Substitute.For<IConfiguration>();
            fakeConfig.ReadSetting("SupportedAudExt").Returns(".mp3|.wav");
            fakeConfig.ReadSetting("SupportedImgExt").Returns(".jpg|.png|.bmp|.gif");
            fakeConfig.ReadSetting("SupportedVidExt").Returns(".mp4|.wmv|.flv|.avi");
            var contentwizardValidator = new ContentWizardValidator(fakeConfig);

            // Act
            var result = contentwizardValidator.ValidateSelection(fileName, ContentType.Image);

            // Assert
            Assert.Equal(1, result.ErrorMessages.Count);
            Assert.Equal(true, result.HasErrors);
        }
    }
}
