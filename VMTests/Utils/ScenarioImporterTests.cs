using System;
using System.Collections.Generic;
using VMUtils;
using VM_Model;
using Xunit;

namespace VMTests.Utils
{
    public class ScenarioImporterTests
    {
        private readonly Importer<ImportedSocialScenarios> _socialimporter = new Importer<ImportedSocialScenarios>(new JsonSerialiser<ImportedSocialScenarios>());
        private readonly Importer<ImportedFaceRecognitionScenario> _faceimporter = new Importer<ImportedFaceRecognitionScenario>(new JsonSerialiser<ImportedFaceRecognitionScenario>());
        private readonly Importer<ImportedVoiceRecognitionScenario> _voiceimporter = new Importer<ImportedVoiceRecognitionScenario>(new JsonSerialiser<ImportedVoiceRecognitionScenario>());


        [Fact]
        public void WriteToString_ValidInput_ShouldNotReturnNull()
        {
            Assert.NotNull(_socialimporter.WriteToString(ImportedScenariosHelper()));
        }

        [Fact]
        public void StringToImportedScenarios_ValidJSonString_ShouldReturnImportedObject()
        {
            var expectedResult = ImportedScenariosHelper();
            var actualObject = _socialimporter.StringToImportedScenarios(Properties.Resources.SocialScenarioRecoJsonTest);

            Assert.Equal(expectedResult.Creation, actualObject.Creation);
            Assert.Equal(expectedResult.LastModified, actualObject.LastModified);
            Assert.Equal(expectedResult.SocialScenario[0].Author, actualObject.SocialScenario[0].Author);
            Assert.Equal(expectedResult.SocialScenario[0].FriendlyName, actualObject.SocialScenario[0].FriendlyName);
            Assert.Equal(expectedResult.SocialScenario[0].Imported, actualObject.SocialScenario[0].Imported);
            Assert.Equal(expectedResult.SocialScenario[0].VideoSegment[0].PlayOrder, actualObject.SocialScenario[0].VideoSegment[0].PlayOrder);
            Assert.Equal(expectedResult.SocialScenario[0].VideoSegment[0].VideoPath, actualObject.SocialScenario[0].VideoSegment[0].VideoPath);
            Assert.Equal(expectedResult.SocialScenario[0].VideoSegment[0].Responses[0].Answer, actualObject.SocialScenario[0].VideoSegment[0].Responses[0].Answer);
            Assert.Equal(expectedResult.SocialScenario[0].VideoSegment[0].Responses[0].ResponseType, actualObject.SocialScenario[0].VideoSegment[0].Responses[0].ResponseType);

        }

        [Fact]
        public void StringToImportedVoiceRecoScenarios_ValidJsonString_ShouldReturnImportedObject()
        {
            var expectedResult = ImportedVideoScenariosHelper();
            var actualObject = _voiceimporter.StringToImportedScenarios(Properties.Resources.VoiceRecoTest);

            Assert.Equal(expectedResult.VoiceRecognitionScenarios[0].Answers, actualObject.VoiceRecognitionScenarios[0].Answers);
            Assert.Equal(expectedResult.VoiceRecognitionScenarios[0].AudioPath, actualObject.VoiceRecognitionScenarios[0].AudioPath);
            Assert.Equal(expectedResult.VoiceRecognitionScenarios[0].Author, actualObject.VoiceRecognitionScenarios[0].Author);
            Assert.Equal(expectedResult.VoiceRecognitionScenarios[0].CopyrightDisclaimer, actualObject.VoiceRecognitionScenarios[0].CopyrightDisclaimer);
            Assert.Equal(expectedResult.VoiceRecognitionScenarios[0].Id, actualObject.VoiceRecognitionScenarios[0].Id);
        }


