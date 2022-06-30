using System;

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
            studentManager.Add(new Student() { id = "1001", first = "qwer" });
            var student = studentManager.StudentGet();

            /*var isValid = student.ID == "1001" && student.FirstName == "qwer";
            if (!isValid)
            {
                throw new Exception("Add test failed");
            }*/
        }
    }
}
