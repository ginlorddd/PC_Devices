using DevExpress.Utils;
using DevExpress.XtraEditors;
using PC_Devices.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PC_Devices.FRM.DEVICE_MANAGEMENT
{
    public partial class FRM_ADD_DEVICE : DevExpress.XtraEditors.XtraForm
    {

        private string _srcHdsdFullPath = "";
        private string _srcBcdtFullPath = "";

        public FRM_ADD_DEVICE()
        {
            InitializeComponent();
            this.Load += FRM_ADD_DEVICE_Load;
        }

        private void FRM_ADD_DEVICE_Load(object sender, EventArgs e)
        {
            LoadDeviceType();
            LoadFactory();
            LoadMainFreq();
        }
        private void LoadDeviceType()
        {
            try
            {
                string queryType = "SELECT TypeID, Type, TypeShort FROM TBL_DEVICE_TYPE";
                DataTable dataType = DBUtils._getData(queryType);

                txtDeviceType.Properties.DataSource = dataType;
                txtDeviceType.Properties.DisplayMember = "Type";
                txtDeviceType.Properties.ValueMember = "TypeID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //private void SaveApprovedFiles(string maQuanLy)
        //{
        //    try
        //    {
        //        // Tạo thư mục
        //        string deviceFolder = Path.Combine(Constaint._folderFileUpload, maQuanLy);
        //        if (!Directory.Exists(deviceFolder))
        //            Directory.CreateDirectory(deviceFolder);

        //        // LSSC
        //        if (!string.IsNullOrEmpty(txtAttachFileLSSC.Text))
        //        {
        //            string dest = Path.Combine(deviceFolder, $"{maQuanLy}_LSSC.pdf");
        //            File.Copy(pathLSSCFile, dest, true);
        //        }

        //        // BCDT
        //        if (!string.IsNullOrEmpty(txtAttachFileBCDT.Text))
        //        {
        //            string dest = Path.Combine(deviceFolder, $"{maQuanLy}_BCDT.pdf");
        //            File.Copy(pathBCDTFile, dest, true);
        //        }

        //        // HDSD
        //        if (!string.IsNullOrEmpty(txtAttachFileHDSD.Text))
        //        {
        //            string dest = Path.Combine(deviceFolder, $"{maQuanLy}_HDSD.pdf");
        //            File.Copy(pathHDSDFile, dest, true);
        //        }

        //        // IMG
        //        if (!string.IsNullOrEmpty(txtAttachFileIMG.Text))
        //        {
        //            string ext = Path.GetExtension(pathIMGFile);
        //            string dest = Path.Combine(deviceFolder, $"{maQuanLy}_IMG{ext}");
        //            File.Copy(pathIMGFile, dest, true);
        //        }


        //        // Bar Code
        //        if (!string.IsNullOrEmpty(pathQrFile) && File.Exists(pathQrFile))
        //        {
        //            string dest = Path.Combine(deviceFolder, $"{maQuanLy}_BarCode.png");
        //            File.Copy(pathQrFile, dest, true);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Không thể lưu file!\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private (string HDSD, string BCDT) GetTypeFiles(int typeId)
        {
            string q = $"SELECT HuongDanSuDung, BaoCaoDaoTao FROM TBL_DEVICE_TYPE WHERE TypeID = {typeId}";
            DataTable dt = DBUtils._getData(q);
            if (dt == null || dt.Rows.Count == 0) return ("", "");

            string hdsd = dt.Rows[0]["HuongDanSuDung"] == DBNull.Value ? "" : dt.Rows[0]["HuongDanSuDung"].ToString();
            string bcdt = dt.Rows[0]["BaoCaoDaoTao"] == DBNull.Value ? "" : dt.Rows[0]["BaoCaoDaoTao"].ToString();
            return (hdsd, bcdt);
        }

        private (string Img, string Lssc, string Hdsd, string Bcdt, string Barcode) SaveApprovedFiles(string maQuanLy)
        {
            // tên file lưu vào DB
            string imgName = null;
            string lsscName = null;
            string hdsdName = null;
            string bcdtName = null;
            string barcodeName = null;

            // folder thiết bị
            string deviceFolder = Path.Combine(Constaint._folderFileUpload, maQuanLy);
            if (!Directory.Exists(deviceFolder))
                Directory.CreateDirectory(deviceFolder);

            // =========================
            // 1) IMG (user chọn)
            // =========================
            if (!string.IsNullOrWhiteSpace(pathIMGFile) && File.Exists(pathIMGFile))
            {
                string ext = Path.GetExtension(pathIMGFile);
                imgName = $"{maQuanLy}_IMG{ext}";
                File.Copy(pathIMGFile, Path.Combine(deviceFolder, imgName), true);
            }

            // =========================
            // 2) LSSC (user chọn)
            // =========================
            if (!string.IsNullOrWhiteSpace(pathLSSCFile) && File.Exists(pathLSSCFile))
            {
                lsscName = $"{maQuanLy}_LSSC.pdf";
                File.Copy(pathLSSCFile, Path.Combine(deviceFolder, lsscName), true);
            }

            // =========================
            // 3) BarCode (đã gen)
            // =========================
            if (!string.IsNullOrWhiteSpace(pathQrFile) && File.Exists(pathQrFile))
            {
                barcodeName = $"{maQuanLy}_BarCode.png";
                File.Copy(pathQrFile, Path.Combine(deviceFolder, barcodeName), true);
            }

            // =========================
            // 4) HDSD + BCDT (auto theo loại thiết bị)
            // =========================
            DataRowView rowType = txtDeviceType.GetSelectedDataRow() as DataRowView;
            if (rowType == null)
                throw new Exception("Chưa chọn loại thiết bị!");

            int typeId = Convert.ToInt32(rowType["TypeID"]);
            string typeShort = rowType["TypeShort"]?.ToString() ?? "";

            var (typeHdsd, typeBcdt) = GetTypeFiles(typeId);

            string typeFolder = Path.Combine(Constaint._folderFileUpload, "DEVICE_TYPE", typeShort);

            // HDSD
            if (!string.IsNullOrWhiteSpace(typeHdsd))
            {
                string src = Path.Combine(typeFolder, typeHdsd);
                if (!File.Exists(src))
                    throw new Exception($"Không tìm thấy file HDSD theo loại '{typeShort}'. Vui lòng cấu hình trong Danh mục loại thiết bị!");

                hdsdName = $"{maQuanLy}_HDSD.pdf";
                File.Copy(src, Path.Combine(deviceFolder, hdsdName), true);
            }

            // BCDT
            if (!string.IsNullOrWhiteSpace(typeBcdt))
            {
                string src = Path.Combine(typeFolder, typeBcdt);
                if (!File.Exists(src))
                    throw new Exception($"Không tìm thấy file BCDT theo loại '{typeShort}'. Vui lòng cấu hình trong Danh mục loại thiết bị!");

                bcdtName = $"{maQuanLy}_BCDT.pdf";
                File.Copy(src, Path.Combine(deviceFolder, bcdtName), true);
            }

            // update textbox để user nhìn (nếu cần)
            if (!string.IsNullOrWhiteSpace(imgName)) txtAttachFileIMG.Text = imgName;
            if (!string.IsNullOrWhiteSpace(lsscName)) txtAttachFileLSSC.Text = lsscName;
            if (!string.IsNullOrWhiteSpace(hdsdName)) txtAttachFileHDSD.Text = hdsdName;
            if (!string.IsNullOrWhiteSpace(bcdtName)) txtAttachFileBCDT.Text = bcdtName;

            return (imgName, lsscName, hdsdName, bcdtName, barcodeName);
        }


        public Image GenBarCode(string text)
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

        private string GenControlNo(string typeShort)
        {
            string query = $@"
                                SELECT MaQuanLy 
                                FROM TBL_DEVICE_MST
                                WHERE MaQuanLy LIKE 'PC-{typeShort}-%' AND ISNULL(Huy, 0) = 0
                                ORDER BY MaQuanLy DESC
                            ";

            DataTable dt = DBUtils._getData(query);

            int next = 1;

            if (dt.Rows.Count > 0)
            {
                string lastCode = dt.Rows[0]["MaQuanLy"].ToString();
                string numberStr = lastCode.Substring(lastCode.LastIndexOf('-') + 1);
                int number = int.Parse(numberStr);
                next = number + 1;
            }

            return $"PC-{typeShort}-{next.ToString("D2")}";
        }


        private DateTime? TinhNgayBaoDuongTiepTheo(DateTime? ngayBaoDuong, string tanSuat)
        {
            if (!ngayBaoDuong.HasValue || string.IsNullOrWhiteSpace(tanSuat))
                return null;

            tanSuat = tanSuat.Trim().ToLower();

            // Tách số trong chuỗi (vd: "6 tháng" -> 6)
            int value = 0;
            var match = System.Text.RegularExpressions.Regex.Match(tanSuat, @"\d+");
            if (!match.Success || !int.TryParse(match.Value, out value))
                return null;

            DateTime ngay = ngayBaoDuong.Value;

            // Xác định đơn vị
            if (tanSuat.Contains("tháng"))
                return ngay.AddMonths(value);

            if (tanSuat.Contains("năm"))
                return ngay.AddYears(value);

            return null;
        }


        private void txtDeviceType_EditValueChanged(object sender, EventArgs e)
        {
            DataRowView row = txtDeviceType.GetSelectedDataRow() as DataRowView;
            if (row == null) return;

            string typeShort = row["TypeShort"].ToString();
            string maQL = GenControlNo(typeShort);
            int typeId = Convert.ToInt32(row["TypeID"]);

            _updatingMql = true;
            txtMQL.Text = maQL;
            _updatingMql = false;

            // gọi trực tiếp để gen barcode (không phụ thuộc event)
            txtMQL_EditValueChanged(txtMQL, EventArgs.Empty);
            AutoFillTrainingFiles(typeId, typeShort);
            if (!File.Exists(_srcHdsdFullPath) || !File.Exists(_srcBcdtFullPath))
            {
                MessageBox.Show("Loại thiết bị chưa có file HDSD/BCDT. Vui lòng cấu hình trong Danh mục loại thiết bị!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        //Gen BarCode theo mã quản lý
        //Cho BarCode là hình ảnh
        //Cho BarCode hiển thị lên
        //Khi ấn lưu 
        //Sẽ lưu hình ảnh vào 1 folder , tên là mã quản lý
        //Lưu hình vào bảng trong database 1 cột, BarCode url : \\172.16.253.4\test\pc-ht-001.jpg

        private void AutoFillTrainingFiles(int typeId, string typeShort)
        {
            try
            {
                string q = $"SELECT HuongDanSuDung, BaoCaoDaoTao FROM TBL_DEVICE_TYPE WHERE TypeID = {typeId}";
                DataTable dt = DBUtils._getData(q);

                if (dt == null || dt.Rows.Count == 0) return;

                string hdsd = dt.Rows[0]["HuongDanSuDung"]?.ToString();
                string bcdt = dt.Rows[0]["BaoCaoDaoTao"]?.ToString();

                // hiển thị lên textbox (nếu bạn có txtAttachFileHDSD/BCDT)
                txtAttachFileHDSD.Text = hdsd;
                txtAttachFileBCDT.Text = bcdt;

                // lưu full path nguồn (để khi save thiết bị copy sang folder thiết bị)
                string typeFolder = Path.Combine(Constaint._folderFileUpload, "DEVICE_TYPE", typeShort);

                _srcHdsdFullPath = string.IsNullOrWhiteSpace(hdsd) ? "" : Path.Combine(typeFolder, hdsd);
                _srcBcdtFullPath = string.IsNullOrWhiteSpace(bcdt) ? "" : Path.Combine(typeFolder, bcdt);

                // nếu muốn: không cho chọn nữa
                // btnChooseHDSD.Enabled = false;
                // btnChooseBCDT.Enabled = false;
            }
            catch { }
        }

        private bool _updatingMql;   // field của form

        private void txtMQL_EditValueChanged(object sender, EventArgs e)
        {
            if (_updatingMql) return;

            try
            {
                string maQL = txtMQL.Text?.Trim();
                if (string.IsNullOrWhiteSpace(maQL))
                {
                    imgBarCode.Image = null;
                    pathQrFile = null;
                    return;
                }

                // (tuỳ chọn) chuẩn hoá: bỏ khoảng trắng, ký tự lạ
                // maQL = maQL.Replace(" ", "");

                Image qrImg = GenBarCode(maQL);
                imgBarCode.Image = qrImg;

                // Lưu ra temp file mới
                string tempPath = Path.Combine(Path.GetTempPath(), $"{maQL}_BarCode.png");

                // tránh lỗi file đang bị dùng/đè: xoá file cũ nếu có
                try { if (File.Exists(tempPath)) File.Delete(tempPath); } catch { }

                qrImg.Save(tempPath, System.Drawing.Imaging.ImageFormat.Png);
                pathQrFile = tempPath;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tạo barcode: " + ex.Message);
            }
        }


        private string pathLSSCFile = "";
        private string pathBCDTFile = "";
        private string pathHDSDFile = "";
        private string pathIMGFile = "";
        private string pathQrFile = "";

        private void btnFileIMG_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.bmp;*.gif)|*.png;*.jpg;*.jpeg;*.bmp;*.gif";
                openFileDialog.CheckFileExists = true;
                openFileDialog.AddExtension = true;

                DialogResult result = openFileDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string pathImg = openFileDialog.FileName;

                    string fileExt = Path.GetExtension(pathImg).ToLower();

                    if (fileExt != ".png" && fileExt != ".jpg" &&
                        fileExt != ".jpeg" && fileExt != ".bmp" && fileExt != ".gif")
                    {
                        MessageBox.Show("Chỉ được phép chọn file hình ảnh!",
                                        "",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                        return;
                    }

                    string fileNameOnly = Path.GetFileName(pathImg);
                    txtAttachFileIMG.Text = fileNameOnly;
                    pathIMGFile = openFileDialog.FileName;
                    // 
                    // txtAttachFileIMG.Enabled = false;

                    // 
                    // _pathImageSelected = pathImg;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void btnFileHDSD_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "PDF Files | *.pdf";
                openFileDialog.CheckFileExists = true;
                openFileDialog.AddExtension = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string path = openFileDialog.FileName;
                    string ext = Path.GetExtension(path).ToLower();

                    if (ext != ".pdf")
                    {
                        MessageBox.Show("Chỉ được phép chọn file PDF!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string fileName = Path.GetFileName(path);
                    txtAttachFileHDSD.Text = fileName;
                    pathHDSDFile = openFileDialog.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void btnFileBCDT_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "PDF Files | *.pdf";
                openFileDialog.CheckFileExists = true;
                openFileDialog.AddExtension = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string path = openFileDialog.FileName;
                    string ext = Path.GetExtension(path).ToLower();

                    if (ext != ".pdf")
                    {
                        MessageBox.Show("Chỉ được phép chọn file PDF!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string fileName = Path.GetFileName(path);
                    txtAttachFileBCDT.Text = fileName;
                    pathBCDTFile = openFileDialog.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void btnFileLSSC_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "PDF Files | *.pdf";
                openFileDialog.CheckFileExists = true;
                openFileDialog.AddExtension = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string path = openFileDialog.FileName;
                    string ext = Path.GetExtension(path).ToLower();

                    if (ext != ".pdf")
                    {
                        MessageBox.Show("Chỉ được phép chọn file PDF!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string fileName = Path.GetFileName(path);
                    txtAttachFileLSSC.Text = fileName;
                    pathLSSCFile = openFileDialog.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //private void btnAdd_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string maQuanLy = txtMQL.Text.Trim();

        //        string queryCheck = $"SELECT * FROM TBL_DEVICE_MST WHERE MaQuanLy = '{maQuanLy}' AND ISNULL(Huy,0) = 0";
        //        DataTable dtCheck = DBUtils._getData(queryCheck);

        //        if (dtCheck.Rows.Count > 0)
        //        {
        //            MessageBox.Show("Mã quản lý thiết bị đã tồn tại!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return;
        //        }

        //        if (string.IsNullOrEmpty(txtDeviceName.Text))
        //        {
        //            MessageBox.Show("Tên thiết bị không được để trống!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return;
        //        }

        //        if (txtDeviceType.EditValue == null)
        //        {
        //            MessageBox.Show("Chọn loại thiết bị!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return;
        //        }

        //        if (txtFactory.EditValue == null)
        //        {
        //            MessageBox.Show("Chọn nhà máy!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return;
        //        }

        //        if (dtNgayBD.EditValue == null)
        //        {
        //            MessageBox.Show("Chọn ngày bảo dưỡng!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return;
        //        }


        //        SaveApprovedFiles(maQuanLy);


        //        DialogResult rs = MessageBox.Show("Xác nhận lưu thiết bị mới?", "Lưu",
        //                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

        //        if (rs != DialogResult.OK) return;


        //        DateTime? ngayBaoDuong = dtNgayBD.EditValue as DateTime?;
        //        string tanSuat = txtTanSuatBD.Text;

        //        DateTime? ngayKeHoach = TinhNgayBaoDuongTiepTheo(ngayBaoDuong, tanSuat);


        //        string queryInsert = @"
        //                                INSERT INTO TBL_DEVICE_MST
        //                                (
        //                                    TenThietBi,
        //                                    MaQuanLy,
        //                                    SerialNo,
        //                                    Model,
        //                                    KichThuoc,
        //                                    NhaCungCap,
        //                                    MucDichSuDung,
        //                                    NhaMay,
        //                                    NguoiDuocPhepSuDung,
        //                                    HuongDanSuDung,
        //                                    BaoCaoDaoTao,
        //                                    LichSuBaoDuong,
        //                                    NgayBaoDuong,
        //                                    KeHoachBaoDuongTiepTheo,
        //                                    TanSuat,
        //                                    TaiSanCoDinh,
        //                                    BarCode,
        //                                    StatusID,
        //                                    Huy,
        //                                    CREATE_DATE,
        //                                    CREATE_BY,
        //                                    UPDATE_DATE,
        //                                    UPDATE_BY
        //                                )
        //                                VALUES
        //                                (
        //                                    @TenThietBi,
        //                                    @MaQuanLy,
        //                                    @SerialNo,
        //                                    @Model,
        //                                    @KichThuoc,
        //                                    @NhaCungCap,
        //                                    @MucDichSuDung,
        //                                    @NhaMay,
        //                                    @NguoiDuocPhepSuDung,
        //                                    @HuongDanSuDung,
        //                                    @BaoCaoDaoTao,
        //                                    @LichSuBaoDuong,
        //                                    @NgayBaoDuong,
        //                                    @KeHoachBaoDuongTiepTheo,
        //                                    @TanSuat,
        //                                    @TaiSanCoDinh,
        //                                    @BarCode,
        //                                    @StatusID,
        //                                    @Huy,
        //                                    GETDATE(),        -- CREATE_DATE
        //                                    @CREATE_BY,       -- CREATE_BY
        //                                    NULL,             -- UPDATE_DATE
        //                                    NULL              -- UPDATE_BY
        //                                )";

        //        // Folder thiết bị
        //        string deviceFolder = Path.Combine(Constaint._folderFileUpload, maQuanLy);
        //        if (!Directory.Exists(deviceFolder)) Directory.CreateDirectory(deviceFolder);

        //        // HDSD
        //        string hdsdFileName = $"{maQuanLy}_HDSD.pdf";
        //        if (!string.IsNullOrWhiteSpace(_srcHdsdFullPath) && File.Exists(_srcHdsdFullPath))
        //        {
        //            File.Copy(_srcHdsdFullPath, Path.Combine(deviceFolder, hdsdFileName), true);
        //        }

        //        // BCDT
        //        string bcdtFileName = $"{maQuanLy}_BCDT.pdf";
        //        if (!string.IsNullOrWhiteSpace(_srcBcdtFullPath) && File.Exists(_srcBcdtFullPath))
        //        {
        //            File.Copy(_srcBcdtFullPath, Path.Combine(deviceFolder, bcdtFileName), true);
        //        }

        //        // DB lưu theo thiết bị như bạn đang làm:

        //        using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
        //        {
        //            conn.Open();
        //            using (SqlCommand cmd = new SqlCommand(queryInsert, conn))
        //            {
        //                cmd.Parameters.AddWithValue("@TenThietBi", txtDeviceName.Text.Trim());
        //                cmd.Parameters.AddWithValue("@MaQuanLy", maQuanLy);

        //                cmd.Parameters.AddWithValue("@SerialNo",
        //                    string.IsNullOrWhiteSpace(txtSerial.Text) ? (object)DBNull.Value : txtSerial.Text.Trim());

        //                cmd.Parameters.AddWithValue("@Model",
        //                    string.IsNullOrWhiteSpace(txtModel.Text) ? (object)DBNull.Value : txtModel.Text.Trim());

        //                cmd.Parameters.AddWithValue("@KichThuoc",
        //                    string.IsNullOrWhiteSpace(txtSize.Text) ? (object)DBNull.Value : txtSize.Text.Trim());

        //                cmd.Parameters.AddWithValue("@NhaCungCap",
        //                    string.IsNullOrWhiteSpace(txtSupplier.Text) ? (object)DBNull.Value : txtSupplier.Text.Trim());

        //                cmd.Parameters.AddWithValue("@MucDichSuDung",
        //                    string.IsNullOrWhiteSpace(txtPurpose.Text) ? (object)DBNull.Value : txtPurpose.Text.Trim());

        //                cmd.Parameters.AddWithValue("@NhaMay",
        //                    string.IsNullOrWhiteSpace(txtFactory.Text) ? (object)DBNull.Value : txtFactory.Text.Trim());

        //                cmd.Parameters.AddWithValue("@NguoiDuocPhepSuDung",
        //                    $"{maQuanLy}_IMG{Path.GetExtension(pathIMGFile)}");

        //                //cmd.Parameters.AddWithValue("@HuongDanSuDung", $"{maQuanLy}_HDSD.pdf");
        //                //cmd.Parameters.AddWithValue("@BaoCaoDaoTao", $"{maQuanLy}_BCDT.pdf");
        //                cmd.Parameters.AddWithValue("@HuongDanSuDung", hdsdFileName);
        //                cmd.Parameters.AddWithValue("@BaoCaoDaoTao", bcdtFileName);
        //                cmd.Parameters.AddWithValue("@LichSuBaoDuong", $"{maQuanLy}_LSSC.pdf");



        //                cmd.Parameters.AddWithValue("@NgayBaoDuong",
        //                    ngayBaoDuong.HasValue ? (object)ngayBaoDuong.Value : DBNull.Value);

        //                cmd.Parameters.AddWithValue("@KeHoachBaoDuongTiepTheo",
        //                    ngayKeHoach.HasValue ? (object)ngayKeHoach.Value : DBNull.Value);

        //                cmd.Parameters.AddWithValue("@TanSuat", txtTanSuatBD.Text.Trim());
        //                cmd.Parameters.AddWithValue("@TaiSanCoDinh", checkTSCD.Checked ? "Có" : "Không");

        //                cmd.Parameters.AddWithValue("@BarCode", $"{maQuanLy}_BarCode.png");

        //                // ✅ SỬA CHUẨN
        //                cmd.Parameters.AddWithValue("@StatusID", 1); // INT
        //                cmd.Parameters.AddWithValue("@Huy", 0);      // BIT / INT
        //                cmd.Parameters.AddWithValue("@CREATE_BY", (object)Constaint._userID ?? DBNull.Value);

        //                cmd.ExecuteNonQuery();

        //            }
        //        }

        //        MessageBox.Show("Lưu thiết bị thành công!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //        this.DialogResult = DialogResult.OK;
        //        this.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string maQuanLy = txtMQL.Text.Trim();

                // 0) Validate cơ bản
                if (string.IsNullOrWhiteSpace(maQuanLy))
                {
                    MessageBox.Show("Mã quản lý không được để trống!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtDeviceType.EditValue == null)
                {
                    MessageBox.Show("Chọn loại thiết bị!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtTanSuatBD.EditValue == null)
                {
                    MessageBox.Show("Chọn tần suất!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 1) Check trùng (Huy=0)
                string queryCheck = $"SELECT 1 FROM TBL_DEVICE_MST WHERE MaQuanLy = '{maQuanLy.Replace("'", "''")}' AND ISNULL(Huy,0) = 0";
                DataTable dtCheck = DBUtils._getData(queryCheck);

                if (dtCheck != null && dtCheck.Rows.Count > 0)
                {
                    MessageBox.Show("Mã quản lý thiết bị đã tồn tại!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtDeviceName.Text))
                {
                    MessageBox.Show("Tên thiết bị không được để trống!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtDeviceType.EditValue == null)
                {
                    MessageBox.Show("Chọn loại thiết bị!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtFactory.EditValue == null)
                {
                    MessageBox.Show("Chọn nhà máy!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dtNgayBD.EditValue == null)
                {
                    MessageBox.Show("Chọn ngày bảo dưỡng!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2) Confirm trước khi copy + insert
                DialogResult rs = MessageBox.Show("Xác nhận lưu thiết bị mới?", "Lưu",
                                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (rs != DialogResult.OK) return;

                // 3) Tính kế hoạch bảo dưỡng
                DateTime? ngayBaoDuong = dtNgayBD.EditValue as DateTime?;
                string tanSuat = txtTanSuatBD.Text;
                DateTime? ngayKeHoach = TinhNgayBaoDuongTiepTheo(ngayBaoDuong, tanSuat);

                // 4) Copy file (IMG/LSSC/Barcode + auto HDSD/BCDT theo loại)
                var files = SaveApprovedFiles(maQuanLy);

                // 5) Insert DB
                string queryInsert = @"
INSERT INTO TBL_DEVICE_MST
(
    TenThietBi, MaQuanLy, SerialNo, Model, KichThuoc,
    NhaCungCap, MucDichSuDung, NhaMay,
    TypeID,
    NguoiDuocPhepSuDung, HuongDanSuDung, BaoCaoDaoTao, LichSuBaoDuong,
    NgayBaoDuong, KeHoachBaoDuongTiepTheo, TanSuat, TaiSanCoDinh,
    BarCode, StatusID, Huy,
    CREATE_DATE, CREATE_BY, UPDATE_DATE, UPDATE_BY
)
VALUES
(
    @TenThietBi, @MaQuanLy, @SerialNo, @Model, @KichThuoc,
    @NhaCungCap, @MucDichSuDung, @NhaMay,
    @TypeID,
    @NguoiDuocPhepSuDung, @HuongDanSuDung, @BaoCaoDaoTao, @LichSuBaoDuong,
    @NgayBaoDuong, @KeHoachBaoDuongTiepTheo, @TanSuat, @TaiSanCoDinh,
    @BarCode, @StatusID, @Huy,
    GETDATE(), @CREATE_BY, NULL, NULL
);";

                using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                {

                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(queryInsert, conn))
                    {
                        int typeId = Convert.ToInt32(txtDeviceType.EditValue);
                        cmd.Parameters.AddWithValue("@TenThietBi", txtDeviceName.Text.Trim());
                        cmd.Parameters.AddWithValue("@MaQuanLy", maQuanLy);

                        cmd.Parameters.AddWithValue("@SerialNo", (object)DbNullIfEmpty(txtSerial.Text) ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Model", (object)DbNullIfEmpty(txtModel.Text) ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@KichThuoc", (object)DbNullIfEmpty(txtSize.Text) ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@NhaCungCap", (object)DbNullIfEmpty(txtSupplier.Text) ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@MucDichSuDung", (object)DbNullIfEmpty(txtPurpose.Text) ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@NhaMay", (object)DbNullIfEmpty(txtFactory.Text) ?? DBNull.Value);

                        cmd.Parameters.AddWithValue("@TypeID", typeId);

                        cmd.Parameters.AddWithValue("@NguoiDuocPhepSuDung", (object)files.Img ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@HuongDanSuDung", (object)files.Hdsd ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@BaoCaoDaoTao", (object)files.Bcdt ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@LichSuBaoDuong", (object)files.Lssc ?? DBNull.Value);

                        cmd.Parameters.AddWithValue("@NgayBaoDuong", ngayBaoDuong.HasValue ? (object)ngayBaoDuong.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@KeHoachBaoDuongTiepTheo", ngayKeHoach.HasValue ? (object)ngayKeHoach.Value : DBNull.Value);

                        cmd.Parameters.AddWithValue("@TanSuat", DbNullIfEmpty(txtTanSuatBD.Text) ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@TaiSanCoDinh", checkTSCD.Checked ? "Có" : "Không");

                        cmd.Parameters.AddWithValue("@BarCode", (object)files.Barcode ?? DBNull.Value);

                        cmd.Parameters.AddWithValue("@StatusID", 1);
                        cmd.Parameters.AddWithValue("@Huy", 0);
                        cmd.Parameters.AddWithValue("@CREATE_BY", (object)Constaint._userID ?? DBNull.Value);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Lưu thiết bị thành công!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                // Bạn không muốn báo lỗi chi tiết thì dùng message chung:
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string DbNullIfEmpty(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return null;
            return s.Trim();
        }


        private void btnDel1_Click(object sender, EventArgs e)
        {
            txtAttachFileIMG.Text = "";
        }

        private void btnDel2_Click(object sender, EventArgs e)
        {
            txtAttachFileHDSD.Text = "";
        }

        private void btnDel3_Click(object sender, EventArgs e)
        {
            txtAttachFileBCDT.Text = "";
        }

        private void btnDel4_Click(object sender, EventArgs e)
        {
            txtAttachFileLSSC.Text = "";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void PreFillFromRegister(DataRow r)
        {
            txtDeviceName.Text = r["DeviceName"].ToString();
            txtSerial.Text = r["Serial"].ToString();
            txtModel.Text = r["Model"].ToString();
            txtSupplier.Text = r["Supplier"].ToString();
            txtPurpose.Text = r["Purpose"].ToString();
            txtFactory.Text = r["FactoryName"].ToString();

            // nếu dùng lookup
            // txtFactory.EditValue = r["FactoryID"];
            // txtDeviceType.EditValue = r["TypeID"];

            checkTSCD.Checked = r["TaiSanCoDinh"].ToString() == "Có";
        }


    }
}