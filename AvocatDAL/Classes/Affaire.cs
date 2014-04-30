using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace AvocatDAL.Classes
{
    class Affaire
    {
        OleDbCommand cmd;
        OleDbConnection cnx;
        OleDbDataAdapter adapter;
        DataTable datatable;

        public Affaire()
        {
            cnx = new OleDbConnection();
            cnx.ConnectionString = AvocatDAL.Properties.Settings.Default.LawyersConnectionString.ToString();
        }

        public DataTable GetAffaires()
        {
            cmd = new OleDbCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "Select * from Affaire";
            return ExecuteQueryDataTable(cmd);
        }

        public DataTable GetAffaireByNumTrib(string NumTrib)
        {
            cmd = new OleDbCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "Select * from Affaire where NumTrib = @NTrib";
            cmd.Parameters.AddWithValue("@NTrib", NumTrib);
            return ExecuteQueryDataTable(cmd);
        }

        public DataTable GetAffaireByNumCapp(string NumCapp)
        {
            cmd = new OleDbCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "Select * from Affaire where NumCapp = @NCapp";
            cmd.Parameters.AddWithValue("@NCapp", NumCapp);
            return ExecuteQueryDataTable(cmd);
        }

        public DataTable GetAffaireByNumCas(string NumCas)
        {
            cmd = new OleDbCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "Select * from Affaire where NumCas = @NCas";
            cmd.Parameters.AddWithValue("@NCas", NumCas);
            return ExecuteQueryDataTable(cmd);
        }

        public DataTable GetAffaireByNumEnq(string NumEnq)
        {
            cmd = new OleDbCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "Select * from Affaire where NumEnquete = @NEnq";
            cmd.Parameters.AddWithValue("@NEnq", NumEnq);
            return ExecuteQueryDataTable(cmd);
        }

        public DataTable GetAffaireByNumDec(string NumDec)
        {
            cmd = new OleDbCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "Select * from Affaire where NumDeclaration = @NDec";
            cmd.Parameters.AddWithValue("@NDec", NumDec);
            return ExecuteQueryDataTable(cmd);
        }

        public DataTable GetAffaireByNature(string Nature)
        {
            cmd = new OleDbCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "Select * from Affaire, AffaireNature where TypeAffaire = ID_Nature and Description = @Nature";
            cmd.Parameters.AddWithValue("@Nature", Nature);
            return ExecuteQueryDataTable(cmd);
        }

        public DataTable GetAffaireByClientFName(string CFN)
        {
            cmd = new OleDbCommand();
            cmd.Connection = cnx;
            cmd.CommandText = @"Select * from Affaire, Person, PersonType, PerGroup where ClientID = ID_Pers and 
                    Person.ID_TYPE = PersonType.ID_Pers and PersonType.Description = 'Client' and FNAME = @CFN";
            cmd.Parameters.AddWithValue("@CFN", CFN);
            return ExecuteQueryDataTable(cmd);
        }

        public DataTable GetAffaireByClientLName(string CLN)
        {
            cmd = new OleDbCommand();
            cmd.Connection = cnx;
            cmd.CommandText = @"Select * from Affaire, Person, PersonType, PerGroup where ClientID = ID_Pers and 
                    Person.ID_TYPE = PersonType.ID_Pers and PersonType.Description = 'Client' and LNAME = @CLN";
            cmd.Parameters.AddWithValue("@CLN", CLN);
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
