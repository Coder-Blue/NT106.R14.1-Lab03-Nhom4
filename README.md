# NT106.R14.1 - Lab 03 - Nhóm 4

Repo này gồm 6 bài Lab 03, mỗi bài là một project WinForms trong cùng một solution.
Chạy app chính sẽ ra menu; bấm vào bài nào thì mở form điều hướng của bài đó, rồi từ
đó mở Server/Client.

README ghi lại cách chạy, cách từng bài hoạt động và mấy lỗi nhóm mình từng gặp.
Không có gì cao siêu, đọc từ trên xuống hoặc nhảy thẳng vào bài cần làm đều được.

## Chạy thử trước đã

Cần có:

- Windows 10/11
- .NET 10 SDK
- Visual Studio 2022/2026 có workload .NET Desktop (hoặc dùng `dotnet` CLI)

Mở `NT106.R14.1-Lab03-Nhom4.slnx`, chọn project `NT106.R14.1-Lab03-Nhom4` làm
startup project rồi bấm F5. Nếu dùng dòng lệnh:

```powershell
dotnet restore
dotnet build
dotnet run --project .\NT106.R14.1-Lab03-Nhom4
```

Chạy riêng một bài, ví dụ Bài 01:

```powershell
dotnet run --project .\Lab03_Bai01
```

Khi cần test nhiều client, cứ mở app chính rồi bấm lại vào bài đó để mở thêm cửa sổ
client. Hoặc chạy thêm một cửa sổ `dotnet run` khác.

Bài 02 cần Telnet Client của Windows. Nếu CMD báo không có lệnh `telnet`, mở
PowerShell bằng quyền Administrator và chạy:

```powershell
dism /online /Enable-Feature /FeatureName:TelnetClient
```

Sau đó mở lại CMD. Hoặc bật trong **Control Panel → Programs → Turn Windows features
on or off → Telnet Client**.

## Trong repo có gì

```text
NT106.R14.1-Lab03-Nhom4/
├── NT106.R14.1-Lab03-Nhom4.slnx   # solution
├── NT106.R14.1-Lab03-Nhom4/       # app chính + FormChinh (menu 6 bài)
├── Lab03_Bai01/                   # UDP Client - Server
├── Lab03_Bai02/                   # Telnet Listener
├── Lab03_Bai03/                   # TCP 1 Server - 1 Client
├── Lab03_Bai04/                   # Quản lý phòng vé
├── Lab03_Bai05/                   # Hôm nay ăn gì? (SQLite)
└── Lab03_Bai06/                   # Chat Room
```

Mỗi project thường có:

- `Bai0xForm`: form điều hướng, mở Server/Client.
- `Bai0xServer`, `Bai0xClient`: hai form chính của bài.
- `*Helper`: mấy hàm dùng chung như kiểm tra IP/port, đọc ghi, ghi log.
- `Program.cs`: để chạy riêng project đó.

## Mấy kiến thức cần nhớ

**UDP** không cần kết nối trước. Gửi được là gửi, nhưng không chắc bên kia nhận được,
cũng không đảm bảo thứ tự. Bài 01 dùng UDP.

**TCP** phải kết nối trước. Dữ liệu đến đúng thứ tự nên hợp với Bài 02, 03, 04, 05, 06.
Server thường `Bind`/`Listen` ở một port, client `Connect` tới IP và port đó.

**IP + port** thường gói trong `IPEndPoint`. Ví dụ `127.0.0.1:8080` là máy mình, port
8080.

**Tiếng Việt** phải dùng UTF-8 ở cả hai đầu. Đừng dùng `Encoding.ASCII`, không thì
chữ có dấu sẽ thành `?` hoặc ký tự lạ.

**WinForms** không cho sửa control từ thread khác. Mấy helper trong repo đã kiểm tra
`InvokeRequired` rồi gọi `BeginInvoke`; cứ làm theo là không bị
`InvalidOperationException`.

**TCP là một dòng byte**, nó không tự biết đâu là hết một tin nhắn. Repo dùng
`StreamReader`/`StreamWriter` với `ReadLine`/`WriteLine` (mỗi tin kết thúc bằng `\n`),
hoặc giao thức dạng `LENH\tthamso`.

## Bài 01 - UDP Client / Server

**Đề bài:** client chỉ định IP, port và thông điệp; server nhận rồi hiển thị. Client
và Server nằm cùng project, có form chung để mở hai bên. Phải gửi được tiếng Việt.

**Chạy:** menu chính → Bài 01 → mở **UDP Server** → giữ port `8080` → **Listen**.
Mở **UDP Client**, nhập `127.0.0.1`, port `8080`, nhập thử `Xin chào từ Nhóm 4` rồi
bấm **Gửi**. Server sẽ hiện log kèm IP và port của client.

**Code:** server dùng `Socket` kiểu `Dgram`, bind `IPAddress.Any` để nhận từ mọi card
mạng, rồi `ReceiveFromAsync` trong một vòng lặp có `CancellationToken`. Client dùng
`UdpClient.Send` với mảng byte UTF-8. Log lên `RichTextBox` thông qua helper có
`BeginInvoke`.

