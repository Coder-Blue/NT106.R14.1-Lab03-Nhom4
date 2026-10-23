# NT106.R14.1 - Lab 03 - Nhóm 4

Bài thực hành Lập trình Sockets trong C#: ứng dụng Windows Forms minh họa giao tiếp TCP giữa Client và Server.

## Chức năng đã hoàn thành

- **Bài 03 - TCP 1 Server, 1 Client**:
  - Server lắng nghe kết nối tại `127.0.0.1:8080` bằng `TcpListener`.
  - Client kết nối bằng `TcpClient`, gửi tin nhắn và nhận phản hồi từ Server.
  - Server hiển thị thông điệp từ Client lên form.
  - Hỗ trợ tiếng Việt có dấu bằng UTF-8.
  - Cập nhật giao diện an toàn giữa các luồng bằng `InvokeRequired`/`BeginInvoke`.

## Cấu trúc solution

| Project | Vai trò |
| --- | --- |
| `NT106.R14.1-Lab03-Nhom4` | Project khởi chạy, chứa form điều hướng chung của Lab 03 |
| `Lab03_Bai03` | Project Bài 03, chứa form điều hướng, TCP Server và TCP Client |

### Tệp chính

| Tệp | Vai trò |
| --- | --- |
| `NT106.R14.1-Lab03-Nhom4/FormChinh.cs` | Form điều hướng chính của Lab 03 |
| `Lab03_Bai03/Bai03Form.cs` | Form mở Server và Client của Bài 03 |
| `Lab03_Bai03/Bai03Server.cs` | TCP Server dùng `TcpListener` |
| `Lab03_Bai03/Bai03Client.cs` | TCP Client dùng `TcpClient` |
| `Lab03_Bai03/TcpHelper.cs` | Hàm dùng chung: kiểm tra IP/port, tạo luồng UTF-8, ghi nhật ký an toàn |

## Cách chạy

1. Mở `NT106.R14.1-Lab03-Nhom4.slnx` bằng Visual Studio hoặc chạy `dotnet run --project NT106.R14.1-Lab03-Nhom4`.
2. Chọn **Bài 03**.
3. Mở **TCP Server** và nhấn **Listen**.
4. Mở **TCP Client**, nhập IP `127.0.0.1`, port `8080` rồi nhấn **Kết nối**.
5. Nhập tin nhắn và nhấn **Gửi**. Server sẽ hiển thị nội dung và trả lời lại Client.

Có thể chạy riêng project Bài 03 bằng `dotnet run --project Lab03_Bai03` nếu chỉ muốn thử Server/Client.

## Ghi chú

- Các bài 01, 02, 04, 05, 06 sẽ được thêm thành project riêng trong cùng solution.
- Tài liệu PDF của môn học chỉ dùng để tham khảo, không đưa vào repository.
