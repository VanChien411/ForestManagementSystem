
-- Xóa database nếu đã tồn tại
USE master;
GO
ALTER DATABASE ForestManagementSystem SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
GO
DROP DATABASE IF EXISTS ForestManagementSystem;
GO
go
CREATE DATABASE ForestManagementSystem;
go
USE ForestManagementSystem;
go

-- Xóa bảng nếu đã tồn tại



-- Bảng TrangThai: Lưu trữ tất cả các trạng thái chung
CREATE TABLE TrangThai (
    MaTrangThai INT PRIMARY KEY IDENTITY(1,1),
    TenTrangThai VARCHAR(50) NOT NULL, -- Ví dụ: Hoạt động, Ngưng hoạt động, Khóa, Rời nhóm
    MoTa TEXT
);

-- Bảng DonViHanhChinhTinh: Lưu trữ đơn vị hành chính cấp Tinh
CREATE TABLE DonViHanhChinhTinh (
    MaTinh INT PRIMARY KEY IDENTITY(1,1),
    TenTinh VARCHAR(100) NOT NULL
);

-- Bảng DonViHanhChinhHuyen: Lưu trữ đơn vị hành chính cấp huyện
CREATE TABLE DonViHanhChinhHuyen (
    MaHuyen INT PRIMARY KEY IDENTITY(1,1),
    TenHuyen VARCHAR(100) NOT NULL,
    MaTinh INT, -- Mã tỉnh liên kết
    FOREIGN KEY (MaTinh) REFERENCES DonViHanhChinhTinh(MaTinh)
);

-- Bảng DonViHanhChinhXa: Lưu trữ đơn vị hành chính cấp xã
CREATE TABLE DonViHanhChinhXa (
    MaXa INT PRIMARY KEY IDENTITY(1,1),
    TenXa VARCHAR(100) NOT NULL,
    MaHuyen INT, -- Liên kết với bảng DonViHanhChinhHuyen
    FOREIGN KEY (MaHuyen) REFERENCES DonViHanhChinhHuyen(MaHuyen)
);

-- Bảng NguoiDung: Lưu trữ thông tin người dùng
CREATE TABLE NguoiDung (
    MaNguoiDung INT PRIMARY KEY IDENTITY(1,1),
    TenNguoiDung VARCHAR(100) NOT NULL,
    TaiKhoan VARCHAR(50) NOT NULL,
    MatKhau VARCHAR(100) NOT NULL,
    Email VARCHAR(100),
    MaXa INT, -- Liên kết với đơn vị hành chính cấp xã
    MaTrangThai INT, -- Liên kết với bảng TrangThai
    NgayTao DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (MaXa) REFERENCES DonViHanhChinhXa(MaXa),
    FOREIGN KEY (MaTrangThai) REFERENCES TrangThai(MaTrangThai)
);

-- Bảng NhomNguoiDung: Lưu trữ nhóm người dùng
CREATE TABLE NhomNguoiDung (
    MaNhom INT PRIMARY KEY IDENTITY(1,1),
    TenNhom VARCHAR(100) NOT NULL,
    MoTa TEXT,
    MaTrangThai INT, -- Liên kết với bảng TrangThai
    FOREIGN KEY (MaTrangThai) REFERENCES TrangThai(MaTrangThai)
);

-- Bảng NguoiDung_Nhom: Lưu trữ mối quan hệ giữa người dùng và nhóm
CREATE TABLE NguoiDung_Nhom (
    MaNguoiDung INT,
    MaNhom INT,
    NgayThamGia  DATETIME DEFAULT CURRENT_TIMESTAMP,
    MaTrangThai INT, -- Liên kết với bảng TrangThai
    PRIMARY KEY (MaNguoiDung, MaNhom),
    FOREIGN KEY (MaNguoiDung) REFERENCES NguoiDung(MaNguoiDung),
    FOREIGN KEY (MaNhom) REFERENCES NhomNguoiDung(MaNhom),
    FOREIGN KEY (MaTrangThai) REFERENCES TrangThai(MaTrangThai)
);

-- Bảng PhanQuyenNhom: Lưu trữ phân quyền cho nhóm người dùng
CREATE TABLE PhanQuyenNhom (
    MaPhanQuyenNhom INT PRIMARY KEY IDENTITY(1,1),
    MaNhom INT,
    MaQuyen VARCHAR(50), -- Ví dụ: QuanLyHuyen, QuanLyXa
    MaTrangThai INT, -- Liên kết với bảng TrangThai
    FOREIGN KEY (MaNhom) REFERENCES NhomNguoiDung(MaNhom),
    FOREIGN KEY (MaTrangThai) REFERENCES TrangThai(MaTrangThai)
);

-- Bảng PhanQuyenNguoiDung: Lưu trữ phân quyền cho người dùng
CREATE TABLE PhanQuyenNguoiDung (
    MaPhanQuyenNguoiDung INT PRIMARY KEY IDENTITY(1,1),
    MaNguoiDung INT,
    MaQuyen VARCHAR(50),
    MaTrangThai INT, -- Liên kết với bảng TrangThai
    FOREIGN KEY (MaNguoiDung) REFERENCES NguoiDung(MaNguoiDung),
    FOREIGN KEY (MaTrangThai) REFERENCES TrangThai(MaTrangThai)
);

-- Bảng Menu: Lưu trữ danh mục menu
CREATE TABLE Menu (
    MaMenu INT PRIMARY KEY IDENTITY(1,1),
    TenMenu VARCHAR(100) NOT NULL,
    DuongDan VARCHAR(200), -- Đường dẫn URL
    ThuTu INT, -- Thứ tự hiển thị
    MaTrangThai INT, -- Liên kết với bảng TrangThai
    FOREIGN KEY (MaTrangThai) REFERENCES TrangThai(MaTrangThai)
);

