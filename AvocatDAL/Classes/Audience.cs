using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace AvocatDAL.Classes
{
    public class Audience
    {
        OleDbCommand cmd;
        OleDbConnection cnx;
        OleDbDataAdapter adapter;
        DataTable datatable;

        public Audience()
        {
            cnx = new OleDbConnection();
            cnx.ConnectionString = AvocatDAL.Properties.Settings.Default.LawyersConnectionString.ToString();
        }

        public DataTable GetAudiences()
        {
            cmd = new OleDbCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "Select * from Audience";
            return ExecuteQueryDataTable(cmd);
        }

        public DataTable GetAudienceByJuridictionID(string JuridictionID)
        {
            cmd = new OleDbCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "Select * from Audience where JuridictionID = @JID";
            cmd.Parameters.AddWithValue("@JID", JuridictionID);
            return ExecuteQueryDataTable(cmd);
        }

        public DataTable GetAudienceByAffaire(string idAffaire)
        {
            cmd = new OleDbCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "Select * from Audience where id_affaire = @idAffaire";
            cmd.Parameters.AddWithValue("@idAffaire", idAffaire);
            return ExecuteQueryDataTable(cmd);
        }

        public void insert_Audience(string idAffaire, string JID, string NextDate, string status, string pour, string commentary)
        {
            cmd = new OleDbCommand();
            cmd.CommandText = @"insert into Audience (id_affaire, JuridictionID, NextDate, Status, pour, commentaire) 
                             values (@idAffaire, @JID, @ND, @Status, @pour, @commentary)";
            cmd.Parameters.AddWithValue("@idAffaire", idAffaire);
            cmd.Parameters.AddWithValue("@JID", JID);
            cmd.Parameters.AddWithValue("@ND", NextDate);
            cmd.Parameters.AddWithValue("@Status", status);
            cmd.Parameters.AddWithValue("@pour", pour);
            cmd.Parameters.AddWithValue("@commentary", commentary);
            ExecuteQuery(cmd);
        }

        public void delete_Audience(string id)
        {
            cmd = new OleDbCommand();
            cmd.CommandText = "Delete From Audience where id_audience = @ID";
            cmd.Parameters.AddWithValue("@ID", id);
            ExecuteQuery(cmd);
        }

        public void update_Audience(int id, string idAffaire, string JID, string NextDate, string status, string pour, string commentary)
        {
            cmd = new OleDbCommand();
            cmd.CommandText = @"Update Audience Set id_affaire = @idAffaire, JuridictionID = @JID, NextDate = @ND,
                            Status = @Status, pour = @for, commentaire = @commentary where id_audience = @ID";
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@idAffaire", idAffaire);
            cmd.Parameters.AddWithValue("@JID", JID);
            cmd.Parameters.AddWithValue("@ND", NextDate);
            cmd.Parameters.AddWithValue("@Status", status);
            cmd.Parameters.AddWithValue("@pour", pour);
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
