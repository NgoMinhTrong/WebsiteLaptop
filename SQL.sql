create database WEB
go
use WEB 
GO
create table DanhMuc
(
	ma int primary key,
	ten Nvarchar(100),
)
go
create table thuongHieu
(
	ma int primary key,
	ten Nvarchar(200)
)
go
create table SanPham
(
	ma int identity(1,1) NOT NULL primary key,
	ten Nvarchar(200) NOT NULL,
	gia float NOT NULL,
	soluong int NOT NULL ,
	mota Nvarchar(200),
	maThuongHieu int NOT NULL,
	maDanhMuc int NOT NULL,
	hinh varchar(100),
	ngaycapnhat datetime NOT NULL,
	Foreign key (maDanhMuc) references DanhMuc(ma),
	Foreign key (maThuongHieu) references ThuongHieu(ma),
)
go
create table HoaDon
(
	ma int primary key,
	makh int NOT NULL,
	ngaysuat date default getdate(),
	thanhtien float NOT NULL
	foreign key (makh) references Account(makh)
)
go
Alter table HoaDon add ngaydat date default getdate()
Alter table HoaDon add dathanhtoan bit
Alter table HoaDon add tinhtranggiaohang bit

create table CTHoaDon
(
	ma int primary key,
	maHoaDon int,
	soluong int NOT NULL,
	maSanPham int NOT NULL,
	foreign key (maHoaDon) references HoaDon(ma),
	foreign key (maSanPham) references SanPham(ma)
)
go
create table TaiKhoan
(
	tendangnhap varchar(20) primary key,
	matkhau varchar(20)
)
go

create table Account
(
	mail varchar(50) ,
	mk varchar(20),
	makh int identity(1,1) primary key,
	hoten Nvarchar (50),
	diachi Nvarchar(200),
	sdt varchar(15),
	
)
go
select * from HoaDon
drop table CTHoaDon

create table Admin
(
	UserAdmin varchar(50) primary key,
	PassAdmin varchar(50),
	Hoten Nvarchar(50),
)
--set dateformat dmy ngày tháng nam

insert into DanhMuc values(001,N'RAM')
insert into DanhMuc values(002,N'Bàn Phím')
insert into DanhMuc values(003,N'SSD')
insert into DanhMuc values(004,N'TAI NGHE')

insert into ThuongHieu values(001,N'Kington')
insert into thuongHieu values(002,N'SamSung')
insert into thuongHieu values(003,N'Hynix ')
insert into thuongHieu values(004,N'Elpida')	
insert into thuongHieu values(005,N'SONY')
insert into thuongHieu values(006,N'DELL/HP/VAIO/ASUS')




