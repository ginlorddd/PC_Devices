using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.BandedGrid;
using PC_Devices.DB;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PC_Devices.FRM.DEVICE_MANAGEMENT
{
    public partial class FRM_DEVICE_REGISTER_LIST : XtraForm
    {
        public FRM_DEVICE_REGISTER_LIST()
        {
            InitializeComponent();
        }

        private void FRM_DEVICE_REGISTER_LIST_Load(object sender, EventArgs e)
        {
            BuildBandedGrid();
            LoadData();
            gvData.FocusedRowChanged += gvData_FocusedRowChanged;
            gvData.RowCellClick += gvData_RowCellClick;
            gvData.CustomUnboundColumnData += gvData_CustomUnboundColumnData;
            gvData.RowCellStyle += gvData_RowCellStyle;

        }
        private void gvData_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "STT" && e.IsGetData)
            {
                e.Value = e.ListSourceRowIndex + 1;
            }
        }

        private void SetupPreviewLayout()
        {
            int yStart = 120;
            int step = 25;

            // Tên thiết bị
            lblTen.Location = new Point(5, yStart);
            lblTen.Size = new Size(250, 20);

            //// Serial
            //lblSerial.Location = new Point(5, yStart + step);
            //lblSerial.Size = new Size(250, 20);

            // Model
            lblModel.Location = new Point(5, yStart + step * 2);
            lblModel.Size = new Size(250, 20);

            // Nhà cung cấp
            lblSupplier.Location = new Point(5, yStart + step * 3);
            lblSupplier.Size = new Size(250, 20);

            //// Mục đích sử dụng
            //lblPurpose.Location = new Point(5, yStart + step * 4);
            //lblPurpose.Size = new Size(250, 20);

            //// Nhà máy
            //lblFactory.Location = new Point(5, yStart + step * 5);
            //lblFactory.Size = new Size(250, 20);

            //// Loại thiết bị
            //lblType.Location = new Point(5, yStart + step * 6);
            //lblType.Size = new Size(250, 20);

            // Ngày về
            lblNgayVe.Location = new Point(5, yStart + step * 7);
            lblNgayVe.Size = new Size(250, 20);

            //// Tài sản cố định
            //lblTSCD.Location = new Point(5, yStart + step * 8);
            //lblTSCD.Size = new Size(250, 20);

            //// THÔNG SỐ THIẾT BỊ
            //lblThongSo.Location = new Point(5, yStart + step * 10);
            //lblThongSo.Size = new Size(260, 20);

            //// Công việc cần dùng
            //lblCongViec.Location = new Point(5, yStart + step * 11);
            //lblCongViec.Size = new Size(260, 20);

            //// Chức năng
            //lblChucNang.Location = new Point(5, yStart + step * 12);
            //lblChucNang.Size = new Size(260, 20);

            //// Tải trọng
            //lblTaiTrong.Location = new Point(5, yStart + step * 13);
            //lblTaiTrong.Size = new Size(260, 20);

            //// Dung sai
            //lblDungSai.Location = new Point(5, yStart + step * 14);
            //lblDungSai.Size = new Size(260, 20);

            //// Đánh giá
            //lblDanhGia.Location = new Point(5, yStart + step * 15);
            //lblDanhGia.Size = new Size(260, 20);

            // Bar Code Picture (giữ nguyên)
            picBarCode.Location = new Point(5, yStart + step * 17);
            picBarCode.Size = new Size(180, 180);
        }

        private BandedGridColumn AddCol(string field, string caption)
        {
            BandedGridColumn col = new BandedGridColumn()
            {
                FieldName = field,
                Caption = caption,
                Visible = true,
                OptionsColumn = { AllowEdit = false }
            };
            gvData.Columns.Add(col);
            return col;
        }

        private void BuildBandedGrid()
        {
            gvData.Bands.Clear();
            gvData.Columns.Clear();

            //========== BANDS ==========

            GridBand bandInfo = gvData.Bands.AddBand("Thông tin thiết bị");
            GridBand bandUse = gvData.Bands.AddBand("Nhu cầu sử dụng");

            // ===== STT (Unbound) =====
            var colSTT = new BandedGridColumn()
            {
                Caption = "STT",
                FieldName = "STT",
                Visible = true,
                Width = 45,
                UnboundType = DevExpress.Data.UnboundColumnType.Integer,
                OptionsColumn = { AllowEdit = false, ReadOnly = true }
            };
            gvData.Columns.Add(colSTT);
            bandInfo.Columns.Add(colSTT);

            //========== COLUMNS – Thông tin thiết bị ==========
            bandInfo.Columns.Add(AddCol("NguoiDangKy", "Người đăng ký"));
            bandInfo.Columns.Add(AddCol("DeviceName", "Tên thiết bị"));
            bandInfo.Columns.Add(AddCol("TrangThai", "Trạng thái"));
            bandInfo.Columns.Add(AddCol("Serial", "Số serial"));
            bandInfo.Columns.Add(AddCol("Model", "Model"));
            bandInfo.Columns.Add(AddCol("Supplier", "Nhà cung cấp"));
            bandInfo.Columns.Add(AddCol("Purpose", "Mục đích sử dụng"));
            bandInfo.Columns.Add(AddCol("FactoryName", "Nhà máy"));
            bandInfo.Columns.Add(AddCol("DeviceType", "Loại thiết bị"));
            bandInfo.Columns.Add(AddCol("NgayVe", "Ngày về"));
            bandInfo.Columns.Add(AddCol("TaiSanCoDinh", "Tài sản cố định"));


            //========== COLUMNS – Nhu cầu sử dụng ==========
            bandUse.Columns.Add(AddCol("ThongSoThietBi", "Thông số thiết bị"));
            bandUse.Columns.Add(AddCol("CongViecCanDung", "Công việc cần dùng"));
            bandUse.Columns.Add(AddCol("ChucNang", "Chức năng"));
            bandUse.Columns.Add(AddCol("TaiTrong", "Tải trọng"));
            bandUse.Columns.Add(AddCol("DungSai", "Dung sai"));
            bandUse.Columns.Add(AddCol("DanhGia", "Đánh giá"));
            //bandUse.Columns.Add(AddCol("BarCode", "Bar Code"));

            gvData.OptionsView.ShowBands = true;
            gvData.OptionsBehavior.Editable = false;
            gvData.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;


            foreach (GridBand band in gvData.Bands)
            {
                band.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                band.AppearanceHeader.Font = new Font("Tahoma", 10F, FontStyle.Bold);
            }
        }

        private void LoadData()
        {
            try
            {
                string query = @"
                SELECT 
                    R.RegisterID,
                    R.CreateBy AS NguoiDangKy,
                    R.DeviceName,
                    S.StatusName AS TrangThai,
                    R.Serial,
                    R.Model,
                    R.Supplier,
                    R.Purpose,
                    F.FactoryName,
                    T.Type AS DeviceType,
                    R.NgayVe,
                    R.TaiSanCoDinh,
                    R.ThongSoThietBi,
                    R.CongViecCanDung,
                    R.ChucNang,
                    R.TaiTrong,
                    R.DungSai,
                    R.DanhGia,
                    R.StatusID
                    
                FROM TBL_DEVICE_REGISTER R
                LEFT JOIN TBL_FACTORY_MST F ON R.FactoryID = F.ID
                LEFT JOIN TBL_DEVICE_TYPE T ON R.TypeID = T.TypeID
                LEFT JOIN TBL_DEVICE_REGISTER_STATUS S ON R.StatusID = S.StatusID
                --LEFT JOIN TBL_ACCOUNT A ON R.CreateBy = A.USER_ID
                WHERE R.Huy = 0
                ORDER BY R.RegisterID";

              
                DataTable dt = DBUtils._getData(query);

                gcData.DataSource = dt;
                gvData.BestFitColumns();
                if (gvData.Columns["StatusID"] != null)
                    gvData.Columns["StatusID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi LoadData:\n" + ex.ToString());
            }
        }

        private string ConvertDate(object date)
        {
            if (date == null || date == DBNull.Value)
                return "";
            if (DateTime.TryParse(date.ToString(), out DateTime d))
                return d.ToString("dd/MM/yyyy");
            return "";
        }

        private void gvData_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            // Chỉ áp style cho cột Trạng thái sử dụng
            if (e.Column.FieldName != "TrangThai") return;

            if (e.RowHandle < 0) return;

            object val = gvData.GetRowCellValue(e.RowHandle, "StatusID");
            if (val == null || val == DBNull.Value) return;

            int statusId = Convert.ToInt32(val);

            if (statusId == 1)        // Chờ duyệt
            {
                e.Appearance.BackColor = Color.Orange;
                e.Appearance.ForeColor = Color.Black;
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
            }
            else if (statusId == 2)   // Đã duyệt
            {
                e.Appearance.BackColor = Color.LightGreen;
                e.Appearance.ForeColor = Color.Black;
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
            }
            else if (statusId == 3)   // Từ chối
            {
                e.Appearance.BackColor = Color.Red;
                e.Appearance.ForeColor = Color.Black;
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
            }
        }

        private void gvData_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            LoadPreview();
        }

        private void gvData_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LoadPreview();
        }

        private void LoadPreview()
        {
            try
            {
                if (gvData.FocusedRowHandle < 0)
                    return;

                lblTen.Text = gvData.GetFocusedRowCellValue("DeviceName")?.ToString();
                lblSerial.Text = gvData.GetFocusedRowCellValue("Serial")?.ToString();
                lblModel.Text = gvData.GetFocusedRowCellValue("Model")?.ToString();
                lblSupplier.Text = gvData.GetFocusedRowCellValue("Supplier")?.ToString();
                lblPurpose.Text = gvData.GetFocusedRowCellValue("Purpose")?.ToString();
                lblFactory.Text = gvData.GetFocusedRowCellValue("FactoryName")?.ToString();
                lblType.Text = gvData.GetFocusedRowCellValue("DeviceType")?.ToString();
                lblNgayVe.Text = ConvertDate(gvData.GetFocusedRowCellValue("NgayVe"));
                lblTSCD.Text = gvData.GetFocusedRowCellValue("TaiSanCoDinh")?.ToString();

                lblThongSo.Text = gvData.GetFocusedRowCellValue("ThongSoThietBi")?.ToString();
                lblCongViec.Text = gvData.GetFocusedRowCellValue("CongViecCanDung")?.ToString();
                lblChucNang.Text = gvData.GetFocusedRowCellValue("ChucNang")?.ToString();
                lblTaiTrong.Text = gvData.GetFocusedRowCellValue("TaiTrong")?.ToString();
                lblDungSai.Text = gvData.GetFocusedRowCellValue("DungSai")?.ToString();
                lblDanhGia.Text = gvData.GetFocusedRowCellValue("DanhGia")?.ToString();

                //===== Bar Code BASE64 =====
                string qrBase64 = gvData.GetFocusedRowCellValue("BarCode")?.ToString();
                if (!string.IsNullOrEmpty(qrBase64))
                {
                    try
                    {
                        byte[] imgBytes = Convert.FromBase64String(qrBase64);
                        using (MemoryStream ms = new MemoryStream(imgBytes))
                        {
                            picBarCode.Image = Image.FromStream(ms);
                        }
                    }
                    catch { picBarCode.Image = null; }
                }
                else
                {
                    picBarCode.Image = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Preview:\n" + ex.Message);
            }
        }

        /* ======================================================
         * 5. BUTTON: THÊM
         * ====================================================== */
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Constaint._access))
            {
                MessageBox.Show("Hãy đăng nhập!",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            FRM_ADD_DEVICE_REGISTER f = new FRM_ADD_DEVICE_REGISTER();
            if (f.ShowDialog() == DialogResult.OK)
                LoadData();
        }

        /* ======================================================
         * 6. BUTTON: XÓA
         * ====================================================== */
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Constaint._access))
            {
                MessageBox.Show("Hãy đăng nhập!",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (gvData.FocusedRowHandle < 0)
            {
                MessageBox.Show("Chọn dòng cần xóa!");
                return;
            }

            int id = Convert.ToInt32(gvData.GetFocusedRowCellValue("RegisterID"));

            if (MessageBox.Show("Xóa đăng ký này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DBUtils._exec($"UPDATE TBL_DEVICE_REGISTER SET Huy = 1 WHERE RegisterID = {id}");
                LoadData();
            }
        }

        private bool UpdateRegisterStatus(int registerId, int newStatusId)
        {
            try
            {
                string sql = @"
UPDATE dbo.TBL_DEVICE_REGISTER
SET StatusID  = @StatusID,
    ApproveBy = @ApproveBy,
    ApproveAt = GETDATE(),
    UpdateAt  = GETDATE(),
    UpdateBy  = @UpdateBy
WHERE RegisterID = @RegisterID
  AND ISNULL(Huy, 0) = 0;
";

                using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@StatusID", newStatusId);
                        cmd.Parameters.AddWithValue("@ApproveBy", (object)Constaint._userID ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@UpdateBy", (object)Constaint._userID ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@RegisterID", registerId);

                        int affected = cmd.ExecuteNonQuery();
                        return affected > 0;
                    }
                }
            }
            catch
            {
                // bạn không muốn show lỗi chi tiết nên catch trống/hoặc message chung
                MessageBox.Show("Không cập nhật được dữ liệu!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        /* ======================================================
         * 7. BUTTON: XÁC NHẬN (Duyệt)
         * ====================================================== */
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Constaint._access))
            {
                MessageBox.Show("Hãy đăng nhập!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Constaint._access != "1" && Constaint._access != "3")
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (gvData.FocusedRowHandle < 0)
            {
                MessageBox.Show("Chọn dòng để xác nhận!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            object idObj = gvData.GetFocusedRowCellValue("RegisterID");
            if (idObj == null || idObj == DBNull.Value)
            {
                MessageBox.Show("Không lấy được RegisterID!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int id = Convert.ToInt32(idObj);

            // StatusID = 2 (Đã duyệt) - theo logic của bạn
            if (UpdateRegisterStatus(id, 2))
            {
                MessageBox.Show("Đã xác nhận!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
        }


        private void btnReject_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Constaint._access))
            {
                MessageBox.Show("Hãy đăng nhập!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Constaint._access != "1" && Constaint._access != "3")
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (gvData.FocusedRowHandle < 0)
            {
                MessageBox.Show("Chọn dòng để từ chối!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            object idObj = gvData.GetFocusedRowCellValue("RegisterID");
            if (idObj == null || idObj == DBNull.Value)
            {
                MessageBox.Show("Không lấy được RegisterID!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int id = Convert.ToInt32(idObj);

            // StatusID = 3 (Từ chối) - theo logic của bạn
            if (UpdateRegisterStatus(id, 3))
            {
                MessageBox.Show("Đã từ chối!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
        }


        /* ======================================================
         * 8. BUTTON: EXPORT
         * ====================================================== */
        private void btnExport_Click(object sender, EventArgs e)
        {
            Constaint._exportGridViewXlsx(gvData, gcData);
        }

        /* ======================================================
         * 9. BUTTON: REFRESH
         * ====================================================== */
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        /* ======================================================
         * 10. BUTTON: CLOSE
         * ====================================================== */
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Constaint._access))
            {
                MessageBox.Show("Hãy đăng nhập!",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (gvData.FocusedRowHandle < 0)
            {
                MessageBox.Show("Vui lòng chọn thiết bị cần sửa!",
                                "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            object idObj = gvData.GetFocusedRowCellValue("RegisterID");
            if (idObj == null || idObj == DBNull.Value)
            {
                MessageBox.Show("Không lấy được RegisterID!",
                                "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int registerId = Convert.ToInt32(idObj);

            FRM_EDIT_DEVICE_REGISTER f = new FRM_EDIT_DEVICE_REGISTER(registerId);
            if (f.ShowDialog() == DialogResult.OK)
                LoadData();
        }

    }
}
