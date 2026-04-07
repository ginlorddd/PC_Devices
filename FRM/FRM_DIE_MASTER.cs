using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DM_OHD.DB;
using DM_OHD.DTO;
using System;
using System.Data;
using System.Xml;
using System.IO.Compression;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;

namespace DM_OHD.FRM
{
    public partial class FRM_DIE_MASTER : XtraForm
    {
        private readonly DieMasterDTO _dto = new DieMasterDTO();

        public FRM_DIE_MASTER()
        {
            InitializeComponent();

            btnSave.Click += BtnSave_Click;
            btnDelete.Click += BtnDelete_Click;
            btnExport.Click += BtnExport_Click;
            btnImport.Click += BtnImport_Click;
            view.DoubleClick += View_DoubleClick;
            ConfigureGridView();
            ApplyPermissions();
            Load += (s, e) => LoadData();
        }

        private void ApplyPermissions()
        {
            bool canSave = HasPermission("DIE_MST_MGMT", "DIE_MST_SAVE");
            bool canDelete = HasPermission("DIE_MST_MGMT", "DIE_MST_DELETE");
            bool canImport = HasPermission("DIE_MST_MGMT", "DIE_MST_IMPORT");
            bool canExport = HasPermission("DIE_MST_MGMT", "DIE_MST_EXPORT");

            btnSave.Enabled = canSave;
            btnDelete.Enabled = canDelete;
            btnImport.Enabled = canImport;
            btnExport.Enabled = canExport;
        }

        private bool HasPermission(params string[] roles)
        {
            if (Constaint.IsAdmin()) return true;
            return roles.Any(Constaint.HasRole);
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
            if (view.Columns["STT"] != null) view.Columns["STT"].Caption = "STT";
            if (view.Columns["DIE_NO"] != null) view.Columns["DIE_NO"].Caption = "Số khuôn";
            if (view.Columns["DIE_NAME"] != null) view.Columns["DIE_NAME"].Caption = "Tên khuôn";
            if (view.Columns["TOTAL_CAVITY"] != null) view.Columns["TOTAL_CAVITY"].Caption = "Tổng số cavity";
            view.BestFitColumns();
        }

        private void EnsureSttColumn()
        {
            if (view.Columns["STT"] == null)
            {
                GridColumn col = view.Columns.AddVisible("STT", "STT");
                col.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
                col.OptionsColumn.AllowEdit = false;
                col.VisibleIndex = 0;
                col.Width = 55;
                col.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            }

            view.CustomUnboundColumnData -= View_CustomUnboundColumnData;
            view.CustomUnboundColumnData += View_CustomUnboundColumnData;
        }

