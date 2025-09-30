CREATE DATABASE QL_DTDD1;

USE QL_DTDD1;

DROP DATABASE QL_DTDD1;

CREATE TABLE KhachHang(
	MaKH INT PRIMARY KEY,
	HoTen NVARCHAR(80),
	DienThoai CHAR(10),
	GioiTinh NVARCHAR(5),
	SoThich NVARCHAR(50),
	Email NVARCHAR(80),
	MatKhau CHAR(50)	
);

CREATE TABLE Loai(
	MaLoai INT PRIMARY KEY,
	TenLoai NVARCHAR(80)
);

CREATE TABLE SanPham(
	MaSP INT PRIMARY KEY,
	TenSP NVARCHAR(80),
	DuongDan CHAR(100),
	Gia INT,
	MoTa NVARCHAR(100),
	MaLoai INT,
	CONSTRAINT fk_SP_L FOREIGN KEY (MaLoai) REFERENCES Loai(MaLoai)
);

CREATE TABLE GioHang(
	MaGH INT PRIMARY KEY,
	MaKH INT,
	MaSP INT,
	SoLuong INT,
	Ngay DATE,
	CONSTRAINT fk_GH_KH FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH),
	CONSTRAINT fk_GH_SP FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP)
);

INSERT INTO Loai VALUES
(1,'Nokia'),
(2,'SamSung'),
(3,'Motorola'),
(4,'LG'),
(5,'Oppo'),
(6,'Iphone'),
(7,'BPhone')

INSERT INTO SanPham VALUES
(1,'N701','N701.jpg',2000000, 'Nang Cap BN',1),
(2,'N72','N72.jpg',2100000, 'Nang Cap BN',1),
(3,'N6030','N6030.jpg',3000000, 'Nang Cap BN',1),
(4,'N6200','N6200.jpg',3200000, 'Nang Cap BN',1),
(5,'GalaxyA6','GalaxyA6.jpg',5200000, 'Nang Cap BN',2),
(6,'GalaxyA9','GalaxyA9.jpg',5500000, 'Nang Cap BN',2),
(7,'GalaxyJ5','GalaxyJ5.jpg',6000000, 'Nang Cap BN',2),
(16,'MotoE5','MotoE5.jpg',2300000, 'Nang Cap BN',3),
(17,'MotoG7','MotoG7.jpg',8000000, 'Nang Cap BN',3),
(18,'LGV50','LGV50.jpg',3200000, 'Nang Cap BN',4),
(19,'LGG8','LGG8.jpg',2200000, 'Nang Cap BN',4),
(20,'OppoA5','OppoA5.jpg',1200000, 'Nang Cap BN',5),
(21,'OppoReno14','OppoReno14.jpg',400000, 'Nang Cap BN',5),
(22,'Iphone4s','Iphone4s.jpg',3000000, 'Nang Cap BN',6),
(23,'Iphone5s','Iphone5s.jpg',4200000, 'Nang Cap BN',6),
(24,'Iphone6s','Iphone6s.jpg',4500000, 'Nang Cap BN',6),
(25,'IphoneX','IphoneX.jpg',20000000, 'Nang Cap BN',6),
(26,'Iphone17ProMax','Iphone17ProMax.jpg',45000000, 'Nang Cap BN',6),
(27,'BPhone3','BPhone3.jpg',3200000, 'Nang Cap BN',7),
(28,'Bphone5','Bphone5.jpg',500000, 'Nang Cap BN',7)


INSERT INTO KhachHang VALUES
(1,N'Phạm Anh Tuấn',0909090909,N'Nam',N'Đọc sách','at@gmail.com','123'),
(2,N'Ngô Thành Nam',0101010101,N'Nam',N'Nấu ăn','tn@gmail.com','456'),
(3,N'Nguyễn Huỳnh Khánh Đoan',0202020202,N'Nữ',N'Bóng rổ','kd@gmail.com','789'),
(4,N'Lê Huyền Trâm',0303030303,N'Nữ',N'Đá banh','ht@gmail.com','012')


