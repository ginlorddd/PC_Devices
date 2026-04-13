# HƯỚNG DẪN THAO TÁC PC_Devices

## 1) Mục đích
Tài liệu này mô tả **quy trình quản lý thiết bị và sử dụng phần mềm PC_Devices** theo lưu đồ nghiệp vụ, giúp các bộ phận thao tác đúng vai trò, đúng thời điểm và đồng bộ dữ liệu trên phần mềm.

---

## 2) Lưu đồ quy trình (Mermaid)

```mermaid
flowchart TD
    A([Đăng ký thiết bị mới]) --> B[Xác nhận thiết bị\n(QA)]
    B --> C[Hiệu chuẩn thiết bị\n(QA)]
    C --> D[Cập nhật vào danh sách quản lý]
    D --> E[Sử dụng thiết bị]
    E --> F[Hiệu chuẩn định kỳ\n(QA)]
    F --> G{Kết quả hiệu chuẩn}

    G -->|OK| E
    G -->|NG| H[Đăng ký hủy thiết bị]
    H --> I[Xác nhận hủy\n(QA)]
    I --> J([Kết thúc])
```

> Ghi chú:
> - **OK**: thiết bị đạt yêu cầu sau hiệu chuẩn, tiếp tục sử dụng.
> - **NG**: thiết bị không đạt, chuyển bước hủy thiết bị theo quy trình.

---

## 3) Phân công trách nhiệm theo từng bước

| STT | Chịu trách nhiệm | Bước quy trình | Thao tác trên PC_Devices |
|---|---|---|---|
| 1 | Các bộ phận | Đăng ký thiết bị mới | Tạo đăng ký thiết bị mới trên phần mềm |
| 2 | QA | Xác nhận thiết bị | QA xác nhận phiếu đăng ký thiết bị |
| 3 | QA | Hiệu chuẩn thiết bị ban đầu | QA thực hiện hiệu chuẩn và nhập kết quả |
| 4 | Các bộ phận | Cập nhật danh sách quản lý | Cập nhật thiết bị vào danh sách quản lý tài sản/thiết bị |
| 5 | Các bộ phận | Sử dụng thiết bị | Sử dụng thiết bị theo mục đích công việc |
| 6 | QA | Hiệu chuẩn định kỳ | Khi đến hạn, QA hiệu chuẩn lại và cập nhật kết quả |
| 7 | Các bộ phận + QA | Xử lý theo kết quả hiệu chuẩn | Nếu **OK**: tiếp tục sử dụng. Nếu **NG**: bộ phận đăng ký hủy, QA xác nhận hủy |

---

## 4) Hướng dẫn thao tác chi tiết trên phần mềm

## Bước 1. Đăng ký thiết bị mới (Các bộ phận)
1. Mở màn hình quản lý thiết bị.
2. Chọn chức năng **Thêm thiết bị** / **Đăng ký thiết bị mới**.
3. Nhập đầy đủ thông tin:
   - Mã thiết bị, tên thiết bị, loại thiết bị
   - Bộ phận sử dụng
   - Ngày đưa vào sử dụng dự kiến
   - Tài liệu đính kèm (nếu có)
4. Nhấn **Lưu** để tạo phiếu đăng ký.

## Bước 2. QA xác nhận thiết bị
1. Vào danh sách **Thiết bị chờ duyệt**.
2. Mở đúng phiếu đăng ký.
3. Kiểm tra thông tin và trạng thái hồ sơ.
4. Nhấn **Xác nhận** (hoặc từ chối nếu thiếu thông tin và ghi lý do).

## Bước 3. QA hiệu chuẩn thiết bị ban đầu
1. Mở thiết bị đã được xác nhận.
2. Chọn chức năng **Hiệu chuẩn**.
3. Nhập thông tin kết quả:
   - Ngày hiệu chuẩn
   - Người thực hiện
   - Kết quả (OK/NG)
   - Biên bản/tệp đính kèm
4. Nhấn **Lưu kết quả**.

## Bước 4. Cập nhật vào danh sách quản lý
1. Sau khi đạt điều kiện sử dụng, chuyển trạng thái thiết bị sang **Đang quản lý/Đang sử dụng**.
2. Kiểm tra thiết bị đã xuất hiện ở danh sách quản lý chính.
3. Bổ sung thông tin quản lý nội bộ (vị trí, người phụ trách, ghi chú).

## Bước 5. Sử dụng thiết bị (Các bộ phận)
1. Bộ phận tiếp nhận và sử dụng thiết bị theo quy định.
2. Theo dõi lịch hiệu chuẩn kế tiếp trên phần mềm.
3. Không sử dụng thiết bị quá hạn hiệu chuẩn.

## Bước 6. QA hiệu chuẩn định kỳ
1. Truy cập danh sách thiết bị sắp đến hạn/đã đến hạn hiệu chuẩn.
2. Tạo phiếu hiệu chuẩn định kỳ.
3. Nhập kết quả mới (OK hoặc NG), đính kèm biên bản.
4. Cập nhật ngày hiệu chuẩn kế tiếp.

## Bước 7. Xử lý kết quả hiệu chuẩn
### Trường hợp **OK**
- Giữ trạng thái thiết bị hoạt động.
- Thiết bị quay lại vòng **Sử dụng thiết bị**.

### Trường hợp **NG**
1. Bộ phận sử dụng tạo phiếu **Đăng ký hủy thiết bị**.
2. QA kiểm tra lý do hủy và tình trạng thực tế.
3. QA thực hiện **Xác nhận hủy** trên phần mềm.
4. Thiết bị chuyển sang trạng thái **Ngừng sử dụng/Đã hủy** và kết thúc quy trình.

---

## 5) Quy tắc dữ liệu bắt buộc (khuyến nghị)
- Mỗi thiết bị phải có **mã định danh duy nhất**.
- Kết quả hiệu chuẩn phải có:
  - Ngày thực hiện
  - Người thực hiện
  - Kết luận OK/NG
- Trường hợp NG cần có:
  - Mô tả lỗi/không phù hợp
  - Hướng xử lý (sửa chữa hoặc hủy)
- Mọi bước quan trọng (xác nhận, hiệu chuẩn, hủy) đều cần lưu vết người thao tác và thời gian.

---

## 6) Checklist thao tác nhanh
- [ ] Đăng ký thiết bị mới
- [ ] QA xác nhận thiết bị
- [ ] QA hiệu chuẩn ban đầu
- [ ] Cập nhật danh sách quản lý
- [ ] Đưa vào sử dụng
- [ ] Hiệu chuẩn định kỳ
- [ ] Nếu NG: đăng ký hủy + QA xác nhận hủy

---

## 7) Kết luận
Quy trình này đảm bảo thiết bị được kiểm soát đầy đủ từ lúc đăng ký, sử dụng, hiệu chuẩn định kỳ đến khi hủy; đồng thời giúp truy vết dữ liệu rõ ràng trên hệ thống PC_Devices.
