using DevExpress.XtraEditors;
using PC_Devices.DB;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PC_Devices.FRM.DEVICE_MANAGEMENT
{
    public partial class FRM_EDIT_DEVICE_REGISTER : XtraForm
    {
        private readonly int _registerId;

        public FRM_EDIT_DEVICE_REGISTER(int registerId)
        {
            InitializeComponent();
            _registerId = registerId;
        }

        private void FRM_EDIT_DEVICE_REGISTER_Load(object sender, EventArgs e)
        {
            LoadFactory();
            LoadDeviceType();
            LoadDataById();
        }

        private void LoadFactory()
        {
            try
            {
                DataTable dt = DBUtils._getData("SELECT ID, FactoryName FROM TBL_FACTORY_MST");
                lkFactory.Properties.DataSource = dt;
                lkFactory.Properties.DisplayMember = "FactoryName";
                lkFactory.Properties.ValueMember = "ID";
                lkFactory.Properties.NullText = "";
                gvFactory.PopulateColumns();
                if (gvFactory.Columns["ID"] != null) gvFactory.Columns["ID"].Visible = false;
            }
            catch
            {
                MessageBox.Show("Không load được danh sách Nhà máy!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadDeviceType()
        {
            try
            {
                DataTable dt = DBUtils._getData("SELECT TypeID, Type FROM TBL_DEVICE_TYPE");
                lkType.Properties.DataSource = dt;
                lkType.Properties.DisplayMember = "Type";
                lkType.Properties.ValueMember = "TypeID";
                lkType.Properties.NullText = "";
                gvType.PopulateColumns();
                if (gvType.Columns["TypeID"] != null) gvType.Columns["TypeID"].Visible = false;
            }
            catch
            {
                MessageBox.Show("Không load được danh sách Loại thiết bị!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadDataById()
        {
            try
            {
                string sql = @"
SELECT TOP 1
    RegisterID, DeviceName, Serial, Model, Supplier, Purpose,
    FactoryID, TypeID, NgayVe, TaiSanCoDinh,
    ThongSoThietBi, CongViecCanDung, ChucNang, TaiTrong, DungSai, DanhGia
FROM TBL_DEVICE_REGISTER
WHERE RegisterID = @ID AND ISNULL(Huy,0) = 0;
";
                using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", _registerId);
                        using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            ad.Fill(dt);

                            if (dt.Rows.Count == 0)
                            {
                                MessageBox.Show("Không tìm thấy đăng ký hoặc đã bị hủy!", "Cảnh báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                Close();
                                return;
                            }

                            DataRow r = dt.Rows[0];
                            txtDeviceName.Text = Convert.ToString(r["DeviceName"]);
                            txtSerial.Text = Convert.ToString(r["Serial"]);
                            txtModel.Text = Convert.ToString(r["Model"]);
                            txtSupplier.Text = Convert.ToString(r["Supplier"]);
                            txtPurpose.Text = Convert.ToString(r["Purpose"]);

                            lkFactory.EditValue = r["FactoryID"] == DBNull.Value ? null : r["FactoryID"];
                            lkType.EditValue = r["TypeID"] == DBNull.Value ? null : r["TypeID"];

                            dtNgayVe.EditValue = r["NgayVe"] == DBNull.Value ? null : r["NgayVe"];
                            txtTSCD.Text = Convert.ToString(r["TaiSanCoDinh"]);

                            memoThongSo.Text = Convert.ToString(r["ThongSoThietBi"]);
                            memoCongViec.Text = Convert.ToString(r["CongViecCanDung"]);
                            memoChucNang.Text = Convert.ToString(r["ChucNang"]);
                            memoTaiTrong.Text = Convert.ToString(r["TaiTrong"]);
                            memoDungSai.Text = Convert.ToString(r["DungSai"]);
                            memoDanhGia.Text = Convert.ToString(r["DanhGia"]);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Lỗi load dữ liệu đăng ký!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtDeviceName.Text))
            {
                MessageBox.Show("Tên thiết bị không được để trống!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDeviceName.Focus();
                return false;
            }

            if (lkFactory.EditValue == null)
            {
                MessageBox.Show("Vui lòng chọn Nhà máy!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lkFactory.Focus();
                return false;
            }

            if (lkType.EditValue == null)
            {
                MessageBox.Show("Vui lòng chọn Loại thiết bị!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lkType.Focus();
                return false;
            }

            if (dtNgayVe.EditValue == null || dtNgayVe.EditValue == DBNull.Value)
            {
                MessageBox.Show("Vui lòng chọn Ngày về!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtNgayVe.Focus();
                return false;
            }

            return true;
        }

        private object DbNullIfEmpty(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return DBNull.Value;
            return s.Trim();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                string sql = @"
UPDATE TBL_DEVICE_REGISTER
SET
    DeviceName = @DeviceName,
    Serial = @Serial,
    Model = @Model,
    Supplier = @Supplier,
    Purpose = @Purpose,
    FactoryID = @FactoryID,
    TypeID = @TypeID,
    NgayVe = @NgayVe,
    TaiSanCoDinh = @TSCD,
    ThongSoThietBi = @ThongSo,
    CongViecCanDung = @CongViec,
    ChucNang = @ChucNang,
    TaiTrong = @TaiTrong,
    DungSai = @DungSai,
    DanhGia = @DanhGia,
    UpdateAt = GETDATE(),
    UpdateBy = @UpdateBy
WHERE RegisterID = @ID AND ISNULL(Huy,0) = 0;
";
                using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@DeviceName", DbNullIfEmpty(txtDeviceName.Text));
                        cmd.Parameters.AddWithValue("@Serial", DbNullIfEmpty(txtSerial.Text));
                        cmd.Parameters.AddWithValue("@Model", DbNullIfEmpty(txtModel.Text));
                        cmd.Parameters.AddWithValue("@Supplier", DbNullIfEmpty(txtSupplier.Text));
                        cmd.Parameters.AddWithValue("@Purpose", DbNullIfEmpty(txtPurpose.Text));

                        cmd.Parameters.AddWithValue("@FactoryID", lkFactory.EditValue);
                        cmd.Parameters.AddWithValue("@TypeID", lkType.EditValue);

                        DateTime ngayVe = Convert.ToDateTime(dtNgayVe.EditValue).Date;
                        cmd.Parameters.AddWithValue("@NgayVe", ngayVe);

                        cmd.Parameters.AddWithValue("@TSCD", DbNullIfEmpty(txtTSCD.Text));

                        cmd.Parameters.AddWithValue("@ThongSo", DbNullIfEmpty(memoThongSo.Text));
                        cmd.Parameters.AddWithValue("@CongViec", DbNullIfEmpty(memoCongViec.Text));
                        cmd.Parameters.AddWithValue("@ChucNang", DbNullIfEmpty(memoChucNang.Text));
                        cmd.Parameters.AddWithValue("@TaiTrong", DbNullIfEmpty(memoTaiTrong.Text));
                        cmd.Parameters.AddWithValue("@DungSai", DbNullIfEmpty(memoDungSai.Text));
                        cmd.Parameters.AddWithValue("@DanhGia", DbNullIfEmpty(memoDanhGia.Text));

                        cmd.Parameters.AddWithValue("@UpdateBy", (object)Constaint._userID ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@ID", _registerId);

                        int affected = cmd.ExecuteNonQuery();
                        if (affected <= 0)
                        {
                            MessageBox.Show("Không cập nhật được dữ liệu (bản ghi có thể đã bị hủy).", "Cảnh báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }

                MessageBox.Show("Cập nhật thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
