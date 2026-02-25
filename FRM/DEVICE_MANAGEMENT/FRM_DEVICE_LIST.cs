using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using PC_Devices.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PC_Devices.FRM.DEVICE_MANAGEMENT
{
    public partial class FRM_DEVICE_LIST : DevExpress.XtraEditors.XtraForm
    {
        public FRM_DEVICE_LIST()
        {
            InitializeComponent();
        }

        private void FRM_DEVICE_LIST_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadPreview();
            gvData.FocusedRowChanged += gvData_FocusedRowChanged; //chọn dòng để preview
            gvData.RowCellStyle += gvData_RowCellStyle; //check dữ liệu để làm màu
            gvData.RowCellClick += gvData_RowCellClick;
            gvData.CustomUnboundColumnData += gvData_CustomUnboundColumnData;

            if (btnPrintBarcode != null)
                btnPrintBarcode.Click += btnPrintBarcode_Click;

        }
        private void gvData_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "STT" && e.IsGetData)
            {
                e.Value = e.ListSourceRowIndex + 1;
            }
        }

        private void gvData_FocusedRowChanged(object sender,
            DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LoadPreview();
        }
        private void LoadData()
        {
            if (Constaint._access == "1")
            {
                btnAdd.Visible = true;
            }
            try
            {
                string queryData = @"
                                    SELECT 
                                        D.TenThietBi,
                                        D.MaQuanLy,
                                        S.StatusName AS TrangThaiSuDung,
                                        D.SerialNo,
                                        D.Model,
                                        D.KichThuoc,
                                        D.NhaCungCap,
                                        D.MucDichSuDung,
                                        D.NhaMay,
                                        D.NguoiDuocPhepSuDung,
                                        D.HuongDanSuDung,
                                        D.BaoCaoDaoTao,
                                        D.LichSuBaoDuong,
                                        D.NgayBaoDuong,
                                        D.KeHoachBaoDuongTiepTheo,
                                        D.TanSuat,
                                        D.TaiSanCoDinh,
                                        D.BarCode,
                                        D.StatusID
                                    FROM dbo.TBL_DEVICE_MST D
                                    INNER JOIN dbo.TBL_DEVICE_STATUS S
                                        ON D.StatusID = S.StatusID
                                    WHERE ISNULL(D.Huy, 0) = 0;";

                DataTable data = DBUtils._getData(queryData) ?? new DataTable();
                gcData.DataSource = data;
                if (gvData.Columns["STT"] == null)
                {
                    DevExpress.XtraGrid.Columns.GridColumn colSTT = gvData.Columns.AddField("STT");
                    colSTT.Caption = "STT";
                    colSTT.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
                    colSTT.VisibleIndex = 0;   // luôn ở đầu
                    colSTT.Width = 50;
                    colSTT.OptionsColumn.AllowEdit = false;
                    colSTT.OptionsColumn.ReadOnly = true;
                }
                gvData.Columns["TenThietBi"].Caption = "Tên thiết bị";
                gvData.Columns["MaQuanLy"].Caption = "Mã quản lý";
                gvData.Columns["TrangThaiSuDung"].Caption = "Trạng thái sử dụng";
                gvData.Columns["SerialNo"].Caption = "Serial No";
                gvData.Columns["Model"].Caption = "Model";
                gvData.Columns["KichThuoc"].Caption = "Kích thước";
                gvData.Columns["NhaCungCap"].Caption = "Nhà cung cấp";
                gvData.Columns["MucDichSuDung"].Caption = "Mục đích sử dụng";
                gvData.Columns["NhaMay"].Caption = "Nhà máy";
                gvData.Columns["NguoiDuocPhepSuDung"].Caption = "Người được phép sử dụng";
                gvData.Columns["HuongDanSuDung"].Caption = "Hướng dẫn sử dụng";
                gvData.Columns["BaoCaoDaoTao"].Caption = "Báo cáo đào tạo";
                gvData.Columns["LichSuBaoDuong"].Caption = "Lịch sử bảo dưỡng";
                gvData.Columns["NgayBaoDuong"].Caption = "Ngày bảo dưỡng";
                gvData.Columns["KeHoachBaoDuongTiepTheo"].Caption = "Bảo dưỡng tiếp theo";
                gvData.Columns["TanSuat"].Caption = "Tần suất";
                gvData.Columns["TaiSanCoDinh"].Caption = "Tài sản cố định";
                gvData.Columns["BarCode"].Caption = "Bar Code";

                // Nếu bạn không muốn hiện StatusID thì ẩn đi
                if (gvData.Columns["StatusID"] != null)
                    gvData.Columns["StatusID"].Visible = false;

                gvData.OptionsBehavior.Editable = false;
                gvData.BestFitColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }



        private void gvData_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            try
            {
                // Chỉ xử lý khi double-click chuột trái
                if (e.Button != MouseButtons.Left || e.Clicks != 2)
                    return;

                string maQL = gvData.GetFocusedRowCellValue("MaQuanLy")?.ToString();
                if (string.IsNullOrEmpty(maQL)) return;

                string col = e.Column.FieldName;

                string fileName = gvData.GetFocusedRowCellValue(col)?.ToString();
                if (string.IsNullOrEmpty(fileName)) return;

                string fullPath = Path.Combine(Constaint._folderFileUpload, maQL, fileName);

                if (!File.Exists(fullPath))
                {
                    //MessageBox.Show("File không tồn tại:\n" + fullPath,
                    //"Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Ảnh
                if (col == "NguoiDuocPhepSuDung" || col == "BarCode")
                {
                    FRM_IMAGE_VIEWER_ADV frm = new FRM_IMAGE_VIEWER_ADV(fullPath);
                    frm.ShowDialog();
                }
                // PDF: HDSD, BCDT, LSSC
                else if (col == "BaoCaoDaoTao" || col == "LichSuBaoDuong" || col == "HuongDanSuDung")
                {
                    FRM_PDF_VIEWER_ADV frm = new FRM_PDF_VIEWER_ADV(fullPath);
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi mở file:\n" + ex.Message);
            }
        }



        private string ConvertToDate(object date)
        {
            if (date == null || date == DBNull.Value)
                return "";

            if (DateTime.TryParse(date.ToString(), out DateTime d))
                return d.ToString("dd/MM/yyyy");

            return "";
        }
        private void LoadPreview()
        {
            try
            {
                if (gvData.FocusedRowHandle < 0)
                    return;

                lblTenThietBi.Text = gvData.GetFocusedRowCellValue("TenThietBi")?.ToString();
                //lblMaQuanLy.Text = gvData.GetFocusedRowCellValue("MaQuanLy")?.ToString();
                //lblTrangThai.Text = gvData.GetFocusedRowCellValue("TrangThaiSuDung")?.ToString();
                lblSerial.Text = gvData.GetFocusedRowCellValue("SerialNo")?.ToString();
                //lblModel.Text = gvData.GetFocusedRowCellValue("Model")?.ToString();
                //lblKichThuoc.Text = gvData.GetFocusedRowCellValue("KichThuoc")?.ToString();
                //lblNhaCungCap.Text = gvData.GetFocusedRowCellValue("NhaCungCap")?.ToString();
                //lblMucDich.Text = gvData.GetFocusedRowCellValue("MucDichSuDung")?.ToString();
                lblNhaMay.Text = gvData.GetFocusedRowCellValue("NhaMay")?.ToString();
                //lblNguoiSuDung.Text = gvData.GetFocusedRowCellValue("NguoiDuocPhepSuDung")?.ToString();
                //lblNgayBD.Text =
                //ConvertToDate(gvData.GetFocusedRowCellValue("NgayBaoDuong"));

                lblKeHoachBD.Text =
                    ConvertToDate(gvData.GetFocusedRowCellValue("KeHoachBaoDuongTiepTheo"));

                //lblTanSuat.Text = gvData.GetFocusedRowCellValue("TanSuat")?.ToString();
                //lblTSCD.Text = gvData.GetFocusedRowCellValue("TaiSanCoDinh")?.ToString();

                // =============================
                //      LOAD Bar Code
                // =============================
                string maQL = gvData.GetFocusedRowCellValue("MaQuanLy")?.ToString();
                string qrFile = gvData.GetFocusedRowCellValue("BarCode")?.ToString();

                if (!string.IsNullOrEmpty(maQL) && !string.IsNullOrEmpty(qrFile))
                {
                    string fullPath = Path.Combine(Constaint._folderFileUpload, maQL, qrFile);

                    if (File.Exists(fullPath))
                        picBarCode.Image = Image.FromFile(fullPath);
                    else
                        picBarCode.Image = null;
                }
                else
                {
                    picBarCode.Image = null;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị Preview:\n" + ex.Message);
            }
        }

        private void gvData_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            // Chỉ áp style cho cột Trạng thái sử dụng
            if (e.Column.FieldName != "TrangThaiSuDung") return;

            if (e.RowHandle < 0) return;

            object val = gvData.GetRowCellValue(e.RowHandle, "StatusID");
            if (val == null || val == DBNull.Value) return;

            int statusId = Convert.ToInt32(val);

            if (statusId == 1)        // Đang sử dụng
            {
                e.Appearance.BackColor = Color.LightGreen;
                e.Appearance.ForeColor = Color.Black;
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
            }
            else if (statusId == 2)   // Chờ duyệt
            {
                e.Appearance.BackColor = Color.LightBlue;
                e.Appearance.ForeColor = Color.Black;
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
            }
            else if (statusId == 3)   // Bảo dưỡng
            {
                e.Appearance.BackColor = Color.Orange;
                e.Appearance.ForeColor = Color.Black;
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
            }
            else if (statusId == 4)   // Đã hủy
            {
                e.Appearance.BackColor = Color.LightCoral;
                e.Appearance.ForeColor = Color.White;
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
            }
            else if (statusId == 5)   // Chờ duyệt hủy
            {
                e.Appearance.BackColor = Color.MediumPurple;
                e.Appearance.ForeColor = Color.White;
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
            }


        }



        public void SearchDevice(string qr)
        {
            if (string.IsNullOrEmpty(qr)) return;

            for (int i = 0; i < gvData.RowCount; i++)
            {
                string value = gvData.GetRowCellValue(i, "MaQuanLy")?.ToString(); // hoặc cột cần tìm

                if (!string.IsNullOrEmpty(value) && value.Trim().Equals(qr.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    gvData.FocusedRowHandle = i;
                    gvData.SelectRow(i);
                    gvData.MakeRowVisible(i);

                    return; // kết thúc ngay khi tìm thấy
                }
            }

            XtraMessageBox.Show("Không tìm thấy thiết bị: " + qr);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Constaint._access))
            {
                MessageBox.Show("Hãy đăng nhập!",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Constaint._access != "1" && Constaint._access != "3")
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            FRM_ADD_DEVICE f = new FRM_ADD_DEVICE();
            f.ShowDialog();
            LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(Constaint._access))
            {
                MessageBox.Show("Hãy đăng nhập!",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Constaint._access != "1" && Constaint._access != "3")
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                if (gvData.FocusedRowHandle < 0)
                {
                    MessageBox.Show("Vui lòng chọn thiết bị cần sửa!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string maQuanLy = gvData.GetFocusedRowCellValue("MaQuanLy")?.ToString();

                if (string.IsNullOrEmpty(maQuanLy))
                {
                    MessageBox.Show("Không lấy được mã quản lý!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Gọi form edit với tham số
                FRM_EDIT_DEVICE frm = new FRM_EDIT_DEVICE(maQuanLy);

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                    LoadPreview();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.ToString());
            }
        }


        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                Constaint._exportGridViewXlsx(gvData, gcData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Constaint._access != "1" && Constaint._access != "3")
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                if (gvData.FocusedRowHandle < 0)
                {
                    MessageBox.Show("Vui lòng chọn thiết bị cần xóa!",
                                    "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string maQuanLy = gvData.GetFocusedRowCellValue("MaQuanLy")?.ToString();

                if (string.IsNullOrEmpty(maQuanLy))
                {
                    MessageBox.Show("Không lấy được mã quản lý!",
                                    "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult dr = MessageBox.Show(
                    "Bạn có chắc chắn muốn hủy/xóa thiết bị:\n\n" + maQuanLy,
                    "Xóa thiết bị",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (dr != DialogResult.Yes)
                    return;

                string query = "UPDATE TBL_DEVICE_MST SET Huy = 1 WHERE MaQuanLy = @MaQuanLy";

                using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaQuanLy", maQuanLy);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Đã xóa thiết bị!",
                                "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadData();
                LoadPreview();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hủy thiết bị: " + ex);
            }
        }

        private void btnCustomDeviceType_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Constaint._access))
            {
                MessageBox.Show("Hãy đăng nhập!",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Constaint._access != "1" && Constaint._access != "3")
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            FRM_DEVICE_TYPE_MST frm = new FRM_DEVICE_TYPE_MST();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
                LoadPreview();
            }
        }

        private void btnPrintBarcode_Click(object sender, EventArgs e)
        {
            DataTable dataBarCode = new DataTable();
            dataBarCode.Columns.Add("Barcode");

            int[] selectedRows = gvData.GetSelectedRows();

            if (selectedRows != null && selectedRows.Length > 0)
            {
                foreach (int rowHandle in selectedRows)
                {
                    if (rowHandle < 0) continue;

                    string maQuanLy = gvData.GetRowCellValue(rowHandle, "MaQuanLy")?.ToString();
                    if (string.IsNullOrWhiteSpace(maQuanLy)) continue;

                    DataRow rowBarcode = dataBarCode.NewRow();
                    rowBarcode["Barcode"] = maQuanLy.Trim();
                    dataBarCode.Rows.Add(rowBarcode);
                }
            }
            else
            {
                MessageBox.Show("Chọn thiết bị cần in mã barcode!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dataBarCode.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu barcode hợp lệ để in!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            BarcodeReport barCode = new BarcodeReport();
            barCode.DataSource = dataBarCode;
            barCode.CreateDocument();

            ReportPrintTool printTool = new ReportPrintTool(barCode);
            printTool.ShowPreview();
        }

    }
}