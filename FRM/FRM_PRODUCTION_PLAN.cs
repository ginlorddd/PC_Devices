using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using PC_Devices.DB;
using PC_Devices.DTO;
using System;
using System.Data;
using System.Windows.Forms;

namespace PC_Devices.FRM
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
            SetGridCaption(viewFY, "PLAN_YEAR", "Năm");
            SetGridCaption(viewFY, "PLAN_MONTH", "Tháng");
            SetGridCaption(viewFY, "FY_SHOTS", "Kế hoạch FY");

            SetGridCaption(viewRatio, "RUN_RATIO", "Tỉ lệ chạy máy (%)");
            SetGridCaption(viewOutput, "OUTPUT_QTY", "Sản lượng khuôn");

            SetGridCaption(viewMaster, "FY_SHOTS", "Kế hoạch FY");
            SetGridCaption(viewMaster, "RUN_RATIO", "Tỉ lệ máy (%)");
            SetGridCaption(viewMaster, "REQUIRED_QTY", "Sản lượng cần SX");
            SetGridCaption(viewMaster, "OHD_MOC", "Mốc OHD");

            viewFY.BestFitColumns();
            viewRatio.BestFitColumns();
            viewOutput.BestFitColumns();
            viewMaster.BestFitColumns();
        }

        private void SetGridCaption(GridView view, string field, string caption)
        {
            if (view.Columns[field] != null) view.Columns[field].Caption = caption;
        }
    }
}
