# Interview Task
### About
**Overview:** _C# UI and API with Specflow framework._

**Covered Features:**
- Evernote Online Notes Functionality
- To Verify Users API

**Technology stack:**
- Basic: C#, .NET Core 3.1, NUnit
- BDD: SpecFlow
- UI: Selenium WebDriver
- API: RestSharp
- Reporting: Living Documentation

### Installation & Configuration
1. Install [.NET Core 3.1](https://dotnet.microsoft.com/en-us/download/dotnet/3.1).
2. Clone this repo.
3. Open CMD Run `dotnet build` in the root folder.

### Test Execution
1. To Run Full end to end type in cmd `dotnet test` in the root folder.
2. To Run Specific Task type in cmd `dotnet test --filter TestCategory=SpecificTags`
   There are two tags in whole projects
   a. `@Task1` to run First Task
   b. `@Task2` to run Second Task

### Generate Report
1. After Test to create LivingDoc and Detail Analysis open CMD in `project_path\project\bin\Debug\netcoreapp3.1`
2. And type `livingdoc test-assembly InterviewTask.dll -t TestExecution.json` to create LivingDoc
3. Find in `project_path\project\bin\Debug\netcoreapp3.1\LivingDoc.html`
