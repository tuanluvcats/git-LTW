create database qltv
use qltv

create table tacgia(
	maTg varchar(10) primary key,
	tenTg nvarchar(50),
	diaChi nvarchar(50),
	dienThoai varchar(10)
);

create table sach(
	maSach varchar(10) primary key,
	tenSach nvarchar(50),
	giaBan decimal(18,0),
	moTa nvarchar(100),
	anhBia nvarchar(100),
	ngayCapNhat date,
	soLuongTon int,
	maCD varchar(10),
	maNXB varchar(10),
);

alter table sach
add constraint fk_sh_cd foreign key (maCD) references chude(maCD),
constraint fk_sh_nxb foreign key (maNXB) references nhaxuatban(maNXB)

create table vietsach(
	maTg varchar(10),
	maSach varchar(10),
	vaiTro nvarchar(50),
	primary key (maTg, maSach)
);

alter table vietsach
add constraint fk_vs_tg foreign key (maTg) references tacgia(maTg),
constraint fk_vs_sh foreign key (maSach) references sach(maSach);

create table chude(
	maCD varchar(10) primary key,
	tenChuDe nvarchar(50)
);

create table nhaxuatban(
	maNXB varchar(10) primary key,
	tenNXB nvarchar(50),
	diaChi nvarchar(50),
	dienThoai varchar(10)
);

create table khachhang(
	maKH varchar(10) primary key,
	hoTen nvarchar(50),
	taiKhoan varchar(50),
	matKhau varchar(50),
	email varchar(50),
	diaChiKH nvarchar(100),
	dienThoaiKH varchar(10),
	ngaySinh date
);

create table dondathang(
	maDonHang varchar(10) primary key,
	daThanhToan nvarchar(50),
	tinhtrangDonHang nvarchar(50),
	ngayDat date,
	ngayGiao date,
	maKH varchar(10),
);

alter table dondathang
add constraint fk_ddh_kh foreign key (maKH) references khachhang(maKh);
 
create table chitietdonhang(
	maDonHang varchar(10),
	maSach varchar(10),
	soLuong int,
	donGia decimal(18,0),
	primary key (maDonHang, maSach)
);

alter table chitietdonhang
add constraint fk_ct_dh foreign key (maDonHang) references dondathang(maDonHang),
constraint fk_ct_sh foreign key (maSach) references sach(maSach);

INSERT INTO chude (tenChuDe) VALUES
(N'Tiểu thuyết'),
(N'Sách giáo khoa'),
(N'Truyện tranh'),
(N'Khoa học'),
(N'Thiếu nhi');


INSERT INTO nhaxuatban (tenNXB, diaChi, dienThoai) VALUES
(N'NXB Kim Đồng', N'55 Quang Trung, Hà Nội', '0243945678'),
(N'NXB Giáo Dục', N'101 Trần Phú, Hà Nội', '0243989123'),
(N'NXB Trẻ', N'161B Lý Chính Thắng, TP.HCM', '0283841234');
