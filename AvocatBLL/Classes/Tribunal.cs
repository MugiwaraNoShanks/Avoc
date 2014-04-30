using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Text.RegularExpressions;

namespace AvocatBLL.Classes
{
    public class Tribunal
    {
        #region Attributs
        public int idTrib { get; set; }
        public string name { get; set; }
        public string city { get; set; }
        public string address { get; set; }
        public AvocatDAL.Classes.Tribunal objDAL;
        //private static readonly char[] SpecialChars = "!@#$%^&*()".ToCharArray();
        //this.name.IndexOfAny(SpecialChars) != -1
        #endregion

        #region Methods
        public Tribunal()
        { 
            objDAL = new AvocatDAL.Classes.Tribunal();
            this.idTrib = 0;
            this.name = "NULL";
            this.city = "NULL";
            this.address = "NULL";
        }

        public DataTable loadTribunal()
        {
            return objDAL.GetTribunals();
        }

        public int save_Tribunal()
        {
            Boolean bopassed = true;
            bopassed = check_rules("insert");

            int Res = 0;
            try
            {
                if (bopassed == true)
                {
                    objDAL.insert_tribunal(this.name, this.city, this.address);
                    Res = 1;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return Res;
        }

        #endregion

        #region Rules
        public bool check_rules(string sub)
        {
            if (sub == "del")
            {
                if (this.idTrib.Equals(0))
                {
                    return false;
                }
            }
            else
            {
                if (sub == "insert")
                {
                    if (this.name == "NULL" || (! CheckStringLatin(this.name)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool CheckStringArabic(string text)
        {
            Match match = Regex.Match(text, "[\u0600-\u06FF\u0750-\u077F ]");
            if (match.Success)
            {
                return true;
            }

            return false;
        }

        public bool CheckStringLatin(string text)
        {
            Match match = Regex.Match(text, "[a-zA-Z0-9 ]");
            if (match.Success)
            {
                return true;
            }

            return false;
        }
        #endregion
    }
}
