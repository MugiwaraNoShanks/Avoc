using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace AvocatDAL.Classes
{
    class PerGroup
    {
        OleDbCommand cmd;
        OleDbConnection cnx;
        OleDbDataAdapter adapter;
        DataTable datatable;

        public PerGroup() 
        {
            cnx = new OleDbConnection();
            cnx.ConnectionString = AvocatDAL.Properties.Settings.Default.LawyersConnectionString.ToString();
        }

        public DataTable GetPerGroup()
        {
            cmd = new OleDbCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "Select * from PerGroup";
            return ExecuteQueryDataTable(cmd);
        }

        public void insert_PerGroup(string Desc)
        {
            cmd = new OleDbCommand();
            cmd.CommandText = "insert into PerGroup (Description) values (@Desc)";
            cmd.Parameters.AddWithValue("@Desc", Desc);
            ExecuteQuery(cmd);
        }

        public void delete_PerGroup(int id)
        {
            cmd = new OleDbCommand();
            cmd.CommandText = "Delete From PerGroup where id_PerGroup = @ID";
            cmd.Parameters.AddWithValue("@ID", id);
            ExecuteQuery(cmd);
        }

        public void update_PerGroup(int id, string Desc)
        {

            cmd = new OleDbCommand();
            cmd.CommandText = "Update PerGroup Set description = @Desc where id_PerGroup = @ID";
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@Desc", Desc);
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
