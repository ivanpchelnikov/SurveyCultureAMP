# Survey Statistic app description.

Setting environment:

Language, Enviroments: C#, .Net 5.0
Requirements: dotnet SDK

For Windows: 
Install:
	-	https://docs.microsoft.com/en-us/dotnet/core/install/windows?tabs=net50
Building: 
	- cd SurveyResultProcessor
	- dotnet test
	- dotnet build -o ./Output
Or:
	- via Visual Studio

Run:
	- dotnet ./Output/SurveyResultProcessor.dll ./SurveyResultProcessor.Test/TestData/survey-1.csv ./SurveyResultProcessor.Test/TestData/survey-1-responses.csv
			Output: There is no input parameter. Please provide a files path as input paramater: <surveyPath> <surveyResponsesPath>.
			
	- dotnet ./Output/SurveyResultProcessor.dll <PathToSurveyInputFile> <PathToSurveyResponseInputFile>

For Mac: 
Install:
	-	https://docs.microsoft.com/en-us/dotnet/core/install/macos
	- 	brew install --cask dotnet-sdk 
Building: 
	- cd SurveyResultProcessor
	- dotnet test
	- dotnet build -o /Output

Run:
	- dotnet ./Output/SurveyResultProcessor.dll ./SurveyResultProcessor.Test/TestData/survey-1.csv ./SurveyResultProcessor.Test/TestData/survey-1-responses.csv
			Output: There is no input parameter. Please provide a files path as input paramater: <surveyPath> <surveyResponsesPath>.
			
	- dotnet ./Output/SurveyResultProcessor.dll <PathToSurveyInputFile> <PathToSurveyResponseInputFile>
	
Design:

The application splitted on 3 parts:
	
	- Model. Decribe domain of application.
	- Services: 
			-	InputDataService. Read inputs from files.
			- ParticipationService. The participation percentage and total participant counts of the survey.
			- ResponseStatisticService. The average for each rating question
	- View. Ouyput in console.
	   
The implementation is easy to extend functionalities and add new rules, commands. 