insert into SanPham values(N'Ram PC Kingston HyperX Fury Black 16GB Bus 2666 DDR4 CL16 DIMM XMP Non-ECC (HX426C16FB/16)',2790000,20,N'Loại sản phẩm: Ram PC Dung lượng: 16 GB(1 x 16GB) Chuẩn: DDR4 Bus: 2666 Mhz Điện áp: 1.2v Bảo hành 3 năm chính hãng',001,001,'ram01.jpg','03/23/2019')
insert into SanPham values(N'SSD Western Digital Black SN750 PCIe Gen3 x4 NVMe M.2 500GB WDS500G3X0C',3350000,26,N'Chuẩn SSD: M.2 NVMe Gen3 x4 Tốc độ đọc: 3470 MB/s Tốc độ ghi: 2600 MB/s Bảo hành chính hãng 60 tháng 1 đổi 1.',004,003,'SSD1.jpg','10/04/2019')
insert into SanPham values(N'Bàn phím cơ Full size RGB Backlit Ghost Gaming - Fantech ✪MK881✪ Blue Switch',5750000,21,N'Phím bấm nhẹ và chuẩn xác	Dễ dàng thay thế nút bấm và switch	Chống thấmchống bụi và chống nước	Công nghệ chiếu sáng RGB',002,002,'BP01.jpg','12/04/2019')
insert into SanPham values(N'tainge 970 EVO Plus PCIe NVMe V-NAND M.2 2280 1TB MZ-V7S1T0BW',5750000,21,N'Chuẩn SSD: M.2 NVMe Gen3 x4 Tốc độ đọc: 3500 MB/s Tốc độ ghi: 3300 MB/s Bảo hành 5 năm 1 đổi 1..',005,004,'TN01.jpg','08/04/2019')
insert into SanPham values(N'Ram PC Kingston HyperX Fury Black 16GB Bus 2666 DDR4 CL16 DIMM XMP Non-ECC (HX426C16FB/16)',2100000,90,N'Loại sản phẩm: Ram PC Dung lượng: 16 GB(1 x 16GB) Chuẩn: DDR4 Bus: 2666 Mhz Điện áp: 1.2v Bảo hành 3 năm chính hãng',001,001,'ram02.jpg','03/01/2019')
insert into SanPham values(N'SSD Western Digital Black SN750 PCIe Gen3 x4 NVMe M.2 500GB WDS500G3X0C',3350000,26,N'Chuẩn SSD: M.2 NVMe Gen3 x4 Tốc độ đọc: 3470 MB/s Tốc độ ghi: 2600 MB/s Bảo hành chính hãng 60 tháng 1 đổi 1.',004,003,'SSD1.jpg','02/20/2019')
insert into SanPham values(N'Bàn phím cơ Full size RGB Backlit Ghost Gaming - Fantech ✪MK881✪ Blue Switch',5750000,21,N'Phím bấm nhẹ và chuẩn xác	Dễ dàng thay thế nút bấm và switch	Chống thấmchống bụi và chống nước	Công nghệ chiếu sáng RGB',002,002,'BP02.jpg','02/01/2019')
insert into SanPham values(N'tainge 970 EVO Plus PCIe NVMe V-NAND M.2 2280 1TB MZ-V7S1T0BW',5750000,21,N'Chuẩn SSD: M.2 NVMe Gen3 x4 Tốc độ đọc: 3500 MB/s Tốc độ ghi: 3300 MB/s Bảo hành 5 năm 1 đổi 1..',005,004,'TN02.jpg','02/2/2019')
insert into SanPham values(N'Ram PC Kingston HyperX Fury Black 16GB Bus 2666 DDR4 CL16 DIMM XMP Non-ECC (HX426C16FB/16)',2100000,90,N'Loại sản phẩm: Ram PC Dung lượng: 16 GB(1 x 16GB) Chuẩn: DDR4 Bus: 2666 Mhz Điện áp: 1.2v Bảo hành 3 năm chính hãng',001,001,'ram03.jpg','06/01/2019')
insert into SanPham values(N'SSD Western Digital Black SN750 PCIe Gen3 x4 NVMe M.2 500GB WDS500G3X0C',3350000,26,N'Chuẩn SSD: M.2 NVMe Gen3 x4 Tốc độ đọc: 3470 MB/s Tốc độ ghi: 2600 MB/s Bảo hành chính hãng 60 tháng 1 đổi 1.',004,003,'SSD1.jpg','2/03/2019')
insert into SanPham values(N'Bàn phím cơ Full size RGB Backlit Ghost Gaming - Fantech ✪MK881✪ Blue Switch',5750000,21,N'Phím bấm nhẹ và chuẩn xác	Dễ dàng thay thế nút bấm và switch	Chống thấmchống bụi và chống nước	Công nghệ chiếu sáng RGB',002,002,'BP03.jpg','02/04/2019')
insert into SanPham values(N'tainge 970 EVO Plus PCIe NVMe V-NAND M.2 2280 1TB MZ-V7S1T0BW',5750000,21,N'Chuẩn SSD: M.2 NVMe Gen3 x4 Tốc độ đọc: 3500 MB/s Tốc độ ghi: 3300 MB/s Bảo hành 5 năm 1 đổi 1..',005,004,'TN03.jpg','03/04/2019')
insert into SanPham values(N'Ram PC Kingston HyperX Fury Black 16GB Bus 2666 DDR4 CL16 DIMM XMP Non-ECC (HX426C16FB/16)',2100000,90,N'Loại sản phẩm: Ram PC Dung lượng: 16 GB(1 x 16GB) Chuẩn: DDR4 Bus: 2666 Mhz Điện áp: 1.2v Bảo hành 3 năm chính hãng',001,001,'ram04.jpg','02/03/2019')
insert into SanPham values(N'SSD Western Digital Black SN750 PCIe Gen3 x4 NVMe M.2 500GB WDS500G3X0C',3350000,26,N'Chuẩn SSD: M.2 NVMe Gen3 x4 Tốc độ đọc: 3470 MB/s Tốc độ ghi: 2600 MB/s Bảo hành chính hãng 60 tháng 1 đổi 1.',004,003,'SSD4.jpg','2/03/2019')
insert into SanPham values(N'Bàn phím cơ Full size RGB Backlit Ghost Gaming - Fantech ✪MK881✪ Blue Switch',5750000,21,N'Phím bấm nhẹ và chuẩn xác	Dễ dàng thay thế nút bấm và switch	Chống thấmchống bụi và chống nước	Công nghệ chiếu sáng RGB',002,002,'BP04.jpg','02/03/2019')
insert into SanPham values(N'tainge 970 EVO Plus PCIe NVMe V-NAND M.2 2280 1TB MZ-V7S1T0BW',5750000,21,N'Chuẩn SSD: M.2 NVMe Gen3 x4 Tốc độ đọc: 3500 MB/s Tốc độ ghi: 3300 MB/s Bảo hành 5 năm 1 đổi 1..',005,004,'TN04.jpg','2/04/2019')


insert into Admin values('minhtrong','minhtrong',N'Ngô Minh Trong')


-- phần này khỏi insert
insert into HoaDon values(001,1,'20190310',1000000)

insert into CTHoaDon values(001,001,2,001)

insert into TaiKhoan values('minhtrong','123')
insert into Admin values('minhtrong','minhtrong',N'Ngô Minh Trong')
--select *from DanhMuc
--select *from CTHoaDon
--select * from SanPham
--select * from HoaDon
--select * from DanhMuc
--select * from taikhoan
SELECT * FROM account
--select * from Admin
-- thêm vào bảng account mà

--update SanPham set hinh = 'ram01.jpg' where ma =2
----update SanPham set hinh = 'SSD1.jpg' where ma =3
--DELETE SanPham 
--Delete Admin


--ALTER TABLE TAIKHOAN ADD PRIMARY KEY (tendangnhap)
--drop table CTHoaDon
--drop table HoaDon
--drop table SanPham
--drop table thuongHieu
--drop table TaiKhoan
--drop table Account
--drop table DanhMuc
--drop table Admin


insert into Account values('trong@1234','004','ngominhtrong','quan9','1234567899')
