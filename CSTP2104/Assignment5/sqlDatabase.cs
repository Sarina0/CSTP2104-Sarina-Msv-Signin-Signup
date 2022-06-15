using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;
using System.Configuration;
using CSTP2104.Shared;
using System.Data;


namespace CSTP2104.Assignment5
{
    public class sqlDatabase : AssignmentBase
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

        public void GetResultSet()
        {// string birth, string address, int num
            string sqlSelect = "SELECT Student_ID, First, Last, DateOfBirth, Address, PhoneNumber From dbo.student";
            SqlConnection sqlConnection = this.GetConnection();
            SqlCommand command = new SqlCommand(sqlSelect, sqlConnection);

            sqlConnection.Open();
            using (SqlDataReader dataReader = command.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    Console.WriteLine("Student ID using key: {0}", dataReader["ID"]);
                    Console.WriteLine("Student ID using GetString: {0}", dataReader.GetString(0));
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

         /*private void ReadFromConfig()
         {
             foreach (ConnectionStringSettings connectionString in ConfigurationManager.ConnectionStrings)
             {
                 Console.WriteLine(connectionString.Name);
                 Console.WriteLine(connectionString.ProviderName);
                 Console.WriteLine(connectionString.ConnectionString);

                 this.devConnectionString = connectionString.ConnectionString;
             }

         }*/
        protected override void Execute()
        {
            var expConnString = new sqlDatabase();
            

            GetConnection();
            expConnString.OpenConnection();

            expConnString.DeleteStudent();

        }

    }
}