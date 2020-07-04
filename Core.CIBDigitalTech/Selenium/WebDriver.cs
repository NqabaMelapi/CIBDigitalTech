using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using Core.CIBDigitalTech.Selenium;

namespace Core.CIBDigitalTech.Selenium
{
    public class WebDriver
    {
        public RemoteWebDriver remoteWebDriver;

        public void WaitForElementToBeEnabled(IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(remoteWebDriver, TimeSpan.FromSeconds(120));

            Func<IWebDriver, bool> CheckEnabled = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                return element.Enabled;
            });

            wait.Until(CheckEnabled);
        }

        public void OpenBrowser(string browser)
        {

            switch (browser)
            {
                case "Chrome":
                    remoteWebDriver = new RemoteWebDriver(new Uri("http://52.136.122.242:4444/wd/hub"), DesiredCapabilities.ChromeDesiredCapabilities().ToCapabilities(), TimeSpan.FromSeconds(300));
                    break;

                case "Firefox":
                    remoteWebDriver = new RemoteWebDriver(new Uri("http://52.136.122.242:4444/wd/hub"), DesiredCapabilities.FirefoxDesiredCapabilities());
                    break;
            }

            if (!remoteWebDriver.Equals(null))
            {
                remoteWebDriver.Manage().Window.Maximize();
                remoteWebDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(120);
                remoteWebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
                remoteWebDriver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(120);
            }
        }

        public void CloseBrowser()
        {
            try
            {
                remoteWebDriver.Quit();
            }
            catch (Exception e)
            {
                string erroMessage = e.Message;
            }
        }

        public void Click(IWebElement element)
        {

            try
            {
                WaitForElementToBeEnabled(element);
                element.Click();
            }
            catch (Exception e)
            {
                string erroMessage = e.Message;
            }            
        }


        public void EnterText(IWebElement element, string value)
        {
            try
            {
                WaitForElementToBeEnabled(element);
                element.SendKeys(value);
            }
            catch (Exception e)
            {
                string erroMessage = e.Message;
            }
        }

        public void SelectDropdownByIndex()
        {

        }

        public void SelectDropdownByValue()
        {

        }


        public void ClickBrowserBackButton()
        {

        }

        public void ClickBrowserForwarButton()
        {

        }

        public void GoToNextTab()
        {

        }

        public void GoToPreviousTab()
        {

        }
    }
}
