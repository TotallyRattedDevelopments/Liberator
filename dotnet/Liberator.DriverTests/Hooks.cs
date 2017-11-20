using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Diagnostics;

namespace Liberator.DriverTests
{
    public class Hooks
    {
        [TearDown]
        public void TearDown()
        {
            Process[] processList = Process.GetProcesses();
            foreach (Process item in processList)
            {
                if (item.ProcessName.Contains("geckodriver") ||
                    item.ProcessName.Contains("chromedriver") ||
                    item.ProcessName.Contains("MicrosoftWebDriver") ||
                    item.ProcessName.Contains("opera") ||
                    item.ProcessName.Contains("phantomjs") ||
                    item.ProcessName.Contains("IEDriverServer") ||
                    item.ProcessName.Contains("iexplore.exe"))
                {
                    item.Kill();
                }
            }
        }
    }
}