**Lưu ý:** muốn test qua LAN thì đổi `127.0.0.1` thành IP private của máy server, ví
dụ `192.168.1.10`, và mở firewall cho app. Hai máy phải cùng mạng.

## Bài 02 - Telnet Listener

**Đề bài:** lắng nghe dữ liệu từ telnet qua TCP port `8080` và hiện lên form.

**Chạy:** menu chính → Bài 02 → **Listen**. Mở CMD, gõ:

```powershell
telnet 127.0.0.1 8080
```

Gõ thử một dòng, Enter. Form sẽ hiện nội dung nhận được. Mở thêm cửa sổ telnet thứ hai
để thấy server xử lý nhiều client cùng lúc.

**Code:** dùng `Socket` với `AddressFamily.InterNetwork`, `SocketType.Stream`,
`ProtocolType.Tcp`; `Bind` + `Listen(10)`, rồi `AcceptAsync` trong vòng lặp. Mỗi client
chạy trên một task riêng. Code bỏ qua các byte điều khiển Telnet (`IAC` = `0xFF` + 2
byte), xử lý backspace (`0x08`/`0x7F`) và cắt dòng theo `\n`.

**Lưu ý:** Bài 02 và Bài 03 cùng dùng port `8080`, nên đừng bật cả hai server cùng lúc.
Nếu báo port đang bận thì tắt bớt một bên.

## Bài 03 - TCP 1 Server - 1 Client

**Đề bài:** server lắng nghe, client kết nối, gửi thông điệp; server nhận và hiển thị.

**Chạy:** menu chính → Bài 03 → mở **TCP Server** → **Listen**. Mở **TCP Client**,
giữ `127.0.0.1:8080` rồi **Kết nối**. Nhập tin nhắn và bấm **Gửi**. Server log
`From client: ...` và trả lời `Đã nhận: ...`. Gõ `quit` hoặc bấm **Ngắt kết nối** để
đóng phiên.

**Code:** server dùng `TcpListener` ở `IPAddress.Loopback` (chỉ trong máy). Mỗi lần
chỉ phục vụ một client; client hiện tại ngắt thì server mới quay lại `Accept`. Client
dùng `TcpClient.ConnectAsync`, `GetStream`, `StreamReader`/`StreamWriter`. Các thao tác
Kết nối / Gửi / Ngắt kết nối được tách thành hàm riêng.

**Lưu ý:** đúng tinh thần "1 Server - 1 Client" của đề. Muốn nhiều client thì xem
Bài 04, 05, 06.

## Bài 04 - Quản lý phòng vé

**Đề bài:** nhiều client cùng đặt vé. Dữ liệu phòng vé lưu ở server. Ghế đã bán ở
client này thì client khác không đặt được nữa.

**Chạy:** menu chính → Bài 04 → **Server** → **Listen** (port `8081`). Bấm lại Bài 04
trên menu để mở thêm client. Ở client: nhập tên khách hàng → **Kết nối** → chọn
phim/phòng → bấm ghế `A1...C5` → **Đặt vé**.

Mở client thứ hai và đặt đúng ghế vừa bán. Client thứ hai sẽ nhận thông báo
`Ghế đã được đặt: ...` và danh sách ghế tự cập nhật.

**Code:** server đọc phòng từ `input5.txt` (file được copy vào thư mục build). Nếu
không có file thì dùng dữ liệu mặc định trong `PhongVeHelper`. Ghế đã bán nằm trong
`Dictionary<string, HashSet<string>>` và được khóa bằng `lock`, nên hai client không
đặt trùng được. Sau mỗi lần đặt thành công, server gửi snapshot mới cho tất cả client.

Giá vé: ghế góc `A1, A5, C1, C5` tính 0.25 lần giá chuẩn; `B2, B3, B4` tính 2 lần;
các ghế còn lại tính 1 lần.

Server còn có nút thêm/xóa phòng, đọc/ghi `input5.txt`, và xuất thống kê ra
`output5.txt`.

**Lưu ý:** ghế đã bán chỉ nằm trong bộ nhớ. Restart server là danh sách vé bán reset;
chỉ danh sách phòng được đọc lại từ `input5.txt`.

## Bài 05 - Hôm nay ăn gì? (SQLite)

**Đề bài:** nhiều người dùng cùng đóng góp món ăn; dữ liệu lưu ở SQLite của server;
có random món từ dữ liệu cá nhân hoặc của cả cộng đồng.

**Chạy:** menu chính → Bài 05 → **Server** → **Listen** (port `8082`). Mở một hoặc
nhiều client. Nhập tên rồi **Kết nối**; tên chưa có sẽ được tạo mới, không cần mật
khẩu. Chọn món để xem ảnh, nhập tên món + chọn ảnh rồi **Thêm món**. Bấm **Ăn gì cá
nhân** hoặc **Ăn gì cộng đồng** để random. Chỉ xóa được món do mình đóng góp.

