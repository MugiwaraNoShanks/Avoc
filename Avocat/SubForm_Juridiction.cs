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
    public partial class SubForm_Juridiction : Form
    {
        public int identifier { get; set; }
        public string name { get; set; }
        public string city { get; set; }
        public string address { get; set; }

        public SubForm_Juridiction()
        {
            InitializeComponent();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                AvocatBLL.Classes.Tribunal Trib = new AvocatBLL.Classes.Tribunal();
                Trib.name = txtBox_City.Text;
                Trib.city = txtBox_Name.Text;
                Trib.address = txtBox_Address.Text;

                int res = 1;
                    Trib.save_Tribunal();

                if (res.Equals(1))
                {
                    MessageBox.Show("Court Added Succefully");
                }
                else
                {
                    MessageBox.Show("There was a probleme");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void btn_Cancel(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