-- Bảng LichSuTruyCap: Lưu trữ lịch sử truy cập
CREATE TABLE LichSuTruyCap (
    MaLichSu INT PRIMARY KEY IDENTITY(1,1),
    MaNguoiDung INT,
    ThoiGianTruyCap DATETIME DEFAULT CURRENT_TIMESTAMP,
    IPAddress VARCHAR(50),
    HanhDong VARCHAR(100), -- Ví dụ: DangNhap, DangXuat
    FOREIGN KEY (MaNguoiDung) REFERENCES NguoiDung(MaNguoiDung)
);

-- Bảng LichSuTacDong: Lưu trữ lịch sử tác động hệ thống
CREATE TABLE LichSuTacDong (
    MaTacDong INT PRIMARY KEY IDENTITY(1,1),
    MaNguoiDung INT,
    ThoiGianTacDong DATETIME DEFAULT CURRENT_TIMESTAMP,
    HanhDong VARCHAR(100), -- Ví dụ: ThemNguoiDung, SuaQuyen
    NoiDung TEXT,
    FOREIGN KEY (MaNguoiDung) REFERENCES NguoiDung(MaNguoiDung)
);

-- Bảng BaoCao: Lưu trữ báo cáo và thống kê
CREATE TABLE BaoCao (
    MaBaoCao INT PRIMARY KEY IDENTITY(1,1),
    LoaiBaoCao VARCHAR(50), -- Ví dụ: TongHop, LichSuTruyCap
    NgayBaoCao DATE,
    NoiDung TEXT,
    MaNguoiDung INT, -- Người tạo báo cáo
    FOREIGN KEY (MaNguoiDung) REFERENCES NguoiDung(MaNguoiDung)
);

-- Bảng HuongDanSuDung: Lưu trữ hướng dẫn sử dụng
CREATE TABLE HuongDanSuDung (
    MaHuongDan INT PRIMARY KEY IDENTITY(1,1),
    TieuDe VARCHAR(100) NOT NULL,
    NoiDung TEXT,
    NgayCapNhat DATE
);


-----------------------


-- Bảng LoaiRung: Lưu trữ các loại rừng theo mục đích sử dụng
CREATE TABLE LoaiRung (
    MaLoaiRung INT PRIMARY KEY IDENTITY(1,1),
    TenLoaiRung VARCHAR(50) NOT NULL, -- Ví dụ: Phòng hộ, Đặc dụng, Sản xuất
    MoTa TEXT
);

-- Bảng NguonGocRung: Lưu trữ nguồn gốc rừng
CREATE TABLE NguonGocRung (
    MaNguonGoc INT PRIMARY KEY IDENTITY(1,1),
    TenNguonGoc VARCHAR(50) NOT NULL -- Ví dụ: Tự nhiên, Trồng
);

-- Bảng DieuKienLapDia: Lưu trữ điều kiện lập địa
CREATE TABLE DieuKienLapDia (
    MaLapDia INT PRIMARY KEY IDENTITY(1,1),
    LoaiDat VARCHAR(50), -- Ví dụ: Đất feralit, đất phù sa
    DoDoc DECIMAL(5,2), -- Độ dốc (độ)
    DoAm DECIMAL(5,2), -- Độ ẩm (%)
    KhiHau VARCHAR(50), -- Ví dụ: Nhiệt đới gió mùa
    MoTa TEXT
);

-- Bảng LoaiCay: Lưu trữ thông tin về loài cây
CREATE TABLE LoaiCay (
    MaLoaiCay INT PRIMARY KEY IDENTITY(1,1),
    TenLoaiCay VARCHAR(100) NOT NULL, -- Ví dụ: Keo, Thông, Lim
    TenKhoaHoc VARCHAR(100),
    LaCayBanDia BIT, -- True: Cây bản địa, False: Cây ngoại lai
    MoTa TEXT
);

-- Bảng LoDatRung: Lưu trữ thông tin về lô đất rừng
CREATE TABLE LoDatRung (
    MaLoDat INT PRIMARY KEY IDENTITY(1,1),
    TenLoDat VARCHAR(50) NOT NULL, -- Tên lô đất (ví dụ: Lô A1)
    DienTich DECIMAL(10,2) NOT NULL, -- Diện tích (ha)
    ToaDo VARCHAR(100), -- Tọa độ địa lý (ví dụ: 21.1234, 105.5678)
    MaLoaiRung INT, -- Liên kết với bảng LoaiRung
    MaNguonGoc INT, -- Liên kết với bảng NguonGocRung
    MaLapDia INT, -- Liên kết với bảng DieuKienLapDia
    ChuSoHuu VARCHAR(100), -- Chủ sở hữu (cá nhân/tổ chức)
    TrangThai VARCHAR(50), -- Ví dụ: Có rừng, Chưa có rừng
    FOREIGN KEY (MaLoaiRung) REFERENCES LoaiRung(MaLoaiRung),
    FOREIGN KEY (MaNguonGoc) REFERENCES NguonGocRung(MaNguonGoc),
    FOREIGN KEY (MaLapDia) REFERENCES DieuKienLapDia(MaLapDia)
);

-- Bảng TruLuong: Lưu trữ trữ lượng rừng theo lô đất
CREATE TABLE TruLuong (
    MaTruLuong INT PRIMARY KEY IDENTITY(1,1),
    MaLoDat INT, -- Liên kết với bảng LoDatRung
    MaLoaiCay INT, -- Liên kết với bảng LoaiCay
    TheTichGo DECIMAL(10,2), -- Thể tích gỗ (m³/ha)
    SoLuongCay INT, -- Số lượng cây/ha
    NgayKiemKe DATE, -- Ngày kiểm kê trữ lượng
    FOREIGN KEY (MaLoDat) REFERENCES LoDatRung(MaLoDat),
    FOREIGN KEY (MaLoaiCay) REFERENCES LoaiCay(MaLoaiCay)
);

