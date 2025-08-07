using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace miniZapier
{
    internal class openCmd: node 
    {
        public string url { get; set; }
        public static IWebDriver driver;
        public openCmd(string url)
        {
            this.url = url;
        }
        public override void execute()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
        }
    }
}
