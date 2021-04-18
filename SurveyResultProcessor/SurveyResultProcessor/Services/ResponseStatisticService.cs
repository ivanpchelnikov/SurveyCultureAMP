using System;
using System.Collections.Generic;
using SurveyResultProcessor.Models;

namespace SurveyResultProcessor
{
    public class ResponseStatisticService : IResponseStatisticService
    {
        public Dictionary<string, int> GetAverageForRatingQuestions(List<string[]> survey, List<SurveyResponse> surveyResponse)
        {
            var stat = new Dictionary<string, int>(survey.Count);
            (var indexOfTypeColumn, var indexOfQuestionColumn) = GetIndexOfTextAndTypeColumns(survey[0]);
            for (int questionNumber = 1; questionNumber < survey.Count; questionNumber++)
            {
                if (Enum.TryParse(survey[questionNumber][indexOfTypeColumn], true, out QuestionType type) && type == QuestionType.ratingquestion)
                {
                    var average = GetAverageFromResponsePerQuestion(questionNumber - 1, surveyResponse);
                    if (average != 0) stat.Add(survey[questionNumber][indexOfQuestionColumn], average);
                }
            }
            return stat;
        }

        private int GetAverageFromResponsePerQuestion(int questionOrder, List<SurveyResponse> surveyResponse)
        {
            var aver = 0;
            var total = 0;
            foreach (var resp in surveyResponse)
            {
                if (!string.IsNullOrEmpty(resp.Submitted) && int.TryParse(resp.Questions[questionOrder], out int result))
                {
                    aver += result;
                    total++;
                }
            }
            return total == 0 ? 0 : aver / total;
        }

        private (int, int) GetIndexOfTextAndTypeColumns(string[] survey)
        {
            var typeIndex = -1;
            var textIndex = -1;
            for (int i = 0; i < survey.Length; i++)
            {
                if (Enum.TryParse(survey[i], true, out Survey text) && text == Survey.Text) textIndex = i;
                if (Enum.TryParse(survey[i], true, out Survey type) && text == Survey.Type) typeIndex = i;
            }
            if (textIndex == -1 || typeIndex == -1) throw new Exception("Question column header is not defined.");
            return (typeIndex, textIndex);
        }
    }
}
