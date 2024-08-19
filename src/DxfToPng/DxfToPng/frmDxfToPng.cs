using DxfToPng.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DxfToPng
{
    public partial class frmDxfToPng : DraggableForm
    {
        #region Draggable
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private void lblTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void btnMaximized_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }
        private void btnMinimized_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void lblTitle_MouseDoubleClick(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #endregion
        public frmDxfToPng()
        {
            InitializeComponent();
        }
        private void frmDxfToPng_Shown(object sender, EventArgs e)
        {

        }
        private void frmDxfToPng_Load(object sender, EventArgs e)
        {
            this.Show();
            Application.DoEvents();
            getFolderList();
        }
        private void getFolderList()
        {
            splashScreenManager1.ShowWaitForm();
            List<FolderViewModel> folderList = new List<FolderViewModel>();
            DirectoryInfo di = new DirectoryInfo(Properties.Settings.Default.FolderPath);
            DirectoryInfo[] dirs = di.GetDirectories();
            foreach (var dir in dirs)
            {
                FolderViewModel folderViewModel = new FolderViewModel
                {
                    Select = false,
                    Name = dir.Name,
                    LastWriteDate = dir.LastWriteTime.ToString("dd-MM-yyyy"),
                    LastWriteHour = dir.LastWriteTime.ToString("hh:mm")
                };
                folderList.Add(folderViewModel);
            }
            gridControl1.DataSource = folderList;
            GridHelper.GridViewSekillendir(gridView1);
            splashScreenManager1.CloseWaitForm();
        }

        private void ExcelTransfer_Click(object sender, EventArgs e)
        {
            GridHelper.ExportExcel(gridView1, "DxfFolder");
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Select") // değişikliğin hemen uygulanması için ekledim.
            {
                gridView1.SetRowCellValue(e.RowHandle, "Select", e.Value);
            }
        }

        private void SelectAll_Click(object sender, EventArgs e)
        {
            var list = (List<FolderViewModel>)gridControl1.DataSource;
            if (list.Count < 1)
            {
                return;
            }
            list = null;

            for (int i = 0; i < gridView1.DataRowCount; i++)
            {
                gridView1.SetRowCellValue(i, "Select", true);
            }
            gridView1.RefreshData();
        }

        private void DeSelectAll_Click(object sender, EventArgs e)
        {
            var list = (List<FolderViewModel>)gridControl1.DataSource;
            if (list.Count < 1)
            {
                return;
            }
            list = null;

            for (int i = 0; i < gridView1.DataRowCount; i++)
            {
                gridView1.SetRowCellValue(i, "Select", false);
            }
            gridView1.RefreshData();
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            var list = (List<FolderViewModel>)gridControl1.DataSource;
            if (list.Count < 1)
            {
                return;
            }
            var items = list.AsEnumerable().Where(r => r.Select == true);
            if (items.Count() < 1)
            {
                return;
            }
            list = null;
            frmConvert frmConvert = new frmConvert(items.ToList());
            frmConvert.ShowDialog();
            getFolderList();
        }
    }
}
