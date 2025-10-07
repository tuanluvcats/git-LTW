create database QLSP;
use QLSP;
go

create table KhachHang(
	MaKhachHang CHAR(20) NOT NULL PRIMARY KEY,
	TenKhachHang NVARCHAR(80),
	SoDienThoai VARCHAR(10),
	MatKhau VARCHAR(20)
);

create table Loai(
	MaLoai CHAR(20) NOT NULL PRIMARY KEY,
	TenLoai NVARCHAR(80)
);

create table NhaSanXuat(
	MaNSX CHAR(20) NOT NULL PRIMARY KEY,
	TenNSX NVARCHAR(80)
);

create table SanPham(
	MaSanPham CHAR(20) NOT NULL PRIMARY KEY,
	TenSP NVARCHAR(80),
	MaL CHAR(20),
	MaSX CHAR(20),
	Gia FLOAT,
	GhiChu NVARCHAR(80),
	Hinh VARCHAR(100),
	constraint fk_SP_L foreign key (MaL) references Loai(MaLoai),
	constraint fk_SP_NSX foreign key (MaSX) references NhaSanXuat(MaNSX)
);

create table HoaDon(
	MaHoaDon CHAR(20) NOT NULL PRIMARY KEY,
	NgayTao DATE,
	MaKH CHAR(20),
	constraint fk_HD_KH foreign key (MaKH) references KhachHang(MaKhachHang)
);

create table ChiTiet(
	MaHD CHAR(20),
	MaSP CHAR(20),
	SoLuong INT,
	PRIMARY KEY (MaHD, MaSP),
	constraint fk_CT_HD foreign key (MaHD) references HoaDon(MaHoaDon),
	constraint fk_CT_SP foreign key (MaSP) references SanPham(MaSanPham)
);

INSERT INTO Loai (MaLoai, TenLoai)
VALUES 
('L01', N'Sách giáo khoa'),
('L02', N'Sách từ điển'),
('L03', N'Sách đại học'),
('L04', N'Truyện tranh');

-- ========================
-- BẢNG NHÀ SẢN XUẤT
-- ========================
INSERT INTO NhaSanXuat (MaNSX, TenNSX)
VALUES 
('NXB01', N'NXB Giáo Dục Việt Nam'),
('NXB02', N'NXB Đại Học Quốc Gia'),
('NXB03', N'NXB Kim Đồng'),
('NXB04', N'NXB Từ Điển Bách Khoa');

-- ========================
-- BẢNG KHÁCH HÀNG
-- ========================
INSERT INTO KhachHang (MaKhachHang, TenKhachHang, SoDienThoai, MatKhau)
VALUES
('KH01', N'Nguyễn Văn A', '0912345678', 'pass123'),
('KH02', N'Lê Thị B', '0987654321', 'abc456'),
('KH03', N'Trần Minh C', '0905123456', '123456'),
('KH04', N'Phạm Thu D', '0977123456', 'mk789');

-- ========================
-- BẢNG SẢN PHẨM
-- ========================
INSERT INTO SanPham (MaSanPham, TenSP, MaL, MaSX, Gia, GhiChu, Hinh)
VALUES
-- Sách giáo khoa
('SP01', N'Sách Toán lớp 10', 'L01', 'NXB01', 35000, N'Tái bản 2024', 'toan10.jpg'),
('SP02', N'Sách Ngữ Văn lớp 11', 'L01', 'NXB01', 42000, N'Bìa mềm', 'van11.jpg'),
('SP03', N'Sách Vật Lý lớp 12', 'L01', 'NXB01', 38000, N'Có bài tập nâng cao', 'ly12.jpg'),

-- Sách từ điển
('SP04', N'Từ điển Anh - Việt', 'L02', 'NXB04', 89000, N'Tái bản lần thứ 5', 'td_av.jpg'),
('SP05', N'Từ điển Việt - Anh', 'L02', 'NXB04', 95000, N'Bìa cứng', 'td_va.jpg'),

-- Sách đại học
('SP06', N'Giáo trình Cấu trúc dữ liệu', 'L03', 'NXB02', 120000, N'Dành cho sinh viên CNTT', 'ctdl.jpg'),
('SP07', N'Giáo trình Kinh tế vi mô', 'L03', 'NXB02', 110000, N'Truy cập online kèm theo', 'ktvm.jpg'),

-- Truyện tranh
('SP08', N'Truyện Doraemon tập 1', 'L04', 'NXB03', 25000, N'Truyện thiếu nhi nổi tiếng', 'doraemon1.jpg'),
('SP09', N'Truyện Conan tập 2', 'L04', 'NXB03', 27000, N'Phiên bản màu', 'conan2.jpg'),
('SP10', N'Truyện One Piece tập 3', 'L04', 'NXB03', 30000, N'Truyện phiêu lưu hành động', 'onepiece3.jpg');

-- ========================
-- BẢNG HÓA ĐƠN
-- ========================
INSERT INTO HoaDon (MaHoaDon, NgayTao, MaKH)
VALUES
('HD01', '2025-09-25', 'KH01'),
('HD02', '2025-09-26', 'KH02'),
('HD03', '2025-09-27', 'KH03'),
('HD04', '2025-09-28', 'KH01'),
('HD05', '2025-09-29', 'KH04');

-- ========================
-- BẢNG CHI TIẾT HÓA ĐƠN
-- ========================
INSERT INTO ChiTiet (MaHD, MaSP, SoLuong)
VALUES
-- Hóa đơn 1 - Nguyễn Văn A
('HD01', 'SP01', 1),
('HD01', 'SP04', 1),

-- Hóa đơn 2 - Lê Thị B
('HD02', 'SP08', 2),
('HD02', 'SP09', 1),

-- Hóa đơn 3 - Trần Minh C
('HD03', 'SP06', 1),
('HD03', 'SP07', 1),

-- Hóa đơn 4 - Nguyễn Văn A (mua thêm)
('HD04', 'SP02', 1),
('HD04', 'SP05', 1),

-- Hóa đơn 5 - Phạm Thu D
('HD05', 'SP10', 3);
GO