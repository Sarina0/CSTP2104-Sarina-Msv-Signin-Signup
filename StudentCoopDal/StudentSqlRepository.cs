using StudentCoopCommon;
using StudentCoopCommon.Interfaces;
using StudentCoopCommon.ViewModels;

using System;

using StudentCoopDal;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;


namespace StudentCoopDal
{
    public class StudentSqlRepository : IStudentRepository
    {
        private List<Student> students = new List<Student>();

        public StudentSqlRepository()
        {

        }

        public StudentSqlRepository(List<Student> students)
        {
            if (students != null)
            {
                this.students = students;
            }
        }

        public void Add(Student student)
        {
            
            this.students.Add(student);

        }

        public Student Get(int id)
        {
            var student = this.students.Find(s => s.id == id);
            return student;
        }

        public void Delete(int id)
        {
            Console.WriteLine("this is delete from sql repo");
        }

        public void Update(int id, Student student)
        {
            Console.WriteLine("this is update from sql repo");
        }

        public IEnumerable<Student> Get(IEnumerable<string> filters)
        {
            throw new NotImplementedException();
        }

        public void Print()
        {
            throw new NotImplementedException();
        }
        public void ThisTest()
        {
            Console.WriteLine("This is test from student sql Repo");
        }
        public void StudentGet()
        {
            Console.WriteLine("this is studentGet from student sql");
        }
       
        public void PrintList()
        {
            Console.WriteLine("sql repo print list");
        }
    }
}
