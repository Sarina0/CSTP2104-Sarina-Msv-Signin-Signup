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
   public class ApplicationRepository
    {

        public string devConnectionString = @"Data Source=DESKTOP-515H0J5\SQLEXPRESS;Initial Catalog=StudentCoop;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        public void OpenConnection()
        {
            SqlConnection sqlConnection = this.GetConnection();
            sqlConnection.Open();

            Console.WriteLine("Connection state = {0}", sqlConnection.State);
            sqlConnection.Close();
        }

        public void SelectCompanyData()
        {
            SqlConnection sqlConnection = this.GetConnection();
            string sqlSelect = "SELECT COUNT(*) FROM dbo.Company";

            SqlCommand command = new SqlCommand(sqlSelect, sqlConnection);

            sqlConnection.Open();
            var count = Convert.ToInt32(command.ExecuteScalar());
            sqlConnection.Close();

            Console.WriteLine("Count is = {0}", count);
        }

        public void DeleteCompany()
        {
            string companyID = "19234";
            var sqlConnection = GetConnection();

            string sqlDelete = string.Format("DELETE FROM dbo.Company WHERE Company_ID='{0}'", companyID);
            SqlCommand command = this.GetSqlCommand(sqlDelete, sqlConnection);
            sqlConnection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            sqlConnection.Close();

            Console.WriteLine("rowsAffected = {0}", rowsAffected);
        }

        public void Read()
        {// string birth, string address, int num
            string sqlSelect = "SELECT Company_ID, Name, Address From dbo.Company";
            SqlConnection sqlConnection = this.GetConnection();
            SqlCommand command = new SqlCommand(sqlSelect, sqlConnection);

            sqlConnection.Open();
            using (SqlDataReader dataReader = command.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    Console.WriteLine("Company ID using key: {0}", dataReader["Company_ID"]);
                    Console.WriteLine("Name of the Company using GetString: {0}", dataReader["Name"]);
                    Console.WriteLine("Address of the Company using GetString: {0}", dataReader["Address"]);
                    Console.WriteLine("");
                }
            }

            sqlConnection.Close();
        }

        public void GetSchemaAndResult()
        {
            string sqlSelect = "SELECT Company_ID From dbo.Company";
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
            string sqlSelect = "SELECT Company_ID From dbo.Company";

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
        //public void Add(int id, string first, string last, string date, string add, int phone)
        public void Create(Company company)
        {

            var sqlConnection = GetConnection();

            string sqlInsert = string.Format("INSERT INTO Company (Company_ID, Name, Address) VALUES('{0}','{1}','{2}','{3}','{4}','{5}')", company.id, company.Name, company.Address);

            SqlCommand command = this.GetSqlCommand(sqlInsert, sqlConnection);
            sqlConnection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            sqlConnection.Close();

            Console.WriteLine("rowsAffected = {0}", rowsAffected);
        }
        private void Update(string name, int id)
        {



            var sqlConnection = GetConnection();

            string sqlInsert = string.Format("UPDATE Company SET Name = '{0}'  Where Company_ID = 21443;", name, id);


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

        public void ReadByID(int id)
        {
            //return new Student();

            string sqlSelect = ("SELECT Compnay_ID, Name, Address From dbo.Company ");
            SqlConnection sqlConnection = this.GetConnection();
            SqlCommand command = new SqlCommand(sqlSelect, sqlConnection);

            sqlConnection.Open();
            using (SqlDataReader dataReader = command.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    Console.WriteLine("Student ID using key: {0}", dataReader[id]);
                    Console.WriteLine("Student First Name using GetString: {0}", dataReader["Name"]);
                    Console.WriteLine("Student Last Name using GetString: {0}", dataReader["Address"]);
                    Console.WriteLine("");
                }
            }

            sqlConnection.Close();
        }

    }
}
   