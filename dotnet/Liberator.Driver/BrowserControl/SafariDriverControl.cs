// SafariDriverControl.cs
//
// Author:
//       kevmccarthy <developments@totallyratted.com>
//
// Copyright (c) 2020 Liberator Test Tools
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using System.IO;
using Liberator.Driver.Enums;
using Liberator.Driver.Preferences;
using OpenQA.Selenium;
using OpenQA.Selenium.Safari;

namespace Liberator.Driver.BrowserControl
{
    internal class SafariDriverControl : IBrowserControl
    {

        public IWebDriver Driver { get; set; }

        public SafariOptions SafariOptions { get; set; }

        public SafariDriverService SafariDriverService { get; set; }

        public SafariDriverControl(BasePreferences preferences)
        {
            SetImportedPreferences((SafariSettings)preferences);
        }

        public SafariDriverControl()
        {
        }

        public IWebDriver StartDriver()
        {
            try
            {
                SetSafariOptions();
                SetSafariService();
                //SetProxy();

                if (SafariDriverService != null && SafariOptions != null)
                {
                    Driver = new SafariDriver(SafariDriverService, SafariOptions);
                }
                else if (SafariOptions == null && SafariDriverService != null)
                {
                    Driver = new SafariDriver(SafariDriverService);
                }
                else if (SafariOptions != null)
                {
                    Driver = new SafariDriver(SafariOptions);
                }

                Console.Out.WriteLine("Started safari driver.");
                return Driver;
            }
            catch (Exception)
            {
                Console.Out.WriteLine("Could not start safari driver.");
                return null;
            }
        }

        public IWebDriver StartDriver(BasePreferences preferences)
        {
            try
            {
                SetImportedPreferences((SafariSettings)preferences);
                StartDriver();
                return Driver;
            }
            catch (Exception exception)
            {
                Console.Out.WriteLine(exception.Message);
                return null;
            }
        }

        private void SetImportedPreferences(SafariSettings safariPreferences)
        {
            try
            {
                if (safariPreferences != null)
                {
                    Safari.Timeout = safariPreferences.Timeout;
                    Safari.AsyncJavaScript = safariPreferences.AsyncJavaScript;
                    Safari.DebugLevel = safariPreferences.DebugLevel;
                    Safari.ImplicitWait = safariPreferences.ImplicitWait;
                    Safari.PageLoad = safariPreferences.PageLoad;
                    Safari.AlertHandling = safariPreferences.AlertHandling;
                    Safari.InternalTimers = safariPreferences.InternalTimers;
                    Safari.MenuHoverTime = safariPreferences.MenuHoverTime;
                    Safari.Sleep = safariPreferences.Sleep;

                    Safari.Port = safariPreferences.Port;
                    Safari.TechnologyPreview = safariPreferences.TechnologyPreview;
                    Safari.AutomaticInspection = safariPreferences.AutomaticInspection;
                    Safari.AutomaticProfiling = safariPreferences.AutomaticProfiling;
                }
            }
            catch (Exception)
            {

            }
        }

        private void SetSafariOptions()
        {
            try
            {
                SafariOptions = new SafariOptions();
                SetAutomaticInspection();
                SetAutomaticProfiling();
            }
            catch (Exception ex)
            {
                switch (BaseSettings.DebugLevel)
                {
                    case EnumConsoleDebugLevel.Human:
                        Console.Out.WriteLine("Could not set the safari diver options.");
                        Console.Out.WriteLine("Please investigate the changes you have made to your config file.");
                        break;
                    case EnumConsoleDebugLevel.NotSpecified:
                    case EnumConsoleDebugLevel.Message:
                        Console.Out.WriteLine(ex.Message);
                        break;
                    case EnumConsoleDebugLevel.StackTrace:
                        Console.Out.WriteLine(ex.Message);
                        Console.Out.WriteLine(ex.StackTrace);
                        break;
                }
            }
        }

        private void SetSafariService()
        {
            try
            {
                SafariDriverService service = SafariDriverService.CreateDefaultService(Directory.GetParent(BaseSettings.SafariDriverLocation).FullName);
                if (BaseSettings.SafariDriverLocation != null || Safari.Port > 0)
                {
                    SetDriverPort(service);
                    SafariDriverService = service;
                    Console.Out.WriteLine("Built Safari Driver Service");
                }
            }
            catch (Exception ex)
            {
                switch (BaseSettings.DebugLevel)
                {
                    case EnumConsoleDebugLevel.Human:
                        Console.Out.WriteLine("Could not start the safari driver service.");
                        Console.Out.WriteLine("Please investigate the changes you have made to your config file.");
                        break;
                    case EnumConsoleDebugLevel.NotSpecified:
                    case EnumConsoleDebugLevel.Message:
                        Console.Out.WriteLine(ex.Message);
                        break;
                    case EnumConsoleDebugLevel.StackTrace:
                        Console.Out.WriteLine(ex.Message);
                        Console.Out.WriteLine(ex.StackTrace);
                        break;
                }
            }
        }

        private void SetDriverPort(SafariDriverService service)
        {
            try
            {
                if (Safari.Port != null && Safari.Port > 0)
                {
                    service.Port = Safari.Port.Value;
                    Console.Out.WriteLine("\nAdded port {0} to the driver.", Safari.Port.ToString());
                }
                Console.Out.WriteLine();
            }
            catch (Exception)
            {
                Console.Out.WriteLine("\nCould not assign port to driver.");
            }
        }

        private void SetAutomaticInspection()
        {
            try
            {
                if (Safari.AutomaticInspection.HasValue)
                {
                    SafariOptions.EnableAutomaticInspection = Safari.AutomaticInspection.Value;
                    Console.Out.WriteLine("\nSet automatic inspection to: {0}", Safari.AutomaticInspection.ToString());
                }
            }
            catch (Exception)
            {
                Console.Out.WriteLine("\nCould not set automatic inspection to: {0}", Safari.AutomaticInspection.ToString());
            }
        }

        private void SetAutomaticProfiling()
        {
            try
            {
                if (Safari.AutomaticProfiling.HasValue)
                {
                    SafariOptions.EnableAutomaticProfiling = Safari.AutomaticProfiling.Value;
                    Console.Out.WriteLine("\nSet automatic profiling to: {0}", Safari.AutomaticProfiling.ToString());
                }
            }
            catch (Exception)
            {
                Console.Out.WriteLine("\nCould not set automatic profiling to: {0}", Safari.AutomaticProfiling.ToString());
            }
        }
    }
}