-- Bảng BienDongRung: Lưu trữ biến động rừng
CREATE TABLE BienDongRung (
    MaBienDong INT PRIMARY KEY IDENTITY(1,1),
    MaLoDat INT, -- Liên kết với bảng LoDatRung
    NgayBienDong DATE NOT NULL, -- Ngày xảy ra biến động
    LoaiBienDong VARCHAR(50) NOT NULL, -- Ví dụ: Phá rừng, Trồng mới, Chuyển mục đích
    DienTichBienDong DECIMAL(10,2), -- Diện tích bị ảnh hưởng (ha)
    MoTa TEXT,
    FOREIGN KEY (MaLoDat) REFERENCES LoDatRung(MaLoDat)
);

-- Bảng DienTichChuaCoRung: Lưu trữ diện tích chưa có rừng
CREATE TABLE DienTichChuaCoRung (
    MaChuaCoRung INT PRIMARY KEY IDENTITY(1,1),
    MaLoDat INT, -- Liên kết với bảng LoDatRung
    DienTich DECIMAL(10,2) NOT NULL, -- Diện tích chưa có rừng (ha)
    MaLapDia INT, -- Liên kết với bảng DieuKienLapDia
    KeHoachTrongRung TEXT, -- Kế hoạch trồng rừng (nếu có)
    FOREIGN KEY (MaLoDat) REFERENCES LoDatRung(MaLoDat),
    FOREIGN KEY (MaLapDia) REFERENCES DieuKienLapDia(MaLapDia)
);

-- Bảng KhuRung: Lưu trữ các khu rừng
CREATE TABLE KhuRung (
    MaKhuRung INT PRIMARY KEY IDENTITY(1,1),
    TenKhuRung VARCHAR(50) NOT NULL,
    MoTa TEXT,
    MaLoaiRung INT, -- Liên kết với loại rừng chính của khu vực
    MaNguonGoc INT, -- Liên kết với nguồn gốc chung của rừng trong khu vực
    MaLapDia INT, -- Liên kết với điều kiện lập địa điển hình
    MaLoDat INT, -- Liên kết với lô đất đại diện hoặc chính của khu vực
    MaNguoiSoHuu INT, -- Liên kết user
    FOREIGN KEY (MaLoaiRung) REFERENCES LoaiRung(MaLoaiRung),
    FOREIGN KEY (MaNguonGoc) REFERENCES NguonGocRung(MaNguonGoc),
    FOREIGN KEY (MaLapDia) REFERENCES DieuKienLapDia(MaLapDia),
    FOREIGN KEY (MaLoDat) REFERENCES LoDatRung(MaLoDat),
    FOREIGN KEY (MaNguoiSoHuu) REFERENCES NguoiDung(MaNguoiDung)
);


------------------

-- Xóa database nếu đã tồn tại
USE master;
GO
ALTER DATABASE ForestManagementSystem SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
GO
DROP DATABASE IF EXISTS ForestManagementSystem;
GO
go
CREATE DATABASE ForestManagementSystem;
go
USE ForestManagementSystem;
go

-- Xóa bảng nếu đã tồn tại



-- Bảng TrangThai: Lưu trữ tất cả các trạng thái chung
CREATE TABLE TrangThai (
    MaTrangThai INT PRIMARY KEY IDENTITY(1,1),
    TenTrangThai VARCHAR(50) NOT NULL, -- Ví dụ: Hoạt động, Ngưng hoạt động, Khóa, Rời nhóm
    MoTa TEXT
);

-- Bảng DonViHanhChinhTinh: Lưu trữ đơn vị hành chính cấp Tinh
CREATE TABLE DonViHanhChinhTinh (
    MaTinh INT PRIMARY KEY IDENTITY(1,1),
    TenTinh VARCHAR(100) NOT NULL
);

-- Bảng DonViHanhChinhHuyen: Lưu trữ đơn vị hành chính cấp huyện
CREATE TABLE DonViHanhChinhHuyen (
    MaHuyen INT PRIMARY KEY IDENTITY(1,1),
    TenHuyen VARCHAR(100) NOT NULL,
    MaTinh INT, -- Mã tỉnh liên kết
    FOREIGN KEY (MaTinh) REFERENCES DonViHanhChinhTinh(MaTinh)
);

-- Bảng DonViHanhChinhXa: Lưu trữ đơn vị hành chính cấp xã
CREATE TABLE DonViHanhChinhXa (
    MaXa INT PRIMARY KEY IDENTITY(1,1),
    TenXa VARCHAR(100) NOT NULL,
    MaHuyen INT, -- Liên kết với bảng DonViHanhChinhHuyen
    FOREIGN KEY (MaHuyen) REFERENCES DonViHanhChinhHuyen(MaHuyen)
);

-- Bảng NguoiDung: Lưu trữ thông tin người dùng
CREATE TABLE NguoiDung (
    MaNguoiDung INT PRIMARY KEY IDENTITY(1,1),
    TenNguoiDung VARCHAR(100) NOT NULL,
    TaiKhoan VARCHAR(50) NOT NULL,
    MatKhau VARCHAR(100) NOT NULL,
    Email VARCHAR(100),
    MaXa INT, -- Liên kết với đơn vị hành chính cấp xã
    MaTrangThai INT, -- Liên kết với bảng TrangThai
    NgayTao DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (MaXa) REFERENCES DonViHanhChinhXa(MaXa),
    FOREIGN KEY (MaTrangThai) REFERENCES TrangThai(MaTrangThai)
);

-- Bảng NhomNguoiDung: Lưu trữ nhóm người dùng
CREATE TABLE NhomNguoiDung (
    MaNhom INT PRIMARY KEY IDENTITY(1,1),
    TenNhom VARCHAR(100) NOT NULL,
    MoTa TEXT,
    MaTrangThai INT, -- Liên kết với bảng TrangThai
    FOREIGN KEY (MaTrangThai) REFERENCES TrangThai(MaTrangThai)
);

-- Bảng NguoiDung_Nhom: Lưu trữ mối quan hệ giữa người dùng và nhóm
CREATE TABLE NguoiDung_Nhom (
    MaNguoiDung INT,
    MaNhom INT,
    NgayThamGia  DATETIME DEFAULT CURRENT_TIMESTAMP,
    MaTrangThai INT, -- Liên kết với bảng TrangThai
    PRIMARY KEY (MaNguoiDung, MaNhom),
    FOREIGN KEY (MaNguoiDung) REFERENCES NguoiDung(MaNguoiDung),
    FOREIGN KEY (MaNhom) REFERENCES NhomNguoiDung(MaNhom),
    FOREIGN KEY (MaTrangThai) REFERENCES TrangThai(MaTrangThai)
);

