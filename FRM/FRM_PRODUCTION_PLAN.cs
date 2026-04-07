using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DM_OHD.DB;
using DM_OHD.DTO;
using System;
using System.Data;
using DevExpress.XtraGrid.Columns;
using DevExpress.Utils;
using System.Globalization;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Linq;

namespace DM_OHD.FRM
{
    public partial class FRM_PRODUCTION_PLAN : XtraForm
    {
        private readonly ProductionPlanDTO _dto = new ProductionPlanDTO();

        public FRM_PRODUCTION_PLAN()
        {
            InitializeComponent();
            ConfigureGrid(viewFY);
            ConfigureGrid(viewRatio);
            ConfigureGrid(viewOutput);
            ConfigureGrid(viewMaster, false);
            RegisterNumberFormat(viewFY);
            RegisterNumberFormat(viewRatio);
            RegisterNumberFormat(viewOutput);
            RegisterNumberFormat(viewMaster);
            ConfigureMonthEditor(deFrom);
            ConfigureMonthEditor(deTo);
            deFrom.EditValue = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            deTo.EditValue = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            btnApplyFilter.Click += (s, e) => ApplyMonthFilterToAllViews();

            btnSaveFY.Click += (s, e) => { _dto.SavePlanFY(gridFY.DataSource as DataTable); LoadData(); };
            btnSaveRatio.Click += (s, e) => { _dto.SaveMachineRatio(gridRatio.DataSource as DataTable); LoadData(); };
            btnSaveOutput.Click += (s, e) => { _dto.SaveDieOutput(gridOutput.DataSource as DataTable); LoadData(); };
            btnGenerateMaster.Click += (s, e) => { _dto.GenerateMasterPlan(); LoadData(); };
            btnExportFY.Click += (s, e) => ExportGrid(viewFY);
            btnImportFY.Click += (s, e) => ImportCsvToGrid(gridFY.DataSource as DataTable, viewFY);
            btnExportRatio.Click += (s, e) => ExportGrid(viewRatio);
            btnImportRatio.Click += (s, e) => ImportCsvToGrid(gridRatio.DataSource as DataTable, viewRatio);
            btnExportOutput.Click += (s, e) => ExportGrid(viewOutput);
            btnImportOutput.Click += (s, e) => ImportCsvToGrid(gridOutput.DataSource as DataTable, viewOutput);
            btnExportMaster.Click += (s, e) => ExportGrid(viewMaster);

            SetupGridEditingBehavior(viewFY);
            SetupGridEditingBehavior(viewRatio);
            SetupGridEditingBehavior(viewOutput);
            SetupGridEditingBehavior(viewMaster);
            StyleButtons();

            ApplyPermissions();
            Load += (s, e) => LoadData();
        }
        private void StyleButtons()
        {
            btnApplyFilter.Appearance.BackColor = Color.RoyalBlue;
            btnApplyFilter.Appearance.ForeColor = Color.White;
            btnApplyFilter.Appearance.Options.UseBackColor = true;
            btnApplyFilter.Appearance.Options.UseForeColor = true;
            btnGenerateMaster.Appearance.BackColor = Color.MediumPurple;
            btnGenerateMaster.Appearance.ForeColor = Color.White;
            btnGenerateMaster.Appearance.Options.UseBackColor = true;
            btnGenerateMaster.Appearance.Options.UseForeColor = true;

            Color exportColor = Color.SteelBlue;
            Color importColor = Color.DarkOrange;
            ApplyButtonColor(btnExportFY, exportColor);
            ApplyButtonColor(btnExportRatio, exportColor);
            ApplyButtonColor(btnExportOutput, exportColor);
            ApplyButtonColor(btnExportMaster, exportColor);
            ApplyButtonColor(btnImportFY, importColor);
            ApplyButtonColor(btnImportRatio, importColor);
            ApplyButtonColor(btnImportOutput, importColor);
            ApplyButtonColor(btnSaveFY, Color.MediumSeaGreen);
            ApplyButtonColor(btnSaveRatio, Color.MediumSeaGreen);
            ApplyButtonColor(btnSaveOutput, Color.MediumSeaGreen);
        }

        private void ApplyButtonColor(SimpleButton button, Color color)
        {
            button.Appearance.BackColor = color;
            button.Appearance.ForeColor = Color.White;
            button.Appearance.Options.UseBackColor = true;
            button.Appearance.Options.UseForeColor = true;
        }

        private void SetupGridEditingBehavior(GridView view)
        {
            view.KeyDown -= View_KeyDown;
            view.KeyDown += View_KeyDown;
            view.ValidatingEditor -= View_ValidatingEditor;
            view.ValidatingEditor += View_ValidatingEditor;
        }

