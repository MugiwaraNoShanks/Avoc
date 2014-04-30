using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace AvocatDAL.Classes
{
    class EventType
    {
        OleDbCommand cmd;
        OleDbConnection cnx;
        OleDbDataAdapter adapter;
        DataTable datatable;

        public EventType()
        {
            cnx = new OleDbConnection();
            cnx.ConnectionString = AvocatDAL.Properties.Settings.Default.LawyersConnectionString.ToString();
        }

        public DataTable GetEventTypes()
        {
            cmd = new OleDbCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "Select * from EventType";
            return ExecuteQueryDataTable(cmd);
        }

        public void insert_EventType(string label, string Desc)
        {
            cmd = new OleDbCommand();
            cmd.CommandText = "insert into EventType (label, description) values (@label, @desc)";
            cmd.Parameters.AddWithValue("@label", label);
            cmd.Parameters.AddWithValue("@desc", Desc);
            ExecuteQuery(cmd);
        }

        public void delete_EventType(int id)
        {
            cmd = new OleDbCommand();
            cmd.CommandText = "Delete From EventType where id_event = @ID";
            cmd.Parameters.AddWithValue("@ID", id);
            ExecuteQuery(cmd);
        }

        public void update_EventType(int id, string label, string desc)
        {
            cmd = new OleDbCommand();
            cmd.CommandText = "Update EventType Set label = @label, description = @desc where id_event = @ID";
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@label", label);
            cmd.Parameters.AddWithValue("@desc", desc);
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