-- Bảng PhanQuyenNhom: Lưu trữ phân quyền cho nhóm người dùng
CREATE TABLE PhanQuyenNhom (
    MaPhanQuyenNhom INT PRIMARY KEY IDENTITY(1,1),
    MaNhom INT,
    MaQuyen VARCHAR(50), -- Ví dụ: QuanLyHuyen, QuanLyXa
    MaTrangThai INT, -- Liên kết với bảng TrangThai
    FOREIGN KEY (MaNhom) REFERENCES NhomNguoiDung(MaNhom),
    FOREIGN KEY (MaTrangThai) REFERENCES TrangThai(MaTrangThai)
);

-- Bảng PhanQuyenNguoiDung: Lưu trữ phân quyền cho người dùng
CREATE TABLE PhanQuyenNguoiDung (
    MaPhanQuyenNguoiDung INT PRIMARY KEY IDENTITY(1,1),
    MaNguoiDung INT,
    MaQuyen VARCHAR(50),
    MaTrangThai INT, -- Liên kết với bảng TrangThai
    FOREIGN KEY (MaNguoiDung) REFERENCES NguoiDung(MaNguoiDung),
    FOREIGN KEY (MaTrangThai) REFERENCES TrangThai(MaTrangThai)
);

-- Bảng Menu: Lưu trữ danh mục menu
CREATE TABLE Menu (
    MaMenu INT PRIMARY KEY IDENTITY(1,1),
    TenMenu VARCHAR(100) NOT NULL,
    DuongDan VARCHAR(200), -- Đường dẫn URL
    ThuTu INT, -- Thứ tự hiển thị
    MaTrangThai INT, -- Liên kết với bảng TrangThai
    FOREIGN KEY (MaTrangThai) REFERENCES TrangThai(MaTrangThai)
);

-- Bảng LichSuTruyCap: Lưu trữ lịch sử truy cập
CREATE TABLE LichSuTruyCap (
    MaLichSu INT PRIMARY KEY IDENTITY(1,1),
    MaNguoiDung INT,
    ThoiGianTruyCap DATETIME DEFAULT CURRENT_TIMESTAMP,
    IPAddress VARCHAR(50),
    HanhDong VARCHAR(100), -- Ví dụ: DangNhap, DangXuat
    FOREIGN KEY (MaNguoiDung) REFERENCES NguoiDung(MaNguoiDung)
);

-- Bảng LichSuTacDong: Lưu trữ lịch sử tác động hệ thống
CREATE TABLE LichSuTacDong (
    MaTacDong INT PRIMARY KEY IDENTITY(1,1),
    MaNguoiDung INT,
    ThoiGianTacDong DATETIME DEFAULT CURRENT_TIMESTAMP,
    HanhDong VARCHAR(100), -- Ví dụ: ThemNguoiDung, SuaQuyen
    NoiDung TEXT,
    FOREIGN KEY (MaNguoiDung) REFERENCES NguoiDung(MaNguoiDung)
);

-- Bảng BaoCao: Lưu trữ báo cáo và thống kê
CREATE TABLE BaoCao (
    MaBaoCao INT PRIMARY KEY IDENTITY(1,1),
    LoaiBaoCao VARCHAR(50), -- Ví dụ: TongHop, LichSuTruyCap
    NgayBaoCao DATETIME,
    NoiDung TEXT,
    MaNguoiDung INT, -- Người tạo báo cáo
    FOREIGN KEY (MaNguoiDung) REFERENCES NguoiDung(MaNguoiDung)
);

-- Bảng HuongDanSuDung: Lưu trữ hướng dẫn sử dụng
CREATE TABLE HuongDanSuDung (
    MaHuongDan INT PRIMARY KEY IDENTITY(1,1),
    TieuDe VARCHAR(100) NOT NULL,
    NoiDung TEXT,
    NgayCapNhat DATETIME
);


-----------------------


-- Bảng LoaiRung: Lưu trữ các loại rừng theo mục đích sử dụng
CREATE TABLE LoaiRung (
    MaLoaiRung INT PRIMARY KEY IDENTITY(1,1),
    TenLoaiRung VARCHAR(50) NOT NULL, -- Ví dụ: Phòng hộ, Đặc dụng, Sản xuất
    MoTa TEXT
);

-- Bảng NguonGocRung: Lưu trữ nguồn gốc rừng
CREATE TABLE NguonGocRung (
    MaNguonGoc INT PRIMARY KEY IDENTITY(1,1),
    TenNguonGoc VARCHAR(50) NOT NULL -- Ví dụ: Tự nhiên, Trồng
);

-- Bảng DieuKienLapDia: Lưu trữ điều kiện lập địa
CREATE TABLE DieuKienLapDia (
    MaLapDia INT PRIMARY KEY IDENTITY(1,1),
    LoaiDat VARCHAR(50), -- Ví dụ: Đất feralit, đất phù sa
    DoDoc DECIMAL(5,2), -- Độ dốc (độ)
    DoAm DECIMAL(5,2), -- Độ ẩm (%)
    KhiHau VARCHAR(50), -- Ví dụ: Nhiệt đới gió mùa
    MoTa TEXT
);

-- Bảng LoaiCay: Lưu trữ thông tin về loài cây
CREATE TABLE LoaiCay (
    MaLoaiCay INT PRIMARY KEY IDENTITY(1,1),
    TenLoaiCay VARCHAR(100) NOT NULL, -- Ví dụ: Keo, Thông, Lim
    TenKhoaHoc VARCHAR(100),
    LaCayBanDia BIT, -- True: Cây bản địa, False: Cây ngoại lai
    MoTa TEXT
);

