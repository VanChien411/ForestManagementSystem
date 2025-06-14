
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