        private void View_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            var view = sender as GridView;
            if (view?.FocusedColumn == null) return;
            string field = view.FocusedColumn.FieldName;
            if (!field.StartsWith("M") || field.Length != 7) return;

            if (decimal.TryParse(Convert.ToString(e.Value)?.Replace(".", "").Replace(",", ""), out decimal num))
            {
                e.Value = Math.Round(num, 0);
            }
            else
            {
                e.Value = 0m;
            }
        }

        private void View_KeyDown(object sender, KeyEventArgs e)
        {
            var view = sender as GridView;
            if (view == null) return;
            if (e.Control && e.KeyCode == Keys.V)
            {
                PasteFromClipboard(view);
                e.Handled = true;
            }
        }

        private void PasteFromClipboard(GridView view)
        {
            string text = Clipboard.GetText();
            if (string.IsNullOrWhiteSpace(text)) return;

            string[] rows = text.Replace("\r", string.Empty)
                                .Split(new[] { "\n" }, StringSplitOptions.None);
            int startRow = view.FocusedRowHandle;
            int startCol = view.FocusedColumn.VisibleIndex;

            for (int r = 0; r < rows.Length; r++)
            {
                if (string.IsNullOrWhiteSpace(rows[r])) continue;
                string[] cells = rows[r].Split('	');
                int targetRow = startRow + r;
                if (targetRow >= view.RowCount) view.AddNewRow();
                targetRow = Math.Min(targetRow, view.RowCount - 1);

                for (int c = 0; c < cells.Length; c++)
                {
                    int targetColIndex = startCol + c;
                    var col = view.VisibleColumns.FirstOrDefault(x => x.VisibleIndex == targetColIndex);
                    if (col == null || col.OptionsColumn.AllowEdit == false) continue;
                    if (!col.FieldName.StartsWith("M")) continue;
                    view.SetRowCellValue(targetRow, col, ParseNumber(cells[c]));
                }
            }
        }

        private decimal ParseNumber(string value)
        {
            string clean = (value ?? string.Empty).Trim().Replace(".", "").Replace(",", "");
            return decimal.TryParse(clean, out decimal num) ? Math.Round(num, 0) : 0m;
        }

        private void ExportGrid(GridView view)
        {
            using (var dialog = new SaveFileDialog { Filter = "Excel file (*.xlsx)|*.xlsx" })
            {
                if (dialog.ShowDialog() != DialogResult.OK) return;
                view.ExportToXlsx(dialog.FileName);
                XtraMessageBox.Show("Export thành công.", "Thông báo");
            }
        }

        private void ImportCsvToGrid(DataTable dt, GridView view)
        {
            if (dt == null) return;
            using (var dialog = new OpenFileDialog { Filter = "CSV file (*.csv)|*.csv|Text file (*.txt)|*.txt" })
            {
                if (dialog.ShowDialog() != DialogResult.OK) return;
                var lines = File.ReadAllLines(dialog.FileName);
                if (lines.Length < 2) return;

                string[] headers = lines[0].Split(',');
                for (int i = 1; i < lines.Length; i++)
                {
                    if (string.IsNullOrWhiteSpace(lines[i])) continue;
                    string[] cells = lines[i].Split(',');
                    DataRow row = dt.NewRow();
                    for (int c = 0; c < headers.Length && c < cells.Length; c++)
                    {
                        string h = headers[c].Trim();
                        if (!dt.Columns.Contains(h)) continue;
                        row[h] = dt.Columns[h].DataType == typeof(decimal) ? ParseNumber(cells[c]) : (object)cells[c].Trim();
                    }
                    dt.Rows.Add(row);
                }
                view.RefreshData();
            }
        }

        private void ConfigureMonthEditor(DateEdit editor)
        {
            editor.Properties.Mask.EditMask = "MM/yyyy";
            editor.Properties.Mask.UseMaskAsDisplayFormat = true;
            editor.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista;
            editor.Properties.VistaCalendarInitialViewStyle = DevExpress.XtraEditors.VistaCalendarInitialViewStyle.YearView;
            editor.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearView;
            editor.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
        }

        private void ApplyPermissions()
        {
            bool canEdit = Constaint.IsAdmin() || Constaint.HasRole("PLAN_MGMT");
            btnSaveFY.Enabled = canEdit;
            btnSaveRatio.Enabled = canEdit;
            btnSaveOutput.Enabled = canEdit;
            btnGenerateMaster.Enabled = canEdit;
            viewFY.OptionsBehavior.Editable = canEdit;
            viewRatio.OptionsBehavior.Editable = canEdit;
            viewOutput.OptionsBehavior.Editable = canEdit;
        }

