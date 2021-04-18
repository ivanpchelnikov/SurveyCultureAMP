using System.Collections.Generic;
using SurveyResultProcessor.Models;

namespace SurveyResultProcessor
{
    interface IParticipationService
    {
        (int, double) GetParticipationDetails(List<SurveyResponse> surveyResponse);
    }
}
