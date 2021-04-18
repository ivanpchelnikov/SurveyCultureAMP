using System;

namespace SurveyResultProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                (var survey, var surveyResponses) = new InputDataService().GetCommandsFromFile(args);
                (var participants, var percentage) = new ParticipationService().GetParticipationDetails(surveyResponses);
                var statistic = new ResponseStatisticService().GetAverageForRatingQuestions(survey, surveyResponses);

                Console.WriteLine("\nSurvey reult:\n");
                Console.WriteLine($"Participation percentage {participants} and total participant counts of the survey: {percentage.ToString("P02")} \n");
                Console.WriteLine($"The average for each rating question:\n");
                foreach (var question in statistic)
                {
                    Console.WriteLine($"Question: {question.Key} Average: {question.Value}");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
