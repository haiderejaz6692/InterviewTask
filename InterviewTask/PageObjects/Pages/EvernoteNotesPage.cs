using InterviewTask.Support;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewTask.PageObjects.Pages
{
    internal class EvernoteNotesPage
    {
        private WebDriver driver;

        public EvernoteNotesPage(WebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        [FindsBy(How = How.Id, Using = "qa-COMMON_EDITOR_IFRAME")]
        private IWebElement iFrmNotesEditor;

        [FindsBy(How = How.XPath, Using = "//en-noteheader//textarea[@placeholder='Title']")]
        private IWebElement txtNotesTitle;

        [FindsBy(How = How.XPath, Using = "//en-noteheader//textarea[@placeholder='Title']//following-sibling::div")]
        private IWebElement lblNotesTitle;

        [FindsBy(How = How.Id, Using = "en-note")]
        private IWebElement txtNotesDesc;

        [FindsBy(How = How.Id, Using = "qa-NOTE_ACTIONS")]
        private IWebElement btnNotesMoreOption;

        [FindsBy(How = How.Id, Using = "qa-ACTION_DELETE")]
        private IWebElement btnNotesDeleteOption;


        public void SwitchIframeNotesEditor()
        {
            Utilities.ExplicitWait(driver, iFrmNotesEditor);
            driver.SwitchTo().Frame(iFrmNotesEditor);
        }

        public void SwitchToDefaultContent()
        {
            driver.SwitchTo().DefaultContent();
        }

        public void EnterNotesTitle(string title)
        {
            Utilities.ExplicitWait(driver,txtNotesTitle);
            txtNotesTitle.SendKeys(title);
        }

        public void VerifyNotesTitle(string expectedTitle)
        {
            Utilities.ExplicitWait(driver, lblNotesTitle);
            Assert.AreEqual(lblNotesTitle.GetAttribute("innerHTML"), expectedTitle);
        }

        public void EnterNotesDesc(string desc)
        {
            txtNotesDesc.SendKeys(desc);
        }

        public void VerifyNotesDesc(string expectedDesc)
        {
            Utilities.ExplicitWait(driver, txtNotesDesc);
            Assert.AreEqual(txtNotesDesc.GetAttribute("innerText"), expectedDesc);
        }

        public void ClickMoreAction()
        {
            btnNotesMoreOption.Click();
        }

        public void ClickMoveToTrash()
        {
            btnNotesDeleteOption.Click();
            Utilities.StaticWait(5000);
        }

        public void ClickOnNoteSpan(string title)
        {
            try
            {
                string xpath = "//span[text()='" + title + "']";
                Utilities.ExplicitWait(driver, By.XPath(xpath));
                driver.FindElement(By.XPath(xpath)).Click();
                Utilities.StaticWait(5000);
            }
            catch (Exception)
            {
                Console.WriteLine("Error on Note Selecting");
            }
        }
    }
}
