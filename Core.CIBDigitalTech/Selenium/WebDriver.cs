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
        protected static RemoteWebDriver remoteWebDriver;

        protected static void WaitForElementToBeEnabled(IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(remoteWebDriver, TimeSpan.FromSeconds(120));

            Func<IWebDriver, bool> CheckEnabled = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                return element.Enabled;
            });

            wait.Until(CheckEnabled);
        }

        protected static void WaitForElementToBeDisplay(IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(remoteWebDriver, TimeSpan.FromSeconds(120));

            Func<IWebDriver, bool> CheckDisplayed = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                return element.Displayed;
            });

            wait.Until(CheckDisplayed);
        }

        public static void OpenBrowser(string browser)
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

        public static void NavigateToUrl(string url)
        {
            try
            {
                remoteWebDriver.Navigate().GoToUrl(url);
            }
            catch (Exception e)
            {
                string erroMessage = e.Message;
            }
        }

        public static void CloseBrowser()
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

        protected static void Click(IWebElement element)
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


        protected static void EnterText(IWebElement element, string value)
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

        protected static void SelectDropdownByIndex(IWebElement element, int index)
        {
            try
            {
                SelectElement select = new SelectElement(element);
                select.SelectByIndex(index);
            }
            catch (Exception e)
            {
                string erroMessage = e.Message;
            }
        }

        protected static void SelectDropdownByValue(IWebElement element, string value)
        {
            try
            {
                SelectElement select = new SelectElement(element);
                select.SelectByValue(value);
            }
            catch (Exception e)
            {
                string erroMessage = e.Message;
            }
        }

        protected static void SelectDropdownByText(IWebElement element, string text)
        {
            try
            {
                SelectElement select = new SelectElement(element);
                select.SelectByText(text);
            }
            catch (Exception e)
            {
                string erroMessage = e.Message;
            }
        }


        protected void ClickBrowserBackButton()
        {

        }

        protected void ClickBrowserForwarButton()
        {

        }

        protected void GoToNextTab()
        {

        }

        protected void GoToPreviousTab()
        {

        }
    }
}