-- Bảng LoDatRung: Lưu trữ thông tin về lô đất rừng
CREATE TABLE LoDatRung (
    MaLoDat INT PRIMARY KEY IDENTITY(1,1),
    TenLoDat VARCHAR(50) NOT NULL, -- Tên lô đất (ví dụ: Lô A1)
    DienTich DECIMAL(10,2) NOT NULL, -- Diện tích (ha)
    ToaDo VARCHAR(100), -- Tọa độ địa lý (ví dụ: 21.1234, 105.5678)
    MaLoaiRung INT, -- Liên kết với bảng LoaiRung
    MaNguonGoc INT, -- Liên kết với bảng NguonGocRung
    MaLapDia INT, -- Liên kết với bảng DieuKienLapDia
    ChuSoHuu VARCHAR(100), -- Chủ sở hữu (cá nhân/tổ chức)
    TrangThai VARCHAR(50), -- Ví dụ: Có rừng, Chưa có rừng
    FOREIGN KEY (MaLoaiRung) REFERENCES LoaiRung(MaLoaiRung),
    FOREIGN KEY (MaNguonGoc) REFERENCES NguonGocRung(MaNguonGoc),
    FOREIGN KEY (MaLapDia) REFERENCES DieuKienLapDia(MaLapDia)
);

-- Bảng TruLuong: Lưu trữ trữ lượng rừng theo lô đất
CREATE TABLE TruLuong (
    MaTruLuong INT PRIMARY KEY IDENTITY(1,1),
    MaLoDat INT, -- Liên kết với bảng LoDatRung
    MaLoaiCay INT, -- Liên kết với bảng LoaiCay
    TheTichGo DECIMAL(10,2), -- Thể tích gỗ (m³/ha)
    SoLuongCay INT, -- Số lượng cây/ha
    NgayKiemKe DATETIME, -- Ngày kiểm kê trữ lượng
    FOREIGN KEY (MaLoDat) REFERENCES LoDatRung(MaLoDat),
    FOREIGN KEY (MaLoaiCay) REFERENCES LoaiCay(MaLoaiCay)
);

-- Bảng BienDongRung: Lưu trữ biến động rừng
CREATE TABLE BienDongRung (
    MaBienDong INT PRIMARY KEY IDENTITY(1,1),
    MaLoDat INT, -- Liên kết với bảng LoDatRung
    NgayBienDong DATETIME NOT NULL, -- Ngày xảy ra biến động
    LoaiBienDong VARCHAR(50) NOT NULL, -- Ví dụ: Phá rừng, Trồng mới, Chuyển mục đích
    DienTichBienDong DECIMAL(10,2), -- Diện tích bị ảnh hưởng (ha)
    MoTa TEXT,
    FOREIGN KEY (MaLoDat) REFERENCES LoDatRung(MaLoDat)
);

-- Bảng DienTichChuaCoRung: Lưu trữ diện tích chưa có rừng
CREATE TABLE DienTichChuaCoRung (
    MaChuaCoRung INT PRIMARY KEY IDENTITY(1,1),
    MaLoDat INT, -- Liên kết với bảng LoDatRung
    DienTich DECIMAL(10,2) NOT NULL, -- Diện tích chưa có rừng (ha)
    MaLapDia INT, -- Liên kết với bảng DieuKienLapDia
    KeHoachTrongRung TEXT, -- Kế hoạch trồng rừng (nếu có)
    FOREIGN KEY (MaLoDat) REFERENCES LoDatRung(MaLoDat),
    FOREIGN KEY (MaLapDia) REFERENCES DieuKienLapDia(MaLapDia)
);

-- Bảng KhuRung: Lưu trữ các khu rừng
CREATE TABLE KhuRung (
    MaKhuRung INT PRIMARY KEY IDENTITY(1,1),
    TenKhuRung VARCHAR(50) NOT NULL,
    MoTa TEXT,
    MaLoaiRung INT, -- Liên kết với loại rừng chính của khu vực
    MaNguonGoc INT, -- Liên kết với nguồn gốc chung của rừng trong khu vực
    MaLapDia INT, -- Liên kết với điều kiện lập địa điển hình
    MaLoDat INT, -- Liên kết với lô đất đại diện hoặc chính của khu vực
    MaNguoiSoHuu INT, -- Liên kết user
    FOREIGN KEY (MaLoaiRung) REFERENCES LoaiRung(MaLoaiRung),
    FOREIGN KEY (MaNguonGoc) REFERENCES NguonGocRung(MaNguonGoc),
    FOREIGN KEY (MaLapDia) REFERENCES DieuKienLapDia(MaLapDia),
    FOREIGN KEY (MaLoDat) REFERENCES LoDatRung(MaLoDat),
    FOREIGN KEY (MaNguoiSoHuu) REFERENCES NguoiDung(MaNguoiDung)
);

-- Bảng QuyHoachRung: Lưu trữ thông tin quy hoạch rừng
CREATE TABLE QuyHoachRung (
    MaQuyHoach INT PRIMARY KEY IDENTITY(1,1),
    MaKhuRung INT, -- Liên kết với khu rừng được quy hoạch
    KyQuyHoach VARCHAR(50) NOT NULL, -- Kỳ quy hoạch (ví dụ: 2025-2030)
    NgayBatDau DATETIME, -- Ngày bắt đầu quy hoạch
    NgayKetThuc DATETIME, -- Ngày kết thúc quy hoạch
    NoiDungBaoCao TEXT, -- Nội dung báo cáo quy hoạch
    DuongDanBanDo VARCHAR(200), -- Đường dẫn hoặc thông tin bản đồ quy hoạch
    MaNguoiDung INT, -- Người phụ trách quy hoạch (liên kết với NguoiDung)
    MaTrangThai INT, -- Trạng thái của quy hoạch (liên kết với TrangThai)
    FOREIGN KEY (MaKhuRung) REFERENCES KhuRung(MaKhuRung),
    FOREIGN KEY (MaNguoiDung) REFERENCES NguoiDung(MaNguoiDung),
    FOREIGN KEY (MaTrangThai) REFERENCES TrangThai(MaTrangThai)
);

