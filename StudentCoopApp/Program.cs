using System;
using StudentCoopBL;
using StudentCoopDal;
using StudentCoopCommon;

namespace StudentCoopApp
{
    class Program
    {
        private StudentRepositoryFactory studentRepositoryFactory = new StudentRepositoryFactory();
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello student coop app");
            var studentManagerTest = new StudentManagerTest();
            studentManagerTest.Get_WhenStudentIsAdded_ShouldBeAbleToGet();
            studentManagerTest.Get_WhenStudentDoesNotExist_ShouldReturnNull();

        }

    }
}