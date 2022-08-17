using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace InterviewTask.Drivers
{
    internal class SeleniumDriver
    {
        private WebDriver driver;
        private readonly ScenarioContext _scenarioContext;
        public SeleniumDriver(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        public WebDriver Setup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            Console.WriteLine("Browser Setuped");
            _scenarioContext.Set(driver, "WebDriver");
            return driver;
        }
    }
}
