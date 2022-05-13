using System;
using CSTP2104.Assignment1;


namespace CSTP2104
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initialing the Report
            ProgressReporter del1 = UtilReporter.InitialReport;
            UtilReporter.ReportProgress(del1);

            //Writing to console
            ProgressReporter del2 = UtilReporter.WriteProgressToConsole;
            UtilReporter.ReportProgress(del2);

            //Writing to the file
            ProgressReporter del3 = UtilReporter.WriteProgressToFileAsync;
            UtilReporter.ReportProgress(del3);
        }
    }
}
