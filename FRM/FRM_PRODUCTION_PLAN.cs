using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DM_OHD.DB;
using DM_OHD.DTO;
using System;
using System.Data;
using DevExpress.XtraGrid.Columns;
using DevExpress.Utils;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;

namespace DM_OHD.FRM
{
    public partial class FRM_PRODUCTION_PLAN : XtraForm
    {
        private readonly ProductionPlanDTO _dto = new ProductionPlanDTO();
        private readonly List<(DateEdit From, DateEdit To)> _tabFilters = new List<(DateEdit From, DateEdit To)>();

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
            BuildMonthFilterBars();

            btnSaveFY.Click += (s, e) => { _dto.SavePlanFY(gridFY.DataSource as DataTable); LoadData(); };
            btnSaveRatio.Click += (s, e) => { _dto.SaveMachineRatio(gridRatio.DataSource as DataTable); LoadData(); };
            btnSaveOutput.Click += (s, e) => { _dto.SaveDieOutput(gridOutput.DataSource as DataTable); LoadData(); };
            btnGenerateMaster.Click += (s, e) => { _dto.GenerateMasterPlan(); LoadData(); };

            ApplyPermissions();
            Load += (s, e) => LoadData();
        }

        private void BuildMonthFilterBars()
        {
            CreateTabFilter(tabFY);
            CreateTabFilter(tabRatio);
            CreateTabFilter(tabOutput);
            CreateTabFilter(tabMaster);
        }

        private void CreateTabFilter(System.Windows.Forms.TabPage tab)
        {
            var panel = new PanelControl
            {
                Dock = System.Windows.Forms.DockStyle.Top,
                Height = 42,
                BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            };

            var lblFrom = new LabelControl { Text = "From:", Left = 10, Top = 13 };
            var deFrom = new DateEdit { Left = 50, Top = 9, Width = 100 };

            var lblTo = new LabelControl { Text = "To:", Left = 168, Top = 13 };
            var deTo = new DateEdit { Left = 190, Top = 9, Width = 100 };

            ConfigureMonthEditor(deFrom);
            ConfigureMonthEditor(deTo);

            deFrom.EditValue = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            deTo.EditValue = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);

            var btnApply = new SimpleButton { Text = "🔍", Left = 300, Top = 8, Width = 52 };
            btnApply.Click += (s, e) =>
            {
                SyncFilterValues(deFrom.DateTime, deTo.DateTime);
                ApplyMonthFilterToAllViews();
            };

            panel.Controls.Add(lblFrom);
            panel.Controls.Add(deFrom);
            panel.Controls.Add(lblTo);
            panel.Controls.Add(deTo);
            panel.Controls.Add(btnApply);

            tab.Controls.Add(panel);
            panel.BringToFront();

            _tabFilters.Add((deFrom, deTo));
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
            SetGridCaption(viewFY, "CAVITY", "MACHINE_NO");
            ConfigureMonthColumns(viewFY, "Kế hoạch FY");

            SetGridCaption(viewRatio, "DIE_NAME", "ITEM_DESC");
            SetGridCaption(viewRatio, "DIE_NO", "MOLD_NO");
            SetGridCaption(viewRatio, "CAVITY", "MACHINE_NO");
            ConfigureMonthColumns(viewRatio, "Tỉ lệ chạy máy (%)");

            SetGridCaption(viewOutput, "DIE_NAME", "ITEM_DESC");
            SetGridCaption(viewOutput, "DIE_NO", "MOLD_NO");
            SetGridCaption(viewOutput, "CAVITY", "MACHINE_NO");
            ConfigureMonthColumns(viewOutput, "Sản lượng khuôn");

            SetGridCaption(viewMaster, "DIE_NAME", "ITEM_DESC");
            SetGridCaption(viewMaster, "DIE_NO", "MOLD_NO");
            SetGridCaption(viewMaster, "CAVITY", "MACHINE_NO");
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
                col.Width = 92;
                col.ToolTip = valueCaption;
            }

            if (view.Columns["PRODUCT_NO"] != null) view.Columns["PRODUCT_NO"].Width = 110;
            if (view.Columns["DIE_NAME"] != null) view.Columns["DIE_NAME"].Width = 180;
            if (view.Columns["DIE_NO"] != null) view.Columns["DIE_NO"].Width = 110;
            if (view.Columns["CAVITY"] != null) view.Columns["CAVITY"].Width = 100;
            if (view.Columns["QTY_TYPE"] != null) view.Columns["QTY_TYPE"].Width = 110;
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
            if (includeQtyType && view.Columns["QTY_TYPE"] != null)
                view.Columns["QTY_TYPE"].Fixed = FixedStyle.Left;
        }

        private void SyncFilterValues(DateTime from, DateTime to)
        {
            DateTime fromMonth = new DateTime(from.Year, from.Month, 1);
            DateTime toMonth = new DateTime(to.Year, to.Month, 1);
            foreach (var filter in _tabFilters)
            {
                filter.From.EditValue = fromMonth;
                filter.To.EditValue = toMonth;
            }
        }

        private (DateEdit From, DateEdit To) GetCurrentFilter()
        {
            int idx = tabControl1.SelectedIndex;
            if (idx >= 0 && idx < _tabFilters.Count) return _tabFilters[idx];
            return _tabFilters.FirstOrDefault();
        }

        private void ApplyMonthFilterToAllViews()
        {
            var activeFilter = GetCurrentFilter();
            DateTime fromDate = activeFilter.From == null ? DateTime.MinValue : activeFilter.From.DateTime;
            DateTime toDate = activeFilter.To == null ? DateTime.MinValue : activeFilter.To.DateTime;
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
