using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MyLoggerLib
{
    public class ConsoleLogger : ILogger
    {
        private static ConsoleLogger clogger = new ConsoleLogger();
        private ConsoleLogger()
        {
            Debug.WriteLine("Console Logger Object Created");
        }

        public static ConsoleLogger GetLogger()
        {
            return clogger;
        }

        public void Log(string msg)
        {
            Debug.WriteLine("Console logged : " + msg);
        }
    }
}
