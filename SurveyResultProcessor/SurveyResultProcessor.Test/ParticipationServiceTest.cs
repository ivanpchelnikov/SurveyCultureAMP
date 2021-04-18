using NUnit.Framework;

namespace SurveyResultProcessor.Test
{
    [TestFixture]
    public class ParticipationServiceTest
    {
        [Test]
        public void InputFileSurvey1Test()
        {
            var args = new string[] { @"..//..//..//TestData//survey-1.csv", @"..//..//..//TestData//survey-1-responses.csv" };
            var input = new InputDataService();
            (var survey, var surveyResponses) = input.GetCommandsFromFile(args);
            var action = new ParticipationService();

            (var participants, var percatageofParticipants) = action.GetParticipationDetails(surveyResponses);
            Assert.True(participants == 5);
            Assert.True(percatageofParticipants == 5 / 6.0);
        }

        [Test]
        public void InputFileSurvey2Test()
        {
            var args = new string[] { @"..//..//..//TestData//survey-2.csv", @"..//..//..//TestData//survey-2-responses.csv" };
            var input = new InputDataService();
            (var survey, var surveyResponses) = input.GetCommandsFromFile(args);
            var action = new ParticipationService();

            (var participants, var percatageofParticipants) = action.GetParticipationDetails(surveyResponses);
            Assert.True(participants == 5);
            Assert.True(percatageofParticipants == 5/5.0);
        }
        [Test]
        public void InputFileSurvey3Test()
        {
            var args = new string[] { @"..//..//..//TestData//survey-3.csv", @"..//..//..//TestData//survey-3-responses.csv" };
            var input = new InputDataService();
            (var survey, var surveyResponses) = input.GetCommandsFromFile(args);
            var action = new ParticipationService();

            (var participants, var percatageofParticipants) = action.GetParticipationDetails(surveyResponses);
            Assert.True(participants == 0);
            Assert.True(percatageofParticipants == 0);
        }
    }
}