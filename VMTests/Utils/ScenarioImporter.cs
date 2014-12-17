using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMUtils;
using VM_Model;
using Xunit;

namespace VMTests
{
    public class ScenarioImporter
    {
        private readonly Importer _importer = new Importer();
        [Fact]
        public void WriteToString_ValidInput_ShouldNotReturnNull()
        {
            Assert.NotNull(_importer.WriteToString(ImportedScenariosHelper()));
        }

        [Fact]
        public void StringToImportedScenarios_ValidJSonString_ShouldReturnImportedObject()
        {
            var expectedResult = ImportedScenariosHelper();
            var actualObject = _importer.StringToImportedScenarios(Properties.Resources.JsonTest);

            Assert.Equal(expectedResult.Creation, actualObject.Creation);
            Assert.Equal(expectedResult.LastModified, actualObject.LastModified);
            Assert.Equal(expectedResult.FaceRecognitionScenarios[0].Answers, actualObject.FaceRecognitionScenarios[0].Answers);
            Assert.Equal(expectedResult.FaceRecognitionScenarios[0].Author, actualObject.FaceRecognitionScenarios[0].Author);
            Assert.Equal(expectedResult.FaceRecognitionScenarios[0].CopyrightDisclaimer, actualObject.FaceRecognitionScenarios[0].CopyrightDisclaimer);
            Assert.Equal(expectedResult.FaceRecognitionScenarios[0].Id, actualObject.FaceRecognitionScenarios[0].Id);
            Assert.Equal(expectedResult.VideoScenarios[0].Author, actualObject.VideoScenarios[0].Author);
            Assert.Equal(expectedResult.VideoScenarios[0].FriendlyName, actualObject.VideoScenarios[0].FriendlyName);
            Assert.Equal(expectedResult.VideoScenarios[0].Imported, actualObject.VideoScenarios[0].Imported);
            Assert.Equal(expectedResult.VideoScenarios[0].VideoSegment[0].PlayOrder, actualObject.VideoScenarios[0].VideoSegment[0].PlayOrder);
            Assert.Equal(expectedResult.VideoScenarios[0].VideoSegment[0].VideoPath, actualObject.VideoScenarios[0].VideoSegment[0].VideoPath);
            Assert.Equal(expectedResult.VideoScenarios[0].VideoSegment[0].Responses[0].Answer, actualObject.VideoScenarios[0].VideoSegment[0].Responses[0].Answer);
            Assert.Equal(expectedResult.VideoScenarios[0].VideoSegment[0].Responses[0].ResponseType, actualObject.VideoScenarios[0].VideoSegment[0].Responses[0].ResponseType);
            Assert.Equal(expectedResult.VoiceRecognitionScenarios[0].Answer, actualObject.VoiceRecognitionScenarios[0].Answer);
            Assert.Equal(expectedResult.VoiceRecognitionScenarios[0].AudioPath, actualObject.VoiceRecognitionScenarios[0].AudioPath);
            Assert.Equal(expectedResult.VoiceRecognitionScenarios[0].Author, actualObject.VoiceRecognitionScenarios[0].Author);
            Assert.Equal(expectedResult.VoiceRecognitionScenarios[0].CopyrightDisclaimer, actualObject.VoiceRecognitionScenarios[0].CopyrightDisclaimer);
            Assert.Equal(expectedResult.VoiceRecognitionScenarios[0].Id, actualObject.VoiceRecognitionScenarios[0].Id);


        }

        private ImportedScenarios ImportedScenariosHelper()
        {
            return new ImportedScenarios
            {
                Creation = new DateTime(2014, 4, 20),
                LastModified = new DateTime(2014, 5, 20),
                FaceRecognitionScenarios = new List<FaceRecognitionScenario>
                                                          {
                                                              new FaceRecognitionScenario
                                                                  {
                                                                      Answers = new List<string>{"Angry", "Disgusted"},
                                                                      Author = "Lord Voldermort",
                                                                      CopyrightDisclaimer = "2014 Voldermort Creations",
                                                                      Id =
                                                                          Guid.Parse(
                                                                              "4bfad142-c027-495d-8f37-582471b03c70"),
                                                                      Image = null
                                                                  }
                                                          },
                VideoScenarios = new List<VideoScenario>
                                                {
                                                    new VideoScenario
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
                VoiceRecognitionScenarios = new List<VoiceRecognitionScenario>
                                                           {
                                                               new VoiceRecognitionScenario
                                                                   {
                                                                       Answer = "Happy",
                                                                       Author = "Dave The Clown",
                                                                       AudioPath = @"C:\Audio\VRS\",
                                                                       CopyrightDisclaimer = "2009 Micheal Jackson",
                                                                       Id =
                                                                           Guid.Parse(
                                                                               "20cc7f02-970e-4684-a143-112d75c39238")
                                                                   },
                                                           }
            };
        }
    }
}