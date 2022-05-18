using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSTP2104.Assignment2
{
    class CalculateSum
    {
        public void RunTasks()
        {
            Task.Run(() => Console.WriteLine("Sum of Number task!"));
            new Thread(() => Console.WriteLine("Start")).Start();
            int sum = 0;
            Task task1 = Task.Run(() =>
            {
                for (int j = 1; j <= 10; j++)
                {
                    sum = sum + j;
                    PrintSum(sum);
                   

                }
            });
            
        }
       

        public void PrintSum(int s)
        {
            Console.Write("\nThe Sum is => {0}\n", s);
            
        }


        public static void WriteProgressToFileAsync(int txt)
        {
            string path = @"C:\Users\sarin\source\repos\CSTP2104\CSTP2104\Assignment2\SumReport.txt";
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
    }
}

