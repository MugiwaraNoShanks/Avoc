namespace Avocat
{
    partial class SubForm_Juridiction
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtBox_City = new System.Windows.Forms.TextBox();
            this.txtBox_Name = new System.Windows.Forms.TextBox();
            this.txtBox_Address = new System.Windows.Forms.TextBox();
            this.btn_Save = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.CourtName = new System.Windows.Forms.Label();
            this.CourtCity = new System.Windows.Forms.Label();
            this.txtBox_ID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtBox_City
            // 
            this.txtBox_City.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBox_City.Location = new System.Drawing.Point(27, 47);
            this.txtBox_City.Name = "txtBox_City";
            this.txtBox_City.Size = new System.Drawing.Size(100, 26);
            this.txtBox_City.TabIndex = 0;
            // 
            // txtBox_Name
            // 
            this.txtBox_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBox_Name.Location = new System.Drawing.Point(214, 48);
            this.txtBox_Name.Name = "txtBox_Name";
            this.txtBox_Name.Size = new System.Drawing.Size(100, 26);
            this.txtBox_Name.TabIndex = 1;
            // 
            // txtBox_Address
            // 
            this.txtBox_Address.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBox_Address.Location = new System.Drawing.Point(27, 90);
            this.txtBox_Address.Name = "txtBox_Address";
            this.txtBox_Address.Size = new System.Drawing.Size(388, 26);
            this.txtBox_Address.TabIndex = 2;
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(126, 131);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 3;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(27, 131);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btn_Cancel);
            // 
            // CourtName
            // 
            this.CourtName.AutoSize = true;
            this.CourtName.Location = new System.Drawing.Point(338, 50);
            this.CourtName.Name = "CourtName";
            this.CourtName.Size = new System.Drawing.Size(38, 13);
            this.CourtName.TabIndex = 5;
            this.CourtName.Text = "NAME";
            // 
            // CourtCity
            // 
            this.CourtCity.AutoSize = true;
            this.CourtCity.Location = new System.Drawing.Point(146, 55);
            this.CourtCity.Name = "CourtCity";
            this.CourtCity.Size = new System.Drawing.Size(31, 13);
            this.CourtCity.TabIndex = 6;
            this.CourtCity.Text = "CITY";
            // 
            // txtBox_ID
            // 
            this.txtBox_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBox_ID.Location = new System.Drawing.Point(214, 12);
            this.txtBox_ID.Name = "txtBox_ID";
            this.txtBox_ID.ReadOnly = true;
            this.txtBox_ID.Size = new System.Drawing.Size(162, 26);
            this.txtBox_ID.TabIndex = 7;
            // 
            // SubForm_Juridiction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 169);
            this.Controls.Add(this.txtBox_ID);
            this.Controls.Add(this.CourtCity);
            this.Controls.Add(this.CourtName);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.txtBox_Address);
            this.Controls.Add(this.txtBox_Name);
            this.Controls.Add(this.txtBox_City);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SubForm_Juridiction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SubForm_Juridiction";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBox_City;
        private System.Windows.Forms.TextBox txtBox_Name;
        private System.Windows.Forms.TextBox txtBox_Address;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label CourtName;
        private System.Windows.Forms.Label CourtCity;
        private System.Windows.Forms.TextBox txtBox_ID;
    }
}