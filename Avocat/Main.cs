using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Avocat
{
    public partial class Main : Form
    {

        #region Attributes
        public String Clicked_Button = "btn_menu_folders";
        private List<TabPage> hiddenPages = new List<TabPage>();
        private List<TabPage> hiddenPagesSup = new List<TabPage>();
        #endregion

        #region Methodes

        public Main()
        {
            InitializeComponent();


            btn_menu_folders.MouseEnter += btn_MouseEnter;
            btn_menu_folders.MouseLeave += btn_MouseLeave;
            btn_menu_audience.MouseEnter += btn_MouseEnter;
            btn_menu_audience.MouseLeave += btn_MouseLeave;
            btn_menu_clients.MouseEnter += btn_MouseEnter;
            btn_menu_clients.MouseLeave += btn_MouseLeave;
            btn_menu_col.MouseEnter += btn_MouseEnter;
            btn_menu_col.MouseLeave += btn_MouseLeave;
            btn_menu_fees.MouseEnter += btn_MouseEnter;
            btn_menu_fees.MouseLeave += btn_MouseLeave;
            btn_menu_tasks.MouseEnter += btn_MouseEnter;
            btn_menu_tasks.MouseLeave += btn_MouseLeave;
            btn_menu_folders.Click += btn_Clicked;
            btn_menu_audience.Click += btn_Clicked;
            btn_menu_clients.Click += btn_Clicked;
            btn_menu_col.Click += btn_Clicked;
            btn_menu_fees.Click += btn_Clicked;
            btn_menu_tasks.Click += btn_Clicked;
            dateTimePicker1.DropDown += dateTimePicker1_DropDown;

            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();

            var picked = dateTimePicker1.Value;
            fn_calendar(picked);

            //EnablePage(aud_new_tabPage, false);
            TabControl.TabPageCollection tabPages = tabControl1.TabPages;

            foreach (TabPage tabP in tabPages)
            {
                hiddenPages.Add(tabP);
                hiddenPagesSup.Add(tabP);
                if (tabP.Name != "tabPage_desk" )
                {
                    EnablePage(tabP, false);                    
                }
            }

        }

        #region tabPage Control
        private void EnablePage(TabPage page, bool enable)
        {
            if (enable)
            {
                page.UseVisualStyleBackColor = false;
                tabControl1.TabPages.Add(page);
                //hiddenPages.Remove(page);
            }
            else
            {
                if (! page.Name.ToString().Contains("desk"))                
                    tabControl1.TabPages.Remove(page);
                //hiddenPages.Add(page);
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            foreach (var page in hiddenPages) page.Dispose();
            base.OnFormClosed(e);
        }
        #endregion

        #region Calendar
        private void fn_calendar(DateTime picked)
        {
            var today = new DateTime(picked.Year, picked.Month, 1);
            int day = (int)today.DayOfWeek;
            int days = DateTime.DaysInMonth(picked.Year, picked.Month);
            int a = 1;
            bool firstPassed = false;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (a > days)
                        break;

                    if (!firstPassed && (i == 0 && j != (day - 1)))
                        continue;

                    firstPassed = true;
                    dataGridView1.Rows[i].Cells[j].Value = a.ToString();
                    ++a;
                }
            }

            DataGridViewComboBoxCell cb = new DataGridViewComboBoxCell();
            cb.Items.Add("Mucha");
            cb.Items.Add("Mucho");
            cb.Items.Add("Muchi");
            cb.Items.Add("Muchu");
            cb.Items.Add("Muche");
            dataGridView1[1, 1] = cb;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            var picked = dateTimePicker1.Value;
            fn_calendar(picked);
        }

        #endregion

        #region datetime Picker show only months works only from WinVista and higher!!!!!!!
        private void dateTimePicker1_DropDown(object sender, EventArgs e)
        {
            IntPtr cal = SendMessage(dateTimePicker1.Handle, DTM_GETMONTHCAL, IntPtr.Zero, IntPtr.Zero);
            SendMessage(cal, MCM_SETCURRENTVIEW, IntPtr.Zero, (IntPtr)1);
        }

        // pinvoke:
        private const int DTM_GETMONTHCAL = 0x1000 + 8;
        private const int MCM_SETCURRENTVIEW = 0x1000 + 32;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
        #endregion

        #region General Buttons' properties 
        private void btn_Clicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
                btn.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.button_background_clicked));
            
            foreach (Button s in panel1.Controls.OfType<Button>())
            {
                if (s.Name != Clicked_Button)
                {
                    s.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.button_background_default));
                }
            }
        }

        private void btn_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn != null && (btn.Name != Clicked_Button))
            {
                btn.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.button_background));
            }

        }

        private void btn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            
            if (btn != null && (btn.Name != Clicked_Button))
            {
                btn.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.button_background_default));
            }
        }

        private void sub_btn_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn != null && (btn.Name != Clicked_Button))
            {
                btn.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.sub_button_background));
            }

        }

        private void sub_btn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn != null && (btn.Name != Clicked_Button))
            {
                btn.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.sub_button_background_default));
            }
        }

        private Button CreateButton(String btn_label, int btn_Y_loc)
        {
            Button myButton = new Button();
            myButton.Text = btn_label;
            myButton.Location = new Point(2, 100 + btn_Y_loc);

            myButton.Font = new Font("Courier New", 14, FontStyle.Bold);
            myButton.FlatAppearance.BorderSize = 1;
            myButton.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            myButton.Size = new System.Drawing.Size(200, 40);
            myButton.TabIndex = 0;
            myButton.FlatStyle = FlatStyle.Flat;
            myButton.FlatAppearance.BorderSize = 0;
            myButton.BackgroundImage = Avocat.Properties.Resources.sub_button_background_default;
            myButton.MouseEnter += sub_btn_MouseEnter;
            myButton.MouseLeave += sub_btn_MouseLeave;
            myButton.UseVisualStyleBackColor = true;

            return myButton;
        }
        #endregion

        #region Buttons
        private void btn_menu_folders_Click(object sender, EventArgs e)
        {
            //var page = new TabPage("Fuck you");
            //page.Name = "Fuck you";
            //tabControl1.TabPages.Add(page);
            //page.Select();
            Clicked_Button = "btn_menu_folders";
            selbtn.Text = btn_menu_folders.Text;

            Dictionary<int, String> btn_dic = new Dictionary<int, String>();
            btn_dic.Add(0, "ملف جديد");
            btn_dic.Add(1, "الملفات الجارية");
            btn_dic.Add(2, "بحث");
            btn_dic.Add(3, "وضع الملفات");

            for (int i = 0; i < btn_dic.Count - 1; i++)
            {
                panel3.Controls.Add(CreateButton(btn_dic[i], (i * 38)));
            }

            //hiddenPagesSup.Clear();
            //hiddenPagesSup.AddRange(hiddenPages);
            foreach (TabPage tPage in hiddenPagesSup)
            {
                if (tPage.Name.ToString().StartsWith("fld"))
                {
                    EnablePage(tPage, true);
                }
                else
                {
                    EnablePage(tPage, false);
                }
            }
            //hiddenPagesSup.Clear();
            //hiddenPagesSup.AddRange(hiddenPages);
        }

        private void btn_menu_audience_Click(object sender, EventArgs e)
        {
            Clicked_Button = "btn_menu_audience";
            selbtn.Text = btn_menu_audience.Text;


            Dictionary<int, String> btn_dic = new Dictionary<int, String>();
            btn_dic.Add(0, "ملف جديد");
            btn_dic.Add(1, "الملفات الجارية");
            btn_dic.Add(2, "الملفات المؤرشفة");
            btn_dic.Add(3, "بحث");
            btn_dic.Add(4, "وضع الملفات");

            for (int i = 0; i < 5; i++)
            {
                panel3.Controls.Add(CreateButton(btn_dic[i], (i * 38)));
            }

            //hiddenPagesSup.Clear();
            //hiddenPagesSup.AddRange(hiddenPages);
            foreach (TabPage tPage in hiddenPagesSup)
            {    
                if (tPage.Name.ToString().StartsWith("aud"))
                {

                    EnablePage(tPage, true);
                }
                else
                {
                    EnablePage(tPage, false);
                }
            }
            //hiddenPagesSup.Clear();
            //hiddenPagesSup.AddRange(hiddenPages);
        }

        private void btn_menu_clients_Click(object sender, EventArgs e)
        {
            Clicked_Button = "btn_menu_clients";
            selbtn.Text = btn_menu_clients.Text;

            foreach (TabPage tPage in hiddenPagesSup)
            {
                if (tPage.Name.ToString().StartsWith("clt"))
                {

                    EnablePage(tPage, true);
                }
                else
                {
                    EnablePage(tPage, false);
                }
            }
        }

        private void btn_menu_col_Click(object sender, EventArgs e)
        {
            Clicked_Button = "btn_menu_col";
            selbtn.Text = btn_menu_col.Text;

            foreach (TabPage tPage in hiddenPagesSup)
            {
                if (tPage.Name.ToString().StartsWith("clg"))
                {

                    EnablePage(tPage, true);
                }
                else
                {
                    EnablePage(tPage, false);
                }
            }
        }

        private void btn_menu_fees_Click(object sender, EventArgs e)
        {
            Clicked_Button = "btn_menu_fees";
            selbtn.Text = btn_menu_fees.Text;

            foreach (TabPage tPage in hiddenPagesSup)
            {
                if (tPage.Name.ToString().StartsWith("task"))
                {

                    EnablePage(tPage, true);
                }
                else
                {
                    EnablePage(tPage, false);
                }
            }
        }

        private void btn_menu_tasks_Click(object sender, EventArgs e)
        {
            Clicked_Button = "btn_menu_tasks";
            selbtn.Text = btn_menu_tasks.Text;
        }


        private void btn_newNF_nums_Click(object sender, EventArgs e)
        {
            FolderProperties FP = new FolderProperties();
            FP.ShowDialog();
        }

        private void btn_Flist_cancel_Click(object sender, EventArgs e)
        {
            FolderEvents FE = new FolderEvents();
            FE.ShowDialog();
        }

        private void btn_Flist_nums_Click(object sender, EventArgs e)
        {
            FolderNumbers FN = new FolderNumbers();
            using (var form = new FolderNumbers())
            {
                var result = form.ShowDialog();
                //if (result == DialogResult.OK)
                //{
                string val = form.ReturnValue1;
                string dateString = form.ReturnValue2;

                MessageBox.Show(val);
                //}
            }
        }
        #endregion

        #region DataGridViews Events
        private void dataGridView5_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int currentRow = int.Parse(e.RowIndex.ToString());
            if (e.RowIndex != -1)
	        {
                string id = dataGridView5[0, currentRow].Value.ToString();
                ClientEdit ceForm = new ClientEdit();
                ceForm.folderID = id;
            }
        }

        private void dataGridView6_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int currentRow = int.Parse(e.RowIndex.ToString());
            if (e.RowIndex != -1)
            {
                string id = dataGridView6[0, currentRow].Value.ToString();
                ClientEdit ceForm = new ClientEdit();
                ceForm.folderID = id;
            }
        }
        #endregion

        private void btn_Configform_Click(object sender, EventArgs e)
        {
            Configuration configForm = new Configuration();
            configForm.ShowDialog();
        }
        
        #endregion

    }
}
