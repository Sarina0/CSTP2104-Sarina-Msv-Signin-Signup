using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;
using System.Configuration;

namespace CSTP2104.Assignment5
{
        public class sqlDatabase
    {

        private string devConnectionString = @"Data Source=DESKTOP-515H0J5\SQLEXPRESS;Initial Catalog=StudentCoop;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private SqlConnection con;

            public void SqlConnect()
            {
                SqlConnection con = new SqlConnection(devConnectionString);
               
            }
            //, string last, string birth, string address, int num
            public void AddVal(int id, string first)
            {
            //SqlConnect();
            SqlConnection con = new SqlConnection(devConnectionString);
            SqlCommand cmd = new SqlCommand("insert the values(@Student_ID, @First,@Last,@DataOfBirth,@Address,@PhoneNumber)", con);
                cmd.Parameters.AddWithValue("@Student_ID", id);
                cmd.Parameters.AddWithValue("@First", first);
            cmd.ExecuteNonQuery();

            con.Close();
            Console.WriteLine("Successfull!");
            Console.WriteLine("{0} and {1} has been added to the table", id, first);
            
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
                string sqlSelect = "SELECT COUNT(*) FROM dbo.student";

                SqlCommand command = new SqlCommand(sqlSelect, sqlConnection);

                sqlConnection.Open();
                var count = Convert.ToInt32(command.ExecuteScalar());
                sqlConnection.Close();

                Console.WriteLine("Count is = {0}", count);
            }

            public void DeleteStudent()
            {
                string studentID = "s123";
                var sqlConnection = GetConnection();

                string sqlDelete = string.Format("DELETE FROM dbo.student WHERE ID='{0}'", studentID);
                SqlCommand command = this.GetSqlCommand(sqlDelete, sqlConnection);
                sqlConnection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                sqlConnection.Close();

                Console.WriteLine("rowsAffected = {0}", rowsAffected);
            }

            private SqlCommand GetSqlCommand(string sqlStatement, SqlConnection connection)
            {
                return new SqlCommand(sqlStatement, connection);
            }

            private SqlConnection GetConnection()
            {
                return new SqlConnection(this.devConnectionString);
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
        }
    }
