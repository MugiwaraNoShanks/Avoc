using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace AvocatDAL.Classes
{
    class PersonType
    {
        OleDbCommand cmd;
        OleDbConnection cnx;
        OleDbDataAdapter adapter;
        DataTable datatable;

        public PersonType()
        {
            cnx = new OleDbConnection();
            cnx.ConnectionString = AvocatDAL.Properties.Settings.Default.LawyersConnectionString.ToString();
        }

        public DataTable GetPersonType()
        {
            cmd = new OleDbCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "Select * from PersonType";
            return ExecuteQueryDataTable(cmd);
        }

        public void insert_PersonType(int idGr, string Desc)
        {
            cmd = new OleDbCommand();
            cmd.CommandText = "insert into PersonType (ID_PerGr, Description) values (@idGr, @Desc)";
            cmd.Parameters.AddWithValue("@Desc", Desc);
            cmd.Parameters.AddWithValue("@idGr", idGr);
            ExecuteQuery(cmd);
        }

        public void delete_PersonType(int id)
        {
            cmd = new OleDbCommand();
            cmd.CommandText = "Delete From PersonType where id_pers = @ID";
            cmd.Parameters.AddWithValue("@ID", id);
            ExecuteQuery(cmd);
        }

        public void update_PersonType(int id, int idGr, string Desc)
        {

            cmd = new OleDbCommand();
            cmd.CommandText = "Update PersonType Set description = @Desc, ID_PerGr = @idGr where id_pers = @ID";
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@Desc", Desc);
            cmd.Parameters.AddWithValue("@idGr", idGr);
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
