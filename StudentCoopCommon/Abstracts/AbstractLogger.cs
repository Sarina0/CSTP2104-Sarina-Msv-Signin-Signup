using StudentCoopCommon.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentCoopCommon.Abstracts
{
    public abstract class AbstractLogger : ILogger
    {
        public virtual void Log(string message)
        {
            Console.WriteLine("{0}", message);
        }

        public virtual void Log(int num, string message)
        {
            Console.WriteLine("{0} - {1}", num, message);
        }
    }
}
