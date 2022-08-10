using StudentCoopBL;
using StudentCoopCommon;
using StudentCoopCommon.Interfaces;
using StudentCoopCommon.Logging;
using StudentCoopCommon.ViewModels;

using StudentCoopDal;
using System;

namespace StudentCoopApp
{
    class StudentManagerTest
    {
        private ILogger logger;
        private StudentManager studentManager;
        private readonly StudentRepositoryFactory studentRepositoryFactory = new StudentRepositoryFactory();
        private const int defaultStudentId = 123;
        private const string defaultStudentFName = "testFName";

        public void Get_WhenStudentIsAdded_ShouldBeAbleToGet()
        {
            // Preparation
            this.InitializeTest();
            var expectedStudent = this.GetStudentObject();
            //this.studentManager.Add(expectedStudent);

            // Test
            var student = this.studentManager.Get(defaultStudentId);

            // Validation of Results
            var isValid = student.id == defaultStudentId && student.first == defaultStudentFName;
            if (!isValid)
            {
                throw new Exception("Add test failed");
            }
        }

        public void Get_WhenStudentDoesNotExist_ShouldReturnNull()
        {
            // Preparation for the test
            this.InitializeTest();

            // Test
            var student = studentManager.Get(9877);

            // Validation of results
            var isValid = student == null;
            if (!isValid)
            {
                throw new Exception("Get when student does not exist failed");
            }
        }

        private void InitializeTest()
        {
            this.logger = new FileLogger();
            this.studentManager = new StudentManager(
                studentRepositoryFactory.Create(StudentRepositoryType.InMemoryStudentRepository),
                logger);
        }

        private Student GetStudentObject(int id = defaultStudentId, string firstName = defaultStudentFName)
        {
            return new Student() { id = id, first = defaultStudentFName };
        }
       
        public void GetStudents()
        {
            InitializeTest();
            studentManager.GetAllStudent();
        }
        
        public void Add_This_Student()
        {
            this.InitializeTest();
            studentManager.Add();
        }
        public void Get_This_StudentBy_id()
        {
            this.InitializeTest();
            studentManager.GetById();

        }
        public int print_ID()
        {
            this.InitializeTest();
            int some = studentManager.GetID();
            return some;
        }

        public void DeleteStudentTest()
        {
            this.InitializeTest();
            studentManager.DeleteStudent();
        }
        public void Update_Student()
        {
            this.InitializeTest();
            studentManager.UpdateStudent();

        }
    }
}
