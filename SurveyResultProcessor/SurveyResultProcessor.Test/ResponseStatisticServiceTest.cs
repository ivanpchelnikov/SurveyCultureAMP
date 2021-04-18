using NUnit.Framework;

namespace SurveyResultProcessor.Test
{
    [TestFixture]
    public class ResponseStatisticServiceTest
    {
        [Test]
        public void InputFileSurvey1Test()
        {
            var args = new string[] { @"..//..//..//TestData//survey-1.csv", @"..//..//..//TestData//survey-1-responses.csv" };
            var input = new InputDataService();
            (var survey, var surveyResponses) = input.GetCommandsFromFile(args);
            var action = new ResponseStatisticService();
            var stat = action.GetAverageForRatingQuestions(survey, surveyResponses);
            Assert.True(stat.Count == 5);
        }

        [Test]
        public void InputFileSurvey3Test()
        {
            var args = new string[] { @"..//..//..//TestData//survey-3.csv", @"..//..//..//TestData//survey-3-responses.csv" };
            var input = new InputDataService();
            (var survey, var surveyResponses) = input.GetCommandsFromFile(args);
            var action = new ResponseStatisticService();
            var stat = action.GetAverageForRatingQuestions(survey, surveyResponses);
            Assert.True(stat.Count == 0);
        }

        [Test]
        public void InputFileSurvey2Test()
        {
            var args = new string[] { @"..//..//..//TestData//survey-2.csv", @"..//..//..//TestData//survey-2-responses.csv" };
            var input = new InputDataService();
            (var survey, var surveyResponses) = input.GetCommandsFromFile(args);
            var action = new ResponseStatisticService();
            var stat = action.GetAverageForRatingQuestions(survey, surveyResponses);
            Assert.True(stat.Count == 4);
        }
    }
}