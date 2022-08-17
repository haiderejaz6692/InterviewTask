using InterviewTask.Support;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace InterviewTask.PageObjects.Pages
{
    internal class EvernoteHomePage
    {
        private WebDriver driver;

        public EvernoteHomePage(WebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
       
        [FindsBy(How = How.Id, Using = "qa-NAV_HOME")]
        private IWebElement mnuHome;

        [FindsBy(How = How.Id, Using = "qa-NAV_ALL_NOTES")]
        private IWebElement mnuNotes;

        [FindsBy(How = How.Id, Using = "qa-NAVBAR_NOTE_ADD_BUTTON")]
        private IWebElement btnAddNotes;

        [FindsBy(How = How.Id, Using = "qa-NAV_USER")]
        private IWebElement navUser;

        [FindsBy(How = How.Id, Using = "qa-ACCOUNT_DROPDOWN_LOGOUT")]
        private IWebElement btnLogout;

        [FindsBy(How = How.Id, Using = "qa-LOGOUT_CONFIRM_DIALOG_CANCEL")]
        private IWebElement btnReturnToApp;

        public void NavigateToNotes()
        {
            Utilities.ExplicitWait(driver, mnuNotes);
            mnuNotes.Click();
        }

        public void NavigateToHome()
        {
            mnuHome.Click();
        }

        public void ClickAddNotesButtton()
        {
            btnAddNotes.Click();
        }

        public void verifyNavUserDisplayed()
        {
            try
            {
               Utilities.ExplicitWait(driver, btnAddNotes);
                Thread.Sleep(2000);
                string isElementDisplayed = btnAddNotes.GetCssValue("display");
                Console.WriteLine(isElementDisplayed);
            }
            catch (Exception)
            {
                Console.WriteLine("Found Exception");
            }
        }

        public void ClickNavUser()
        {
            navUser.Click();
        }

        public void ClickLogoutButton()
        {
            btnLogout.Click();
        }


        public void SessionLogout()
        {
            Utilities.ExplicitWait(driver, navUser);
            navUser.Click();
            Utilities.ExplicitWait(driver, btnLogout);
            btnLogout.Click();
            try
            {
                Utilities.StaticWait(5000);
                Utilities.ExplicitWait(driver, btnReturnToApp);
                btnReturnToApp.Click();
                SessionLogout();
            }
            catch
            {
                Console.WriteLine("Successfully Saved");
            }

        }
    }
}