        private void ConfigureGrid(GridView view, bool editable = true)
        {
            view.OptionsView.ShowAutoFilterRow = true;
            view.OptionsView.ShowGroupPanel = false;
            view.OptionsView.NewItemRowPosition = editable ? NewItemRowPosition.Top : NewItemRowPosition.None;
            view.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            view.Appearance.HeaderPanel.Options.UseFont = true;
            view.OptionsView.ColumnAutoWidth = false;
            view.OptionsView.AllowCellMerge = true;
            view.CellMerge -= View_CellMerge;
            view.CellMerge += View_CellMerge;
        }

        private void View_CellMerge(object sender, CellMergeEventArgs e)
        {
            var view = sender as GridView;
            string field = e.Column.FieldName;
            if (field != "PRODUCT_NO" && field != "DIE_NO" && field != "DIE_NAME")
            {
                e.Merge = false;
                e.Handled = true;
                return;
            }

            string v1 = Convert.ToString(view.GetRowCellValue(e.RowHandle1, e.Column));
            string v2 = Convert.ToString(view.GetRowCellValue(e.RowHandle2, e.Column));
            e.Merge = string.Equals(v1, v2, StringComparison.OrdinalIgnoreCase);
            e.Handled = true;
        }

        private void LoadData()
        {
            gridFY.DataSource = _dto.GetPlanFY();
            gridRatio.DataSource = _dto.GetMachineRatio();
            gridOutput.DataSource = _dto.GetDieOutput();
            gridMaster.DataSource = _dto.GetMaster();
            SetCaptions();
            ApplyMonthFilterToAllViews();
        }

        private void SetCaptions()
        {
            SetGridCaption(viewFY, "PRODUCT_NO", "ITEM_CODE");
            SetGridCaption(viewFY, "DIE_NAME", "ITEM_DESC");
            SetGridCaption(viewFY, "DIE_NO", "MOLD_NO");
            SetGridCaption(viewFY, "CAVITY", "CAVITY");
            ConfigureMonthColumns(viewFY, "Kế hoạch FY");

            SetGridCaption(viewRatio, "DIE_NAME", "ITEM_DESC");
            SetGridCaption(viewRatio, "DIE_NO", "MOLD_NO");
            SetGridCaption(viewRatio, "CAVITY", "CAVITY");
            ConfigureMonthColumns(viewRatio, "Tỉ lệ chạy máy (%)");

            SetGridCaption(viewOutput, "DIE_NAME", "ITEM_DESC");
            SetGridCaption(viewOutput, "DIE_NO", "MOLD_NO");
            SetGridCaption(viewOutput, "CAVITY", "CAVITY");
            ConfigureMonthColumns(viewOutput, "Sản lượng khuôn");

            SetGridCaption(viewMaster, "DIE_NAME", "ITEM_DESC");
            SetGridCaption(viewMaster, "DIE_NO", "MOLD_NO");
            SetGridCaption(viewMaster, "TOTAL_CAVITY", "TOTAL_CAVITY");
            if (viewMaster.Columns["CAVITY_DETAIL"] != null) viewMaster.Columns["CAVITY_DETAIL"].Visible = false;
            SetGridCaption(viewMaster, "QTY_TYPE", "QTY_TYPE");
            ConfigureMonthColumns(viewMaster, "Bảng 1 - Kế hoạch OHD");

            ApplyFixedColumns(viewFY, true, false);
            ApplyFixedColumns(viewRatio, false, false);
            ApplyFixedColumns(viewOutput, false, false);
            ApplyFixedColumns(viewMaster, false, true);
            ApplySort(viewFY, true, false);
            ApplySort(viewRatio, false, false);
            ApplySort(viewOutput, false, false);
            ApplySort(viewMaster, false, true);
        }

        private void ConfigureMonthColumns(GridView view, string valueCaption)
        {
            foreach (GridColumn col in view.Columns)
            {
                if (!col.FieldName.StartsWith("M")) continue;
                if (col.FieldName.Length != 7) continue;
                if (!int.TryParse(col.FieldName.Substring(1, 4), out int year)) continue;
                if (!int.TryParse(col.FieldName.Substring(5, 2), out int month)) continue;

                col.Caption = $"{month:00}/{year}";
                col.DisplayFormat.FormatType = FormatType.Custom;
                col.OptionsColumn.AllowEdit = view.OptionsBehavior.Editable;
                col.Width = 92;
                col.ToolTip = valueCaption;
            }

            if (view.Columns["PRODUCT_NO"] != null) view.Columns["PRODUCT_NO"].Width = 110;
            if (view.Columns["DIE_NAME"] != null) view.Columns["DIE_NAME"].Width = 180;
            if (view.Columns["DIE_NO"] != null) view.Columns["DIE_NO"].Width = 110;
            if (view.Columns["CAVITY"] != null) view.Columns["CAVITY"].Width = 100;
            if (view.Columns["TOTAL_CAVITY"] != null) view.Columns["TOTAL_CAVITY"].Width = 110;
            if (view.Columns["QTY_TYPE"] != null) view.Columns["QTY_TYPE"].Width = 150;
        }