        [Fact]
        public void StringToImportedFaceRecoScenarios_ValidJSonString_ShouldReturnImportedObject()
        {
            var expectedResult = FaceRecognitionScenarioScenarioHelper();
            var actualObject = _faceimporter.StringToImportedScenarios(Properties.Resources.FaceRecoJsonTest);

            Assert.Equal(expectedResult.Creation, actualObject.Creation);
            Assert.Equal(expectedResult.LastModified, actualObject.LastModified);
            Assert.Equal(expectedResult.FaceRecognitionScenarios[0].Answers, actualObject.FaceRecognitionScenarios[0].Answers);
            Assert.Equal(expectedResult.FaceRecognitionScenarios[0].Author, actualObject.FaceRecognitionScenarios[0].Author);
            Assert.Equal(expectedResult.FaceRecognitionScenarios[0].CopyrightDisclaimer, actualObject.FaceRecognitionScenarios[0].CopyrightDisclaimer);
            Assert.Equal(expectedResult.FaceRecognitionScenarios[0].Id, actualObject.FaceRecognitionScenarios[0].Id);


        }

        private ImportedFaceRecognitionScenario FaceRecognitionScenarioScenarioHelper()
        {
            return new ImportedFaceRecognitionScenario
            {
                FaceRecognitionScenarios = new List<FaceRecognitionScenario>
                {
                    new FaceRecognitionScenario
                    {
                        Answers = new List<string> {"Angry", "Disgusted"},
                        Author = "Lord Voldermort",
                        CopyrightDisclaimer = "2014 Voldermort Creations",
                        Id =
                            Guid.Parse(
                                "4bfad142-c027-495d-8f37-582471b03c70"),
                        ImageName = "angryface.png",
                        QuestionTitle = "Angry Face",
                    }
                },
                Creation = new DateTime(2014, 12, 27),
                LastModified = new DateTime(2014, 12, 27)
            };
        }

        private ImportedVoiceRecognitionScenario ImportedVideoScenariosHelper()
        {
            return new ImportedVoiceRecognitionScenario
            {
                Creation = new DateTime(2015, 01, 09),
                LastModified = new DateTime(2015,01,09),
                VoiceRecognitionScenarios  = new List<VoiceRecognitionScenario>
                                                           {
                                                               new VoiceRecognitionScenario
                                                                   {
                                                                       Answers = new List<string> {"Happy", "Eccstatic"},
                                                                       Author = "Dave The Clown",
                                                                       AudioPath = @"C:\Audio\VRS\",
                                                                       CopyrightDisclaimer = "2009 Micheal Jackson",
                                                                       QuestionTitle = "Hey Hey",
                                                                       Id =
                                                                           Guid.Parse(
                                                                               "20cc7f02-970e-4684-a143-112d75c39238")
                                                                   },
                                                           }
            };
        }

        private ImportedSocialScenarios ImportedScenariosHelper()
        {
            return new ImportedSocialScenarios
            {
                Creation = new DateTime(2014, 4, 20),
                LastModified = new DateTime(2014, 5, 20),
                SocialScenario = new List<SocialScenario>
                                                {
                                                    new SocialScenario
                                                        {
                                                            Author = "Fred Flintstone",
                                                            FriendlyName = "Day in Bedrock",
                                                            Id = Guid.Parse("d8f18d79-0c48-43cf-8b78-c456f5e8b010"),
                                                            Imported = new DateTime(2011, 04, 03),
                                                            VideoSegment = new List<VideoSegment>
                                                                               {
                                                                                   new VideoSegment
                                                                                       {
                                                                                           PlayOrder = 1,
                                                                                           Responses =
                                                                                               new List<Response>
                                                                                                   {
                                                                                                       new Response
                                                                                                           {
                                                                                                               Answer =
                                                                                                                   "Morning",
                                                                                                               ResponseType
                                                                                                                   =
                                                                                                                   ResponseType.Positive
                                                                                                           },
                                                                                                       new Response
                                                                                                           {
                                                                                                               Answer =
                                                                                                                   "Go Away",
                                                                                                               ResponseType
                                                                                                                   =
                                                                                                                   ResponseType.Negative
                                                                                                           }
                                                                                                   }
                                                                                       }
                                                                               }
                                                        }
                                                },
            };
        }
    }
}