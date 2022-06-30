using System;
using StudentCoopBL;

using StudentCoopCommon;

namespace StudentCoopApp
{
    class Program
    {
       public  static void Main(string[] args)
        {
            Console.WriteLine("Hello student coop app");
            //var program = new Program();
            //program.Add_WhenStudentIsAdded_ItShouldBeAbleToGet();
        }

        /*public void Add_WhenStudentIsAdded_ItShouldBeAbleToGet()
        {
            var studentManager = new StudentManager();
            studentManager.Add(new Student() { ID = "1001", FirstName = "qwer" });
            var student = studentManager.Get("1001");

            var isValid = student.ID == "1001" && student.FirstName == "qwer";
            if (!isValid)
            {
                throw new Exception("Add test failed");
            }
        }*/
    }
}