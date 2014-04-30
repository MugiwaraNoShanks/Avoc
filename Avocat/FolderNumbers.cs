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
    public partial class FolderNumbers : Form
    {
        public string ReturnValue1 { get; set; }
        public string ReturnValue2 { get; set; }
        
        public FolderNumbers()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.ReturnValue1 = "Something";
            this.ReturnValue2 = DateTime.Now.ToString();
            this.Close();
        }
    }
}
