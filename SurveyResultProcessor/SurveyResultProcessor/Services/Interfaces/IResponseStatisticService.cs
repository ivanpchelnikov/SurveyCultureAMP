using System.Collections.Generic;
using SurveyResultProcessor.Models;

namespace SurveyResultProcessor
{
    interface IResponseStatisticService
    {
       Dictionary<string, int> GetAverageForRatingQuestions(List<string[]> survey, List<SurveyResponse> surveyResponse);
    }
}
