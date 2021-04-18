using System.Collections.Generic;

namespace SurveyResultProcessor.Models
{
    public class SurveyResponse
    {
        public string Email { get; set; }
        public string EmployeeId { get; set; }
        public string Submitted { get; set; }
        public List<string> Questions { get; set; }
    }
}