        private void View_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "STT" && e.IsGetData)
            {
                e.Value = e.ListSourceRowIndex + 1;
            }
        }

        private void LoadData()
        {
            grid.DataSource = _dto.GetAll();
            view.PopulateColumns();
            EnsureSttColumn();
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

        private void View_DoubleClick(object sender, EventArgs e)
        {
            int rowHandle = view.FocusedRowHandle;
            if (rowHandle < 0) return;
            txtDieNo.Text = view.GetRowCellDisplayText(rowHandle, "DIE_NO");
            txtDieName.Text = view.GetRowCellDisplayText(rowHandle, "DIE_NAME");
            spCavity.Value = Convert.ToDecimal(view.GetRowCellValue(rowHandle, "TOTAL_CAVITY"));
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
                int okCount = 0;
                int skipCount = 0;

                foreach (DataRow row in source.Rows)
                {
                    string dieNo = GetFieldValue(row, "Số khuôn", "so khuon", "die_no", "die no");
                    string dieName = GetFieldValue(row, "Tên khuôn", "ten khuon", "die_name", "die name");
                    string cavityText = GetFieldValue(row, "Tổng số cavity", "tong so cavity", "cavity", "total_cavity");

                    if (string.IsNullOrWhiteSpace(dieNo))
                    {
                        skipCount++;
                        continue;
                    }

                    if (!int.TryParse(cavityText, out int cavity))
                    {
                        skipCount++;
                        continue;
                    }

                    _dto.Save(dieNo.Trim(), dieName.Trim(), cavity);
                    okCount++;
                }

                LoadData();
                XtraMessageBox.Show($"Import xong. Thành công: {okCount}, Bỏ qua: {skipCount}");
            }
        }

        private string GetFieldValue(DataRow row, params string[] candidateHeaders)
        {
            foreach (DataColumn col in row.Table.Columns)
            {
                string normalized = NormalizeHeader(col.ColumnName);
                foreach (string candidate in candidateHeaders)
                {
                    if (normalized == NormalizeHeader(candidate))
                    {
                        return Convert.ToString(row[col] ?? string.Empty);
                    }
                }
            }
            return string.Empty;
        }

        private string NormalizeHeader(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return string.Empty;
            string normalized = text.Trim().ToLowerInvariant().Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();
            foreach (char c in normalized)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(c);
                if (uc != UnicodeCategory.NonSpacingMark && char.IsLetterOrDigit(c))
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        private DataTable ReadExcel(string filePath)
        {
            string ext = Path.GetExtension(filePath).ToLowerInvariant();
            if (ext == ".xlsx")
            {
                return ReadXlsx(filePath);
            }

            throw new NotSupportedException("Định dạng .xls cần Microsoft Access Database Engine. Vui lòng lưu file thành .xlsx để import.");
        }

        private DataTable ReadXlsx(string filePath)
        {
            DataTable table = new DataTable();

            using (ZipArchive archive = ZipFile.OpenRead(filePath))
            {
                List<string> sharedStrings = ReadSharedStrings(archive);
                string sheetPath = GetFirstSheetPath(archive);
                ZipArchiveEntry sheetEntry = archive.GetEntry(sheetPath);
                if (sheetEntry == null)
                {
                    throw new Exception("Không tìm thấy sheet trong file excel.");
                }

                XmlDocument doc = new XmlDocument();
                using (Stream stream = sheetEntry.Open())
                {
                    doc.Load(stream);
                }

                XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
                ns.AddNamespace("x", "http://schemas.openxmlformats.org/spreadsheetml/2006/main");
                XmlNodeList rows = doc.SelectNodes("//x:sheetData/x:row", ns);
                if (rows == null || rows.Count == 0)
                {
                    return table;
                }

                bool headerDone = false;
                foreach (XmlNode row in rows)
                {
                    Dictionary<int, string> values = new Dictionary<int, string>();
                    foreach (XmlNode cell in row.SelectNodes("x:c", ns))
                    {
                        string r = cell.Attributes?["r"]?.Value ?? string.Empty;
                        int colIndex = GetColumnIndex(r);
                        string val = ReadCellValue(cell, ns, sharedStrings);
                        values[colIndex] = val;
                    }

                    if (!headerDone)
                    {
                        int maxCol = values.Count == 0 ? 0 : values.Keys.Max();
                        for (int i = 0; i <= maxCol; i++)
                        {
                            string colName = values.ContainsKey(i) ? values[i] : $"Column{i + 1}";
                            if (string.IsNullOrWhiteSpace(colName)) colName = $"Column{i + 1}";
                            if (table.Columns.Contains(colName)) colName = colName + "_" + i;
                            table.Columns.Add(colName);
                        }
                        headerDone = true;
                        continue;
                    }

                    DataRow dr = table.NewRow();
                    for (int i = 0; i < table.Columns.Count; i++)
                    {
                        dr[i] = values.ContainsKey(i) ? values[i] : string.Empty;
                    }
                    table.Rows.Add(dr);
                }
            }

            return table;
        }

        private List<string> ReadSharedStrings(ZipArchive archive)
        {
            List<string> list = new List<string>();
            ZipArchiveEntry entry = archive.GetEntry("xl/sharedStrings.xml");
            if (entry == null) return list;

            XmlDocument doc = new XmlDocument();
            using (Stream stream = entry.Open())
            {
                doc.Load(stream);
            }

            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("x", "http://schemas.openxmlformats.org/spreadsheetml/2006/main");
            XmlNodeList nodes = doc.SelectNodes("//x:sst/x:si", ns);
            foreach (XmlNode node in nodes)
            {
                XmlNode t = node.SelectSingleNode(".//x:t", ns);
                list.Add(t?.InnerText ?? string.Empty);
            }
            return list;
        }

        private string GetFirstSheetPath(ZipArchive archive)
        {
            XmlDocument wbDoc = new XmlDocument();
            using (Stream s = archive.GetEntry("xl/workbook.xml").Open())
            {
                wbDoc.Load(s);
            }
            XmlNamespaceManager wbNs = new XmlNamespaceManager(wbDoc.NameTable);
            wbNs.AddNamespace("x", "http://schemas.openxmlformats.org/spreadsheetml/2006/main");
            wbNs.AddNamespace("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            XmlNode firstSheet = wbDoc.SelectSingleNode("//x:sheets/x:sheet", wbNs);
            string rId = firstSheet?.Attributes?["r:id"]?.Value;
            if (string.IsNullOrWhiteSpace(rId)) return "xl/worksheets/sheet1.xml";

            XmlDocument relDoc = new XmlDocument();
            using (Stream s = archive.GetEntry("xl/_rels/workbook.xml.rels").Open())
            {
                relDoc.Load(s);
            }

            XmlNamespaceManager relNs = new XmlNamespaceManager(relDoc.NameTable);
            relNs.AddNamespace("r", "http://schemas.openxmlformats.org/package/2006/relationships");
            XmlNode relNode = relDoc.SelectSingleNode($"//r:Relationship[@Id='{rId}']", relNs);
            string target = relNode?.Attributes?["Target"]?.Value ?? "worksheets/sheet1.xml";
            return "xl/" + target.TrimStart('/');
        }

        private int GetColumnIndex(string cellRef)
        {
            int idx = 0;
            foreach (char c in cellRef)
            {
                if (!char.IsLetter(c)) break;
                idx = idx * 26 + (char.ToUpperInvariant(c) - 'A' + 1);
            }
            return Math.Max(0, idx - 1);
        }

        private string ReadCellValue(XmlNode cell, XmlNamespaceManager ns, List<string> sharedStrings)
        {
            string type = cell.Attributes?["t"]?.Value;
            XmlNode valueNode = cell.SelectSingleNode("x:v", ns);
            if (valueNode == null)
            {
                XmlNode inlineNode = cell.SelectSingleNode("x:is/x:t", ns);
                return inlineNode?.InnerText ?? string.Empty;
            }

            string raw = valueNode.InnerText;
            if (type == "s" && int.TryParse(raw, out int sstIndex) && sstIndex >= 0 && sstIndex < sharedStrings.Count)
            {
                return sharedStrings[sstIndex];
            }
            return raw;
        }

    }
}
