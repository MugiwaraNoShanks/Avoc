using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace AvocatDAL.Classes
{
    class Events
    {
        OleDbCommand cmd;
        OleDbConnection cnx;
        OleDbDataAdapter adapter;
        DataTable datatable;

        public Events()
        {
            cnx = new OleDbConnection();
            cnx.ConnectionString = AvocatDAL.Properties.Settings.Default.LawyersConnectionString.ToString();
        }

        public DataTable GetEvents()
        {
            cmd = new OleDbCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "Select * from Events";
            return ExecuteQueryDataTable(cmd);
        }

        public DataTable GetEventsByType(string EventTypeName)
        {
            cmd = new OleDbCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "Select * from Events, EventType where Type = ID_Event and label = @EventName";
            cmd.Parameters.AddWithValue("@EventName", EventTypeName);
            return ExecuteQueryDataTable(cmd);
        }

        public DataTable GetEventsByAffaire(string idAffaire)
        {
            cmd = new OleDbCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "Select * from Events where id_affaire = @idAffaire";
            cmd.Parameters.AddWithValue("@idAffaire", idAffaire);
            return ExecuteQueryDataTable(cmd);
        }

        public void insert_Events(string idAffaire, string devent, string hours, string price, string type, string commentary)
        {
            cmd = new OleDbCommand();
            cmd.CommandText = @"insert into Events (id_affaire, dateevent, hours, price, type, commentary) 
                             values (@idAffaire, @DEvent, @hours, @price, @type, @commentary)";
            cmd.Parameters.AddWithValue("@idAffaire", idAffaire);
            cmd.Parameters.AddWithValue("@DEvent", devent);
            cmd.Parameters.AddWithValue("@hours", hours);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@type", type);
            cmd.Parameters.AddWithValue("@commentary", commentary);
            ExecuteQuery(cmd);
        }

        public void delete_Events(int id)
        {
            cmd = new OleDbCommand();
            cmd.CommandText = "Delete From Events where id = @ID";
            cmd.Parameters.AddWithValue("@ID", id);
            ExecuteQuery(cmd);
        }

        public void update_Events(int id, string idAffaire, string devent, string hours, string price, string type, string commentary)
        {
            cmd = new OleDbCommand();
            cmd.CommandText = @"Update Events Set id_affaire = @idAffaire, dateevent = @DEvent, hours = @hours,
                                price = @price, type = @type, commentary = @commentary where id = @ID";
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@idAffaire", idAffaire);
            cmd.Parameters.AddWithValue("@DEvent", devent);
            cmd.Parameters.AddWithValue("@hours", hours);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@type", type);
            cmd.Parameters.AddWithValue("@commentary", commentary);
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
