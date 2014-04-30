using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace AvocatDAL.Classes
{
    class Person
    {
        OleDbCommand cmd;
        OleDbConnection cnx;
        OleDbDataAdapter adapter;
        DataTable datatable;

        public Person()
        {
            cnx = new OleDbConnection();
            cnx.ConnectionString = AvocatDAL.Properties.Settings.Default.LawyersConnectionString.ToString();
        }

        public DataTable GetPersons()
        {
            cmd = new OleDbCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "Select * from Person";
            return ExecuteQueryDataTable(cmd);
        }

        public DataTable GetPersonByID(int ID)
        {
            cmd = new OleDbCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "Select * from Person where ID_Pers = @ID";
            cmd.Parameters.AddWithValue("@ID", ID);
            return ExecuteQueryDataTable(cmd);
        }

        public DataTable GetPersonByLastName(string name)
        {
            cmd = new OleDbCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "Select * from Person where lname = @name";
            cmd.Parameters.AddWithValue("@name", name);
            return ExecuteQueryDataTable(cmd);
        }

        public DataTable GetPersonByFirstName(string name)
        {
            cmd = new OleDbCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "Select * from Person where fname = @name";
            cmd.Parameters.AddWithValue("@name", name);
            return ExecuteQueryDataTable(cmd);
        }

        public DataTable GetPersonByFullName(string fname, string lname)
        {
            cmd = new OleDbCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "Select * from Person where fname = @fname and lname = @lname";
            cmd.Parameters.AddWithValue("@fname", fname);
            cmd.Parameters.AddWithValue("@lname", lname);
            return ExecuteQueryDataTable(cmd);
        }

        public DataTable GetPersonByType(string PType)
        {
            cmd = new OleDbCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "Select * from Person, PersonType where Person.ID_Type = PersonType.ID_Pers and PersonType.Description = @Type";
            cmd.Parameters.AddWithValue("@Type", PType);
            return ExecuteQueryDataTable(cmd);
        }

        public DataTable GetPersonByCity(string City)
        {
            cmd = new OleDbCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "Select * from Person where City = @City";
            cmd.Parameters.AddWithValue("@City", City);
            return ExecuteQueryDataTable(cmd);
        }

        public DataTable GetPersonByMobile(string Mobile)
        {
            cmd = new OleDbCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "Select * from Person where Mobile1 = @Mobile";
            cmd.Parameters.AddWithValue("@Mobile", Mobile);
            return ExecuteQueryDataTable(cmd);
        }

        public void insert_Person(string lname, string fname, string city, string address1, string address2,
            string tel1, string tel2, string mobile1, string mobile2, string fax, string idType, string RS)
        {
            cmd = new OleDbCommand();
            cmd.CommandText = @"insert into Person (fname, lname, city, address1, address2, 
            tel1, tel2, mobile1, mobile2, fax, id_type, RS) values (@fname, @lname, @city, 
            @address1, @address2, @tel1, @tel2, @mobile1, @mobile1, @fax, @id_type, @RS)";
            cmd.Parameters.AddWithValue("@fname", fname);
            cmd.Parameters.AddWithValue("@lname", lname);
            cmd.Parameters.AddWithValue("@city", city);
            cmd.Parameters.AddWithValue("@address1", address1);
            cmd.Parameters.AddWithValue("@address2", address2);
            cmd.Parameters.AddWithValue("@tel1", tel1);
            cmd.Parameters.AddWithValue("@tel2", tel2);
            cmd.Parameters.AddWithValue("@mobile1", mobile1);
            cmd.Parameters.AddWithValue("@mobile1", mobile1);
            cmd.Parameters.AddWithValue("@fax", fax);
            cmd.Parameters.AddWithValue("@id_type", idType);
            cmd.Parameters.AddWithValue("@RS", RS);
            ExecuteQuery(cmd);
        }

        public void delete_Person(int id)
        {
            cmd = new OleDbCommand();
            cmd.CommandText = "Delete From Person where ID_Pers = @ID";
            cmd.Parameters.AddWithValue("@ID", id);

            ExecuteQuery(cmd);
        }

        public void update_Person(int id, string lname, string fname, string city, string address1, string address2, 
            string tel1, string tel2, string mobile1, string mobile2, string fax, string idType, string RS)
        {

            cmd = new OleDbCommand();
            cmd.CommandText = @"Update Person Set fname = @fname, lname = @lname, city = @city,
            address1 = @address1, address2 = @address2, tel1 = @tel1, tel2 = @tel2, mobile1 = @mobile1,
            mobile2 = @mobile2, fax = @fax, id_type = @idType, RS = @RS where ID_Pers = @ID";
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@fname", fname);
            cmd.Parameters.AddWithValue("@lname", lname);
            cmd.Parameters.AddWithValue("@city", city);
            cmd.Parameters.AddWithValue("@address1", address1);
            cmd.Parameters.AddWithValue("@address2", address2);
            cmd.Parameters.AddWithValue("@tel1", tel1);
            cmd.Parameters.AddWithValue("@tel2", tel2);
            cmd.Parameters.AddWithValue("@mobile1", mobile1);
            cmd.Parameters.AddWithValue("@mobile1", mobile1);
            cmd.Parameters.AddWithValue("@fax", fax);
            cmd.Parameters.AddWithValue("@id_type", idType);
            cmd.Parameters.AddWithValue("@RS", RS);
            ExecuteQuery(cmd);
        }

        public void ExecuteQuery(OleDbCommand command)
        {
            try
            {
                cnx.Open();
                command.ExecuteNonQuery();
                cnx.Close();
            }
            catch
            {
                throw;
            }
        }


        public DataTable ExecuteQueryDataTable(OleDbCommand command)
        {
            datatable = new DataTable();

            try
            {
                cnx.Open();
                adapter = new OleDbDataAdapter();
                adapter.SelectCommand = command;
                cnx.Close();

                adapter.Fill(datatable);
                return datatable;
            }
            catch
            {
                throw;
            }
        }



    }
}
