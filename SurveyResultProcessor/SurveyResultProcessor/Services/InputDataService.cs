using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using SurveyResultProcessor.Models;

namespace SurveyResultProcessor
{
    public class InputDataService : IInputDataService
    {
        public (List<string[]>, List<SurveyResponse>) GetCommandsFromFile(string[] args)
        {
            if (args == null || args.Length < 2) throw new Exception("One of the input parameters are missing. Please provide a file path as a paramater.");

            if (!File.Exists(args[0])) throw new Exception($"File path {args[0]} doesn't exist.");
            if (!File.Exists(args[1])) throw new Exception($"File path {args[1]} doesn't exist.");
            var surveys = new List<string[]>();
            var fileStream = new FileStream(args[0], FileMode.Open);
            using (var reader = new StreamReader(fileStream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    surveys.Add(GetColumnsFromRow(line));
                }
            }
            var surveyResponse = new List<SurveyResponse>();
            fileStream = new FileStream(args[1], FileMode.Open);
            using (var reader = new StreamReader(fileStream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    surveyResponse.Add(SurveyResponseFromFileInput(line));
                }
            }

            return (surveys, surveyResponse);
        }

        private string[] GetColumnsFromRow(string line)
        {
            var rgx = new Regex(",(?=([^\"]*\"[^\"]*\")*[^\"]*$)");
            string[] words = rgx.Split(line).Where(w=> !rgx.Match(w).Success).Distinct().ToArray();
            if (words.Length > 3) throw new Exception("Wrong formatting input. Please check input files.");
            return words;
        }

        private static SurveyResponse SurveyResponseFromFileInput(string line)
        {
            var surveyParts = line.Split(',');

            if (surveyParts.Length == 0) return null;
            var survResp = new SurveyResponse
            {
                Email = surveyParts[0],
                EmployeeId = surveyParts[1],
                Submitted = surveyParts[2],
                Questions = new List<string>(surveyParts.Length - 3)
            };
            for (int i = 3; i < surveyParts.Length; i++)
            {
                survResp.Questions.Add(surveyParts[i]);
            }
            return survResp;
        }
    }
}
