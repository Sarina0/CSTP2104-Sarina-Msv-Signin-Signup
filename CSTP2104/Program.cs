using System;
using System.Threading.Tasks;
using CSTP2104.Assignment1;
using CSTP2104.Assignment2;

namespace CSTP2104
{
    class Program
    {
        public static async Task Main(string[] args)
        {    //Assignment1

            /*//Initialing the Report
            ProgressReporter del1 = UtilReporter.InitialReport;
            UtilReporter.ReportProgress(del1);

            //Writing to console
            ProgressReporter del2 = UtilReporter.WriteProgressToConsole;
            UtilReporter.ReportProgress(del2);

            //Writing to the file
            ProgressReporter del3 = UtilReporter.WriteProgressToFileAsync;
            UtilReporter.ReportProgress(del3);*/

            //Assignment2

            CalSum();

        }
        public static void CalSum()
        {
            var ut = new CalculateSum();
            ut.RunTasks();
        }
    }
}
