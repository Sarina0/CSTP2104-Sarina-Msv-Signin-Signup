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
            List<int> task1 = new List<int>();

            task1 = CalSum();

            // turning this function to a task and write to console
            //string stringList = string.Join(",", task1.ToArray());

            Task<string> task2 = Task.Run(() =>
            {
                string stringList = string.Join(",", task1.ToArray());
                Console.WriteLine("Writing to console task " + stringList);
                Task Task3 = WriteFileAsync(stringList);
                return stringList;
            });

            Console.ReadLine();

        }
        public static async Task WriteFileAsync(string data)
        {
            Console.WriteLine("Async Write File has started.");
            using (var sw = new StreamWriter(@"C:\Users\sarin\source\repos\CSTP2104\CSTP2104\Assignment2\SumReport.txt"))
            {
                await sw.WriteAsync(data);
            }
            Console.WriteLine("Async Write File has completed.");
        }

        public static List<int> CalSum()
        {
            int sum = 0;
            var SumNum = new List<int>();
            //StringBuilder myStringBuilder = new StringBuilder("1. " + content);
            for (int i = 2; i <= 10; i++)
            {
                sum = sum + i;
                Console.WriteLine("the sum is {0}", sum);
                SumNum.Add(sum);
                //myStringBuilder.Append($"\r\n{i}. {content}");
            }
            return SumNum;

        }


    }
}

