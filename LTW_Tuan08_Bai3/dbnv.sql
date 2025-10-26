create database QL_NhanSu
use QL_NhanSu

create table tbl_Department(
	DeptId int IDENTITY(1,1) primary key,
	Name nvarchar(50)
);


create table tbl_Employee(
	Id int IDENTITY(1,1) primary key,
	Name nvarchar(50),
	Gender nvarchar(5),
	City nvarchar(50),
	DeptId int
	constraint fk_e_depar foreign key (DeptId) references tbl_Department(DeptId)
);

insert into tbl_Department values
(N'Khoa CNTT'),
(N'Khoa Ngoại Ngữ'),
(N'Khoa Tài Chính'),
(N'Khoa Thực Phẩm'),
(N'Phòng Đào Tạo')

insert into tbl_Employee values
(N'Nguyễn Hải Yến', N'Nữ', N'Đà Lạt',1),
(N'Trương Mạnh Hùng', N'Nam', N'TP.HCM',1),
(N'Đình Duy Mạnh', N'Nam', N'Thái Bình',2),
(N'Ngô Thị Nguyệt', N'Nữ', N'Long An',2),
(N'Đào Minh Châu', N'Nữ', N'Bạc Liêu',3),
(N'Phan Thị Ngọc Mai', N'Nữ', N'Bến Tre',3),
(N'Trương Nguyễn Quỳnh Anh', N'Nữ', N'TP.HCM',4),
(N'LÊ Thanh Liêm', N'Nam', N'TP.HCM',4),
(N'bbbb', N'Nữ', N'TP.HCM',5)