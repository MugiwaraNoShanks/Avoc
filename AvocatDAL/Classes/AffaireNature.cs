using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace AvocatDAL.Classes
{
    class AffaireNature
    {
        OleDbCommand cmd;
        OleDbConnection cnx;
        OleDbDataAdapter adapter;
        DataTable datatable;

        public AffaireNature() 
        {
            cnx = new OleDbConnection();
            cnx.ConnectionString = AvocatDAL.Properties.Settings.Default.LawyersConnectionString.ToString();
        }

        public DataTable GetAffaireNature()
        {
            cmd = new OleDbCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "Select * from AffaireNature";
            return ExecuteQueryDataTable(cmd);
        }

        public DataTable GetAffaireNatureByName(string name)
        {
            cmd = new OleDbCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "Select * from AffaireNature where name = @name";
            cmd.Parameters.AddWithValue("@name", name);
            return ExecuteQueryDataTable(cmd);
        }

        public void insert_AffaireNature(string name)
        {
            cmd = new OleDbCommand();
            cmd.CommandText = "insert into AffaireNature (Description) values (@name)";
            cmd.Parameters.AddWithValue("@name", name);
            ExecuteQuery(cmd);
        }

        public void delete_AffaireNature(int id)
        {
            cmd = new OleDbCommand();
            cmd.CommandText = "Delete From AffaireNature where id_nature = @ID";
            cmd.Parameters.AddWithValue("@ID", id);
            ExecuteQuery(cmd);
        }

        public void update_AffaireNature(int id, string Desc)
        {

            cmd = new OleDbCommand();
            cmd.CommandText = "Update AffaireNature Set description = @Desc where id_nature = @ID";
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
