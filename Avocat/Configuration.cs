using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Avocat
{
    public partial class Configuration : Form
    {
        public Configuration()
        {
            InitializeComponent();
        }

        private void btn_AddJuridiction_Click(object sender, EventArgs e)
        {
            SubForm_Juridiction subf_JUR = new SubForm_Juridiction();
            subf_JUR.ShowDialog();
        }

        private void Configuration_Load(object sender, EventArgs e)
        {
            AvocatBLL.Classes.Tribunal AvocBLLJuridition = new AvocatBLL.Classes.Tribunal();
            DataTable dt = AvocBLLJuridition.loadTribunal();
            //listBoxJuridiction.DataSource = AvocBLLJuridition.loadTribunal();
            //listBoxJuridiction.DisplayMember = "Name";
            //listBoxJuridiction.ValueMember = "ID_Trib";
            foreach (DataRow row in dt.Rows)
            {
                string name = row["name"].ToString();
                string city = row["city"].ToString();
                listBoxJuridiction.Items.Add(string.Format("{0} | {1}", name, city));
            }
        }
    }
}