        private void ApplySort(GridView view, bool includeProductNo, bool includeQtyType)
        {
            view.BeginSort();
            try
            {
                view.ClearSorting();
                int i = 0;
                if (includeProductNo && view.Columns["PRODUCT_NO"] != null)
                    view.Columns["PRODUCT_NO"].SortIndex = i++;
                if (view.Columns["DIE_NAME"] != null)
                    view.Columns["DIE_NAME"].SortIndex = i++;
                if (view.Columns["DIE_NO"] != null)
                    view.Columns["DIE_NO"].SortIndex = i++;
                if (view.Columns["CAVITY"] != null)
                    view.Columns["CAVITY"].SortIndex = i++;
                if (includeQtyType && view.Columns["TOTAL_CAVITY"] != null)
                    view.Columns["TOTAL_CAVITY"].SortIndex = i++;
                if (includeQtyType && view.Columns["QTY_TYPE"] != null)
                    view.Columns["QTY_TYPE"].SortIndex = i;
            }
            finally
            {
                view.EndSort();
            }
        }

        private void ApplyFixedColumns(GridView view, bool includeProductNo, bool includeQtyType)
        {
            if (includeProductNo && view.Columns["PRODUCT_NO"] != null)
                view.Columns["PRODUCT_NO"].Fixed = FixedStyle.Left;
            if (view.Columns["DIE_NAME"] != null)
                view.Columns["DIE_NAME"].Fixed = FixedStyle.Left;
            if (view.Columns["DIE_NO"] != null)
                view.Columns["DIE_NO"].Fixed = FixedStyle.Left;
            if (view.Columns["CAVITY"] != null)
                view.Columns["CAVITY"].Fixed = FixedStyle.Left;
            if (includeQtyType && view.Columns["TOTAL_CAVITY"] != null)
                view.Columns["TOTAL_CAVITY"].Fixed = FixedStyle.Left;
            if (includeQtyType && view.Columns["QTY_TYPE"] != null)
                view.Columns["QTY_TYPE"].Fixed = FixedStyle.Left;
        }

        private void ApplyMonthFilterToAllViews()
        {
            DateTime fromDate = deFrom.DateTime;
            DateTime toDate = deTo.DateTime;
            DateTime from = fromDate == DateTime.MinValue ? new DateTime(2025, 1, 1) : new DateTime(fromDate.Year, fromDate.Month, 1);
            DateTime to = toDate == DateTime.MinValue ? new DateTime(2030, 12, 1) : new DateTime(toDate.Year, toDate.Month, 1);
            if (from > to)
            {
                var temp = from;
                from = to;
                to = temp;
            }

            ApplyMonthVisibility(viewFY, from, to);
            ApplyMonthVisibility(viewRatio, from, to);
            ApplyMonthVisibility(viewOutput, from, to);
            ApplyMonthVisibility(viewMaster, from, to);
        }

        private void ApplyMonthVisibility(GridView view, DateTime from, DateTime to)
        {
            foreach (GridColumn col in view.Columns)
            {
                if (!col.FieldName.StartsWith("M") || col.FieldName.Length != 7) continue;
                if (!int.TryParse(col.FieldName.Substring(1, 4), out int year)) continue;
                if (!int.TryParse(col.FieldName.Substring(5, 2), out int month)) continue;

                DateTime current = new DateTime(year, month, 1);
                col.Visible = current >= from && current <= to;
            }
        }

        private void RegisterNumberFormat(GridView view)
        {
            view.CustomColumnDisplayText -= View_CustomColumnDisplayText;
            view.CustomColumnDisplayText += View_CustomColumnDisplayText;
        }

        private void View_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if (e.Value == null || e.Value == DBNull.Value) return;
            string field = e.Column?.FieldName ?? string.Empty;
            bool isMonthValue = field.StartsWith("M") && field.Length == 7;
            if (!isMonthValue) return;

            if (!decimal.TryParse(Convert.ToString(e.Value), out decimal number)) return;
            e.DisplayText = number.ToString("N0", CultureInfo.InvariantCulture).Replace(",", ".");
        }

        private void SetGridCaption(GridView view, string field, string caption)
        {
            if (view.Columns[field] != null) view.Columns[field].Caption = caption;
        }
    }
}
