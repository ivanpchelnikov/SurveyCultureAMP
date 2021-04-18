using System;
using NUnit.Framework;

namespace SurveyResultProcessor.Test
{
    [TestFixture]
    public class InputDataServiceTest
    {
        [Test]
        public void InputFileSurvey1Test()
        {
            var args = new string[] { @"..//..//..//TestData//survey-1.csv", @"..//..//..//TestData//survey-1-responses.csv" };
            var action = new InputDataService();
            (var survey, var surveyResponses) = action.GetCommandsFromFile(args);
            Assert.True(survey.Count - 1 == surveyResponses[0].Questions.Count);
        }

        [Test]
        public void InputFileSurvey2Test()
        {
            var args = new string[] { @"..//..//..//TestData//survey-2.csv", @"..//..//..//TestData//survey-2-responses.csv" };
            var action = new InputDataService();
            (var survey, var surveyResponses) = action.GetCommandsFromFile(args);
            Assert.True(survey.Count - 1 == surveyResponses[0].Questions.Count);
        }

        [Test]
        public void InputFileSurvey3Test()
        {
            var args = new string[] { @"..//..//..//TestData//survey-3.csv", @"..//..//..//TestData//survey-3-responses.csv" };
            var action = new InputDataService();
            (var survey, var surveyResponses) = action.GetCommandsFromFile(args);
            Assert.True(survey.Count - 1 == surveyResponses[0].Questions.Count);
        }

        [Test]
        public void InputFileSurveyNoArgTest()
        {
            var args = new string[] { };
            var action = new InputDataService();
            var ex = Assert.Throws<Exception>(() => action.GetCommandsFromFile(args));
            Assert.That(ex.Message, Is.EqualTo("One of the input parameters are missing. Please provide a file path as a paramater."));
        }

        [Test]
        public void InputFileSurveyOneMissingTest()
        {
            var args = new string[] { @"..//..//..//TestData//survey-3-responses.csv", @"..//..//..//TestData//survey-3-responses!!!!!.csv" };
            var action = new InputDataService();
            var ex = Assert.Throws<Exception>(() => action.GetCommandsFromFile(args));
            Assert.That(ex.Message, Does.Contain($"File path {args[1]} doesn't exist."));
        }

        [Test]
        public void InputFileSurveyOneMissingOrdserTest()
        {
            var args = new string[] { @"..//..//..//TestData//survey-3-responses.csv", @"..//..//..//TestData//survey-3-responses.csv" };
            var action = new InputDataService();
            var ex = Assert.Throws<Exception>(() => action.GetCommandsFromFile(args));
            Assert.That(ex.Message, Does.Contain($"Wrong formatting input. Please check input files."));
        }
    }
}