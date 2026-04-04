using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using PC_Devices.DTO;
using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;

namespace PC_Devices.FRM
{
    public partial class FRM_DIE_MASTER : XtraForm
    {
        private readonly DieMasterDTO _dto = new DieMasterDTO();

        public FRM_DIE_MASTER()
        {
            InitializeComponent();
            btnSave.ImageOptions.Image = DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/add_16x16.png");
            btnDelete.ImageOptions.Image = DevExpress.Images.ImageResourceCache.Default.GetImage("images/edit/delete_16x16.png");
            btnExport.ImageOptions.Image = DevExpress.Images.ImageResourceCache.Default.GetImage("images/export/exporttoxlsx_16x16.png");
            btnImport.ImageOptions.Image = DevExpress.Images.ImageResourceCache.Default.GetImage("images/import/import_16x16.png");

            btnSave.Click += BtnSave_Click;
            btnDelete.Click += BtnDelete_Click;
            btnExport.Click += BtnExport_Click;
            btnImport.Click += BtnImport_Click;
            view.RowClick += View_RowClick;
            ConfigureGridView();
            Load += (s, e) => LoadData();
        }


        private void ConfigureGridView()
        {
            view.OptionsView.ShowAutoFilterRow = true;
            view.OptionsView.ShowGroupPanel = false;
            view.OptionsView.ColumnAutoWidth = false;
            view.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            view.Appearance.HeaderPanel.Options.UseFont = true;
        }

        private void ApplyColumnCaptions()
        {
            if (view.Columns["DIE_NO"] != null) view.Columns["DIE_NO"].Caption = "Số khuôn";
            if (view.Columns["DIE_NAME"] != null) view.Columns["DIE_NAME"].Caption = "Tên khuôn";
            if (view.Columns["TOTAL_CAVITY"] != null) view.Columns["TOTAL_CAVITY"].Caption = "Tổng số cavity";
            view.BestFitColumns();
        }

        private void LoadData()
        {
            grid.DataSource = _dto.GetAll();
            ApplyColumnCaptions();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            _dto.Save(txtDieNo.Text.Trim(), txtDieName.Text.Trim(), Convert.ToInt32(spCavity.Value));
            LoadData();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            _dto.Delete(txtDieNo.Text.Trim());
            LoadData();
        }

        private void View_RowClick(object sender, RowClickEventArgs e)
        {
            if (e.RowHandle < 0) return;
            txtDieNo.Text = view.GetRowCellDisplayText(e.RowHandle, "DIE_NO");
            txtDieName.Text = view.GetRowCellDisplayText(e.RowHandle, "DIE_NAME");
            spCavity.Value = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, "TOTAL_CAVITY"));
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog { Filter = "Excel (*.xlsx)|*.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    grid.ExportToXlsx(sfd.FileName);
                    XtraMessageBox.Show("Export thành công: " + sfd.FileName);
                }
            }
        }

        private void BtnImport_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog { Filter = "Excel (*.xlsx;*.xls)|*.xlsx;*.xls" })
            {
                if (ofd.ShowDialog() != DialogResult.OK) return;

                DataTable source = ReadExcel(ofd.FileName);
                foreach (DataRow row in source.Rows)
                {
                    string dieNo = Convert.ToString(row[0]).Trim();
                    string dieName = Convert.ToString(row[1]).Trim();
                    int cavity = Convert.ToInt32(row[2]);
                    if (!string.IsNullOrWhiteSpace(dieNo))
                    {
                        _dto.Save(dieNo, dieName, cavity);
                    }
                }
                LoadData();
                XtraMessageBox.Show("Import thành công.");
            }
        }

        private DataTable ReadExcel(string filePath)
        {
            string ext = Path.GetExtension(filePath).ToLower();
            string connStr = ext == ".xls"
                ? $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={filePath};Extended Properties='Excel 8.0;HDR=YES'"
                : $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filePath};Extended Properties='Excel 12.0 Xml;HDR=YES'";

            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                conn.Open();
                DataTable schema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string sheetName = schema.Rows[0]["TABLE_NAME"].ToString();
                using (OleDbDataAdapter ad = new OleDbDataAdapter($"SELECT * FROM [{sheetName}]", conn))
                {
                    DataTable dt = new DataTable();
                    ad.Fill(dt);
                    return dt;
                }
            }
        }
    }
}
