using StudentCoopApp;
using StudentCoopBL;

using StudentCoopCommon;
using StudentCoopCommon.Abstracts;
using StudentCoopCommon.Interfaces;
using StudentCoopCommon.Logging;

using StudentCoopDal;
using System;

namespace StudentCoopApp
{
    class Program
    {
        //private StudentRepositoryFactory studentRepositoryFactory = new StudentRepositoryFactory();
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello student coop app");
            var studentManagerTest = new StudentManagerTest();


            //studentManagerTest.DeleteStudentTest();
            studentManagerTest.GetStudents();
            //studentManagerTest.Get_This_StudentBy_id();
            //studentManagerTest.Update_Student();




        }

    }
}