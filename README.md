# NT106.R14.1 - Lab 03 - Nhóm 4

Bài Lab 03 nhóm 4 lớp NT106.R14.1: 6 ứng dụng Windows Forms minh họa lập trình socket
trong C#.

## Các bài

- **Bài 01 - UDP**: Client/Server chung project; client chỉ định IP, port và nội dung;
  server nhận và hiển thị; hỗ trợ tiếng Việt UTF-8.
- **Bài 02 - Telnet**: dùng `Socket` lắng nghe dữ liệu telnet ở port 8080 và hiển thị
  lên form.
- **Bài 03 - TCP 1 Server - 1 Client**: server lắng nghe, client kết nối, gửi và nhận
  tin nhắn.
- **Bài 04 - Quản lý phòng vé**: một server, nhiều client đặt vé; dữ liệu và ghế đã
  bán được đồng bộ tại server.
- **Bài 05 - Hôm nay ăn gì?**: một server, nhiều client đóng góp món; dữ liệu lưu
  SQLite tại server; random món cá nhân hoặc cộng đồng.
- **Bài 06 - Chat Room**: một server, nhiều client; chỉ cần tên; chat chung, nhắn
  riêng, gửi ảnh `.jpg`/`.png` và file `.txt`.

## Cài đặt và chạy

1. Cài .NET 10 SDK và Visual Studio 2022/2026 (workload .NET Desktop).
2. Mở `NT106.R14.1-Lab03-Nhom4.slnx`, chọn project `NT106.R14.1-Lab03-Nhom4` làm
   startup rồi bấm F5. Hoặc chạy:

   ```powershell
   dotnet run --project .\NT106.R14.1-Lab03-Nhom4
   ```

3. Chọn bài ở menu chính, bấm **Listen** ở Server rồi mở Client. Muốn test nhiều client
   thì bấm lại bài đó trên menu.
4. Bài 02 cần bật Telnet Client:
   `dism /online /Enable-Feature /FeatureName:TelnetClient`.

## Cấu trúc mã nguồn

| Tệp / thư mục | Vai trò |
|---|---|
| `NT106.R14.1-Lab03-Nhom4.slnx` | Solution gom 6 project |
| `NT106.R14.1-Lab03-Nhom4/` | App chính, menu 6 bài |
| `Lab03_Bai01/` | UDP Client - Server |
| `Lab03_Bai02/` | Telnet Listener |
| `Lab03_Bai03/` | TCP 1 Server - 1 Client |
| `Lab03_Bai04/` | Quản lý phòng vé |
| `Lab03_Bai05/` | Hôm nay ăn gì? (SQLite) |
| `Lab03_Bai06/` | Chat Room |

## Ghi chú

- Port: Bài 01/02/03 dùng `8080`, Bài 04 dùng `8081`, Bài 05 dùng `8082`, Bài 06 dùng
  `8083`. Bài 02 và 03 không chạy server cùng lúc.
- Mỗi bài là một project trong cùng solution, có form điều hướng riêng; giao diện dễ
  nhìn, có trạng thái/log; code tách helper, tên biến/hàm rõ nghĩa.
- Nộp source trên GitHub và file zip theo quy định của môn.
