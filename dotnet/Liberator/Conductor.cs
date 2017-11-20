using Liberator.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Liberator
{
    public class Conductor
    {
        public delegate void RodentDelegate();

        public Conductor()
        {

        }


        public void SendInstruction(RodentDelegate rodent)
        {
            Thread thread = new Thread(new ThreadStart(rodent))
            {
                IsBackground = false,
                Name = rodent.Method.Name,
                Priority = ThreadPriority.AboveNormal
            };
            thread.Start();
        }
    }
}
