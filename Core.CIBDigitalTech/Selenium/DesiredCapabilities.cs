using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CIBDigitalTech.Selenium
{
    internal class DesiredCapabilities
    {
        public static ChromeOptions ChromeDesiredCapabilities()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("no-sandbox");

            return options;
        }

        public static FirefoxOptions FirefoxDesiredCapabilities()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.AddArgument("no-sandbox");
            return options;
        }
    }
}
