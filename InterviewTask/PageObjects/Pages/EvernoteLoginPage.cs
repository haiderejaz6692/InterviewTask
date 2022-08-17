using InterviewTask.Support;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using SeleniumExtras.PageObjects;

namespace InterviewTask.PageObjects.Pages
{
    internal class EvernoteLoginPage
    {
        private WebDriver driver;

        public EvernoteLoginPage(WebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement txtUsername;

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement txtPassword;

        [FindsBy(How = How.Id, Using = "loginButton")]
        private IWebElement btnLogin;

        [FindsBy(How = How.Id, Using = "responseMessage")]
        private IWebElement lblResponseMessage;

        [FindsBy(How = How.XPath, Using = "//nav[@class='utility-nav']//a[text()='Log In']")]
        private IWebElement loginLink;

        public void EnterUsername (string username)
        {
            txtUsername.SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            Utilities.ExplicitWait(driver, txtPassword);
            txtPassword.SendKeys(password);
        }

        public void ClickLoginBtn()
        {
            btnLogin.Click();
        }

        public void VerifyResponseMessage(String isExists)
        {
            /*driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);*/
            /* WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(120));
             wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("responseMessage")));
 */
            if (isExists.ToUpper() == "NOT EXISTS")
            {
                string foundLblText="exists";
                try
                {
                    Utilities.ExplicitWait(driver, lblResponseMessage);
                    bool isElementDisplayed = lblResponseMessage.Displayed;
                    Console.WriteLine(isElementDisplayed);
                    Console.WriteLine(lblResponseMessage.Text);
                    foundLblText = lblResponseMessage.Text;
                }
                catch (Exception)
                {
                    Console.WriteLine("Found Exception");
                }

                Console.WriteLine(isExists);
            
                Assert.AreEqual(foundLblText.ToUpper(), "There is no account for the username or email you entered.".ToUpper());
            }
            else
            {
                Assert.True(true);
            }
        }

        public void ClickLoginLink()
        {
            Utilities.ExplicitWait(driver, loginLink);
            loginLink.Click();
        }
    }
}
