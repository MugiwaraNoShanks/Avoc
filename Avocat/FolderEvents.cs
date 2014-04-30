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
    public partial class FolderEvents : Form
    {
        public FolderEvents()
        {
            
         

            InitializeComponent();

        }

        protected override void OnPaint(PaintEventArgs e)
        {
           Graphics g = this.CreateGraphics();
            g.DrawLine(new Pen(Color.Black), 20, 350, 450, 350);
        }
    }
}
