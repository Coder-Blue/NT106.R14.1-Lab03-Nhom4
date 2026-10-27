# NT106.R14.1 - Lab 03 - Nhóm 4

> Lập trình Sockets trong C# - README "cầm tay chỉ việc" cho sinh viên hay quên.

Repo này gom **6 bài thực hành Lab 03** vào cùng một solution. Mỗi bài là một project
WinForms riêng, có form điều hướng để mở Server/Client. Nếu bạn chỉ muốn chạy thử ngay,
nhảy xuống [Chạy nhanh](#2-chạy-nhanh). Nếu đang bị lỗi, xem [Lỗi hay gặp](#8-lỗi-hay-gặp).

## Mục lục

1. [Mục tiêu và môi trường](#1-mục-tiêu-và-môi-trường)
2. [Chạy nhanh](#2-chạy-nhanh)
3. [Cấu trúc repo](#3-cấu-trúc-repo)
4. [Socket căn bản "đủ xài"](#4-socket-căn-bản-đủ-xài)
5. [Từng bài thực hành](#5-từng-bài-thực-hành)
6. [Giao thức client - server](#6-giao-thức-client---server)
7. [Đối chiếu yêu cầu đề bài](#7-đối-chiếu-yêu-cầu-đề-bài)
8. [Lỗi hay gặp](#8-lỗi-hay-gặp)
9. [Nộp bài](#9-nộp-bài)
10. [Tham khảo](#10-tham-khảo)

---

## 1. Mục tiêu và môi trường

Sau Lab 03, tụi mình cần biết:

- Socket là gì, dùng UDP và TCP khác nhau thế nào.
- Viết ứng dụng client/server bằng C# với `System.Net` và `System.Net.Sockets`.
- Dùng đa luồng (multithreading) để server phục vụ nhiều client.
- Cập nhật giao diện WinForms an toàn từ luồng khác (`InvokeRequired` / `BeginInvoke`).
- Gửi/nhận tiếng Việt có dấu bằng UTF-8.

**Môi trường đang dùng trong repo:**

| Thành phần | Phiên bản / ghi chú |
|---|---|
| Hệ điều hành | Windows 10/11 |
| IDE | Visual Studio 2022/2026 (có workload .NET Desktop) |
| .NET SDK | .NET 10 (`net10.0-windows`) |
| Ngôn ngữ | C# + WinForms |
| Thư viện thêm | `Microsoft.Data.Sqlite` (Bài 05) |
| Công cụ phụ | Telnet Client của Windows (Bài 02) |

> Đề bài gốc nằm ở `Lab-3-Working-with-Sockets-in-C.pdf`. File này đang được
> `.gitignore` bỏ qua để repo nhẹ hơn; nếu cần thì mở trực tiếp trong thư mục máy.

Cài Telnet Client trên Windows (mở PowerShell bằng quyền Administrator):

```powershell
dism /online /Enable-Feature /FeatureName:TelnetClient
```

Hoặc vào **Control Panel → Programs → Turn Windows features on or off → Telnet Client**.

---

## 2. Chạy nhanh

### Cách 1: Visual Studio

1. Mở `NT106.R14.1-Lab03-Nhom4.slnx`.
2. Chuột phải project `NT106.R14.1-Lab03-Nhom4` → **Set as Startup Project**.
3. Bấm **F5**.
4. Cửa sổ **LAB 03 - LẬP TRÌNH SOCKETS TRONG C#** hiện ra, chọn bài cần chạy.

### Cách 2: dòng lệnh

```powershell
dotnet restore
dotnet build
dotnet run --project .\NT106.R14.1-Lab03-Nhom4
```

Chạy riêng một bài (ví dụ Bài 01):

```powershell
dotnet run --project .\Lab03_Bai01
```

> **Mẹo:** mỗi project đều chạy độc lập được. Khi cần test nhiều client, mở app chính
> rồi bấm vào bài đó nhiều lần, hoặc chạy thêm một cửa sổ `dotnet run` khác.

---

## 3. Cấu trúc repo

```text
NT106.R14.1-Lab03-Nhom4/
├── NT106.R14.1-Lab03-Nhom4.slnx   # solution gom tất cả project
├── NT106.R14.1-Lab03-Nhom4/       # app chính + FormChinh (menu 6 bài)
├── Lab03_Bai01/                   # UDP Client - Server
├── Lab03_Bai02/                   # Telnet Listener
├── Lab03_Bai03/                   # TCP 1 Server - 1 Client
├── Lab03_Bai04/                   # TCP 1 Server - Multi Client: quản lý phòng vé
├── Lab03_Bai05/                   # TCP 1 Server - Multi Client: hôm nay ăn gì? (SQLite)
└── Lab03_Bai06/                   # TCP 1 Server - Multi Client: chat room
```

Mỗi project đều có:

- `*Form.cs` + `*Form.Designer.cs`: form điều hướng của bài.
- `*Server.cs`, `*Client.cs`: form server/client tương ứng.
- `*Helper.cs`: hàm dùng chung (đọc/ghi, kiểm tra IP/port, log, UTF-8...).
- `Program.cs`: điểm khởi chạy nếu chạy project riêng.

Cách tổ chức này đúng yêu cầu đề: **mỗi bài là một project, nằm trong cùng một solution,
và có form điều hướng riêng**.

---

## 4. Socket căn bản "đủ xài"

### 4.1. Vài lớp cần nhớ

| Lớp | Namespace | Dùng để |
|---|---|---|
| `IPAddress` | `System.Net` | Biểu diễn địa chỉ IP |
| `IPEndPoint` | `System.Net` | Ghép địa chỉ IP + port |
| `Socket` | `System.Net.Sockets` | Socket thô, dùng được cả UDP/TCP |
| `UdpClient` | `System.Net.Sockets` | Gửi/nhận UDP nhanh gọn |
| `TcpListener` | `System.Net.Sockets` | Lắng nghe kết nối TCP |
| `TcpClient` | `System.Net.Sockets` | Tạo kết nối TCP từ client |
| `NetworkStream` | `System.Net.Sockets` | Luồng đọc/ghi dữ liệu TCP |
| `StreamReader` / `StreamWriter` | `System.IO` | Đọc/ghi dòng văn bản cho dễ |

### 4.2. UDP

- **Không cần kết nối** trước khi gửi.
- Nhanh, nhẹ, nhưng **không đảm bảo** gói tin đến đủ/đúng thứ tự.
- Phù hợp cho bài gửi thông điệp đơn giản như Bài 01.

Luồng cơ bản:

```text
Client: tạo Socket(UDP) -> SendTo(IP, port)
Server: tạo Socket(UDP) -> Bind(IPAddress.Any, port) -> ReceiveFrom()
```

### 4.3. TCP

- **Có kết nối**: phải connect thành công rồi mới gửi/nhận.
- Đảm bảo dữ liệu đến đúng thứ tự, phù hợp cho Bài 03, 04, 05, 06.

Luồng cơ bản:

```text
Server: TcpListener.Start() -> AcceptTcpClient() -> GetStream() -> đọc/ghi -> đóng
Client: TcpClient.Connect() -> GetStream() -> ghi/đọc -> đóng
```

### 4.4. Ba thứ dễ làm sai nhất

1. **Tiếng Việt bị lỗi font**: phải dùng `Encoding.UTF8` ở cả hai đầu. Repo dùng
   `new UTF8Encoding(false)` để tránh BOM.
2. **Cập nhật UI từ luồng khác**: không gán trực tiếp `label.Text` từ thread phụ.
   Dùng `InvokeRequired` + `BeginInvoke`, hoặc `async/await` cho gọn.
3. **Không có "hàng rào" tin nhắn**: TCP là một dòng byte, không tự biết đâu là hết
   một tin nhắn. Repo dùng `StreamReader.ReadLine`/`StreamWriter.WriteLine` (mỗi tin
   nhắn kết thúc bằng `\n`) hoặc giao thức dạng `LENH\tthamso`.

---

## 5. Từng bài thực hành

### Bài 01 - UDP Client / Server

**Yêu cầu:** client chỉ định IP, port và thông điệp; server nhận và hiển thị thông điệp.
Hai bên nằm cùng project, có form chung để mở Client/Server. Hỗ trợ tiếng Việt UTF-8.

**Chạy thử:**

1. Menu chính → **Bài 01**.
2. Bấm **UDP Server** → giữ port `8080` → bấm **Listen**.
3. Bấm **UDP Client** → nhập `127.0.0.1`, port `8080`, nhập
   `Xin chào từ Nhóm 4` → bấm **Gửi**.
4. Server hiện log dạng `127.0.0.1:<port>: Xin chào từ Nhóm 4`.

**Cách làm trong code:**

- Server dùng `Socket` kiểu `Dgram`, bind `IPAddress.Any` để nhận mọi card mạng.
- Nhận bằng `ReceiveFromAsync` + `CancellationToken` để có thể bấm **Stop**.
- Client dùng `UdpClient.Send` với mảng byte UTF-8.
- Log lên `RichTextBox` thông qua helper có kiểm tra `InvokeRequired`.

**Test LAN:** thay `127.0.0.1` bằng IP private của máy server (ví dụ `192.168.1.10`),
mở firewall cho app, và đảm bảo hai máy cùng mạng.

---

### Bài 02 - Telnet Listener

**Yêu cầu:** lắng nghe dữ liệu từ telnet qua TCP port `8080`, hiển thị nội dung lên form.

**Chạy thử:**

1. Menu chính → **Bài 02** → bấm **Listen**.
2. Mở CMD/PowerShell, gõ:

   ```powershell
   telnet 127.0.0.1 8080
   ```

3. Gõ thử `hello từ telnet`, Enter. Form sẽ hiện từng dòng nhận được.
4. Mở thêm cửa sổ telnet khác để thấy server phục vụ nhiều client cùng lúc.

**Cách làm trong code:**

- Dùng `Socket` với `AddressFamily.InterNetwork`, `SocketType.Stream`, `ProtocolType.Tcp`.
- `Bind` + `Listen(10)`, sau đó `AcceptAsync` trong vòng lặp.
- Mỗi client được xử lý trên một task riêng, có `CancellationToken`.
- Bỏ qua các byte điều khiển Telnet (`IAC` = `0xFF` + 2 byte) để log không bị rác.
- Hỗ trợ backspace (`0x08` / `0x7F`) và cắt dòng theo `\n`.

> **Lưu ý:** Bài 02 và Bài 03 cùng dùng port `8080`, nên **không bật cả hai server
> cùng lúc**. Nếu bị lỗi "port đang được dùng", tắt bớt một bên.

---

### Bài 03 - TCP 1 Server - 1 Client

**Yêu cầu:** server lắng nghe, client kết nối, gửi thông điệp; server nhận và hiển thị.

**Chạy thử:**

1. Menu chính → **Bài 03** → **TCP Server** → **Listen**.
2. Bấm **TCP Client** → giữ `127.0.0.1:8080` → **Kết nối**.
3. Nhập tin nhắn → **Gửi**. Server log `From client: ...` và trả lời `Đã nhận: ...`.
4. Gõ `quit` hoặc bấm **Ngắt kết nối** để đóng phiên.

**Cách làm trong code:**

- Server dùng `TcpListener` tại `IPAddress.Loopback` (chỉ nhận trong máy).
- Mỗi lần chỉ phục vụ **một client**: xử lý xong client hiện tại mới quay lại `Accept`.
  Đúng tinh thần "1 Server - 1 Client" của đề.
- Client dùng `TcpClient.ConnectAsync`, `GetStream`, `StreamReader`/`StreamWriter`.
- Tin nhắn kết thúc bằng `\n`, đọc bằng `ReadLineAsync` để không bị dính chùm.
- Client tách riêng các thao tác **Kết nối / Gửi / Ngắt kết nối** để dễ đọc và dễ sửa.

---

### Bài 04 - 1 Server - Multi Client: Quản lý phòng vé

**Yêu cầu:** nhiều client cùng đặt vé; dữ liệu phòng vé lưu tại server; vé đã đặt ở
quầy này thì quầy khác không đặt được nữa.

**Chạy thử:**

1. Menu chính → **Bài 04** → **Server** → **Listen** (port `8081`).
2. Bấm lại **Bài 04** trên menu để mở thêm một hoặc nhiều cửa sổ **Client**.
3. Ở client: nhập tên khách hàng → **Kết nối** → chọn phim/phòng → bấm các ghế
   `A1...C5` → **Đặt vé**.
4. Mở client thứ hai, thử đặt đúng ghế vừa bán. Client thứ hai sẽ nhận thông báo
   `Ghế đã được đặt: ...` và danh sách ghế tự đồng bộ.

**Cách làm trong code:**

- Server đọc danh sách phòng từ `input5.txt` (được copy vào thư mục build). Nếu file
  không có, server dùng dữ liệu mặc định trong `PhongVeHelper`.
- Toàn bộ trạng thái ghế nằm ở server trong `Dictionary<string, HashSet<string>>`,
  khóa bằng `lock` để tránh hai client đặt trùng.
- Sau mỗi lần đặt thành công, server gửi "snapshot" mới cho tất cả client.
- Giá vé: ghế góc `A1, A5, C1, C5` = 0.25x; ghế giữa `B2, B3, B4` = 2x;
  các ghế còn lại = 1x giá chuẩn.
- Server có thêm công cụ: thêm/xóa phòng, đọc/ghi `input5.txt`, xuất thống kê ra
  `output5.txt`.

> **Lưu ý:** ghế đã bán được lưu **trong bộ nhớ**. Khởi động lại server thì danh sách
> vé bán sẽ reset; chỉ danh sách phòng là đọc lại từ `input5.txt`.

---

### Bài 05 - 1 Server - Multi Client: Hôm nay ăn gì? (SQLite)

**Yêu cầu:** nhiều người dùng cùng đóng góp món ăn; dữ liệu lưu tại SQLite của server;
có chức năng chọn ngẫu nhiên món từ dữ liệu cá nhân hoặc cộng đồng.

**Chạy thử:**

1. Menu chính → **Bài 05** → **Server** → **Listen** (port `8082`).
2. Mở một hoặc nhiều **Client**.
3. Nhập tên của bạn → **Kết nối**. Tên chưa có sẽ được tạo mới (không cần mật khẩu).
4. Chọn món trong danh sách để xem ảnh; nhập tên món + chọn ảnh → **Thêm món**.
5. Bấm **Ăn gì cá nhân** hoặc **Ăn gì cộng đồng** để random.
6. Chỉ xóa được món do chính mình đóng góp.

**Cách làm trong code:**

- Server tạo file `homnayangi.db` trong thư mục build bằng `Microsoft.Data.Sqlite`.
- Hai bảng: `NguoiDung (IDNCC, HoVaTen, QuyenHan)` và
  `MonAn (IDMA, TenMonAn, HinhAnh, IDNCC)`.
- Lần chạy đầu, server seed 3 người dùng và 5 món ăn kèm ảnh trong `hinh-anh/`.
- Client gửi tên trước (`TEN`), server trả về thông tin `BAN` và snapshot `MON`.
- `RANDOM 1` = random món của mình; `RANDOM 0` = random cả cộng đồng.
- Dữ liệu **được giữ lại** sau khi khởi động lại server.

> **Lưu ý:** client chỉ gửi **tên file ảnh**, không upload cả file. Server chỉ chấp nhận
> ảnh có sẵn trong thư mục `hinh-anh` của server; nếu không tìm thấy sẽ dùng
> `default.png`. Vì vậy muốn thêm ảnh mới, chép ảnh vào `Lab03_Bai05/hinh-anh/` rồi
> build lại (hoặc chép vào thư mục build).

---

### Bài 06 - 1 Server - Multi Client: Chat Room

**Yêu cầu:** mỗi người dùng có một tài khoản (chỉ cần tên), gửi tin nhắn thì mọi người
nhận được; có nhắn tin riêng; mở rộng gửi ảnh `.jpg`, `.png` và file `.txt`.

**Chạy thử:**

1. Menu chính → **Bài 06** → **Server** → **Listen** (port `8083`).
2. Mở nhiều **Client**, mỗi client nhập một tên khác nhau (1-30 ký tự) → **Kết nối**.
3. Chọn **Mọi người** để chat chung, hoặc chọn một tên trong combo box để nhắn riêng.
4. Bấm **Gửi tệp** để gửi ảnh/txt (tối đa 5 MB). Ảnh sẽ được xem trước; file nhận
   được lưu trong thư mục `tep-nhan-duoc` cạnh file chạy.

**Cách làm trong code:**

- Server quản lý `Dictionary<string, KetNoiClient>` theo tên người dùng.
- Tin nhắn chung dùng lệnh `PUBLIC`; tin nhắn riêng dùng `PRIVATE`; file dùng `FILE`.
- Server broadcast danh sách người dùng bằng `USERS`, gửi tin bằng `MSG`.
- File được mã hóa Base64 để đi trên giao thức dòng (`\n`), giới hạn 5 MB.
- Client lưu file nhận được với tiền tố thời gian để không ghi đè.

> **Lưu ý:** đây là chat room phục vụ học tập, **không có mã hóa, không có xác thực
> mật khẩu**. Không dùng cho mạng công cộng/Internet.

---

## 6. Giao thức client - server

Repo dùng giao thức văn bản, mỗi dòng kết thúc bằng `\n`, các trường cách nhau bằng
`\t`. Dưới đây là bảng tóm tắt để bạn dễ sửa/debug:

| Bài | Client → Server | Server → Client |
|---|---|---|
| 01 | Gói UDP thô (UTF-8) | Không phản hồi |
| 02 | Dữ liệu telnet thô | Không phản hồi |
| 03 | `noi dung\n`, `quit\n` | `Đã nhận: ...\n` |
| 04 | `DAT\t<phim>\t<phong>\t<khach>\t<ghe1,ghe2>`; `QUIT` | `PHONG\t...`; `HET`; `KQ\tOK/LOI\t<thông báo>` |
| 05 | `TEN\t<tên>`; `THEM\t<tên món>\t<tên ảnh>`; `XOA\t<IDMA>`; `RANDOM\t1/0`; `QUIT` | `BAN\t...`; `MON\t...`; `HET`; `KQ\tOK/LOI\t...`; `CHON\t...` |
| 06 | `TEN\t<tên>`; `PUBLIC\t<nội dung>`; `PRIVATE\t<người nhận>\t<nội dung>`; `FILE\t<người nhận hoặc *>\t<tên tệp>\t<base64>`; `QUIT` | `TEN_OK\t<tên>`; `LOI\t...`; `MSG\t...`; `USERS\t...`; `FILE\t...` |

> Khi tự thêm chức năng, nhớ **escape** ký tự `\t`, `\r`, `\n` trong dữ liệu người dùng
> (các helper `ChuanHoa...` trong repo đã làm việc này).

---

## 7. Đối chiếu yêu cầu đề bài

| Yêu cầu trong PDF | Trạng thái | Ghi chú |
|---|---|---|
| Mỗi bài là 1 project, cùng 1 solution | ✅ | 6 project + app menu |
| Mỗi project có form điều hướng | ✅ | `Bai0xForm` mở Server/Client |
| Giao diện dễ nhìn, thể hiện đủ yêu cầu, đẹp | ✅ | WinForms, màu thống nhất, có trạng thái/log |
| Code sạch, đặt tên rõ ràng | ✅ | Tên biến/hàm tiếng Việt rõ nghĩa, tách Helper |
| Bài 01: UDP client/server, chọn IP/port/nội dung, UTF-8 | ✅ | `Lab03_Bai01` |
| Bài 02: Telnet listener dùng `Socket`, port 8080 | ✅ | `Lab03_Bai02` |
| Bài 03: TCP 1 server - 1 client, Listen/Connect/Send | ✅ | `Lab03_Bai03` |
| Bài 04: 1 server - multi client, dữ liệu vé tại server, đồng bộ | ✅ | `Lab03_Bai04` |
| Bài 05: 1 server - multi client, SQLite tại server, random cá nhân/cộng đồng | ✅ | `Lab03_Bai05` |
| Bài 06: chat room, broadcast, nhắn riêng, gửi ảnh/txt | ✅ | `Lab03_Bai06` |
| Nộp source trên GitHub | ✅ | Repo này |
| Nộp báo cáo + source đúng định dạng zip | ⬜ | Làm theo mục [Nộp bài](#9-nộp-bài) |

---

## 8. Lỗi hay gặp

| Lỗi / hiện tượng | Nguyên nhân thường gặp | Cách xử lý |
|---|---|---|
| `Only one usage of each socket address is normally permitted` | Port đang bị chương trình khác chiếm (nhất là 8080 giữa Bài 02 và 03) | Tắt server cũ, đổi port, hoặc `netstat -ano \| findstr :8080` để tìm process |
| Client báo "Không thể kết nối" | Chưa bấm **Listen** ở server; sai IP/port; firewall chặn | Bật server trước, kiểm tra IP/port, thêm rule firewall |
| Tiếng Việt hiện `?` hoặc ký tự lạ | Một bên dùng ASCII/encoding khác | Dùng UTF-8 ở cả client và server; không dùng `Encoding.ASCII` |
| `InvalidOperationException: Cross-thread operation not valid` | Gán control từ thread khác | Dùng `InvokeRequired`/`BeginInvoke` như các helper trong repo |
| Telnet báo không tồn tại | Chưa bật Telnet Client | Chạy lệnh `dism` ở mục 1, hoặc dùng PuTTY |
| Không thấy ảnh món ăn | Ảnh không nằm trong thư mục `hinh-anh` của server | Chép ảnh vào `Lab03_Bai05/hinh-anh/` rồi build lại |
| `The database file is locked` | Mở nhiều server hoặc dùng tool khác đang giữ DB | Chỉ chạy một server; đóng DB browser trước khi ghi |
| Gửi file báo quá lớn | Giới hạn 5 MB | Nén/chọn file nhỏ hơn |
| Build lỗi `NETSDK1045` | Máy chưa có .NET 10 SDK | Cài .NET 10 SDK, kiểm tra `dotnet --version` |
| Chạy `dotnet run` bị mở sai project | Đang đứng ở solution root | Thêm `--project .\Lab03_Bai0x` |

---

## 9. Nộp bài

Theo yêu cầu trong PDF:

1. Push toàn bộ source lên GitHub (repo này).
2. Nhóm trưởng nộp bài tại website môn học.
3. Nén toàn bộ file liên quan thành **một file `.zip`**, đặt tên:

   ```text
   <Mã lớp>-Lab03-<MSSV1>-<MSSV2>.zip
   ```

   Ví dụ:

   ```text
   NT106.M21.MMCL.1-Lab03-25520001-25520002.zip
   ```

4. **Không** đưa `bin/`, `obj/`, `.vs/` vào file nộp.
5. Kiểm tra lại: mở solution trên máy khác (hoặc xóa `bin/obj` rồi build lại) phải
   chạy được.

> Nộp trễ, thiếu file, code không chạy hoặc copy code nguồn khác sẽ bị trừ theo mức độ
> (theo PDF). Chạy thử `dotnet build` trước khi nộp là cách nhanh nhất để tránh lỗi.

---

## 10. Tham khảo

- Microsoft, *C# Guide*: <https://docs.microsoft.com/en-us/dotnet/csharp/>
- Microsoft, *System.Net.Sockets*: <https://docs.microsoft.com/en-us/dotnet/api/system.net.sockets>
- Microsoft, *TcpClient*: <https://docs.microsoft.com/en-us/dotnet/api/system.net.sockets.tcpclient>
- Microsoft, *TcpListener*: <https://docs.microsoft.com/en-us/dotnet/api/system.net.sockets.tcplistener>
- Microsoft, *UdpClient*: <https://docs.microsoft.com/en-us/dotnet/api/system.net.sockets.udpclient>
- Microsoft, *Microsoft.Data.Sqlite*: <https://learn.microsoft.com/en-us/dotnet/standard/data/sqlite/>
- Robert C. Martin, *Clean Code: A Handbook of Agile Software Craftsmanship*, 2009.
- Telnet Client trên Windows: <https://learn.microsoft.com/en-us/windows-server/administration/windows-commands/telnet>

---

**Chúc bạn chạy được ngay lần đầu.** Nếu không, đừng lo - mở mục
[Lỗi hay gặp](#8-lỗi-hay-gặp), hoặc hỏi nhóm trưởng. Ai cũng từng bị `port 8080` chặn
ít nhất một lần. :)
