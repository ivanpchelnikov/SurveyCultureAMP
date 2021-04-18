using System.Collections.Generic;
using SurveyResultProcessor.Models;

namespace SurveyResultProcessor
{
    public class ParticipationService : IParticipationService
    {
        public (int, double) GetParticipationDetails(List<SurveyResponse> surveyResponse)
        {
            var countParticipants = GetPaticipants(surveyResponse);

            return (countParticipants, countParticipants*1.0/surveyResponse.Count);
        }

        private int GetPaticipants(List<SurveyResponse> surveyResponse)
        {
            var count = 0;
            foreach (var response in surveyResponse)
            {
                if (!string.IsNullOrEmpty(response.Submitted))
                {
                    count++;
                }
            }
            return count;
        }
    }
}