using StudentCoopCommon;

using System;
using System.Collections.Generic;
using System.Text;
namespace StudentCoopDal
{
    public class StudentRepository
    {


        public string devConnectionString = @"Data Source=DESKTOP-515H0J5\SQLEXPRESS;Initial Catalog=StudentCoop;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public sqlDatabase()
        {
            //this.ReadFromConfig();
        }

        public void OpenConnection()
        {
            SqlConnection sqlConnection = this.GetConnection();
            sqlConnection.Open();

            Console.WriteLine("Connection state = {0}", sqlConnection.State);
            sqlConnection.Close();
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

        public void DeleteStudent()
        {
            string studentID = "19234";
            var sqlConnection = GetConnection();

            string sqlDelete = string.Format("DELETE FROM dbo.Student WHERE Student_ID='{0}'", studentID);
            SqlCommand command = this.GetSqlCommand(sqlDelete, sqlConnection);
            sqlConnection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            sqlConnection.Close();

            Console.WriteLine("rowsAffected = {0}", rowsAffected);
        }

        public void StudentGet()
        {// string birth, string address, int num
            string sqlSelect = "SELECT Student_ID, First, Last, DateOfBirth, Address, PhoneNumber From dbo.student";
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


        private SqlCommand GetSqlCommand(string sqlStatement, SqlConnection connection)
        {
            return new SqlCommand(sqlStatement, connection);
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(devConnectionString);

        }

        private void Add(int id, string first, string last, string date, string add, int phone)
        {

            var sqlConnection = GetConnection();

            string sqlInsert = string.Format("INSERT INTO Student (Student_ID, First, Last, DateOfBirth, Address, PhoneNumber) VALUES('{0}','{1}','{2}','{3}','{4}','{5}')", id, first, last, date, add, phone);

            SqlCommand command = this.GetSqlCommand(sqlInsert, sqlConnection);
            sqlConnection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            sqlConnection.Close();

            Console.WriteLine("rowsAffected = {0}", rowsAffected);
        }
        private void StudentUpdate(string first, string last)
        {



            int id = 21443;




            var sqlConnection = GetConnection();

            string sqlInsert = string.Format("UPDATE Student SET First = '{0}', Last = '{1}'  Where Student_ID = 21443;", first, last);


            SqlCommand command = this.GetSqlCommand(sqlInsert, sqlConnection);
            sqlConnection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            sqlConnection.Close();

            Console.WriteLine("rowsAffected = {0}", rowsAffected);

        }
        /*public void Add(Student student)
        {
            // all database related code is here
        }*/

        public Student Get(string id)
        {
            return new Student();
        }
        
    }
}
