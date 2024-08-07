﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using CSTP2104.Shared;

public delegate void ProgressReporter(int rep);
namespace CSTP2104.Assignment1
{
    class UtilReporter : AssignmentBase
    {
        public static void ReportProgress(ProgressReporter del)
        {
            //Console.WriteLine(del);
            
            // === you should set your delegate to desired targets WriteToConsole and WriteToFile before going into the loop ===
            //     remember I want all the code related to the assignment in one file
            //     how is this being called?
            
            Console.WriteLine(" you have added your report please waite for process..");
            del(55);
            Console.WriteLine("this is del " + del);
            for (int i = 0; i <= 10; i++)
            {

                //Console.WriteLine(i);
                Console.WriteLine(i * 10); // === you should be calling your deletgate here instead of writing to the console ===
                                           //     letting the delegate to the work for both targets
                //Console.WriteLine("time");
                Thread.Sleep(100);
            }
        }



        public static void InitialReport(int ini)
        {
            Console.WriteLine("This is the begining of the report <{0}>", ini);
        }


        public static void WriteProgressToConsole(int w_repo)
        {
            Console.WriteLine(" Console :The Progress report is : " + w_repo);

        }

        public static void WriteProgressToFileAsync(int txt)
        {
            string path = @"C:\Users\sarin\source\repos\CSTP2104\CSTP2104\Assignment1\TextReport.txt";
            try
            {
                File.WriteAllText(path, txt.ToString());
                Console.WriteLine("String written to file successfully.");
                try
                {
                    // Open the text file using a stream reader.
                    using (var sr = new StreamReader(path))
                    {
                        // Read the stream as a string, and write the string to the console.
                        Console.WriteLine(sr.ReadToEnd());
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine("The file could not be read:");
                    Console.WriteLine(e.Message);
                }

            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
          

           }

        protected override void Execute()
        {
            TestDelegate();
        }
        public void TestDelegate()
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

