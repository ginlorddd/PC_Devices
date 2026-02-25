using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using PC_Devices.DB;
using PC_Devices.FRM.MAIL;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PC_Devices.FRM.DEVICE_MANAGEMENT
{
    public partial class FRM_DEVICE_MAINT_LIST : XtraForm
    {
        // Lưu grid view mà user vừa thao tác gần nhất (để preview + edit đúng grid)
        private GridView _activeView;

        public FRM_DEVICE_MAINT_LIST()
        {
            InitializeComponent();
        }

        private void FRM_DEVICE_MAINT_LIST_Load(object sender, EventArgs e)
        {
            // Load data
            LoadUpcomingList();   // gcData / gvData
            LoadMaintList();      // gcData1 / gvData1

            // Hook events cho cả 2 GridView (dùng chung handlers để khỏi lặp code)
            HookGridEvents(gvData);
            HookGridEvents(gvData1);

            SetupPreviewLayout();

            // Set active view mặc định
            _activeView = gvData;
            LoadPreviewFromGrid(_activeView);

        }

        // ============================
        // HOOK EVENTS (DÙNG CHUNG)
        // ============================
        private void HookGridEvents(GridView view)
        {
            view.FocusedRowChanged -= View_FocusedRowChanged;
            view.FocusedRowChanged += View_FocusedRowChanged;

            view.RowCellClick -= View_RowCellClick;
            view.RowCellClick += View_RowCellClick;

            view.RowCellStyle -= View_RowCellStyle;
            view.RowCellStyle += View_RowCellStyle;

            view.CustomUnboundColumnData -= View_CustomUnboundColumnData;
            view.CustomUnboundColumnData += View_CustomUnboundColumnData;
        }

        // ============================
        // LOAD DATA
        // ============================
        private void LoadUpcomingList()
        {
            try
            {
                string query = @"
SELECT 
    D.TenThietBi,
    D.MaQuanLy,
    S.StatusName AS TrangThaiSuDung,
    D.SerialNo,
    D.Model,
    D.NhaMay,
    D.NgayBaoDuong,
    D.LichSuBaoDuong,
    D.KeHoachBaoDuongTiepTheo,
    D.TanSuat,
    D.BarCode,
    D.StatusID
FROM dbo.TBL_DEVICE_MST D
INNER JOIN dbo.TBL_DEVICE_STATUS S ON D.StatusID = S.StatusID
WHERE 
    ISNULL(D.Huy,0) = 0
    AND D.StatusID = 1
    AND D.KeHoachBaoDuongTiepTheo IS NOT NULL
    AND D.KeHoachBaoDuongTiepTheo <= DATEADD(MONTH, 1, GETDATE());";

                DataTable dt = DBUtils._getData(query) ?? new DataTable();
                gcData.DataSource = dt;

                EnsureSTTColumn(gvData);
                ApplyGridCaptionAndHide(gvData);

                gvData.OptionsBehavior.Editable = false;
                gvData.BestFitColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi LoadUpcomingList:\n" + ex.Message);
            }
        }

        private void LoadMaintList()
        {
            try
            {
                string query = @"
SELECT 
    D.TenThietBi,
    D.MaQuanLy,
    S.StatusName AS TrangThaiSuDung,
    D.SerialNo,
    D.Model,
    D.NhaMay,
    D.NgayBaoDuong,
    D.LichSuBaoDuong,
    D.KeHoachBaoDuongTiepTheo,
    D.TanSuat,
    D.BarCode,
    D.StatusID
FROM dbo.TBL_DEVICE_MST D
INNER JOIN dbo.TBL_DEVICE_STATUS S ON D.StatusID = S.StatusID
WHERE 
    ISNULL(D.Huy,0) = 0
    AND D.StatusID = 3
ORDER BY D.KeHoachBaoDuongTiepTheo ASC;";

                DataTable dt = DBUtils._getData(query) ?? new DataTable();
                gcData1.DataSource = dt;

                EnsureSTTColumn(gvData1);
                ApplyGridCaptionAndHide(gvData1);

                gvData1.OptionsBehavior.Editable = false;
                gvData1.BestFitColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi LoadMaintList:\n" + ex.Message);
            }
        }

        

        private void ReloadAll()
        {
            LoadUpcomingList();
            LoadMaintList();

            // Preview theo grid mà user đang thao tác
            var v = GetActiveView();
            if (v != null)
                LoadPreviewFromGrid(v);
        }

        // ============================
        // GRID UI HELPERS
        // ============================
        private void EnsureSTTColumn(GridView view)
        {
            if (view.Columns["STT"] == null)
            {
                var colSTT = view.Columns.AddField("STT");
                colSTT.Caption = "STT";
                colSTT.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
                colSTT.VisibleIndex = 0;
                colSTT.Width = 50;
                colSTT.OptionsColumn.AllowEdit = false;
                colSTT.OptionsColumn.ReadOnly = true;
                colSTT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                colSTT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }
        }

        private void ApplyGridCaptionAndHide(GridView view)
        {
            if (view.Columns["TenThietBi"] != null) view.Columns["TenThietBi"].Caption = "Tên thiết bị";
            if (view.Columns["MaQuanLy"] != null) view.Columns["MaQuanLy"].Caption = "Mã quản lý";
            if (view.Columns["TrangThaiSuDung"] != null) view.Columns["TrangThaiSuDung"].Caption = "Trạng thái sử dụng";
            if (view.Columns["SerialNo"] != null) view.Columns["SerialNo"].Caption = "Serial No";
            if (view.Columns["Model"] != null) view.Columns["Model"].Caption = "Model";
            if (view.Columns["NhaMay"] != null) view.Columns["NhaMay"].Caption = "Nhà máy";
            if (view.Columns["NgayBaoDuong"] != null) view.Columns["NgayBaoDuong"].Caption = "Lần bảo dưỡng trước";
            if (view.Columns["LichSuBaoDuong"] != null) view.Columns["LichSuBaoDuong"].Caption = "Lịch sử bảo dưỡng";
            if (view.Columns["KeHoachBaoDuongTiepTheo"] != null) view.Columns["KeHoachBaoDuongTiepTheo"].Caption = "Bảo dưỡng tiếp theo";
            if (view.Columns["TanSuat"] != null) view.Columns["TanSuat"].Caption = "Tần suất";


            // Ẩn cột kỹ thuật
            if (view.Columns["BarCode"] != null) view.Columns["StatusID"].Visible = false;
            if (view.Columns["StatusID"] != null) view.Columns["StatusID"].Visible = false;
        }

        // ============================
        // EVENT HANDLERS (DÙNG CHUNG)
        // ============================
        private void View_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var view = sender as GridView;
            if (view == null) return;

            _activeView = view;
            LoadPreviewFromGrid(view);
        }

        private void View_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            var view = sender as GridView;
            if (view == null) return;

            // click 1 cái cũng update preview cho mượt
            _activeView = view;
            LoadPreviewFromGrid(view);

            // double click BarCode để xem ảnh
            if (e.Clicks != 2) return;

            if (e.Column.FieldName != "LichSuBaoDuong") return;

            string maQL = view.GetFocusedRowCellValue("MaQuanLy")?.ToString();
            string fileName = view.GetFocusedRowCellValue("LichSuBaoDuong")?.ToString();
            if (string.IsNullOrWhiteSpace(maQL) || string.IsNullOrWhiteSpace(fileName)) return;

            string fullPath = Path.Combine(Constaint._folderFileUpload, maQL, fileName);
            if (!File.Exists(fullPath)) return;

            FRM_PDF_VIEWER_ADV frm = new FRM_PDF_VIEWER_ADV(fullPath);
            frm.ShowDialog();
        }

        private void View_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "STT" && e.IsGetData)
            {
                e.Value = e.ListSourceRowIndex + 1;
            }
        }

        private void View_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            var view = sender as GridView;
            if (view == null) return;

            if (e.RowHandle < 0) return;

            // 1) Tô màu cột Trạng thái sử dụng theo StatusID
            if (e.Column.FieldName == "TrangThaiSuDung")
            {
                object v = view.GetRowCellValue(e.RowHandle, "StatusID");
                if (v == null || v == DBNull.Value) return;

                int statusId = Convert.ToInt32(v);

                switch (statusId)
                {
                    case 1: e.Appearance.BackColor = Color.LightGreen; e.Appearance.ForeColor = Color.Black; break; // Đang sử dụng
                    case 2: e.Appearance.BackColor = Color.LightBlue; e.Appearance.ForeColor = Color.Black; break; // Chờ duyệt
                    case 3: e.Appearance.BackColor = Color.Orange; e.Appearance.ForeColor = Color.Black; break; // Bảo dưỡng
                    case 4: e.Appearance.BackColor = Color.LightCoral; e.Appearance.ForeColor = Color.White; break; // Đã hủy
                    case 5: e.Appearance.BackColor = Color.MediumPurple; e.Appearance.ForeColor = Color.White; break; // Chờ duyệt hủy
                }

                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                return;
            }

            // 2) Tô màu cột KeHoachBaoDuongTiepTheo theo hạn
            if (e.Column.FieldName == "KeHoachBaoDuongTiepTheo")
            {
                object v = view.GetRowCellValue(e.RowHandle, "KeHoachBaoDuongTiepTheo");
                if (v == null || v == DBNull.Value) return;

                DateTime ngay = Convert.ToDateTime(v);
                DateTime today = DateTime.Today;
                DateTime next30 = today.AddDays(30);

                if (ngay < today)
                {
                    e.Appearance.BackColor = Color.Red;
                    e.Appearance.ForeColor = Color.White;
                }
                else if (ngay <= next30)
                {
                    e.Appearance.BackColor = Color.Gold;
                    e.Appearance.ForeColor = Color.Black;
                }
                else
                {
                    e.Appearance.BackColor = Color.LightGreen;
                    e.Appearance.ForeColor = Color.Black;
                }
            }
        }

        // ============================
        // PREVIEW
        // ============================
        private void SetupPreviewLayout()
        {
            lblAlert.Font = new Font("Tahoma", 14, FontStyle.Bold);
        }

        private string ConvertDate(object date)
        {
            if (date == null || date == DBNull.Value) return "";
            if (DateTime.TryParse(date.ToString(), out DateTime d))
                return d.ToString("dd/MM/yyyy");
            return "";
        }

        private void LoadPreviewFromGrid(GridView gv)
        {
            try
            {
                if (gv == null || gv.FocusedRowHandle < 0)
                {
                    // clear preview
                    lblTen.Text = "";
                    lblMaQL.Text = "";
                    lblSerial.Text = "";
                    lblNhaMay.Text = "";
                    lblNgayBD.Text = "";
                    lblKeHoachBD.Text = "";
                    lblAlert.Text = "";
                    picBarCode.Image = null;
                    return;
                }

                lblTen.Text = gv.GetFocusedRowCellValue("TenThietBi")?.ToString();
                lblMaQL.Text = gv.GetFocusedRowCellValue("MaQuanLy")?.ToString();
                lblSerial.Text = gv.GetFocusedRowCellValue("SerialNo")?.ToString();
                lblNhaMay.Text = gv.GetFocusedRowCellValue("NhaMay")?.ToString();
                lblNgayBD.Text = ConvertDate(gv.GetFocusedRowCellValue("NgayBaoDuong"));
                lblKeHoachBD.Text = ConvertDate(gv.GetFocusedRowCellValue("KeHoachBaoDuongTiepTheo"));

                // BarCode IMG
                string maQL = gv.GetFocusedRowCellValue("MaQuanLy")?.ToString();
                string barFile = gv.GetFocusedRowCellValue("BarCode")?.ToString();
                if (!string.IsNullOrWhiteSpace(maQL) && !string.IsNullOrWhiteSpace(barFile))
                {
                    string fullPath = Path.Combine(Constaint._folderFileUpload, maQL, barFile);
                    if (File.Exists(fullPath))
                    {
                        // Tránh lock file ảnh
                        using (var fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
                        {
                            picBarCode.Image = Image.FromStream(fs);
                        }
                    }
                    else
                    {
                        picBarCode.Image = null;
                    }
                }
                else
                {
                    picBarCode.Image = null;
                }

                // Cảnh báo
                object v = gv.GetFocusedRowCellValue("KeHoachBaoDuongTiepTheo");
                if (v != null && v != DBNull.Value)
                {
                    DateTime next = Convert.ToDateTime(v);
                    int days = (next.Date - DateTime.Today).Days;

                    if (next.Date < DateTime.Today)
                    {
                        lblAlert.ForeColor = Color.Red;
                        lblAlert.Text = $"⚠ QUÁ HẠN {Math.Abs(days)} ngày!";
                    }
                    else if (days <= 30)
                    {
                        lblAlert.ForeColor = Color.Orange;
                        lblAlert.Text = $"⏳ Còn {days} ngày!";
                    }
                    else
                    {
                        lblAlert.ForeColor = Color.Green;
                        lblAlert.Text = $"✔ Còn {days} ngày (an toàn)";
                    }
                }
                else
                {
                    lblAlert.Text = "";
                }
            }
            catch
            {
                // không spam message
            }
        }

        private GridView GetActiveView()
        {
            // Ưu tiên view user vừa thao tác
            if (_activeView != null && _activeView.FocusedRowHandle >= 0)
                return _activeView;

            // fallback theo FocusedView của GridControl
            if (gcData.FocusedView == gvData && gvData.FocusedRowHandle >= 0)
                return gvData;

            if (gcData1.FocusedView == gvData1 && gvData1.FocusedRowHandle >= 0)
                return gvData1;

            // fallback cuối
            if (gvData.FocusedRowHandle >= 0) return gvData;
            if (gvData1.FocusedRowHandle >= 0) return gvData1;

            return null;
        }

        // ============================
        // BUTTONS
        // ============================
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ReloadAll();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                // export theo grid đang active (đúng hành vi user)
                var v = GetActiveView();
                if (v == gvData)
                    Constaint._exportGridViewXlsx(gvData, gcData);
                else if (v == gvData1)
                    Constaint._exportGridViewXlsx(gvData1, gcData1);
                else
                    Constaint._exportGridViewXlsx(gvData, gcData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                var view = GetActiveView();
                if (view == null)
                {
                    MessageBox.Show("Vui lòng chọn thiết bị cần sửa!", "",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string maQuanLy = view.GetFocusedRowCellValue("MaQuanLy")?.ToString();
                if (string.IsNullOrWhiteSpace(maQuanLy))
                {
                    MessageBox.Show("Không lấy được mã quản lý!", "",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                FRM_EDIT_MAINT frm = new FRM_EDIT_MAINT(maQuanLy);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    ReloadAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở form sửa:\n" + ex.Message);
            }
        }

        private void btnSendMail_Click(object sender, EventArgs e)
        {
            var view = GetActiveView();
            if (view == null)
            {
                MessageBox.Show("Vui lòng chọn thiết bị cần gửi mail!",
                    "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maQL = view.GetFocusedRowCellValue("MaQuanLy")?.ToString();
            string tenTB = view.GetFocusedRowCellValue("TenThietBi")?.ToString();
            object ngayObj = view.GetFocusedRowCellValue("KeHoachBaoDuongTiepTheo");

            DateTime? ngayKH = null;
            int daysRemain = 0;

            if (ngayObj != null && ngayObj != DBNull.Value)
            {
                DateTime d = Convert.ToDateTime(ngayObj);
                ngayKH = d;
                daysRemain = (d.Date - DateTime.Today).Days;
            }

            FRM_SEND_EMAIL_MAINT frm = new FRM_SEND_EMAIL_MAINT(maQL, tenTB, ngayKH, daysRemain);
            frm.ShowDialog();
        }

    }
}