CREATE TABLE DiemTruotLo (
    MaTruotLo INT PRIMARY KEY IDENTITY(1,1),
    TenDiem VARCHAR(100) NOT NULL, -- Tên điểm trượt lở (ví dụ: Điểm trượt lở Quốc lộ 6)
    ToaDo VARCHAR(100), -- Tọa độ địa lý (ví dụ: 21.1234, 105.5678)
    MaXa INT, -- Liên kết với đơn vị hành chính cấp xã
    NgayXayRa DATE, -- Ngày xảy ra trượt lở
    MucDoNghiemTrong VARCHAR(50), -- Ví dụ: Nhẹ, Trung bình, Nghiêm trọng
    NguyenNhan TEXT, -- Nguyên nhân trượt lở (ví dụ: Mưa lớn, phá rừng)
    ThietHai TEXT, -- Mô tả thiệt hại (ví dụ: 2 nhà sập, 10ha đất bị ảnh hưởng)
    MaTrangThai INT, -- Liên kết với bảng TrangThai (ví dụ: Đang xử lý, Đã khắc phục)
    MaNguoiCapNhat INT, -- Người cập nhật thông tin (liên kết với NguoiDung)
    NgayCapNhat DATETIME DEFAULT CURRENT_TIMESTAMP, -- Thời gian cập nhật
    FOREIGN KEY (MaXa) REFERENCES DonViHanhChinhXa(MaXa),
    FOREIGN KEY (MaTrangThai) REFERENCES TrangThai(MaTrangThai),
    FOREIGN KEY (MaNguoiCapNhat) REFERENCES NguoiDung(MaNguoiDung)
);

CREATE TABLE DiemLuQuet (
    MaLuQuet INT PRIMARY KEY IDENTITY(1,1),
    TenDiem VARCHAR(100) NOT NULL, -- Tên điểm lũ quét (ví dụ: Lũ quét suối Ia Lốp)
    ToaDo VARCHAR(100), -- Tọa độ địa lý
    MaXa INT, -- Liên kết với đơn vị hành chính cấp xã
    NgayXayRa DATE, -- Ngày xảy ra lũ quét
    MucDoNghiemTrong VARCHAR(50), -- Ví dụ: Nhẹ, Trung bình, Nghiêm trọng
    NguyenNhan TEXT, -- Nguyên nhân lũ quét
    ThietHai TEXT, -- Mô tả thiệt hại
    MaTrangThai INT, -- Liên kết với bảng TrangThai
    MaNguoiCapNhat INT, -- Người cập nhật thông tin
    NgayCapNhat DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (MaXa) REFERENCES DonViHanhChinhXa(MaXa),
    FOREIGN KEY (MaTrangThai) REFERENCES TrangThai(MaTrangThai),
    FOREIGN KEY (MaNguoiCapNhat) REFERENCES NguoiDung(MaNguoiDung)
);

CREATE TABLE BaoCaoThienTai (
    MaBaoCaoThienTai INT PRIMARY KEY IDENTITY(1,1),
    TieuDe VARCHAR(200) NOT NULL, -- Tiêu đề báo cáo
    LoaiThienTai VARCHAR(50) NOT NULL, -- Ví dụ: Trượt lở, Lũ quét
    MaTruotLo INT NULL, -- Liên kết với điểm trượt lở (nếu có)
    MaLuQuet INT NULL, -- Liên kết với điểm lũ quét (nếu có)
    MaXa INT, -- Liên kết với đơn vị hành chính cấp xã
    NgayBaoCao DATE NOT NULL, -- Ngày lập báo cáo
    NoiDung TEXT, -- Nội dung chi tiết báo cáo
    MaNguoiTao INT, -- Người tạo báo cáo
    MaTrangThai INT, -- Trạng thái báo cáo (ví dụ: Đang soạn thảo, Đã duyệt)
    NgayCapNhat DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (MaTruotLo) REFERENCES DiemTruotLo(MaTruotLo),
    FOREIGN KEY (MaLuQuet) REFERENCES DiemLuQuet(MaLuQuet),
    FOREIGN KEY (MaXa) REFERENCES DonViHanhChinhXa(MaXa),
    FOREIGN KEY (MaNguoiTao) REFERENCES NguoiDung(MaNguoiDung),
    FOREIGN KEY (MaTrangThai) REFERENCES TrangThai(MaTrangThai)
);
------------------

INSERT INTO TrangThai (TenTrangThai, MoTa) VALUES
('Hoạt động', 'Đang hoạt động bình thường'),
('Ngưng hoạt động', 'Tạm thời ngừng hoạt động'),
('Khóa', 'Bị khóa bởi quản trị viên'),
('Rời nhóm', 'Người dùng đã rời khỏi nhóm');

INSERT INTO TrangThai (TenTrangThai, MoTa) VALUES
('Đang xử lý', 'Sự kiện thiên tai đang được xử lý'),
('Đã khắc phục', 'Sự kiện thiên tai đã được khắc phục'),
('Đang soạn thảo', 'Báo cáo đang được soạn thảo'),
('Đã duyệt', 'Báo cáo đã được duyệt');

INSERT INTO DonViHanhChinhTinh (TenTinh) VALUES
('Lâm Đồng'),
('Gia Lai'),
('Đắk Lắk');

INSERT INTO DonViHanhChinhHuyen (TenHuyen, MaTinh) VALUES
('Đà Lạt', 1), -- Thuộc Lâm Đồng
('Di Linh', 1),
('Pleiku', 2), -- Thuộc Gia Lai
('Kon Tum', 2),
('Buôn Ma Thuột', 3); -- Thuộc Đắk Lắk

INSERT INTO DonViHanhChinhXa (TenXa, MaHuyen) VALUES
('Trạm Hành', 1), -- Thuộc Đà Lạt
('Gia Bắc', 2), -- Thuộc Di Linh
('Chư Păh', 3), -- Thuộc Pleiku
('Đắk Tô', 4), -- Thuộc Kon Tum
('Hòa Bình', 5); -- Thuộc Buôn Ma Thuột

