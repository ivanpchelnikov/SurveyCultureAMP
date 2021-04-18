using System.Collections.Generic;
using SurveyResultProcessor.Models;

namespace SurveyResultProcessor
{
    interface IInputDataService
    {
        (List<string[]>, List<SurveyResponse>) GetCommandsFromFile(string[] args);
    }
}
