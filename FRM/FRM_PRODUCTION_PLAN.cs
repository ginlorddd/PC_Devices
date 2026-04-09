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
using System.Xml;
using System.IO.Compression;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DM_OHD.FRM
{
    public partial class FRM_PRODUCTION_PLAN : XtraForm
    {
        private const string SelectFieldName = "ROW_SELECTED";
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
            deTo.EditValue = new DateTime(DateTime.Today.Year + 1, 12, 1);
            btnApplyFilter.Click += (s, e) => ApplyMonthFilterToAllViews();

            btnSaveFY.Click += (s, e) => { _dto.SavePlanFY(gridFY.DataSource as DataTable); LoadData(); };
            btnSaveRatio.Click += (s, e) => { _dto.SaveMachineRatio(gridRatio.DataSource as DataTable); LoadData(); };
            btnSaveOutput.Click += (s, e) => { _dto.SaveDieOutput(gridOutput.DataSource as DataTable); LoadData(); };
            btnDeleteFY.Click += (s, e) => DeleteSelectedRows(viewFY);
            btnDeleteRatio.Click += (s, e) => DeleteSelectedRows(viewRatio);
            btnDeleteOutput.Click += (s, e) => DeleteSelectedRows(viewOutput);
            btnGenerateMaster.Click += (s, e) => { _dto.GenerateMasterPlan(); LoadData(); };
            btnExportFY.Click += (s, e) => ExportGrid(viewFY);
            btnImportFY.Click += (s, e) => ImportExcelToGrid(gridFY.DataSource as DataTable, viewFY);
            btnExportRatio.Click += (s, e) => ExportGrid(viewRatio);
            btnImportRatio.Click += (s, e) => ImportExcelToGrid(gridRatio.DataSource as DataTable, viewRatio);
            btnExportOutput.Click += (s, e) => ExportGrid(viewOutput);
            btnImportOutput.Click += (s, e) => ImportExcelToGrid(gridOutput.DataSource as DataTable, viewOutput);
            btnExportMaster.Click += (s, e) => ExportGrid(viewMaster);

            SetupGridEditingBehavior(viewFY);
            SetupGridEditingBehavior(viewRatio);
            SetupGridEditingBehavior(viewOutput);
            SetupGridEditingBehavior(viewMaster);
            viewFY.MouseDown += View_MouseDownSelectHeader;
            viewRatio.MouseDown += View_MouseDownSelectHeader;
            viewOutput.MouseDown += View_MouseDownSelectHeader;
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
            ApplyButtonColor(btnDeleteFY, Color.IndianRed);
            ApplyButtonColor(btnDeleteRatio, Color.IndianRed);
            ApplyButtonColor(btnDeleteOutput, Color.IndianRed);
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
                string[] cells = rows[r].Split('\t');
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
            string clean = (value ?? string.Empty).Trim();
            if (string.IsNullOrWhiteSpace(clean) || clean == "-") return 0m;

            NumberStyles styles = NumberStyles.Number | NumberStyles.AllowExponent;
            if (decimal.TryParse(clean, styles, CultureInfo.InvariantCulture, out decimal numInvariant))
                return Math.Round(numInvariant, 0);
            if (decimal.TryParse(clean, styles, CultureInfo.GetCultureInfo("vi-VN"), out decimal numVi))
                return Math.Round(numVi, 0);
            if (decimal.TryParse(clean, styles, CultureInfo.GetCultureInfo("en-US"), out decimal numEn))
                return Math.Round(numEn, 0);

            if (Regex.IsMatch(clean, @"^\d{1,3}(\.\d{3})+$"))
            {
                string normalized = clean.Replace(".", "");
                if (decimal.TryParse(normalized, styles, CultureInfo.InvariantCulture, out decimal numDotGrouped))
                    return Math.Round(numDotGrouped, 0);
            }

            if (Regex.IsMatch(clean, @"^\d{1,3}(,\d{3})+$"))
            {
                string normalized = clean.Replace(",", "");
                if (decimal.TryParse(normalized, styles, CultureInfo.InvariantCulture, out decimal numCommaGrouped))
                    return Math.Round(numCommaGrouped, 0);
            }

            return 0m;
        }

        private void ExportGrid(GridView view)
        {
            using (var dialog = new SaveFileDialog { Filter = "Excel file (*.xlsx)|*.xlsx" })
            {
                if (dialog.ShowDialog() != DialogResult.OK) return;
                GridColumn sttCol = view.Columns["STT"];
                GridColumn selectCol = view.Columns[SelectFieldName];
                bool sttVisible = sttCol != null && sttCol.Visible;
                bool selectVisible = selectCol != null && selectCol.Visible;
                try
                {
                    if (sttCol != null) sttCol.Visible = false;
                    if (selectCol != null) selectCol.Visible = false;
                    view.ExportToXlsx(dialog.FileName);
                }
                finally
                {
                    if (sttCol != null) sttCol.Visible = sttVisible;
                    if (selectCol != null) selectCol.Visible = selectVisible;
                }
                XtraMessageBox.Show("Export thành công.", "Thông báo");
            }
        }

        private void ImportExcelToGrid(DataTable dt, GridView view)
        {
            if (dt == null) return;
            using (var dialog = new OpenFileDialog { Filter = "Excel (*.xlsx)|*.xlsx" })
            {
                if (dialog.ShowDialog() != DialogResult.OK) return;
                DataTable source = ReadXlsx(dialog.FileName);
                dt.Rows.Clear();
                string[] keyColumns = { "PRODUCT_NO", "DIE_NO", "DIE_NAME", "CAVITY" };
                Dictionary<string, string> lastKeyValues = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                foreach (DataRow srcRow in source.Rows)
                {
                    DataRow row = dt.NewRow();
                    bool hasMappedValue = false;
                    foreach (DataColumn sourceCol in source.Columns)
                    {
                        string header = sourceCol.ColumnName.Trim();
                        string targetColumn = ResolveTargetColumnName(view, dt, header);
                        if (string.IsNullOrWhiteSpace(targetColumn)) continue;
                        string value = Convert.ToString(srcRow[sourceCol] ?? string.Empty).Trim();
                        if (dt.Columns[targetColumn].DataType == typeof(decimal))
                        {
                            decimal number = ParseNumber(value);
                            bool isRatioMonth = view == viewRatio && targetColumn.StartsWith("M") && targetColumn.Length == 7;
                            if (isRatioMonth && number >= 0m && number <= 1m) number *= 100m;
                            row[targetColumn] = number;
                        }
                        else
                        {
                            row[targetColumn] = value;
                        }
                        hasMappedValue = hasMappedValue || !string.IsNullOrWhiteSpace(value);
                    }

                    foreach (string keyCol in keyColumns)
                    {
                        if (!dt.Columns.Contains(keyCol)) continue;
                        string current = Convert.ToString(row[keyCol]);
                        if (string.IsNullOrWhiteSpace(current))
                        {
                            if (lastKeyValues.TryGetValue(keyCol, out string lastValue))
                                row[keyCol] = lastValue;
                        }
                        else
                        {
                            lastKeyValues[keyCol] = current.Trim();
                            row[keyCol] = current.Trim();
                        }
                    }

                    bool hasKey = HasAnyValue(row, "PRODUCT_NO", "DIE_NO", "DIE_NAME", "CAVITY");
                    if (hasMappedValue && hasKey) dt.Rows.Add(row);
                }
                view.RefreshData();
            }
        }

        private bool HasAnyValue(DataRow row, params string[] columns)
        {
            return columns.Any(c => row.Table.Columns.Contains(c) && !string.IsNullOrWhiteSpace(Convert.ToString(row[c])));
        }

        private string ResolveTargetColumnName(GridView view, DataTable dt, string sourceHeader)
        {
            if (string.IsNullOrWhiteSpace(sourceHeader)) return null;
            string header = sourceHeader.Trim();
            if (string.Equals(header, "STT", StringComparison.OrdinalIgnoreCase)
                || string.Equals(header, "Chọn", StringComparison.OrdinalIgnoreCase)
                || string.Equals(header, SelectFieldName, StringComparison.OrdinalIgnoreCase))
            {
                return null;
            }
            if (dt.Columns.Contains(header)) return header;

            GridColumn byCaption = view.Columns
                .Cast<GridColumn>()
                .FirstOrDefault(c => string.Equals(c.Caption?.Trim(), header, StringComparison.OrdinalIgnoreCase)
                                     && dt.Columns.Contains(c.FieldName));
            if (byCaption != null) return byCaption.FieldName;

            string monthField = TryParseMonthHeaderToFieldName(header);
            if (!string.IsNullOrWhiteSpace(monthField) && dt.Columns.Contains(monthField)) return monthField;

            return null;
        }

        private string TryParseMonthHeaderToFieldName(string header)
        {
            Match slashPattern = Regex.Match(header, @"^(?<m>\d{1,2})[\/\-](?<y>\d{4})$");
            if (slashPattern.Success)
            {
                int month = int.Parse(slashPattern.Groups["m"].Value);
                int year = int.Parse(slashPattern.Groups["y"].Value);
                if (month >= 1 && month <= 12) return $"M{year}{month:00}";
            }

            Match thgPattern = Regex.Match(header, @"^(Thg|THG)\s*(?<m>\d{1,2})[-\/](?<y>\d{2,4})$");
            if (thgPattern.Success)
            {
                int month = int.Parse(thgPattern.Groups["m"].Value);
                string yearText = thgPattern.Groups["y"].Value;
                int year = yearText.Length == 2 ? 2000 + int.Parse(yearText) : int.Parse(yearText);
                if (month >= 1 && month <= 12) return $"M{year}{month:00}";
            }

            string[] dateFormats = { "d/M/yyyy", "dd/MM/yyyy", "M/d/yyyy", "MM/dd/yyyy", "d-M-yyyy", "M-d-yyyy" };
            List<DateTime> parsedDates = new List<DateTime>();
            foreach (string format in dateFormats)
            {
                if (DateTime.TryParseExact(header, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsed))
                {
                    parsedDates.Add(parsed);
                }
            }
            DateTime firstDayCandidate = parsedDates.FirstOrDefault(d => d.Day == 1);
            if (firstDayCandidate != default(DateTime))
            {
                return $"M{firstDayCandidate.Year}{firstDayCandidate.Month:00}";
            }
            if (parsedDates.Count > 0)
            {
                DateTime parsed = parsedDates[0];
                return $"M{parsed.Year}{parsed.Month:00}";
            }

            string[] monthNameFormats = { "MMM-yy", "MMM-yyyy", "MMMM-yy", "MMMM-yyyy", "MMM yy", "MMM/yyyy" };
            foreach (string format in monthNameFormats)
            {
                if (DateTime.TryParseExact(header, format, CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces, out DateTime parsed))
                {
                    return $"M{parsed.Year}{parsed.Month:00}";
                }
            }

            if (double.TryParse(header, NumberStyles.Any, CultureInfo.InvariantCulture, out double oaDate))
            {
                if (oaDate > 20000 && oaDate < 70000)
                {
                    DateTime parsed = DateTime.FromOADate(oaDate);
                    return $"M{parsed.Year}{parsed.Month:00}";
                }
            }

            return null;
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
            btnDeleteFY.Enabled = canEdit;
            btnDeleteRatio.Enabled = canEdit;
            btnDeleteOutput.Enabled = canEdit;
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
            EnsureSttColumn(view);
            ConfigureSelector(view);
        }

        private void ConfigureSelector(GridView view)
        {
            bool allowSelector = view == viewFY || view == viewRatio || view == viewOutput;
            view.OptionsSelection.MultiSelect = false;
            view.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect;
            view.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DefaultBoolean.False;
            view.OptionsSelection.CheckBoxSelectorColumnWidth = 0;
            if (!allowSelector) return;

            DataTable dt = view.GridControl?.DataSource as DataTable;
            if (dt != null && !dt.Columns.Contains(SelectFieldName))
            {
                dt.Columns.Add(SelectFieldName, typeof(bool));
                foreach (DataRow row in dt.Rows) row[SelectFieldName] = false;
            }
        }

        private void View_CellMerge(object sender, CellMergeEventArgs e)
        {
            var view = sender as GridView;
            string field = e.Column.FieldName;
            if (field == "STT")
            {
                e.Merge = false;
                e.Handled = true;
                return;
            }

            bool isMaster = view == viewMaster;
            if (!isMaster && field != "PRODUCT_NO" && field != "DIE_NO" && field != "DIE_NAME")
            {
                e.Merge = false;
                e.Handled = true;
                return;
            }

            if (isMaster && field != "DIE_NO" && field != "DIE_NAME" && field != "TOTAL_CAVITY")
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
            RebuildViewColumns(viewFY, true);
            RebuildViewColumns(viewRatio, true);
            RebuildViewColumns(viewOutput, true);
            RebuildViewColumns(viewMaster, false);
            SetCaptions();
            ApplyMonthFilterToAllViews();
        }

        private void SetCaptions()
        {
            SetGridCaption(viewFY, "STT", "STT");
            SetGridCaption(viewFY, "PRODUCT_NO", "Mã hàng");
            SetGridCaption(viewFY, "DIE_NAME", "Tên khuôn");
            SetGridCaption(viewFY, "DIE_NO", "Số khuôn");
            SetGridCaption(viewFY, "CAVITY", "Số cavity");
            ConfigureMonthColumns(viewFY, "Kế hoạch FY");

            SetGridCaption(viewRatio, "STT", "STT");
            SetGridCaption(viewRatio, "DIE_NAME", "Tên khuôn");
            SetGridCaption(viewRatio, "DIE_NO", "Số khuôn");
            SetGridCaption(viewRatio, "CAVITY", "Số cavity");
            ConfigureMonthColumns(viewRatio, "Tỉ lệ chạy máy (%)");

            SetGridCaption(viewOutput, "STT", "STT");
            SetGridCaption(viewOutput, "DIE_NAME", "Tên khuôn");
            SetGridCaption(viewOutput, "DIE_NO", "Số khuôn");
            SetGridCaption(viewOutput, "CAVITY", "Số cavity");
            ConfigureMonthColumns(viewOutput, "Sản lượng khuôn");

            SetGridCaption(viewMaster, "STT", "STT");
            SetGridCaption(viewMaster, "DIE_NAME", "Tên khuôn");
            SetGridCaption(viewMaster, "DIE_NO", "Số khuôn");
            SetGridCaption(viewMaster, "TOTAL_CAVITY", "Tổng số cavity");
            if (viewMaster.Columns["CAVITY_DETAIL"] != null) viewMaster.Columns["CAVITY_DETAIL"].Visible = false;
            if (viewMaster.Columns["QTY_ORDER"] != null) viewMaster.Columns["QTY_ORDER"].Visible = false;
            SetGridCaption(viewMaster, "QTY_TYPE", "Loại dữ liệu");
            ConfigureMonthColumns(viewMaster, "Bảng 1 - Kế hoạch OHD");
            NormalizeLeadingColumns(viewFY, true);
            NormalizeLeadingColumns(viewRatio, true);
            NormalizeLeadingColumns(viewOutput, true);
            NormalizeLeadingColumns(viewMaster, false);

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

            if (view.Columns["STT"] != null) view.Columns["STT"].Width = 55;
            if (view.Columns["PRODUCT_NO"] != null) view.Columns["PRODUCT_NO"].Width = 110;
            if (view.Columns["DIE_NAME"] != null) view.Columns["DIE_NAME"].Width = 180;
            if (view.Columns["DIE_NO"] != null) view.Columns["DIE_NO"].Width = 110;
            if (view.Columns["CAVITY"] != null) view.Columns["CAVITY"].Width = 100;
            if (view.Columns["TOTAL_CAVITY"] != null) view.Columns["TOTAL_CAVITY"].Width = 110;
            if (view.Columns["QTY_TYPE"] != null) view.Columns["QTY_TYPE"].Width = 230;
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
                if (includeQtyType && view.Columns["QTY_ORDER"] != null)
                    view.Columns["QTY_ORDER"].SortIndex = i++;
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
            if (view.Columns["STT"] != null) view.Columns["STT"].Fixed = FixedStyle.Left;
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
            bool isRatioView = sender == viewRatio;
            if (isRatioView)
            {
                e.DisplayText = $"{number.ToString("N0", CultureInfo.InvariantCulture).Replace(",", ".")}%";
            }
            else
            {
                e.DisplayText = number.ToString("N0", CultureInfo.InvariantCulture).Replace(",", ".");
            }
        }

        private void SetGridCaption(GridView view, string field, string caption)
        {
            if (view.Columns[field] != null) view.Columns[field].Caption = caption;
        }

        private void NormalizeLeadingColumns(GridView view, bool hasSelect)
        {
            if (hasSelect && view.Columns[SelectFieldName] != null)
            {
                view.Columns[SelectFieldName].VisibleIndex = 0;
                view.Columns[SelectFieldName].Fixed = FixedStyle.Left;
            }

            if (view.Columns["STT"] != null)
            {
                view.Columns["STT"].VisibleIndex = hasSelect ? 1 : 0;
                view.Columns["STT"].Fixed = FixedStyle.Left;
            }
        }

        private void EnsureSttColumn(GridView view)
        {
            if (view.Columns["STT"] == null)
            {
                GridColumn col = view.Columns.AddVisible("STT", "STT");
                col.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
                col.OptionsColumn.AllowEdit = false;
                col.Fixed = FixedStyle.Left;
                col.Width = 55;
                col.VisibleIndex = 1;
            }

            view.CustomUnboundColumnData -= View_CustomUnboundColumnData;
            view.CustomUnboundColumnData += View_CustomUnboundColumnData;
        }

        private void RebuildViewColumns(GridView view, bool includeSelectColumn)
        {
            view.Columns.Clear();
            view.PopulateColumns();
            if (includeSelectColumn) EnsureSelectionColumn(view);
            ConfigureSelector(view);
            EnsureSttColumn(view);
        }

        private void EnsureSelectionColumn(GridView view)
        {
            ConfigureSelector(view);
            GridColumn selectCol = view.Columns[SelectFieldName];
            if (selectCol == null)
            {
                selectCol = view.Columns.AddVisible(SelectFieldName, "Chọn");
            }
            selectCol.Visible = true;
            selectCol.VisibleIndex = 0;
            selectCol.Fixed = FixedStyle.Left;
            selectCol.Width = 52;
            selectCol.OptionsColumn.AllowEdit = true;
        }

        private void View_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName != "STT" || !e.IsGetData) return;
            e.Value = e.ListSourceRowIndex + 1;
        }

        private void DeleteSelectedRows(GridView view)
        {
            DataTable dt = view.GridControl?.DataSource as DataTable;
            if (dt == null || !dt.Columns.Contains(SelectFieldName)) return;
            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                if (!Convert.ToBoolean(dt.Rows[i][SelectFieldName])) continue;
                dt.Rows.RemoveAt(i);
            }
            view.RefreshData();
        }

        private void View_MouseDownSelectHeader(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;
            var hit = view.CalcHitInfo(e.Location);
            if (hit.HitTest != GridHitTest.Column || hit.Column == null || hit.Column.FieldName != SelectFieldName) return;

            DataTable dt = view.GridControl?.DataSource as DataTable;
            if (dt == null || !dt.Columns.Contains(SelectFieldName)) return;

            bool shouldSelectAll = dt.AsEnumerable().Any(r => !Convert.ToBoolean(r[SelectFieldName]));
            foreach (DataRow row in dt.Rows)
            {
                row[SelectFieldName] = shouldSelectAll;
            }
            view.RefreshData();
        }

        private DataTable ReadXlsx(string filePath)
        {
            DataTable table = new DataTable();
            using (ZipArchive archive = ZipFile.OpenRead(filePath))
            {
                List<string> sharedStrings = ReadSharedStrings(archive);
                string sheetPath = GetFirstSheetPath(archive);
                ZipArchiveEntry sheetEntry = archive.GetEntry(sheetPath);
                if (sheetEntry == null) return table;

                XmlDocument doc = new XmlDocument();
                using (Stream stream = sheetEntry.Open())
                {
                    doc.Load(stream);
                }

                XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
                ns.AddNamespace("x", "http://schemas.openxmlformats.org/spreadsheetml/2006/main");
                XmlNodeList rows = doc.SelectNodes("//x:sheetData/x:row", ns);
                if (rows == null || rows.Count == 0) return table;

                bool headerDone = false;
                foreach (XmlNode row in rows)
                {
                    Dictionary<int, string> values = new Dictionary<int, string>();
                    foreach (XmlNode cell in row.SelectNodes("x:c", ns))
                    {
                        string r = cell.Attributes?["r"]?.Value ?? string.Empty;
                        int colIndex = GetColumnIndex(r);
                        values[colIndex] = ReadCellValue(cell, ns, sharedStrings);
                    }

                    if (!headerDone)
                    {
                        int maxCol = values.Count == 0 ? 0 : values.Keys.Max();
                        for (int i = 0; i <= maxCol; i++)
                        {
                            string colName = values.ContainsKey(i) ? values[i] : $"Column{i + 1}";
                            if (string.IsNullOrWhiteSpace(colName)) colName = $"Column{i + 1}";
                            if (table.Columns.Contains(colName)) colName += "_" + i;
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
            return target.StartsWith("xl/") ? target : "xl/" + target.TrimStart('/');
        }

        private int GetColumnIndex(string cellRef)
        {
            if (string.IsNullOrWhiteSpace(cellRef)) return 0;
            int i = 0;
            while (i < cellRef.Length && char.IsLetter(cellRef[i])) i++;
            string letters = cellRef.Substring(0, i).ToUpperInvariant();
            int index = 0;
            foreach (char c in letters) index = index * 26 + (c - 'A' + 1);
            return Math.Max(0, index - 1);
        }

        private string ReadCellValue(XmlNode cell, XmlNamespaceManager ns, List<string> sharedStrings)
        {
            string type = cell.Attributes?["t"]?.Value ?? string.Empty;
            XmlNode valNode = cell.SelectSingleNode("x:v", ns);
            if (valNode == null) return string.Empty;
            string raw = valNode.InnerText ?? string.Empty;
            if (type == "s" && int.TryParse(raw, out int idx) && idx >= 0 && idx < sharedStrings.Count)
            {
                return sharedStrings[idx];
            }
            return raw;
        }
    }
}
