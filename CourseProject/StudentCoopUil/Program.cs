using System;
using StudentCoopBL;
using StudentCoopCommon;
using StudentCoopDal;
namespace StudentCoopUil
{
    class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            program.Add_WhenStudentIsAdded_ItShouldBeAbleToGet();
        }

        public void Add_WhenStudentIsAdded_ItShouldBeAbleToGet()
        {
            var studentManager = new StudentManager();
            //studentManager.Add(new Student() { id = 23452, first = "Melody" });
            //var student = studentManager.Get(23452);
            //Console.WriteLine(student.first);
            //var student = StudentManager.Get();
            studentManager.Get();
            /*var isValid = student.ID == "1001" && student.FirstName == "qwer";
            if (!isValid)
            {
                throw new Exception("Add test failed");
            }*/
        }
    }
}
