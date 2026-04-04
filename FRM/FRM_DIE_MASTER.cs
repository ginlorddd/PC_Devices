using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using PC_Devices.DTO;
using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;

namespace PC_Devices.FRM
{
    public class FRM_DIE_MASTER : XtraForm
    {
        private readonly DieMasterDTO _dto = new DieMasterDTO();
        private readonly GridControl grid = new GridControl();
        private readonly GridView view = new GridView();
        private readonly TextEdit txtDieNo = new TextEdit();
        private readonly TextEdit txtDieName = new TextEdit();
        private readonly SpinEdit spCavity = new SpinEdit();

        public FRM_DIE_MASTER()
        {
            Text = "Die Master";
            Width = 1100;
            Height = 700;

            PanelControl panel = new PanelControl { Dock = DockStyle.Top, Height = 120 };
            Controls.Add(panel);

            panel.Controls.Add(new LabelControl { Text = "Số khuôn", Left = 15, Top = 20 });
            panel.Controls.Add(new LabelControl { Text = "Tên khuôn", Left = 15, Top = 55 });
            panel.Controls.Add(new LabelControl { Text = "Tổng số cavity", Left = 370, Top = 20 });

            txtDieNo.SetBounds(95, 15, 220, 25);
            txtDieName.SetBounds(95, 50, 250, 25);
            spCavity.SetBounds(470, 15, 120, 25);
            spCavity.Properties.IsFloatValue = false;
            spCavity.Properties.MinValue = 1;
            spCavity.Properties.MaxValue = 100;

            panel.Controls.Add(txtDieNo);
            panel.Controls.Add(txtDieName);
            panel.Controls.Add(spCavity);

            SimpleButton btnSave = new SimpleButton { Text = "Thêm/Sửa", Left = 620, Top = 15, Width = 95 };
            SimpleButton btnDelete = new SimpleButton { Text = "Xóa", Left = 725, Top = 15, Width = 95 };
            SimpleButton btnExport = new SimpleButton { Text = "Export", Left = 830, Top = 15, Width = 95 };
            SimpleButton btnImport = new SimpleButton { Text = "Import Excel", Left = 935, Top = 15, Width = 120 };

            btnSave.Click += (s, e) =>
            {
                _dto.Save(txtDieNo.Text.Trim(), txtDieName.Text.Trim(), Convert.ToInt32(spCavity.Value));
                LoadData();
            };
            btnDelete.Click += (s, e) =>
            {
                _dto.Delete(txtDieNo.Text.Trim());
                LoadData();
            };
            btnExport.Click += BtnExport_Click;
            btnImport.Click += BtnImport_Click;

            panel.Controls.Add(btnSave);
            panel.Controls.Add(btnDelete);
            panel.Controls.Add(btnExport);
            panel.Controls.Add(btnImport);

            grid.Dock = DockStyle.Fill;
            grid.MainView = view;
            grid.ViewCollection.Add(view);
            Controls.Add(grid);

            view.RowClick += View_RowClick;
            Load += (s, e) => LoadData();
        }

        private void LoadData()
        {
            grid.DataSource = _dto.GetAll();
            view.BestFitColumns();
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
