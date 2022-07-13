using StudentCoopCommon.Abstracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace StudentCoopCommon.Logging
{
    public class FileLogger : AbstractLogger
    {
        private const string LogFilename = "StudentCoopLogs";

        public override void Log(string message)
        {
            using (StreamWriter stream = new StreamWriter(LogFilename, append:true))
            {
                stream.WriteLine(message);
            }
        }

        public override void Log(int num, string message)
        {
            using (StreamWriter stream = new StreamWriter(LogFilename, append: true))
            {
                stream.WriteLine($"{num} - {message}");
            }
        }
    }
}