**Code:** server tạo `homnayangi.db` trong thư mục build bằng `Microsoft.Data.Sqlite`.
Có hai bảng `NguoiDung (IDNCC, HoVaTen, QuyenHan)` và
`MonAn (IDMA, TenMonAn, HinhAnh, IDNCC)`. Lần chạy đầu, server tạo sẵn 3 người dùng và
5 món ăn kèm ảnh trong `hinh-anh/`.

Client gửi tên trước (`TEN`), server trả về thông tin `BAN` và snapshot `MON`. Các lệnh
sau đó là `THEM`, `XOA`, `RANDOM 1` (cá nhân) hoặc `RANDOM 0` (cộng đồng). Dữ liệu vẫn
còn sau khi restart server.

**Lưu ý:** client chỉ gửi **tên file ảnh**, không upload cả file. Server chỉ nhận ảnh
có sẵn trong thư mục `hinh-anh` của server; không tìm thấy thì dùng `default.png`.
Muốn thêm ảnh mới thì chép vào `Lab03_Bai05/hinh-anh/` rồi build lại.

## Bài 06 - Chat Room

**Đề bài:** mỗi người dùng có một tài khoản (chỉ cần tên), gửi tin nhắn thì mọi người
nhận được; có nhắn riêng; mở rộng gửi ảnh `.jpg`, `.png` và file `.txt`.

**Chạy:** menu chính → Bài 06 → **Server** → **Listen** (port `8083`). Mở nhiều client,
mỗi client nhập một tên khác nhau (1-30 ký tự) rồi **Kết nối**. Chọn **Mọi người** để
chat chung, hoặc chọn một tên trong combo box để nhắn riêng. Bấm **Gửi tệp** để gửi
ảnh/txt (tối đa 5 MB). Ảnh sẽ được xem trước; file nhận được lưu trong thư mục
`tep-nhan-duoc` cạnh file chạy.

**Code:** server giữ `Dictionary<string, KetNoiClient>` theo tên người dùng. Tin nhắn
chung dùng `PUBLIC`, nhắn riêng dùng `PRIVATE`, gửi file dùng `FILE`. Server broadcast
danh sách người dùng bằng `USERS`, gửi tin bằng `MSG`. File được mã hóa Base64 để đi
trên giao thức dòng (`\n`), giới hạn 5 MB. Client lưu file với tiền tố thời gian để
không ghi đè.

**Lưu ý:** đây là chat room để học, không có mã hóa và không có mật khẩu. Đừng dùng
cho mạng công cộng hay Internet.

## Mấy lỗi hay gặp

- **`Only one usage of each socket address is normally permitted`**: port đang bị
  chương trình khác chiếm. Bài 02 và 03 cùng dùng `8080`, nên tắt bớt một server. Có
  thể kiểm tra bằng `netstat -ano | findstr :8080`.
- **Client báo không kết nối được**: chưa bấm **Listen** ở server, sai IP/port, hoặc
  firewall chặn. Bật server trước rồi kiểm tra lại.
- **Tiếng Việt bị `?` hoặc ký tự lạ**: một bên đang dùng ASCII/encoding khác. Dùng
  UTF-8 ở cả client và server.
- **`InvalidOperationException: Cross-thread operation not valid`**: đang sửa control
  từ thread khác. Dùng `InvokeRequired`/`BeginInvoke` như các helper trong repo.
- **CMD báo không có `telnet`**: chưa bật Telnet Client. Chạy lệnh `dism` ở đầu bài,
  hoặc dùng PuTTY.
- **Không thấy ảnh món ăn**: ảnh không nằm trong `hinh-anh` của server. Chép ảnh vào
  `Lab03_Bai05/hinh-anh/` rồi build lại.
- **`The database file is locked`**: đang mở nhiều server hoặc có tool khác giữ DB.
  Chỉ chạy một server, đóng DB browser trước khi ghi.
- **Build lỗi `NETSDK1045`**: máy chưa có .NET 10 SDK. Cài SDK rồi kiểm tra bằng
  `dotnet --version`.
- **`dotnet run` mở sai project**: đang đứng ở solution root. Thêm
  `--project .\Lab03_Bai0x`.

## Đối chiếu với đề bài

- 6 bài, mỗi bài một project, tất cả nằm trong cùng solution; project nào cũng có form
  điều hướng để mở Server/Client.
- Giao diện tự thiết kế, có trạng thái và log; code tách helper, tên biến/hàm rõ nghĩa.
- Các chức năng chính đã làm đủ: UDP, Telnet, TCP 1-1, quản lý phòng vé, SQLite cho
  "hôm nay ăn gì?", chat room kèm gửi ảnh/txt.
- Nộp bài: source trên GitHub, nhóm trưởng nộp file zip theo quy định của môn.

Trước khi nộp, chạy `dotnet build` sạch và mở thử vài bài. Kẹt chỗ nào thì xem lại
mấy lỗi ở trên hoặc hỏi nhóm trưởng.
