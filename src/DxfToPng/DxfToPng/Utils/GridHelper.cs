using DevExpress.Export;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

public class GridHelper
{
    public static void GridViewSekillendir(GridView gridView)
    {
        gridView.OptionsBehavior.AllowAddRows = DefaultBoolean.False;
        gridView.OptionsBehavior.AllowDeleteRows = DefaultBoolean.False;
        gridView.OptionsFind.AlwaysVisible = true;
        gridView.OptionsView.ShowAutoFilterRow = true;
        gridView.OptionsView.ShowFooter = false;
        //gridView.OptionsBehavior.Editable = false;
        gridView.OptionsBehavior.ReadOnly = false;
        gridView.OptionsFind.FindNullPrompt = "Aradığınız kelimeyi giriniz...";
        gridView.OptionsFind.FindMode = FindMode.Always;
        gridView.OptionsFind.FindDelay = 100;
        gridView.Appearance.FocusedCell.BackColor = Color.LightGreen;
        gridView.Appearance.FocusedRow.BackColor = Color.LightGreen;
        gridView.Appearance.HideSelectionRow.BackColor = Color.LightGreen;
    }
    public static void ExportExcel(GridView view, string raporAdi, ExportType exportType = ExportType.WYSIWYG, TextExportMode textExportMode = TextExportMode.Text)
    {
        //ExceleKaydet(gridView1, "Rapor", ExportType.WYSIWYG, TextExportMode.Text);
        string dosyaAdi = string.Format("{0}_{1:yyyyMMddHHmm}.xlsx", raporAdi, DateTime.Now);


        var saveFileDialog = new SaveFileDialog
        {
            FileName = dosyaAdi,
            Filter = @"Excel Çalışma Kitabı |*.xlsx",
            InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        };

        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
            var options = new XlsxExportOptionsEx
            {
                ExportType = exportType,
                SheetName = dosyaAdi,
                ShowGroupSummaries = DefaultBoolean.Default,
                TextExportMode = textExportMode
            };

            view.OptionsPrint.AutoWidth = true;
            view.ExportToXlsx(saveFileDialog.FileName, options);

            if (MessageBox.Show(@"Excel dosyasını hemen açmak istiyor musunuz?", @"Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Process.Start(saveFileDialog.FileName);
            }
        }
    }
    public static void FocusedRow(GridView gridView, string column, object value)
    {
        #region Focused New Row
        int rowHandle = gridView.LocateByValue(column, value); // "column" sütun adındaki değeri arar
        if (rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
        {
            gridView.FocusedRowHandle = rowHandle;
        }
        #endregion
    }
}