INSERT INTO NguoiDung (TenNguoiDung, TaiKhoan, MatKhau, Email, MaXa, MaTrangThai, NgayTao) VALUES
('Nguyễn Văn A', 'nguyenvana', 'password123', 'nguyenvana@example.com', 1, 1, '2025-01-01'),
('Trần Thị B', 'tranthib', 'password456', 'tranthib@example.com', 2, 1, '2025-02-01'),
('admin', 'admin', 'admin', 'admin@example.com', 1, 1, '2025-01-01'),
('Lê Văn C', 'levanc', 'password789', 'levanc@example.com', 3, 1, '2025-03-01');

INSERT INTO NhomNguoiDung (TenNhom, MoTa, MaTrangThai) VALUES
('Quản lý rừng', 'Nhóm quản lý các khu rừng', 1),
('Kiểm lâm', 'Nhóm kiểm lâm địa phương', 1),
('Nhà nghiên cứu', 'Nhóm nghiên cứu rừng', 1);

INSERT INTO NguoiDung_Nhom (MaNguoiDung, MaNhom, NgayThamGia, MaTrangThai) VALUES
(1, 1, '2025-01-02', 1),
(2, 2, '2025-02-02', 1),
(3, 3, '2025-03-02', 1);

INSERT INTO PhanQuyenNhom (MaNhom, MaQuyen, MaTrangThai) VALUES
(1, 'QuanLyHuyen', 1),
(2, 'QuanLyXa', 1),
(3, 'NghienCuu', 1);

INSERT INTO PhanQuyenNguoiDung (MaNguoiDung, MaQuyen, MaTrangThai) VALUES
(1, 'Admin', 1),
(2, 'KiemLam', 1),
(3, 'NghienCuu', 1);

INSERT INTO Menu (TenMenu, DuongDan, ThuTu, MaTrangThai) VALUES
('Quản lý rừng', '/forest-management', 1, 1),
('Báo cáo', '/reports', 2, 1),
('Hướng dẫn sử dụng', '/help', 3, 1);

INSERT INTO LichSuTruyCap (MaNguoiDung, ThoiGianTruyCap, IPAddress, HanhDong) VALUES
(1, '2025-06-01 08:00:00', '192.168.1.1', 'DangNhap'),
(2, '2025-06-01 09:00:00', '192.168.1.2', 'DangNhap'),
(3, '2025-06-01 10:00:00', '192.168.1.3', 'DangXuat');

INSERT INTO LichSuTacDong (MaNguoiDung, ThoiGianTacDong, HanhDong, NoiDung) VALUES
(1, '2025-06-01 08:30:00', 'ThemNguoiDung', 'Thêm người dùng mới: Trần Thị B'),
(2, '2025-06-01 09:30:00', 'SuaQuyen', 'Cập nhật quyền cho nhóm Kiểm lâm'),
(3, '2025-06-01 10:30:00', 'TaoBaoCao', 'Tạo báo cáo trữ lượng rừng');

INSERT INTO BaoCao (LoaiBaoCao, NgayBaoCao, NoiDung, MaNguoiDung) VALUES
('TongHop', '2025-06-01', 'Báo cáo tổng hợp diện tích rừng', 1),
('LichSuTruyCap', '2025-06-02', 'Báo cáo lịch sử truy cập hệ thống', 2);

INSERT INTO HuongDanSuDung (TieuDe, NoiDung, NgayCapNhat) VALUES
('Hướng dẫn quản lý lô đất rừng', 'Hướng dẫn chi tiết cách nhập liệu và quản lý lô đất rừng', '2025-06-01'),
('Hướng dẫn tạo báo cáo', 'Hướng dẫn cách tạo và xuất báo cáo từ hệ thống', '2025-06-02');

INSERT INTO LoaiRung (TenLoaiRung, MoTa) VALUES
('Phòng hộ', 'Rừng bảo vệ nguồn nước, chống xói mòn'),
('Đặc dụng', 'Rừng bảo tồn thiên nhiên, đa dạng sinh học'),
('Sản xuất', 'Rừng phục vụ khai thác gỗ và sản phẩm lâm nghiệp');

INSERT INTO NguonGocRung (TenNguonGoc) VALUES
('Tự nhiên'),
('Trồng');

INSERT INTO DieuKienLapDia (LoaiDat, DoDoc, DoAm, KhiHau, MoTa) VALUES
('Đất feralit', 15.5, 70.0, 'Nhiệt đới gió mùa', 'Đất đỏ bazan, phù hợp với cây công nghiệp'),
('Đất phù sa', 5.0, 80.0, 'Nhiệt đới gió mùa', 'Đất phù sa ven sông, độ ẩm cao');

INSERT INTO LoaiCay (TenLoaiCay, TenKhoaHoc, LaCayBanDia, MoTa) VALUES
('Keo', 'Acacia mangium', 0, 'Cây ngoại lai, sinh trưởng nhanh'),
('Thông', 'Pinus merkusii', 1, 'Cây bản địa, gỗ chất lượng cao'),
('Lim', 'Erythrophleum fordii', 1, 'Cây bản địa, gỗ quý hiếm');

INSERT INTO LoDatRung (TenLoDat, DienTich, ToaDo, MaLoaiRung, MaNguonGoc, MaLapDia, ChuSoHuu, TrangThai) VALUES
('Lô A1', 50.5, '21.1234, 105.5678', 1, 1, 1, 'Công ty Lâm nghiệp A', 'Có rừng'),
('Lô B2', 30.0, '21.2345, 105.6789', 2, 2, 2, 'Hộ gia đình Nguyễn Văn B', 'Chưa có rừng');

INSERT INTO TruLuong (MaLoDat, MaLoaiCay, TheTichGo, SoLuongCay, NgayKiemKe) VALUES
(1, 1, 200.5, 1000, '2025-05-01'),
(1, 2, 150.0, 800, '2025-05-01');

