using Microsoft.Data.SqlClient;
using StudentCoopCommon;
using StudentCoopCommon.Interfaces;
using StudentCoopCommon.ViewModels;

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace StudentCoopDal
{
    public class StudentRepository : IStudentRepositoryReportable, IPrintable
    {
        private List<Student> students = new List<Student>();
        private List<Student> singleStudent2 = new List<Student>();


        public string devConnectionString = @"Data Source=DESKTOP-515H0J5\SQLEXPRESS;Initial Catalog=StudentCoop;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public StudentRepository()
        {

        }
        public void PrintList()
        {
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine(students[i]);
            }
        }

        public void OpenConnection()
        {
            SqlConnection sqlConnection = this.GetConnection();
            sqlConnection.Open();

            Console.WriteLine("Connection state = {0}", sqlConnection.State);
            sqlConnection.Close();
        }
        private SqlConnection GetConnection()
        {
            return new SqlConnection(devConnectionString);

        }


        public void SelectStudentData()
        {
            SqlConnection sqlConnection = this.GetConnection();
            string sqlSelect = "SELECT COUNT(*) FROM dbo.Student";

            SqlCommand command = new SqlCommand(sqlSelect, sqlConnection);

            sqlConnection.Open();
            var count = Convert.ToInt32(command.ExecuteScalar());
            sqlConnection.Close();

            Console.WriteLine("Count is = {0}", count);
        }



        public void GetSchemaAndResult()
        {
            string sqlSelect = "SELECT Student_ID From dbo.Student";
            SqlConnection sqlConnection = this.GetConnection();
            SqlCommand command = new SqlCommand(sqlSelect, sqlConnection);

            sqlConnection.Open();
            SqlDataReader dataReader = command.ExecuteReader();
            DataTable dataTable = dataReader.GetSchemaTable();

            foreach (DataRow row in dataTable.Rows)
            {
                foreach (DataColumn column in dataTable.Columns)
                {
                    Console.WriteLine("{0} - {1}", column.ColumnName, row[column]);
                }
            }

            sqlConnection.Close();
        }

        public void GetDataUsingDataTable()
        {
            string sqlSelect = "SELECT ID From dbo.Student";

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlSelect, this.devConnectionString);

            // Fill a DataTable using DataAdapter
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine("row: {0}", row[0]);
            }

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Console.WriteLine("rows(): {0}", dataTable.Rows[i]["ID"]);
            }
        }

        public List<Student> Get()
        {
            return this.students;
        }

        private SqlCommand GetSqlCommand(string sqlStatement, SqlConnection connection)
        {
            return new SqlCommand(sqlStatement, connection);
        }




        /*public void Get()
        {
            //return new Student();

            string sqlSelect = ("SELECT Student_ID, First, Last, DateOfBirth, Address, PhoneNumber From dbo.student ");
            SqlConnection sqlConnection = this.GetConnection();
            SqlCommand command = new SqlCommand(sqlSelect, sqlConnection);

            sqlConnection.Open();
            using (SqlDataReader dataReader = command.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    Console.WriteLine("Student ID using key: {0}", dataReader["Student_ID"]);
                    Console.WriteLine("Student First Name using GetString: {0}", dataReader["First"]);
                    Console.WriteLine("Student Last Name using GetString: {0}", dataReader["Last"]);
                    Console.WriteLine("Student Date of birth using GetString: {0}", dataReader["DateOfBirth"]);
                    Console.WriteLine("Student Address using GetString: {0}", dataReader["Address"]);
                    Console.WriteLine("Student Phone number GetInt32: {0}", dataReader["PhoneNumber"]);
                    Console.WriteLine("");
                }
            }

            sqlConnection.Close();
        }*/
        public void StudentAdd(int id, string first, string last, string date, string add, int phone)
        {

            var sqlConnection = GetConnection();

            string sqlInsert = string.Format("INSERT INTO Student (Student_ID, First, Last, DateOfBirth, Address, PhoneNumber) VALUES('{0}','{1}','{2}','{3}','{4}','{5}')", id, first, last, date, add, phone);

            SqlCommand command = this.GetSqlCommand(sqlInsert, sqlConnection);
            sqlConnection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            sqlConnection.Close();

            Console.WriteLine("rowsAffected = {0}", rowsAffected);
        }


        public void StudentGet()
        {
            var expConnString = new StudentRepository();


            GetConnection();
            expConnString.OpenConnection();
            string sqlSelect = "SELECT  First, Last, DateOfBirth, Address, PhoneNumber From dbo.student";
            SqlConnection sqlConnection = this.GetConnection();
            SqlCommand command = new SqlCommand(sqlSelect, sqlConnection);

            sqlConnection.Open();
            using (SqlDataReader dataReader = command.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    //Console.WriteLine("Student ID using key: {0}", dataReader["Student_ID"]);
                    Console.WriteLine("Student First Name using GetString: {0}", dataReader["First"]);
                    Console.WriteLine("Student Last Name using GetString: {0}", dataReader["Last"]);
                    Console.WriteLine("Student Date of birth using GetString: {0}", dataReader["DateOfBirth"]);
                    Console.WriteLine("Student Address using GetString: {0}", dataReader["Address"]);
                    Console.WriteLine("Student Phone number GetInt32: {0}", dataReader["PhoneNumber"]);
                    Console.WriteLine("");
                }
            }

            sqlConnection.Close();
        }


        public void Delete(string id)
        {
            throw new NotImplementedException();
        }



        public StudentRepository(List<Student> students)
        {
            if (students != null)
            {
                this.students = students;
            }
        }



        public IEnumerable<Student> Get(IEnumerable<string> filters)
        {
            throw new NotImplementedException();
        }

        public void Print()
        {
            throw new NotImplementedException();
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
            students.Add(student);
        }
        public void Update(int id, Student student)
        {

            var sqlConnection = GetConnection();

            string sqlInsert = string.Format("UPDATE Student SET First = '{0}', Last = '{1}'  Where Student_ID = {2};", student.first, student.last, id);


            SqlCommand command = this.GetSqlCommand(sqlInsert, sqlConnection);
            sqlConnection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            sqlConnection.Close();

            Console.WriteLine("rowsAffected = {0}", rowsAffected);

        }
        public void Delete(int id)
        {
            var sqlConnection = GetConnection();

            string sqlDelete = string.Format("DELETE FROM dbo.Student WHERE Student_ID='{0}'", id);
            SqlCommand command = this.GetSqlCommand(sqlDelete, sqlConnection);
            sqlConnection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            sqlConnection.Close();

            Console.WriteLine("rowsAffected = {0}", rowsAffected);
        }
        public Student Get(int id)
        {
            var expConnString = new StudentRepository();

            var student = this.students.Find(s => s.id == id);



            GetConnection();
            expConnString.OpenConnection();
            string sqlSelect = string.Format("SELECT  First, Last, DateOfBirth, Address, PhoneNumber From dbo.student WHERE Student_ID = {0} ", id);

            SqlConnection sqlConnection = this.GetConnection();
            SqlCommand command = new SqlCommand(sqlSelect, sqlConnection);

            sqlConnection.Open();
            using (SqlDataReader dataReader = command.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    //Console.WriteLine("Student ID using key: {0}", dataReader[id]);
                    Console.WriteLine("Student ID using key: {0}", id);
                    Console.WriteLine("Student First Name using GetString: {0}", dataReader["First"]);
                    Console.WriteLine("Student Last Name using GetString: {0}", dataReader["Last"]);
                    Console.WriteLine("Student Date of birth using GetString: {0}", dataReader["DateOfBirth"]);
                    Console.WriteLine("Student Address using GetString: {0}", dataReader["Address"]);
                    Console.WriteLine("Student Phone number GetInt32: {0}", dataReader["PhoneNumber"]);
                    Console.WriteLine("");

                    singleStudent2.Add(student);

                }
            }

            sqlConnection.Close();

            return student;

        }


    }
}
