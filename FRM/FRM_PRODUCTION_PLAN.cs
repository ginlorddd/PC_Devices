using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DM_OHD.DB;
using DM_OHD.DTO;
using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;

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

            btnSaveFY.Click += (s, e) => { _dto.SavePlanFY(gridFY.DataSource as DataTable); LoadData(); };
            btnSaveRatio.Click += (s, e) => { _dto.SaveMachineRatio(gridRatio.DataSource as DataTable); LoadData(); };
            btnSaveOutput.Click += (s, e) => { _dto.SaveDieOutput(gridOutput.DataSource as DataTable); LoadData(); };
            btnGenerateMaster.Click += (s, e) => { _dto.GenerateMasterPlan(); LoadData(); };

            ApplyPermissions();
            Load += (s, e) => LoadData();
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
        }

        private void LoadData()
        {
            gridFY.DataSource = _dto.GetPlanFY();
            gridRatio.DataSource = _dto.GetMachineRatio();
            gridOutput.DataSource = _dto.GetDieOutput();
            gridMaster.DataSource = _dto.GetMaster();
            SetCaptions();
        }

        private void SetCaptions()
        {
            SetGridCaption(viewFY, "PRODUCT_NO", "Mã sản phẩm");
            SetGridCaption(viewFY, "DIE_NO", "Số khuôn");
            SetGridCaption(viewFY, "DIE_NAME", "Tên khuôn");
            SetGridCaption(viewFY, "CAVITY", "Cavity");
            ConfigureMonthColumns(viewFY, "Kế hoạch FY");

            SetGridCaption(viewRatio, "DIE_NO", "Số khuôn");
            SetGridCaption(viewRatio, "DIE_NAME", "Tên khuôn");
            SetGridCaption(viewRatio, "CAVITY", "Cavity");
            ConfigureMonthColumns(viewRatio, "Tỉ lệ chạy máy (%)");

            SetGridCaption(viewOutput, "DIE_NO", "Số khuôn");
            SetGridCaption(viewOutput, "DIE_NAME", "Tên khuôn");
            SetGridCaption(viewOutput, "CAVITY", "Cavity");
            ConfigureMonthColumns(viewOutput, "Sản lượng khuôn");

            SetGridCaption(viewMaster, "FY_SHOTS", "Kế hoạch FY");
            SetGridCaption(viewMaster, "RUN_RATIO", "Tỉ lệ máy (%)");
            SetGridCaption(viewMaster, "REQUIRED_QTY", "Sản lượng cần SX");
            SetGridCaption(viewMaster, "OHD_MOC", "Mốc OHD");

            viewFY.BestFitColumns();
            viewRatio.BestFitColumns();
            viewOutput.BestFitColumns();
            viewMaster.BestFitColumns();
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
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                col.DisplayFormat.FormatString = "n0";
                col.Width = 85;
                col.ToolTip = valueCaption;
            }

            if (view.Columns["PRODUCT_NO"] != null) view.Columns["PRODUCT_NO"].Width = 110;
            if (view.Columns["DIE_NO"] != null) view.Columns["DIE_NO"].Width = 110;
            if (view.Columns["DIE_NAME"] != null) view.Columns["DIE_NAME"].Width = 180;
            if (view.Columns["CAVITY"] != null) view.Columns["CAVITY"].Width = 120;
        }

        private void SetGridCaption(GridView view, string field, string caption)
        {
            if (view.Columns[field] != null) view.Columns[field].Caption = caption;
        }
    }
}
