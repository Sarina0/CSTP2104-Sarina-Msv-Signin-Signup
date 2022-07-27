using StudentCoopCommon;
using StudentCoopCommon.Interfaces;
using StudentCoopCommon.ViewModels;

using System;
using StudentCoopCommon;
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
        public string devConnectionString = @"Data Source=DESKTOP-515H0J5\SQLEXPRESS;Initial Catalog=StudentCoop;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public void Add(Student student)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

       

        public Student Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Student student)
        {
            throw new NotImplementedException();
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

        public void StudentGet()
        {
            var expConnString = new StudentSqlRepository();


            GetConnection();
            expConnString.OpenConnection();
            string sqlSelect = "SELECT Sudent_ID, First, Last, DateOfBirth, Address, PhoneNumber From dbo.student";
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
    }
}
