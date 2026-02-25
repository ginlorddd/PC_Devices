using DevExpress.XtraEditors;
using PC_Devices.DB;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PC_Devices.FRM.DEVICE_MANAGEMENT
{
    public partial class FRM_ADD_DEVICE_REGISTER : XtraForm
    {
        public FRM_ADD_DEVICE_REGISTER()
        {
            InitializeComponent();
        }

        private void FRM_ADD_DEVICE_REGISTER_Load(object sender, EventArgs e)
        {
            try
            {
                LoadLookups();

                // default UI
                dtNgayVe.EditValue = DateTime.Today;
                chkTSCD.Checked = false;

                // Không cho người dùng gõ vào GridLookUpEdit (chỉ chọn)
                SetupLookupReadOnly(gluFactory);
                SetupLookupReadOnly(gluType);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load form:\n" + ex.Message);
            }
        }

        private void SetupLookupReadOnly(DevExpress.XtraEditors.GridLookUpEdit glu)
        {
            // chỉ cho chọn, không cho gõ text tự do
            glu.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            glu.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;

            if (glu.Properties.View != null)
            {
                glu.Properties.View.OptionsBehavior.Editable = false;
                glu.Properties.View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
                glu.Properties.View.OptionsSelection.EnableAppearanceFocusedCell = false;
            }
        }

        private void LoadLookups()
        {
            // Factory
            DataTable dtFactory = DBUtils._getData(@"
                SELECT ID, FactoryName
                FROM TBL_FACTORY_MST
                ORDER BY FactoryName");

            gluFactory.Properties.DataSource = dtFactory;
            gluFactory.Properties.DisplayMember = "FactoryName";
            gluFactory.Properties.ValueMember = "ID";
            gluFactory.Properties.PopulateViewColumns();
            if (gluFactory.Properties.View.Columns["ID"] != null)
                gluFactory.Properties.View.Columns["ID"].Visible = false;

            // Device Type
            DataTable dtType = DBUtils._getData(@"
                SELECT TypeID, Type, TypeShort
                FROM TBL_DEVICE_TYPE
                ORDER BY Type");

            gluType.Properties.DataSource = dtType;
            gluType.Properties.DisplayMember = "Type";
            gluType.Properties.ValueMember = "TypeID";
            gluType.Properties.PopulateViewColumns();
            if (gluType.Properties.View.Columns["TypeID"] != null)
                gluType.Properties.View.Columns["TypeID"].Visible = false;
            // TypeShort có thể giữ hoặc ẩn tùy bạn
            // if (gluType.Properties.View.Columns["TypeShort"] != null)
            //     gluType.Properties.View.Columns["TypeShort"].Visible = false;
        }

        private int? GetLookupIntValue(GridLookUpEdit glu)
        {
            if (glu.EditValue == null || glu.EditValue == DBNull.Value) return null;
            if (int.TryParse(glu.EditValue.ToString(), out int v)) return v;
            return null;
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtDeviceName.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên thiết bị!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDeviceName.Focus();
                return false;
            }

            int? factoryId = GetLookupIntValue(gluFactory);
            if (!factoryId.HasValue)
            {
                MessageBox.Show("Vui lòng chọn Nhà máy!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gluFactory.Focus();
                return false;
            }

            int? typeId = GetLookupIntValue(gluType);
            if (!typeId.HasValue)
            {
                MessageBox.Show("Vui lòng chọn Loại thiết bị!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gluType.Focus();
                return false;
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateForm()) return;

                int factoryId = GetLookupIntValue(gluFactory).Value;
                int typeId = GetLookupIntValue(gluType).Value;

                DateTime? ngayVe = null;
                if (dtNgayVe.EditValue != null && dtNgayVe.EditValue != DBNull.Value)
                {
                    if (DateTime.TryParse(dtNgayVe.EditValue.ToString(), out DateTime d))
                        ngayVe = d.Date;
                }

                string tsCoDinh = chkTSCD.Checked ? "Có" : "Không";

                // Vì chưa có Mã quản lý => KHÔNG sinh barcode
                // -> BarCode = NULL (hoặc "" nếu bạn muốn)
                string insert = @"
                    INSERT INTO TBL_DEVICE_REGISTER
                    (DeviceName, Serial, Model, Supplier, Purpose, FactoryID, TypeID, NgayVe, TaiSanCoDinh,
                     ThongSoThietBi, CongViecCanDung, ChucNang, TaiTrong, DungSai, DanhGia,
                     CreateAt, CreateBy, Huy, StatusID, BarCode)
                    VALUES
                    (@DeviceName, @Serial, @Model, @Supplier, @Purpose, @FactoryID, @TypeID, @NgayVe, @TaiSanCoDinh,
                     @ThongSoThietBi, @CongViecCanDung, @ChucNang, @TaiTrong, @DungSai, @DanhGia,
                     GETDATE(), @CreateBy, 0, 1, NULL)";

                using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(insert, conn))
                    {
                        cmd.Parameters.AddWithValue("@DeviceName", txtDeviceName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Serial", (object)(txtSerial.Text?.Trim() ?? "") ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Model", (object)(txtModel.Text?.Trim() ?? "") ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Supplier", (object)(txtSupplier.Text?.Trim() ?? "") ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Purpose", (object)(txtPurpose.Text?.Trim() ?? "") ?? DBNull.Value);

                        cmd.Parameters.AddWithValue("@FactoryID", factoryId);
                        cmd.Parameters.AddWithValue("@TypeID", typeId);

                        cmd.Parameters.AddWithValue("@NgayVe", ngayVe.HasValue ? (object)ngayVe.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@TaiSanCoDinh", (object)tsCoDinh ?? DBNull.Value);

                        cmd.Parameters.AddWithValue("@ThongSoThietBi", (object)(mmThongSo.Text?.Trim() ?? "") ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@CongViecCanDung", (object)(mmCongViec.Text?.Trim() ?? "") ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@ChucNang", (object)(mmChucNang.Text?.Trim() ?? "") ?? DBNull.Value);

                        cmd.Parameters.AddWithValue("@TaiTrong", (object)(txtTaiTrong.Text?.Trim() ?? "") ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@DungSai", (object)(txtDungSai.Text?.Trim() ?? "") ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@DanhGia", (object)(mmDanhGia.Text?.Trim() ?? "") ?? DBNull.Value);

                        cmd.Parameters.AddWithValue("@CreateBy", (object)Constaint._userID ?? DBNull.Value);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Đăng ký thiết bị thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch
            {
                // bạn nói không muốn show lỗi chi tiết → mình để thông báo chung
                MessageBox.Show("Không thể lưu đăng ký. Vui lòng kiểm tra dữ liệu và thử lại!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
