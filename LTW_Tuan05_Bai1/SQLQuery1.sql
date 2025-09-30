CREATE DATABASE QL_NhanSu;

USE QL_NhanSu;
GO


CREATE TABLE tbl_Deparment(
	Deptld INT PRIMARY KEY,
	NAME NVARCHAR(80)
);

GO
CREATE TABLE tbl_Employee(
	Id INT PRIMARY KEY,
	Name NVARCHAR(80),
	Gender NVARCHAR(10),
	City NVARCHAR(80),
	Deptld INT,
	CONSTRAINT fk_Emp_Depar FOREIGN KEY (Deptld) REFERENCES tbl_Deparment(Deptld)
);


INSERT INTO tbl_Deparment VALUES
(1, N'Khoa CNTT'),
(2, N'Khoa Ngoại Ngữ'),
(3, N'Khoa Tài Chính'),
(4, N'Khoa Thực Phẩm'),
(5, N'Khoa Đào tạo')
GO

INSERT INTO tbl_Employee VALUES
(1,	N'Nguyễn Hải Yến',			N'Nữ',	N'Đà Lạt',1),
(2,	N'Trương Mạnh Hùng',		N'Nam',	N'TP.HCM',1),
(3,	N'Đình Duy Minh',			N'Nam',	N'Thái Bình',2),
(4,	N'Ngô Thị Nguyệt',			N'Nữ',	N'Long An',2),
(5,	N'Đào Minh Châu',			N'Nữ',	N'Bạc Liêu',3),
(14,N'Phan Thị Ngọc Mai',		N'Nữ',	N'Bến Tre',3),
(15,N'Trương Nguyễn Quỳnh Anh',	N'Nữ',	N'TP.HCM',4),
(16,N'Lê Thanh Liêm',			N'Nam',	N'TP.HCM',4),
(17,N'bbb',						N'Nữ',	N'TP.HCM',5)
GO
