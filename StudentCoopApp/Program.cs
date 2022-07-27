using System;
using StudentCoopBL;
using StudentCoopDal;
using StudentCoopCommon;
using StudentCoopCommon.Abstracts;
using StudentCoopCommon.Interfaces;
using StudentCoopCommon.Logging;

namespace StudentCoopApp
{
    class Program
    {
        //private StudentRepositoryFactory studentRepositoryFactory = new StudentRepositoryFactory();
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello student coop app");
            var studentManagerTest = new StudentManagerTest();
            studentManagerTest.Get_WhenStudentIsAdded_ShouldBeAbleToGet();
            studentManagerTest.Get_WhenStudentDoesNotExist_ShouldReturnNull();
            studentManagerTest.Add_WhenStudentIsAdded_ItShouldBeAbleToGet();
            studentManagerTest.Get_AllData_StudentInDatabase();
            studentManagerTest.Add_WhenStudentIsAdded_ItShouldBeAbleToGet();


        }

    }
}