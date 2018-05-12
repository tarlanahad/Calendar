namespace Calendar
{
    partial class EventItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.location = new System.Windows.Forms.Label();
            this.title = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.time = new System.Windows.Forms.Label();
            this.brightPanel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // location
            // 
            this.location.AutoSize = true;
            this.location.Font = new System.Drawing.Font("Bahnschrift", 7.25F);
            this.location.ForeColor = System.Drawing.Color.White;
            this.location.Location = new System.Drawing.Point(58, 28);
            this.location.MaximumSize = new System.Drawing.Size(130, 0);
            this.location.Name = "location";
            this.location.Size = new System.Drawing.Size(62, 12);
            this.location.TabIndex = 13;
            this.location.Text = "28 May, Baku";
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Bahnschrift", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.Color.White;
            this.title.Location = new System.Drawing.Point(57, 12);
            this.title.MaximumSize = new System.Drawing.Size(130, 13);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(119, 13);
            this.title.TabIndex = 12;
            this.title.Text = "Meeting with investors";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(58)))));
            this.panel1.Controls.Add(this.time);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(51, 62);
            this.panel1.TabIndex = 14;
            // 
            // time
            // 
            this.time.Dock = System.Windows.Forms.DockStyle.Top;
            this.time.Font = new System.Drawing.Font("Bahnschrift SemiLight", 9.25F);
            this.time.ForeColor = System.Drawing.Color.White;
            this.time.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.time.Location = new System.Drawing.Point(0, 0);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(51, 25);
            this.time.TabIndex = 13;
            this.time.Text = "12:00 AM";
            // 
            // brightPanel
            // 
            this.brightPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.brightPanel.Location = new System.Drawing.Point(49, 0);
            this.brightPanel.Name = "brightPanel";
            this.brightPanel.Size = new System.Drawing.Size(219, 62);
            this.brightPanel.TabIndex = 15;
            // 
            // EventItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(63)))), ((int)(((byte)(86)))));
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.location);
            this.Controls.Add(this.title);
            this.Controls.Add(this.brightPanel);
            this.Name = "EventItem";
            this.Size = new System.Drawing.Size(268, 62);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label location;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel brightPanel;
        private System.Windows.Forms.Label time;



    }
}
