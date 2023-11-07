USE MASTER
GO

IF DB_ID('QLNV') IS NOT NULL
DROP DATABASE QLNV
GO

CREATE DATABASE QLNV
GO

USE QLNV
GO

CREATE TABLE Phong
(
	Maphong INT PRIMARY KEY IDENTITY,
	Tenphong NVARCHAR(25)
)
GO

INSERT INTO Phong VALUES
(N'Hành chính'),
(N'Kinh doanh'),
(N'Tiếp thị'),
(N'Quản lý'),
(N'Nhân sự'),
(N'Kế toán'),
(N'Tổng hợp'),
(N'Công nghệ thông tin')
GO

--DROP TABLE Phong
--GO

CREATE TABLE NhanVien
(
	Manv INT PRIMARY KEY IDENTITY,
	Hoten NVARCHAR(30),
	Tuoi INT,
	Diachi NVARCHAR(30),
	Luong INT,
	Maphong INT FOREIGN KEY REFERENCES Phong(Maphong)
)
GO

INSERT INTO NhanVien VALUES
(N'Nguyễn Lan Anh', 32, N'Hà Nội', 6500000, 3),
(N'Trần Thị Hường', 30, N'Hà Nam', 8000000, 2),
(N'Phạm Văn Hà', 30, N'Hải Phòng', 9000000, 1),
(N'Dương Hồng Linh', 35, N'Thái Bình', 9500000, 5),
(N'Lê Văn Hùng', 32, N'Nam Định', 10000000, 4),
(N'Đào Hải Yến', 28, N'Ninh Bình', 8500000, 8),
(N'Nguyễn My Hà', 26, N'Hải Dương', 5500000, 7),
(N'Trần Phương Thuỷ', 24, N'Bắc Giang', 12000000, 6),
(N'Hoàng Phi Hùng', 24, N'Bắc Ninh',7500000, 3),
(N'Trương Công Tuấn', 40, N'Quảng Ninh', 6000000, 7)
GO

--DROP TABLE NhanVien
--GO

CREATE TABLE tblUser
(
	id INT PRIMARY KEY IDENTITY,
	username VARCHAR(50) UNIQUE,
	password NVARCHAR(100),
	role TINYINT
)
GO

INSERT INTO tblUser VALUES
('admin', '123', 1),
('1', '1', 2),
('2', '2', 2)
GO

--DROP TABLE tblUser
--GO

--SELECT * FROM Phong
--GO
--SELECT * FROM NhanVien
--GO
--SELECT * FROM tblUser
--GO