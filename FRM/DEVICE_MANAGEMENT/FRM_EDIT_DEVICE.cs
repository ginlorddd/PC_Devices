using DevExpress.XtraEditors;
using PC_Devices.DB;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PC_Devices.FRM.DEVICE_MANAGEMENT
{
    public partial class FRM_EDIT_DEVICE : XtraForm
    {
        private string _maQuanLy;
        private string _deviceFolder;

        // File cũ (đang lưu trong DB)
        private string oldIMG = "";
        private string oldLSSC = "";
        private string oldBCDT = "";
        private string oldHDSD = "";
        private string oldQr = "";

        // File mới user chọn (chỉ cho IMG/LSSC/QRCode)
        private string newIMG = "";
        private string newLSSC = "";
        private string newQr = "";

        private string newBCDT = "";
        private string newHDSD = "";


        public FRM_EDIT_DEVICE(string maQuanLy)
        {
            InitializeComponent();
            _maQuanLy = maQuanLy;

            this.Load += FRM_EDIT_DEVICE_Load;
        }

        private void FRM_EDIT_DEVICE_Load(object sender, EventArgs e)
        {
            _deviceFolder = Path.Combine(Constaint._folderFileUpload, _maQuanLy);

            LoadDeviceType();
            LoadFactory();
            LoadMainFreq();
            LoadDeviceInfo();

            // Auto fill HDSD/BCDT khi đổi loại
            txtDeviceType.EditValueChanged += txtDeviceType_EditValueChanged;

            // Khuyến nghị: HDSD/BCDT không cho chọn nữa (auto theo type)
            //DisableManualPickHdsdBcdt();
        }

        // ============================================================
        // DISABLE PICK HDSD/BCDT (auto)
        // ============================================================
        private void DisableManualPickHdsdBcdt()
        {
            try
            {
                // Nếu bạn muốn ẩn luôn:
                // btnChooseHDSD.Visible = false;
                // btnChooseBCDT.Visible = false;

                // Nếu muốn disable:
                if (btnChooseHDSD != null) btnChooseHDSD.Enabled = false;
                if (btnChooseBCDT != null) btnChooseBCDT.Enabled = false;

                if (txtAttachFileHDSD != null)
                    txtAttachFileHDSD.ReadOnly = true;

                if (txtAttachFileBCDT != null) txtAttachFileBCDT.ReadOnly = true;
            }
            catch { }
        }

        // ============================================================
        // LOAD MASTER DATA
        // ============================================================
        private void LoadDeviceType()
        {
            try
            {
                string queryType = "SELECT TypeID, Type, TypeShort, HuongDanSuDung, BaoCaoDaoTao FROM TBL_DEVICE_TYPE";
                DataTable dataType = DBUtils._getData(queryType);

                txtDeviceType.Properties.DataSource = dataType;
                txtDeviceType.Properties.DisplayMember = "Type";
                txtDeviceType.Properties.ValueMember = "TypeID";
            }
            catch
            {
                MessageBox.Show("Không load được danh mục loại thiết bị!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadFactory()
        {
            try
            {
                string queryFactory = "SELECT * FROM TBL_FACTORY_MST";
                DataTable dataFactory = DBUtils._getData(queryFactory);

                txtFactory.Properties.DataSource = dataFactory;
                txtFactory.Properties.DisplayMember = "FactoryName";
                txtFactory.Properties.ValueMember = "ID";
            }
            catch
            {
                MessageBox.Show("Không load được danh mục nhà máy!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadMainFreq()
        {
            try
            {
                string queryMainFreq = "SELECT FreqID, FreqName FROM TBL_MAINT_FREQ";
                DataTable dataMainFreq = DBUtils._getData(queryMainFreq);

                txtTanSuatBD.Properties.DataSource = dataMainFreq;
                txtTanSuatBD.Properties.DisplayMember = "FreqName";
                txtTanSuatBD.Properties.ValueMember = "FreqID";
            }
            catch
            {
                MessageBox.Show("Không load được tần suất bảo dưỡng!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // LOAD DEVICE INFO
        // ============================================================
        private void LoadDeviceInfo()
        {
            try
            {
                string query = "SELECT  d.*, f.ID AS FactoryID, mf.FreqID   AS FreqID FROM TBL_DEVICE_MST d LEFT JOIN TBL_FACTORY_MST f ON d.NhaMay = f.FactoryName LEFT JOIN TBL_MAINT_FREQ mf ON d.TanSuat = mf.FreqName WHERE d.MaQuanLy = @MaQuanLy AND ISNULL(d.Huy,0) = 0";

                DataTable dt;

                using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);

                    SqlDataAdapter ad = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    ad.Fill(dt);
                }

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy thông tin thiết bị!", "Lỗi");
                    this.Close();
                    return;
                }

                DataRow r = dt.Rows[0];

                // ✅ TypeID trong TBL_DEVICE_MST
                int? typeId = null;
                if (r["TypeID"] != DBNull.Value && int.TryParse(r["TypeID"].ToString(), out int t))
                    typeId = t;

                if (typeId.HasValue)
                    txtDeviceType.EditValue = typeId.Value;
                else
                    txtDeviceType.EditValue = null;

                txtMQL.Text = r["MaQuanLy"]?.ToString();
                txtDeviceName.Text = r["TenThietBi"]?.ToString();
                txtSerial.Text = r["SerialNo"]?.ToString();
                txtModel.Text = r["Model"]?.ToString();
                txtPurpose.Text = r["MucDichSuDung"]?.ToString();
                txtSupplier.Text = r["NhaCungCap"]?.ToString();
                txtSize.Text = r["KichThuoc"]?.ToString();
                //txtFactory.Text = r["NhaMay"]?.ToString();
                if (r["FactoryID"] != DBNull.Value)
                    txtFactory.EditValue = Convert.ToInt32(r["FactoryID"]);
                else
                    txtFactory.EditValue = null;
                //txtTanSuatBD.Text = r["TanSuat"]?.ToString();
                if (r["FreqID"] != DBNull.Value)
                    txtTanSuatBD.EditValue = Convert.ToInt32(r["FreqID"]);
                else
                    txtTanSuatBD.EditValue = null;

                checkTSCD.Checked = (r["TaiSanCoDinh"]?.ToString() == "Có");

                // ngày bảo dưỡng
                dtNgayBD.EditValue = (r["NgayBaoDuong"] == DBNull.Value) ? null : (DateTime?)Convert.ToDateTime(r["NgayBaoDuong"]);

                // file cũ
                oldIMG = r["NguoiDuocPhepSuDung"]?.ToString();
                oldHDSD = r["HuongDanSuDung"]?.ToString();
                oldBCDT = r["BaoCaoDaoTao"]?.ToString();
                oldLSSC = r["LichSuBaoDuong"]?.ToString();
                oldQr = r["BarCode"]?.ToString();

                // hiển thị textbox file
                txtAttachFileIMG.Text = oldIMG;
                txtAttachFileHDSD.Text = oldHDSD;
                txtAttachFileBCDT.Text = oldBCDT;
                txtAttachFileLSSC.Text = oldLSSC;

                // show QR
                string qrPath = Path.Combine(Constaint._folderFileUpload, _maQuanLy, oldQr);
                if (File.Exists(qrPath))
                    imgBarCode.Image = Image.FromFile(qrPath);

                // Nếu bạn có cột TypeID trong TBL_DEVICE_MST thì nên set txtDeviceType.EditValue tại đây
                // Nếu chưa có thì bỏ qua.
                if (dt.Columns.Contains("TypeID") && r["TypeID"] != DBNull.Value)
                    txtDeviceType.EditValue = Convert.ToInt32(r["TypeID"]);
            }
            catch
            {
                MessageBox.Show("Không load được thông tin thiết bị!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // CHỌN FILE (CHỈ IMG / LSSC) - HDSD/BCDT AUTO
        // ============================================================
        private void btnChooseIMG_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image Files|*.png;*.jpg;*.jpeg";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                newIMG = dlg.FileName;
                txtAttachFileIMG.Text = Path.GetFileName(newIMG);
            }
        }

        private void btnChooseLSSC_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "PDF Files|*.pdf";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                newLSSC = dlg.FileName;
                txtAttachFileLSSC.Text = Path.GetFileName(newLSSC);
            }
        }

        private void btnChooseHDSD_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "PDF Files|*.pdf";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                newLSSC = dlg.FileName;
                txtAttachFileLSSC.Text = Path.GetFileName(newLSSC);
            }
        }

        private void btnChooseBCDT_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "PDF Files|*.pdf";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                newLSSC = dlg.FileName;
                txtAttachFileLSSC.Text = Path.GetFileName(newLSSC);
            }
        }

        // ============================================================
        // BARCODE
        // ============================================================
        public Image GenerateBarCode(string text)
        {
            var writer = new ZXing.BarcodeWriter
            {
                Format = ZXing.BarcodeFormat.CODE_128,
                Options = new ZXing.Common.EncodingOptions
                {
                    Height = 80,
                    Width = 300,
                    Margin = 2
                }
            };
            return writer.Write(text);
        }

        private void btnGenQR_Click(object sender, EventArgs e)
        {
            string code = txtMQL.Text.Trim();
            if (string.IsNullOrWhiteSpace(code)) return;

            Image qr = GenerateBarCode(code);
            imgBarCode.Image = qr;

            string temp = Path.Combine(Path.GetTempPath(), $"{code}_BarCode.png");
            qr.Save(temp);

            newQr = temp;
        }

        // ============================================================
        // AUTO FILL HDSD/BCDT WHEN TYPE CHANGED
        // ============================================================
        private void txtDeviceType_EditValueChanged(object sender, EventArgs e)
        {
            int? typeId = GetCurrentTypeId();
            if (!typeId.HasValue) return;

            var info = GetTypeInfo(typeId.Value);

            // chỉ fill tên file type để user thấy (file thật sẽ copy lúc Save)
            txtAttachFileHDSD.Text = info.HdsdFile;
            txtAttachFileBCDT.Text = info.BcdtFile;
        }

        private int? GetCurrentTypeId()
        {
            if (txtDeviceType.EditValue == null || txtDeviceType.EditValue == DBNull.Value)
                return null;

            if (int.TryParse(txtDeviceType.EditValue.ToString(), out int id))
                return id;

            return null;
        }

        private (string TypeShort, string HdsdFile, string BcdtFile) GetTypeInfo(int typeId)
        {
            try
            {
                string q = @"
SELECT TypeShort, HuongDanSuDung, BaoCaoDaoTao
FROM TBL_DEVICE_TYPE
WHERE TypeID = @TypeID AND ISNULL(Huy,0)=0";

                using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                using (SqlCommand cmd = new SqlCommand(q, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@TypeID", typeId);

                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        if (!rd.Read()) return ("", "", "");

                        string typeShort = rd["TypeShort"] == DBNull.Value ? "" : rd["TypeShort"].ToString();
                        string hdsd = rd["HuongDanSuDung"] == DBNull.Value ? "" : rd["HuongDanSuDung"].ToString();
                        string bcdt = rd["BaoCaoDaoTao"] == DBNull.Value ? "" : rd["BaoCaoDaoTao"].ToString();

                        return (typeShort, hdsd, bcdt);
                    }
                }
            }
            catch
            {
                return ("", "", "");
            }
        }


        private (string HDSD, string BCDT) GetTypeFiles(int typeId)
        {
            try
            {
                string q = "SELECT HuongDanSuDung, BaoCaoDaoTao FROM TBL_DEVICE_TYPE WHERE TypeID = @TypeID";
                using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                using (SqlCommand cmd = new SqlCommand(q, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@TypeID", typeId);

                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        ad.Fill(dt);
                        if (dt.Rows.Count == 0) return ("", "");

                        string hdsd = dt.Rows[0]["HuongDanSuDung"] == DBNull.Value ? "" : dt.Rows[0]["HuongDanSuDung"].ToString();
                        string bcdt = dt.Rows[0]["BaoCaoDaoTao"] == DBNull.Value ? "" : dt.Rows[0]["BaoCaoDaoTao"].ToString();
                        return (hdsd, bcdt);
                    }
                }
            }
            catch
            {
                return ("", "");
            }
        }

        // ============================================================
        // HELPERS
        // ============================================================
        private object DbNullIfEmpty(string text)
        {
            return string.IsNullOrWhiteSpace(text) ? (object)DBNull.Value : text.Trim();
        }

        private DateTime? TinhNgayBaoDuongTiepTheo(DateTime? ngayBaoDuong, string tanSuat)
        {
            if (!ngayBaoDuong.HasValue || string.IsNullOrWhiteSpace(tanSuat))
                return null;

            string s = tanSuat.Trim().ToLower();

            Match m = Regex.Match(s, @"\d+");
            if (!m.Success || !int.TryParse(m.Value, out int n) || n <= 0)
                return null;

            if (s.Contains("tháng")) return ngayBaoDuong.Value.AddMonths(n);
            if (s.Contains("năm")) return ngayBaoDuong.Value.AddYears(n);

            return null;
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtDeviceName.Text))
            {
                XtraMessageBox.Show("Vui lòng nhập Tên thiết bị!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDeviceName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtFactory.Text))
            {
                XtraMessageBox.Show("Vui lòng chọn Nhà máy!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFactory.Focus();
                return false;
            }

            if (txtDeviceType.EditValue == null)
            {
                XtraMessageBox.Show("Vui lòng chọn Loại thiết bị!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDeviceType.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTanSuatBD.Text))
            {
                XtraMessageBox.Show("Vui lòng chọn Tần suất bảo dưỡng!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTanSuatBD.Focus();
                return false;
            }

            if (dtNgayBD.EditValue == null || dtNgayBD.EditValue == DBNull.Value)
            {
                XtraMessageBox.Show("Vui lòng chọn Ngày bảo dưỡng!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtNgayBD.Focus();
                return false;
            }

            return true;
        }

        // ============================================================
        // COPY FILES:
        // - IMG/LSSC/Barcode from user selection (if any)
        // - HDSD/BCDT auto from TYPE folder, then rename to MaQuanLy_*.pdf
        // ============================================================
        private (string Img, string Lssc, string Hdsd, string Bcdt, string Barcode) SaveFilesByRule()
        {
            if (!Directory.Exists(_deviceFolder))
                Directory.CreateDirectory(_deviceFolder);

            string imgName = oldIMG;
            string lsscName = oldLSSC;
            string hdsdName = oldHDSD;
            string bcdtName = oldBCDT;
            string barcodeName = oldQr;

            // =========================
            // 1) IMG (user chọn)
            // =========================
            if (!string.IsNullOrWhiteSpace(newIMG) && File.Exists(newIMG))
            {
                string ext = Path.GetExtension(newIMG);
                string dest = Path.Combine(_deviceFolder, $"{_maQuanLy}_IMG{ext}");
                File.Copy(newIMG, dest, true);
                imgName = Path.GetFileName(dest);
            }

            // =========================
            // 2) LSSC (user chọn)
            // =========================
            if (!string.IsNullOrWhiteSpace(newLSSC) && File.Exists(newLSSC))
            {
                string dest = Path.Combine(_deviceFolder, $"{_maQuanLy}_LSSC.pdf");
                File.Copy(newLSSC, dest, true);
                lsscName = Path.GetFileName(dest);
            }

            // =========================
            // 3) Barcode (user gen)
            // =========================
            if (!string.IsNullOrWhiteSpace(newQr) && File.Exists(newQr))
            {
                string dest = Path.Combine(_deviceFolder, $"{_maQuanLy}_BarCode.png");
                File.Copy(newQr, dest, true);
                barcodeName = Path.GetFileName(dest);
            }

            // =========================
            // 4) HDSD / BCDT:
            //    - nếu user chọn file mới -> ưu tiên file đó
            //    - nếu user không chọn -> auto theo loại thiết bị
            // =========================

            // 4.1) nếu user chọn HDSD thủ công
            if (!string.IsNullOrWhiteSpace(newHDSD) && File.Exists(newHDSD))
            {
                string dest = Path.Combine(_deviceFolder, $"{_maQuanLy}_HDSD.pdf");
                File.Copy(newHDSD, dest, true);
                hdsdName = Path.GetFileName(dest);
            }
            else
            {
                // auto theo type
                var auto = GetAutoTypeFilesAndCopyToDeviceFolder(copyHdsd: true, copyBcdt: false);
                if (!string.IsNullOrWhiteSpace(auto.Hdsd))
                    hdsdName = auto.Hdsd;
            }

            // 4.2) nếu user chọn BCDT thủ công
            if (!string.IsNullOrWhiteSpace(newBCDT) && File.Exists(newBCDT))
            {
                string dest = Path.Combine(_deviceFolder, $"{_maQuanLy}_BCDT.pdf");
                File.Copy(newBCDT, dest, true);
                bcdtName = Path.GetFileName(dest);
            }
            else
            {
                // auto theo type
                var auto = GetAutoTypeFilesAndCopyToDeviceFolder(copyHdsd: false, copyBcdt: true);
                if (!string.IsNullOrWhiteSpace(auto.Bcdt))
                    bcdtName = auto.Bcdt;
            }

            // update UI
            txtAttachFileIMG.Text = imgName;
            txtAttachFileLSSC.Text = lsscName;
            txtAttachFileHDSD.Text = hdsdName;
            txtAttachFileBCDT.Text = bcdtName;

            return (imgName, lsscName, hdsdName, bcdtName, barcodeName);
        }

        private (string Hdsd, string Bcdt) GetAutoTypeFilesAndCopyToDeviceFolder(bool copyHdsd, bool copyBcdt)
        {
            DataRowView rowType = txtDeviceType.GetSelectedDataRow() as DataRowView;
            if (rowType == null) return ("", "");

            int typeId = Convert.ToInt32(rowType["TypeID"]);
            string typeShort = rowType["TypeShort"]?.ToString() ?? "";

            var (typeHdsd, typeBcdt) = GetTypeFiles(typeId);
            string typeFolder = Path.Combine(Constaint._folderFileUpload, "DEVICE_TYPE", typeShort);

            string hdsdName = "";
            string bcdtName = "";

            if (copyHdsd && !string.IsNullOrWhiteSpace(typeHdsd))
            {
                string src = Path.Combine(typeFolder, typeHdsd);
                if (File.Exists(src))
                {
                    hdsdName = $"{_maQuanLy}_HDSD.pdf";
                    File.Copy(src, Path.Combine(_deviceFolder, hdsdName), true);
                }
            }

            if (copyBcdt && !string.IsNullOrWhiteSpace(typeBcdt))
            {
                string src = Path.Combine(typeFolder, typeBcdt);
                if (File.Exists(src))
                {
                    bcdtName = $"{_maQuanLy}_BCDT.pdf";
                    File.Copy(src, Path.Combine(_deviceFolder, bcdtName), true);
                }
            }

            return (hdsdName, bcdtName);
        }


        // ============================================================
        // SAVE
        // ============================================================
        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                if (!ValidateInput()) return;

                // confirm
                if (MessageBox.Show("Xác nhận cập nhật thiết bị?", "Cập nhật",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;

                // 1) Copy file theo rule mới
                var files = SaveFilesByRule();

                // 2) Ngày bảo dưỡng + kế hoạch
                DateTime? newNgayBaoDuong = null;
                if (dtNgayBD.EditValue != null && dtNgayBD.EditValue != DBNull.Value)
                {
                    if (DateTime.TryParse(dtNgayBD.EditValue.ToString(), out DateTime d))
                        newNgayBaoDuong = d.Date;
                }

                string tanSuatText = txtTanSuatBD.Text.Trim();
                DateTime? keHoachTiepTheo = TinhNgayBaoDuongTiepTheo(newNgayBaoDuong, tanSuatText);

                // 3) Update DB
                string query = @"
UPDATE TBL_DEVICE_MST SET
    TenThietBi = @TenThietBi,
    SerialNo = @SerialNo,
    Model = @Model,
    KichThuoc = @KichThuoc,
    NhaCungCap = @NhaCungCap,
    MucDichSuDung = @MucDichSuDung,
    NhaMay = @NhaMay,

    NguoiDuocPhepSuDung = @IMG,
    HuongDanSuDung = @HDSD,
    BaoCaoDaoTao = @BCDT,
    LichSuBaoDuong = @LSSC,
    BarCode = @QR,

    NgayBaoDuong = @NgayBaoDuong,
    KeHoachBaoDuongTiepTheo = @KeHoachBaoDuongTiepTheo,
    TanSuat = @TanSuat,
    TaiSanCoDinh = @TSCD,

    UPDATE_DATE = GETDATE(),
    UPDATE_BY = @UPDATE_BY
WHERE MaQuanLy = @MaQuanLy;
";

                using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TenThietBi", DbNullIfEmpty(txtDeviceName.Text));
                        cmd.Parameters.AddWithValue("@SerialNo", DbNullIfEmpty(txtSerial.Text));
                        cmd.Parameters.AddWithValue("@Model", DbNullIfEmpty(txtModel.Text));
                        cmd.Parameters.AddWithValue("@KichThuoc", DbNullIfEmpty(txtSize.Text));
                        cmd.Parameters.AddWithValue("@NhaCungCap", DbNullIfEmpty(txtSupplier.Text));
                        cmd.Parameters.AddWithValue("@MucDichSuDung", DbNullIfEmpty(txtPurpose.Text));
                        cmd.Parameters.AddWithValue("@NhaMay", DbNullIfEmpty(txtFactory.Text));

                        cmd.Parameters.AddWithValue("@IMG", (object)files.Img ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@HDSD", DbNullIfEmpty(oldHDSD));
                        cmd.Parameters.AddWithValue("@BCDT", DbNullIfEmpty(oldBCDT));
                        cmd.Parameters.AddWithValue("@LSSC", (object)files.Lssc ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@QR", (object)files.Barcode ?? DBNull.Value);

                        cmd.Parameters.AddWithValue("@NgayBaoDuong", newNgayBaoDuong.HasValue ? (object)newNgayBaoDuong.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@KeHoachBaoDuongTiepTheo", keHoachTiepTheo.HasValue ? (object)keHoachTiepTheo.Value : DBNull.Value);

                        cmd.Parameters.AddWithValue("@TanSuat", DbNullIfEmpty(tanSuatText));
                        cmd.Parameters.AddWithValue("@TSCD", checkTSCD.Checked ? "Có" : "Không");

                        cmd.Parameters.AddWithValue("@UPDATE_BY", (object)Constaint._userID ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);

                        int affected = cmd.ExecuteNonQuery();
                        if (affected <= 0)
                        {
                            MessageBox.Show("Không cập nhật được dữ liệu (không tìm thấy mã quản lý).",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }

                MessageBox.Show("Cập nhật thành công!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                // Bạn không muốn show chi tiết thì đổi sang message chung
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
