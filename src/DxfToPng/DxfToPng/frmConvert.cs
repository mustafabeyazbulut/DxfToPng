using DxfToPng.ViewModel;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DxfToPng
{
    public partial class frmConvert : DraggableForm
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
        private void lblTitle_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //if (WindowState == FormWindowState.Normal)
            //    this.WindowState = FormWindowState.Maximized;
            //else
            //    this.WindowState = FormWindowState.Normal;
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #endregion
        ProgressBarHelper progFolder;
        List<FolderViewModel> items;
        public frmConvert(List<FolderViewModel> _items)
        {
            InitializeComponent();
            items = _items;
            progFolder = new ProgressBarHelper(progressFolder, this);
        }
        private void frmConvert_Load(object sender, EventArgs e)
        {
            this.Show();
            Application.DoEvents();
            dxfToPng();
        }

        private void dxfToPng()
        {
            progFolder.SetupProgress(items.Count);
            Application.DoEvents();
            foreach (var item in items)
            {
                lblProgressFolder.Text = Properties.Settings.Default.FolderPath + @"\" + item.Name;
                progFolder.UpdateProgress();
                Application.DoEvents();
                DXFDAL.DrawThumbnails(Properties.Settings.Default.FolderPath + @"\" + item.Name);
            }
            lblTitle.Text = "İşlem Tamamlandı.";
        }
    }
}
