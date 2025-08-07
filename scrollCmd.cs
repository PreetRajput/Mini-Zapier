using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsInput;

namespace miniZapier
{
    internal class scrollCmd:node 
    {
        String dir;
        int pixels;
        IWebDriver driver;

        public scrollCmd(string dir, int pixels)
        {
            this.dir = dir;
            this.pixels = pixels;
            this.driver = openCmd.driver;
        }
        public override void execute()
        {

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript($"window.scrollBy(0, -{pixels});");
            if (dir.Equals("down"))
            {

            }
            else if (dir.Equals("up"))
            {
                js.ExecuteScript($"window.scrollBy(0, {pixels});");

            }
            else if (dir.Equals("right"))
            {
                js.ExecuteScript($"window.scrollBy({pixels}, 0);");

            }
            else if (dir.Equals("left"))
            {
                js.ExecuteScript($"window.scrollBy(-{pixels},0);");

            }
        }
    }
}