INSERT INTO BienDongRung (MaLoDat, NgayBienDong, LoaiBienDong, DienTichBienDong, MoTa) VALUES
(1, '2025-04-01', 'Trồng mới', 10.0, 'Trồng mới 500 cây keo'),
(2, '2025-05-01', 'Phá rừng', 5.0, 'Phá rừng trái phép');

INSERT INTO DienTichChuaCoRung (MaLoDat, DienTich, MaLapDia, KeHoachTrongRung) VALUES
(2, 20.0, 2, 'Kế hoạch trồng 1000 cây keo vào năm 2026');

INSERT INTO KhuRung (TenKhuRung, MoTa, MaLoaiRung, MaNguonGoc, MaLapDia, MaLoDat, MaNguoiSoHuu) VALUES
('Khu rừng Đà Lạt', 'Khu rừng phòng hộ lớn tại Đà Lạt', 1, 1, 1, 1, 1),
('Khu rừng Gia Lai', 'Khu rừng sản xuất tại Gia Lai', 3, 2, 2, 2, 2);

INSERT INTO QuyHoachRung (MaKhuRung, KyQuyHoach, NgayBatDau, NgayKetThuc, NoiDungBaoCao, DuongDanBanDo, MaNguoiDung, MaTrangThai) VALUES
(1, '2025-2030', '2025-01-01', '2030-12-31', 'Quy hoạch bảo vệ rừng phòng hộ', '/maps/dalat_forest.pdf', 1, 1),
(2, '2025-2030', '2025-01-01', '2030-12-31', 'Quy hoạch khai thác rừng sản xuất', '/maps/gialai_forest.pdf', 2, 1);

--DiemTruotLo
INSERT INTO DiemTruotLo (TenDiem, ToaDo, MaXa, NgayXayRa, MucDoNghiemTrong, NguyenNhan, ThietHai, MaTrangThai, MaNguoiCapNhat) VALUES
('Trượt lở Quốc lộ 27', '21.2345, 105.6789', 1, '2025-05-01', 'Nghiêm trọng', 'Mưa lớn kéo dài 3 ngày', '3 nhà sập, 5ha đất nông nghiệp bị ảnh hưởng', 5, 1),
('Trượt lở suối Gia Bắc', '21.3456, 105.7890', 2, '2025-06-01', 'Trung bình', 'Phá rừng trái phép', '2ha rừng phòng hộ bị thiệt hại', 6, 2),
('Trượt lở đèo Chư Păh', '21.4567, 105.8901', 3, '2025-04-10', 'Nhẹ', 'Địa chất yếu do mưa', 'Tắc đường 2 giờ, không có thiệt hại lớn', 6, 3),
('Trượt lở đồi Đắk Tô', '21.5678, 105.9012', 4, '2025-05-15', 'Trung bình', 'Mưa lớn và xói mòn đất', '1ha đất canh tác bị mất', 5, 2),
('Trượt lở Hòa Bình', '21.6789, 106.0123', 5, '2025-03-20', 'Nghiêm trọng', 'Mưa lũ kết hợp địa hình dốc', '4 nhà bị hư hỏng, 10ha đất bị xói mòn', 5, 1);

--Bảng DiemLuQuet
INSERT INTO DiemLuQuet (TenDiem, ToaDo, MaXa, NgayXayRa, MucDoNghiemTrong, NguyenNhan, ThietHai, MaTrangThai, MaNguoiCapNhat) VALUES
('Lũ quét suối Trạm Hành', '21.1234, 105.5678', 1, '2025-04-15', 'Nghiêm trọng', 'Mưa lũ bất thường', '10 nhà bị ngập, 20ha hoa màu mất trắng', 5, 1),
('Lũ quét Gia Bắc', '21.2345, 105.6789', 2, '2025-05-20', 'Trung bình', 'Mưa lớn cục bộ', '5ha đất nông nghiệp bị ngập', 6, 2),
('Lũ quét Chư Păh', '21.3456, 105.7890', 3, '2025-06-05', 'Nghiêm trọng', 'Mưa kéo dài và rừng bị phá', '15 nhà bị hư hỏng, 30ha đất bị xói mòn', 5, 3),
('Lũ quét Đắk Tô', '21.4567, 105.8901', 4, '2025-03-25', 'Nhẹ', 'Mưa lớn trong 2 giờ', '2ha đất bị xói mòn, không có thiệt hại lớn', 6, 2),
('Lũ quét Hòa Bình', '21.5678, 106.0123', 5, '2025-04-30', 'Trung bình', 'Mưa lớn và địa hình thấp', '3 nhà bị ngập, 10ha hoa màu bị thiệt hại', 5, 1);

INSERT INTO BaoCaoThienTai (TieuDe, LoaiThienTai, MaTruotLo, MaLuQuet, MaXa, NgayBaoCao, NoiDung, MaNguoiTao, MaTrangThai) VALUES
('Báo cáo trượt lở Quốc lộ 27', 'Trượt lở', 1, NULL, 1, '2025-05-02', 'Trượt lở gây tắc đường Quốc lộ 27, cần khắc phục khẩn cấp. Đã cử đội cứu hộ.', 1, 7),
('Báo cáo lũ quét Chư Păh', 'Lũ quét', NULL, 3, 3, '2025-06-06', 'Lũ quét tại suối Chư Păh gây thiệt hại lớn, cần hỗ trợ khẩn cấp cho 15 hộ dân.', 3, 8),
('Báo cáo tổng hợp thiên tai Gia Bắc', 'Trượt lở', 2, 2, 2, '2025-06-02', 'Gia Bắc chịu cả trượt lở và lũ quét, cần kế hoạch tái định cư.', 2, 7),
('Báo cáo trượt lở Đắk Tô', 'Trượt lở', 4, NULL, 4, '2025-05-16', 'Trượt lở đồi Đắk Tô gây mất đất canh tác, đề xuất cải tạo đất.', 2, 8),
('Báo cáo lũ quét Hòa Bình', 'Lũ quét', NULL, 5, 5, '2025-05-01', 'Lũ quét tại Hòa Bình gây ngập lụt, cần hỗ trợ nông dân.', 1, 7);

