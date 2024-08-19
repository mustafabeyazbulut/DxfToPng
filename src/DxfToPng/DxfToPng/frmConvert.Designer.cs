namespace DxfToPng
{
    partial class frmConvert
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConvert));
            this.pnlTitleBar = new System.Windows.Forms.Panel();
            this.pnlWinfowsState = new System.Windows.Forms.Panel();
            this.btnMinimized = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.progressFolder = new System.Windows.Forms.ProgressBar();
            this.lblProgressFolder = new System.Windows.Forms.Label();
            this.pnlTitleBar.SuspendLayout();
            this.pnlWinfowsState.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTitleBar
            // 
            this.pnlTitleBar.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.pnlTitleBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(50)))));
            this.pnlTitleBar.Controls.Add(this.pnlWinfowsState);
            this.pnlTitleBar.Controls.Add(this.lblTitle);
            this.pnlTitleBar.Location = new System.Drawing.Point(5, 5);
            this.pnlTitleBar.Name = "pnlTitleBar";
            this.pnlTitleBar.Size = new System.Drawing.Size(790, 39);
            this.pnlTitleBar.TabIndex = 4;
            // 
            // pnlWinfowsState
            // 
            this.pnlWinfowsState.Controls.Add(this.btnMinimized);
            this.pnlWinfowsState.Controls.Add(this.btnClose);
            this.pnlWinfowsState.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlWinfowsState.Location = new System.Drawing.Point(665, 0);
            this.pnlWinfowsState.Name = "pnlWinfowsState";
            this.pnlWinfowsState.Size = new System.Drawing.Size(125, 39);
            this.pnlWinfowsState.TabIndex = 5;
            // 
            // btnMinimized
            // 
            this.btnMinimized.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMinimized.FlatAppearance.BorderSize = 0;
            this.btnMinimized.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimized.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnMinimized.ForeColor = System.Drawing.Color.White;
            this.btnMinimized.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimized.Image")));
            this.btnMinimized.Location = new System.Drawing.Point(43, 0);
            this.btnMinimized.Name = "btnMinimized";
            this.btnMinimized.Size = new System.Drawing.Size(41, 39);
            this.btnMinimized.TabIndex = 6;
            this.btnMinimized.UseVisualStyleBackColor = true;
            this.btnMinimized.Click += new System.EventHandler(this.btnMinimized_Click);
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(84, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(41, 39);
            this.btnClose.TabIndex = 4;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(790, 39);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "İşlem Başlatıldı";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lblTitle_MouseDoubleClick);
            this.lblTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblTitle_MouseDown);
            // 
            // progressFolder
            // 
            this.progressFolder.Location = new System.Drawing.Point(11, 85);
            this.progressFolder.Name = "progressFolder";
            this.progressFolder.Size = new System.Drawing.Size(778, 42);
            this.progressFolder.TabIndex = 5;
            // 
            // lblProgressFolder
            // 
            this.lblProgressFolder.ForeColor = System.Drawing.Color.White;
            this.lblProgressFolder.Location = new System.Drawing.Point(11, 59);
            this.lblProgressFolder.Name = "lblProgressFolder";
            this.lblProgressFolder.Size = new System.Drawing.Size(778, 23);
            this.lblProgressFolder.TabIndex = 6;
            // 
            // frmConvert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 146);
            this.Controls.Add(this.lblProgressFolder);
            this.Controls.Add(this.progressFolder);
            this.Controls.Add(this.pnlTitleBar);
            this.FormBorderColor = System.Drawing.Color.IndianRed;
            this.FormBorderThickness = 2;
            this.Name = "frmConvert";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmConvert";
            this.Load += new System.EventHandler(this.frmConvert_Load);
            this.pnlTitleBar.ResumeLayout(false);
            this.pnlWinfowsState.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitleBar;
        private System.Windows.Forms.Panel pnlWinfowsState;
        private System.Windows.Forms.Button btnMinimized;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ProgressBar progressFolder;
        private System.Windows.Forms.Label lblProgressFolder;
    }
}