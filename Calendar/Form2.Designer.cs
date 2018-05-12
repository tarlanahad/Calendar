namespace Calendar
{
    partial class Form2
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
            this.add = new System.Windows.Forms.Button();
            this.am_pm = new System.Windows.Forms.Button();
            this.selectedDate = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cancel = new System.Windows.Forms.PictureBox();
            this.minuteTxt = new Calendar.TextBoxPlaceHolder();
            this.hourTxt = new Calendar.TextBoxPlaceHolder();
            this.eventLocation = new Calendar.TextBoxPlaceHolder();
            this.eventTitle = new Calendar.TextBoxPlaceHolder();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cancel)).BeginInit();
            this.SuspendLayout();
            // 
            // add
            // 
            this.add.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.add.ForeColor = System.Drawing.Color.White;
            this.add.Location = new System.Drawing.Point(12, 171);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(214, 29);
            this.add.TabIndex = 12;
            this.add.Text = "Add event";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // am_pm
            // 
            this.am_pm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.am_pm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.am_pm.ForeColor = System.Drawing.Color.White;
            this.am_pm.Location = new System.Drawing.Point(108, 113);
            this.am_pm.Name = "am_pm";
            this.am_pm.Size = new System.Drawing.Size(45, 30);
            this.am_pm.TabIndex = 11;
            this.am_pm.Text = "AM";
            this.am_pm.UseVisualStyleBackColor = true;
            this.am_pm.Click += new System.EventHandler(this.am_pm_Click);
            // 
            // selectedDate
            // 
            this.selectedDate.AutoSize = true;
            this.selectedDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.selectedDate.Location = new System.Drawing.Point(12, 9);
            this.selectedDate.Name = "selectedDate";
            this.selectedDate.Size = new System.Drawing.Size(97, 20);
            this.selectedDate.TabIndex = 15;
            this.selectedDate.Text = "18 Jan 2018";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Calendar.Properties.Resources.icon_location;
            this.pictureBox2.Location = new System.Drawing.Point(206, 79);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(25, 25);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 17;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Calendar.Properties.Resources.icon_title;
            this.pictureBox1.Location = new System.Drawing.Point(206, 42);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // cancel
            // 
            this.cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancel.Image = global::Calendar.Properties.Resources.icon_cancel;
            this.cancel.Location = new System.Drawing.Point(201, 6);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(25, 25);
            this.cancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cancel.TabIndex = 13;
            this.cancel.TabStop = false;
            this.cancel.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // minuteTxt
            // 
            this.minuteTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(61)))), ((int)(((byte)(85)))));
            this.minuteTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.minuteTxt.ForeColor = System.Drawing.Color.White;
            this.minuteTxt.Location = new System.Drawing.Point(60, 113);
            this.minuteTxt.MaxLength = 2;
            this.minuteTxt.Name = "minuteTxt";
            this.minuteTxt.Size = new System.Drawing.Size(42, 30);
            this.minuteTxt.TabIndex = 14;
            this.minuteTxt.Text = "00";
            this.minuteTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // hourTxt
            // 
            this.hourTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(61)))), ((int)(((byte)(85)))));
            this.hourTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.hourTxt.ForeColor = System.Drawing.Color.White;
            this.hourTxt.Location = new System.Drawing.Point(12, 113);
            this.hourTxt.MaxLength = 2;
            this.hourTxt.Name = "hourTxt";
            this.hourTxt.Size = new System.Drawing.Size(42, 30);
            this.hourTxt.TabIndex = 9;
            this.hourTxt.Text = "12";
            this.hourTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // eventLocation
            // 
            this.eventLocation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(61)))), ((int)(((byte)(85)))));
            this.eventLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.eventLocation.ForeColor = System.Drawing.Color.White;
            this.eventLocation.Location = new System.Drawing.Point(12, 77);
            this.eventLocation.Name = "eventLocation";
            this.eventLocation.Size = new System.Drawing.Size(188, 30);
            this.eventLocation.TabIndex = 8;
            // 
            // eventTitle
            // 
            this.eventTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(61)))), ((int)(((byte)(85)))));
            this.eventTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.eventTitle.ForeColor = System.Drawing.Color.White;
            this.eventTitle.Location = new System.Drawing.Point(12, 41);
            this.eventTitle.Multiline = true;
            this.eventTitle.Name = "eventTitle";
            this.eventTitle.Size = new System.Drawing.Size(188, 30);
            this.eventTitle.TabIndex = 7;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(61)))), ((int)(((byte)(85)))));
            this.ClientSize = new System.Drawing.Size(238, 219);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.selectedDate);
            this.Controls.Add(this.minuteTxt);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.add);
            this.Controls.Add(this.am_pm);
            this.Controls.Add(this.hourTxt);
            this.Controls.Add(this.eventLocation);
            this.Controls.Add(this.eventTitle);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cancel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox cancel;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button am_pm;
        private TextBoxPlaceHolder hourTxt;
        private TextBoxPlaceHolder eventLocation;
        private TextBoxPlaceHolder eventTitle;
        private TextBoxPlaceHolder minuteTxt;
        private System.Windows.Forms.Label selectedDate;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;


    }
}