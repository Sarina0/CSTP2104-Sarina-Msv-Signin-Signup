using System;
using System.Collections.Generic;
using System.Text;

namespace StudentCoopCommon.Interfaces
{
    public interface ILogger
    {
        void Log(string message);
        void Log(int num, string message);
    }
}
