using InterviewTask.PageObjects.Pages;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace InterviewTask.StepDefinitions
{
    [Binding]
    public class EvernoteOnlineNotesStepDefinitions
    {

        private readonly ScenarioContext _scenarioContext;
        WebDriver driver;
        public EvernoteOnlineNotesStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            driver = _scenarioContext.Get<WebDriver>("WebDriver");
            loginPage = new EvernoteLoginPage(driver);
            homePage = new EvernoteHomePage(driver);
            notesPage = new EvernoteNotesPage(driver);
        }

        EvernoteLoginPage loginPage;
        EvernoteHomePage homePage;
        EvernoteNotesPage notesPage;

        [Given(@"User Lands On Login Page")]
        public void GivenUserLandsOnLoginPage()
        {
            driver.Navigate().GoToUrl("https://www.evernote.com/Login.action");
        }

        [When(@"User Enters Email ""([^""]*)""")]
        public void WhenUserEntersEmail(string email)
        {
            loginPage.EnterUsername(email);
        }

        [Then(@"User Clicks on Continue/Login Button")]
        public void ThenUserClicksOnContinueButton()
        {
            loginPage.ClickLoginBtn();   
        }

        [Then(@"Verify user ""([^""]*)""")]
        public void ThenVerifyUser(string exists)
        {
            loginPage.VerifyResponseMessage(exists);
        }

        [Then(@"User Enters Password ""([^""]*)"" and Login if user ""([^""]*)""")]
        public void ThenUserEntersPasswordAndLoginIfUser(string password, string exists)
        {
            if (exists.ToUpper() == "EXISTS")
            {
                loginPage.EnterPassword(password);
                loginPage.ClickLoginBtn();
                homePage.verifyNavUserDisplayed();
            }
        }

        [Then(@"User Enters Password ""([^""]*)""")]
        public void ThenUserEntersPassword(string password)
        {
            loginPage.EnterPassword(password);
        }

        [Then(@"User navigate to Notes")]
        public void ThenUserNavigateToNotes()
        {
            homePage.NavigateToNotes();
        }

        [Then(@"User clicks add notes button")]
        public void ThenUserClicksAddNotesButton()
        {
            homePage.ClickAddNotesButtton();
        }

        [Then(@"Add Notes Title ""([^""]*)""")]
        public void ThenAddNotesTitle(string title)
        {
            notesPage.SwitchIframeNotesEditor();
            notesPage.EnterNotesTitle(title);
        }

        [Then(@"Add Notes Description ""([^""]*)""")]
        public void ThenAddNotesDescription(string desc)
        {
            notesPage.EnterNotesDesc(desc);
            notesPage.SwitchToDefaultContent();
        }

        [Then(@"User Logout the session")]
        public void ThenUserLogoutTheSession()
        {
            homePage.SessionLogout();
        }

        [Then(@"User Navigate to Login Page")]
        public void ThenUserNavigateToLoginPage()
        {
            loginPage.ClickLoginLink();
        }

        [Then(@"Verify Created Note with Title ""([^""]*)"" and Description ""([^""]*)""")]
        public void ThenVerifyCreatedNoteWithTitleAndDescription(string title, string desc)
        {
            notesPage.ClickOnNoteSpan(title);
            notesPage.SwitchIframeNotesEditor();
            notesPage.VerifyNotesTitle(title);
            notesPage.VerifyNotesDesc(desc);
            notesPage.SwitchToDefaultContent();
        }

        [Then(@"Move it to trash")]
        public void ThenMoveItToTrash()
        {
            notesPage.ClickMoreAction();
            notesPage.ClickMoveToTrash();
        }


    }
}
