using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace AvocatDAL.Classes
{
    public class Tribunal
    {
        //string strcon = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=\\server\share\folder\myAccessFile.accdb;";
        OleDbCommand cmd;
        OleDbConnection cnx;
        OleDbDataAdapter adapter;
        DataTable datatable;

        public Tribunal()
        {
            cnx = new OleDbConnection();
            cnx.ConnectionString = AvocatDAL.Properties.Settings.Default.LawyersConnectionString.ToString();        
        }

        public DataTable GetTribunals()
        {
            cmd = new OleDbCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "Select * from Tribunal";
            return ExecuteQueryDataTable(cmd);
        }

        public DataTable GetTribunalsByName(string name)
        {
            cmd = new OleDbCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "Select * from Tribunal where name = @name";
            cmd.Parameters.AddWithValue("@name", name);
            return ExecuteQueryDataTable(cmd);
        }

        public void insert_tribunal(string name, string city, string address)
        {
            cmd = new OleDbCommand();
            cmd.CommandText = "insert into Tribunal (name, city, address) values (@name, @city, @address)";
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@city", city);
            cmd.Parameters.AddWithValue("@address", address);
            ExecuteQuery(cmd);
        }

        public void delete_tribunal(int id)
        {
            cmd = new OleDbCommand();
            cmd.CommandText = "Delete From Tribunal where id_trib = @ID";
            cmd.Parameters.AddWithValue("@ID", id);
            ExecuteQuery(cmd);
        }

        public void update_tribunal(int id, string name, string city, string address)
        {

            cmd = new OleDbCommand();
            cmd.CommandText = "Update Tribunal Set name = @name, city = @city, address = @address where id_trib = @ID";
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@city", city);
            cmd.Parameters.AddWithValue("@address", address);
            ExecuteQuery(cmd);
        }

        public void ExecuteQuery(OleDbCommand command)
        {
            try
            {
                cnx.Open();
                command.Connection = cnx;
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
