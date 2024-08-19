namespace DxfToPng
{
    partial class frmDxfToPng
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDxfToPng));
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::DxfToPng.WaitForm1), true, true);
            this.pnlTitleBar = new System.Windows.Forms.Panel();
            this.pnlWinfowsState = new System.Windows.Forms.Panel();
            this.btnMinimized = new System.Windows.Forms.Button();
            this.btnMaximized = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.topPanel = new System.Windows.Forms.Panel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.seçimÖlçütüToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.DeSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.ExcelTransfer = new System.Windows.Forms.ToolStripMenuItem();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.selectColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.nameColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LastWriteDateColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LastWriteHourColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.btnConvert = new System.Windows.Forms.Button();
            this.pnlTitleBar.SuspendLayout();
            this.pnlWinfowsState.SuspendLayout();
            this.mainLayout.SuspendLayout();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.bottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 500;
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
            this.pnlTitleBar.Size = new System.Drawing.Size(1098, 39);
            this.pnlTitleBar.TabIndex = 3;
            // 
            // pnlWinfowsState
            // 
            this.pnlWinfowsState.Controls.Add(this.btnMinimized);
            this.pnlWinfowsState.Controls.Add(this.btnMaximized);
            this.pnlWinfowsState.Controls.Add(this.btnClose);
            this.pnlWinfowsState.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlWinfowsState.Location = new System.Drawing.Point(973, 0);
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
            this.btnMinimized.Location = new System.Drawing.Point(2, 0);
            this.btnMinimized.Name = "btnMinimized";
            this.btnMinimized.Size = new System.Drawing.Size(41, 39);
            this.btnMinimized.TabIndex = 6;
            this.btnMinimized.UseVisualStyleBackColor = true;
            this.btnMinimized.Click += new System.EventHandler(this.btnMinimized_Click);
            // 
            // btnMaximized
            // 
            this.btnMaximized.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMaximized.FlatAppearance.BorderSize = 0;
            this.btnMaximized.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaximized.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnMaximized.ForeColor = System.Drawing.Color.White;
            this.btnMaximized.Image = ((System.Drawing.Image)(resources.GetObject("btnMaximized.Image")));
            this.btnMaximized.Location = new System.Drawing.Point(43, 0);
            this.btnMaximized.Name = "btnMaximized";
            this.btnMaximized.Size = new System.Drawing.Size(41, 39);
            this.btnMaximized.TabIndex = 5;
            this.btnMaximized.UseVisualStyleBackColor = true;
            this.btnMaximized.Click += new System.EventHandler(this.btnMaximized_Click);
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
            this.lblTitle.Size = new System.Drawing.Size(1098, 39);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "DXF TO PNG";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.DoubleClick += new System.EventHandler(this.lblTitle_MouseDoubleClick);
            this.lblTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblTitle_MouseDown);
            // 
            // mainLayout
            // 
            this.mainLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainLayout.ColumnCount = 1;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Controls.Add(this.topPanel, 0, 0);
            this.mainLayout.Controls.Add(this.bottomPanel, 0, 1);
            this.mainLayout.Location = new System.Drawing.Point(5, 47);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.RowCount = 2;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.mainLayout.Size = new System.Drawing.Size(1098, 528);
            this.mainLayout.TabIndex = 4;
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.gridControl1);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topPanel.Location = new System.Drawing.Point(3, 3);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1092, 469);
            this.topPanel.TabIndex = 0;
            // 
            // gridControl1
            // 
            this.gridControl1.ContextMenuStrip = this.contextMenuStrip1;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1092, 469);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seçimÖlçütüToolStripMenuItem,
            this.ExcelTransfer});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(146, 48);
            // 
            // seçimÖlçütüToolStripMenuItem
            // 
            this.seçimÖlçütüToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SelectAll,
            this.DeSelectAll});
            this.seçimÖlçütüToolStripMenuItem.Name = "seçimÖlçütüToolStripMenuItem";
            this.seçimÖlçütüToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.seçimÖlçütüToolStripMenuItem.Text = "Seçim Ölçütü";
            // 
            // SelectAll
            // 
            this.SelectAll.Name = "SelectAll";
            this.SelectAll.Size = new System.Drawing.Size(142, 22);
            this.SelectAll.Text = "Tümünü Seç";
            this.SelectAll.Click += new System.EventHandler(this.SelectAll_Click);
            // 
            // DeSelectAll
            // 
            this.DeSelectAll.Name = "DeSelectAll";
            this.DeSelectAll.Size = new System.Drawing.Size(142, 22);
            this.DeSelectAll.Text = "Seçimi Kaldır";
            this.DeSelectAll.Click += new System.EventHandler(this.DeSelectAll_Click);
            // 
            // ExcelTransfer
            // 
            this.ExcelTransfer.Name = "ExcelTransfer";
            this.ExcelTransfer.Size = new System.Drawing.Size(145, 22);
            this.ExcelTransfer.Text = "Excel\'e Aktar";
            this.ExcelTransfer.Click += new System.EventHandler(this.ExcelTransfer_Click);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.Color.LightGreen;
            this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView1.ColumnPanelRowHeight = 40;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.selectColumn,
            this.nameColumn,
            this.LastWriteDateColumn,
            this.LastWriteHourColumn});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowHeight = 30;
            this.gridView1.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanging);
            // 
            // selectColumn
            // 
            this.selectColumn.AppearanceCell.Options.UseTextOptions = true;
            this.selectColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.selectColumn.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.selectColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.selectColumn.AppearanceHeader.Options.UseFont = true;
            this.selectColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.selectColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.selectColumn.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.selectColumn.Caption = "Seç";
            this.selectColumn.FieldName = "Select";
            this.selectColumn.Name = "selectColumn";
            this.selectColumn.Visible = true;
            this.selectColumn.VisibleIndex = 0;
            // 
            // nameColumn
            // 
            this.nameColumn.AppearanceCell.Options.UseTextOptions = true;
            this.nameColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.nameColumn.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.nameColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.nameColumn.AppearanceHeader.Options.UseFont = true;
            this.nameColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.nameColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.nameColumn.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.nameColumn.Caption = "Ad";
            this.nameColumn.FieldName = "Name";
            this.nameColumn.Name = "nameColumn";
            this.nameColumn.OptionsColumn.ReadOnly = true;
            this.nameColumn.Visible = true;
            this.nameColumn.VisibleIndex = 1;
            // 
            // LastWriteDateColumn
            // 
            this.LastWriteDateColumn.AppearanceCell.Options.UseTextOptions = true;
            this.LastWriteDateColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.LastWriteDateColumn.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.LastWriteDateColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LastWriteDateColumn.AppearanceHeader.Options.UseFont = true;
            this.LastWriteDateColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.LastWriteDateColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.LastWriteDateColumn.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.LastWriteDateColumn.Caption = "Değiştirme Tarihi";
            this.LastWriteDateColumn.FieldName = "LastWriteDate";
            this.LastWriteDateColumn.Name = "LastWriteDateColumn";
            this.LastWriteDateColumn.OptionsColumn.ReadOnly = true;
            this.LastWriteDateColumn.Visible = true;
            this.LastWriteDateColumn.VisibleIndex = 2;
            // 
            // LastWriteHourColumn
            // 
            this.LastWriteHourColumn.AppearanceCell.Options.UseTextOptions = true;
            this.LastWriteHourColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.LastWriteHourColumn.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.LastWriteHourColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LastWriteHourColumn.AppearanceHeader.Options.UseFont = true;
            this.LastWriteHourColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.LastWriteHourColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.LastWriteHourColumn.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.LastWriteHourColumn.Caption = "Değiştirme Saati";
            this.LastWriteHourColumn.FieldName = "LastWriteHour";
            this.LastWriteHourColumn.Name = "LastWriteHourColumn";
            this.LastWriteHourColumn.OptionsColumn.ReadOnly = true;
            this.LastWriteHourColumn.Visible = true;
            this.LastWriteHourColumn.VisibleIndex = 3;
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.btnConvert);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bottomPanel.Location = new System.Drawing.Point(3, 478);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(1092, 47);
            this.bottomPanel.TabIndex = 1;
            // 
            // btnConvert
            // 
            this.btnConvert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConvert.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Tan;
            this.btnConvert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConvert.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnConvert.ForeColor = System.Drawing.Color.White;
            this.btnConvert.Location = new System.Drawing.Point(0, 0);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(1092, 47);
            this.btnConvert.TabIndex = 0;
            this.btnConvert.Text = "Seçilenler İçin Çevirme İşlemini Başlat";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // frmDxfToPng
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 580);
            this.Controls.Add(this.mainLayout);
            this.Controls.Add(this.pnlTitleBar);
            this.FormBorderColor = System.Drawing.Color.White;
            this.FormBorderThickness = 2;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDxfToPng";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmDxfToPng_Load);
            this.Shown += new System.EventHandler(this.frmDxfToPng_Shown);
            this.pnlTitleBar.ResumeLayout(false);
            this.pnlWinfowsState.ResumeLayout(false);
            this.mainLayout.ResumeLayout(false);
            this.topPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.bottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlTitleBar;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlWinfowsState;
        private System.Windows.Forms.Button btnMinimized;
        private System.Windows.Forms.Button btnMaximized;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Panel bottomPanel;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Button btnConvert;
        private DevExpress.XtraGrid.Columns.GridColumn nameColumn;
        private DevExpress.XtraGrid.Columns.GridColumn LastWriteDateColumn;
        private DevExpress.XtraGrid.Columns.GridColumn selectColumn;
        private DevExpress.XtraGrid.Columns.GridColumn LastWriteHourColumn;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem seçimÖlçütüToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SelectAll;
        private System.Windows.Forms.ToolStripMenuItem DeSelectAll;
        private System.Windows.Forms.ToolStripMenuItem ExcelTransfer;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
    }
}

