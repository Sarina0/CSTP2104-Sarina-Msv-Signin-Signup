using System;
using StudentCoopCommon;
using StudentCoopCommon.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentCoopDal
{
    public class ApplicationRepository : IStudentRepositoryReportable, IPrintable
    {
            private List<Student> students = new List<Student>();

            public ApplicationRepository(List<Student> students)
            {
                if (students != null)
                {
                    this.students = students;
                }
            }

            public void Add(Student student)
        {
              var sqlConnection = GetConnection();

            string sqlInsert = string.Format("INSERT INTO Student (Student_ID, First, Last, DateOfBirth, Address, PhoneNumber) VALUES('{0}','{1}','{2}','{3}','{4}','{5}')", student.id, student.first, student.last, student.date, student.add, student.phone);

            SqlCommand command = this.GetSqlCommand(sqlInsert, sqlConnection);
            sqlConnection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            sqlConnection.Close();

            Console.WriteLine("rowsAffected = {0}", rowsAffected);
        }

            public Student Get(string id)
            {
                var student = this.students.Find(s => s.ID == id);
                return student;
            }

            public void Delete(string id)
            {
                throw new NotImplementedException();
            }

            public void Update(Student student)
            {
                throw new NotImplementedException();
            }

            public IEnumerable<Student> Get(IEnumerable<string> filters)
            {
                throw new NotImplementedException();
            }

            public void Print()
            {
                throw new NotImplementedException();
            }
        }
    }

}
