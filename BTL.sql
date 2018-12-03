create database QLTV
use QLTV
create table NHANVIEN
 (
            MaNV              varchar(20) primary key,
            TenNV             nvarchar(50),
            NgaySinh          date,
            GioiTinh          nvarchar(3),
            DiaChi            nvarchar(100),
			DienThoai         varchar(20),
            NgayVaoLam        date,
            Luong             float
 );
 create table DOCGIA
( 
            MaDG             varchar(20)  primary key ,
            TenDG             nvarchar(50),
            NgaySinh          date,
            GioiTinh          nvarchar(3),
            DiaChi            nvarchar(100),
            DienThoai         varchar(20)
 );
 
 create table SACH
 (
			MaSach			varchar(20) primary key ,
			TenSach			nvarchar(50),
			LoaiSach		nvarchar(50),
			LinhVuc			nvarchar(50),
			TacGia			nvarchar(50),
			NXB				nvarchar(50),
			NgayXB			date
 );
 create table PHIEUMUON
 (
			MaPhieuMuon		varchar(20) primary key , 
			MaNV            varchar(20)	references NHANVIEN (MaNV) on delete no action on update no action,
			MaDG            varchar(20)	references DOCGIA (MaDG) on delete no action on update no action,
			NgayMuon		date,
			NgayHenTra		date,

 );
 create table CHITIETPHIEUMUON
 (
			MaPhieuMuon		varchar(20) references PHIEUMUON(MaPhieuMuon) on delete cascade on update cascade,
            MaSach          varchar(20) references SACH(MaSach) on delete no action on update no action,
            SoLuong             int,
            primary key(MaPhieuMuon, MaSach),
 );
  create table PHIEUTRA
 (
			MaPhieuTra		varchar(20) primary key , 
			MaNV            varchar(20)	references NHANVIEN (MaNV) on delete no action on update no action,
			MaDG            varchar(20)	references DOCGIA (MaDG) on delete no action on update no action,
			NgayTra			date,
			TinhTrang		nvarchar(50),
			MaPhieuMuon		varchar(20) references PHIEUMUON(MaPhieuMuon) on delete cascade on update cascade,
 );
   create table CHITIETPHIEUTRA
(
			MaPhieuTra		varchar(20) references PHIEUTRA(MaPhieuTra) on delete cascade on update cascade,
            MaSach          varchar(20) references SACH(MaSach) on delete no action on update no action,
            SoLuongTra             int,
            primary key(MaPhieuTra, MaSach),
);
insert into NHANVIEN(MaNV,TenNV,NgaySinh,GioiTinh,DiaChi,DienThoai,NgayVaoLam,Luong)
values('NV01',N'Nguyễn Ngọc Long','4/6/1990',N'Nam',N'hà nội','0947689458','3/1/2018',6500000)
insert into NHANVIEN(MaNV,TenNV,NgaySinh,GioiTinh,DiaChi,DienThoai,NgayVaoLam,Luong)
values('NV02',N'Nguyễn Bảo Trâm','4/5/1989',N'Nữ',N'hải phòng','0947689458','10/5/2017',5000000)
insert into NHANVIEN(MaNV,TenNV,NgaySinh,GioiTinh,DiaChi,DienThoai,NgayVaoLam,Luong)
values('NV03',N'Nguyễn Thị Tuyết','5/9/1996',N'Nữ',N'đà nẵng','0947689458','6/6/2017',3000000)
insert into NHANVIEN(MaNV,TenNV,NgaySinh,GioiTinh,DiaChi,DienThoai,NgayVaoLam,Luong)
values('NV4',N'Hồ Ngọc Hải','4/3/1990',N'Nam',N'bắc ninh','0947689458','1/2/2018',5000000)
insert into NHANVIEN(MaNV,TenNV,NgaySinh,GioiTinh,DiaChi,DienThoai,NgayVaoLam,Luong)
values('NV05',N'Lê Thanh Thủy','9/10/1995',N'Nữ',N'hà nội','0947689458','9/1/2017',4500000)
insert into NHANVIEN(MaNV,TenNV,NgaySinh,GioiTinh,DiaChi,DienThoai,NgayVaoLam,Luong)
values('NV06',N'Trần Thùy Trang','4/5/1998',N'Nữ',N'hà nội','0947689458','8/7/2016',5000000)

-----------------
---lấy tất cả thông tin của nhân viên
select * from NHANVIEN
---thêm nhân viên
create proc them_NV
@MaNV              varchar(20),
@TenNV             nvarchar(50),
@NgaySinh          date,
@GioiTinh          nvarchar(3),
@DiaChi            nvarchar(100),
@DienThoai         varchar(20),
@NgayVaoLam        date,
@Luong            float,
@cmt				varchar(20)
as
begin
insert into NHANVIEN(MaNV,TenNV,NgaySinh,GioiTinh,DiaChi,DienThoai,NgayVaoLam,Luong,CMT) 
values (@MaNV,@TenNV,@NgaySinh,@GioiTinh,@DiaChi,@DienThoai,@NgayVaoLam,@Luong,@cmt)
end
----kiểm tra mã trùng
create proc kientra_ma
@ma varchar(20)
as
begin
select * from NHANVIEN where MaNV=@ma
end
exec kientra_ma 'NV05'
----update nhân viên
create proc update_NV
@manv varchar(20),
@ten nvarchar(50),
@ns date,
@gt nvarchar(3),
@dc nvarchar(100),
@dt varchar(20),
@nvl date,
@luong float
as
update NHANVIEN set  MaNV=@manv,TenNV=@ten,NgaySinh=@ns,GioiTinh=@gt,DiaChi=@dc,DienThoai=@dt,NgayVaoLam=@nvl,Luong=@luong
where MaNV=@manv

-----DELETE NHÂN VIÊN------------------------------------------
create proc delete_NV
@manv varchar(20)
as
delete from [dbo].[NHANVIEN] where [MaNV]=@manv

---Tìm kiếm Nhân Viên----
CREATE PROCEDURE TimKiemNVByID
	@maNV varchar(20)
AS
BEGIN
     SELECT *
     FROM NhanVien
     WHERE MaNV = @maNV
END


---Bảng Độc giả---

insert into DOCGIA(MaDG,TenDG,NgaySinh,GioiTinh,DiaChi,DienThoai)
values('DG101',N'Trần Thúy Hằng','8/02/1990',N'Nữ',N'Hà Nội','01637714806')
insert into DOCGIA(MaDG,TenDG,NgaySinh,GioiTinh,DiaChi,DienThoai)
values('DG121',N'Kim Thanh Hiền','09/23/1996',N'Nữ',N'Hải Dương','01694902934')
insert into DOCGIA(MaDG,TenDG,NgaySinh,GioiTinh,DiaChi,DienThoai)
values('DG132',N'Trần Nguyễn Minh Quân','12/25/1994',N'Nam',N'Hà Nội','0936714806')
insert into DOCGIA(MaDG,TenDG,NgaySinh,GioiTinh,DiaChi,DienThoai)
values('DG15',N'Lê Minh Hằng','03/30/2000',N'Nữ',N'Thái Bình','01637846392')
insert into DOCGIA(MaDG,TenDG,NgaySinh,GioiTinh,DiaChi,DienThoai)
values('DG102',N'Phạm Gia Hưng','10/12/1990',N'Nam',N'Thái Bình','01697635289')
insert into DOCGIA(MaDG,TenDG,NgaySinh,GioiTinh,DiaChi,DienThoai)
values('DG103',N'Nguyễn Hoàng Linh','09/05/1997',N'Nữ',N'Hà Nội','0936669406')

select * from [dbo].[DOCGIA]

---Kiểm tra mã độc giả trùng---
create proc KT_MaDG
@maDG varchar(20)
as
begin
select * from DOCGIA where MaDG=@maDG
end
exec KT_MaDG'DG101'
 
 ---thêm độc giả----
create proc Them_DG
			@maDG        varchar(20) ,
            @tenDG       nvarchar(50),
            @NS          date,
            @GT          nvarchar(3),
            @DC          nvarchar(100),
            @DT          varchar(20)
as
begin
insert into DOCGIA(MaDG,TenDG,NgaySinh,GioiTinh,DiaChi,DienThoai) 
values (@maDG,@tenDG,@NS,@GT,@DC,@DT)
end

----update độc giả
create proc update_DG
			@maDG        varchar(20) ,
            @tenDG       nvarchar(50),
            @NS          date,
            @GT          nvarchar(3),
            @DC          nvarchar(100),
            @DT          varchar(20)
as
update DOCGIA set  MaDG=@maDG,TenDG=@tenDG,NgaySinh=@NS,GioiTinh=@GT,DiaChi=@DC,DienThoai=@DT
where MaDG=@maDG

-----DELETE độc giả------------------------------------------
create proc delete_DG
@maDG varchar(20)
as
delete from DOCGIA where [MaDG]=@maDG

---Tìm kiếm độc giả----
CREATE PROCEDURE TimKiemDGByID
	@maDG varchar(20)
AS
BEGIN
     SELECT *
     FROM DOCGIA
     WHERE MaDG = @maDG
END


-----Bẳng SÁCH-----
insert into SACH(MaSach,TenSach,LoaiSach,LinhVuc,TacGia,NXB,NgayXB)
values('KT011',N'Một vành đai',N'Sách viết',N'Kinh Tế',N'TS.Phạm Sỹ Thanh',N'NXB Thế Giới', '05/27/2017')
insert into SACH(MaSach,TenSach,LoaiSach,LinhVuc,TacGia,NXB,NgayXB)
values('KT211',N'Bí Ẩn Của Vốn',N'Sách dịch',N'Kinh Tế',N'Hernando De Soto',N'NXB Chính trị quốc gia', '08/15/2017')
insert into SACH(MaSach,TenSach,LoaiSach,LinhVuc,TacGia,NXB,NgayXB)
values('CT011',N'Đừng Hoang Tưởng Về Biển Lớn ',N'Sách viết',N'Chính trị',N'Alan Phan',N'NXB Thế Giới', '02/12/2017')
insert into SACH(MaSach,TenSach,LoaiSach,LinhVuc,TacGia,NXB,NgayXB)
values('TN411',N'Hành trình yêu thương - Nhật ký Thiện Nhân',N'Sách viết',N'Thiếu nhi',N'Trần Mai Anh',N'NXB Kim Đồng', '10/09/2017')
insert into SACH(MaSach,TenSach,LoaiSach,LinhVuc,TacGia,NXB,NgayXB)
values('TN0113',N'Cánh Tay Cha Là Con Thuyền Vững Chãi',N'Sách dịch',N'Thiếu nhi',N'Stein Erik Lunde',N'NXB Kim Đồng', '12/30/2016')
insert into SACH(MaSach,TenSach,LoaiSach,LinhVuc,TacGia,NXB,NgayXB)
values('VH011',N'Tình Cát',N'Sách viết',N'Văn học',N'Nguyễn Quang Lập',N'NXB Hội Nhà Văn', '04/07/2015')
insert into SACH(MaSach,TenSach,LoaiSach,LinhVuc,TacGia,NXB,NgayXB)
values('VH015',N'Định chế totem hiện nay',N'Sách dịch',N'Văn học',N'Claude Lévi - Strauss',N'NXB Tri thức', '06/11/2006')

select * from SACH
---Kiểm tra mã trùng---
create proc KT_MaSach
@maSach varchar(20)
as
begin
select * from SACH where MaSach=@maSach
end
exec KT_MaSach'VH015'

---thêm độc Sách----
create proc Them_Sach
			@maSach        varchar(20) ,
            @tenSach       nvarchar(50),
            @loaiSach      nvarchar(50),
            @linhVuc       nvarchar(50),
            @tacGia        nvarchar(50),
            @NhaXB         nvarchar(50),
			@ngayXB         date
as
begin
insert into SACH(MaSach,TenSach,LoaiSach,LinhVuc,TacGia,NXB,NgayXB) 
values (@maSach,@tenSach,@loaiSach,@linhVuc,@tacGia,@NhaXB,@ngayXB)
end

----update Sách
create proc update_Sach
			@maSach        varchar(20) ,
            @tenSach       nvarchar(50),
            @loaiSach      nvarchar(50),
            @linhVuc       nvarchar(50),
            @tacGia        nvarchar(50),
            @NhaXB         nvarchar(50),
			@ngayXB         date
as
update SACH set  MaSach = @maSach,TenSach = @tenSach,LoaiSach = @loaiSach,LinhVuc = @linhVuc,TacGia = @tacGia,NXB = @NhaXB,NgayXB = @ngayXB
where MaSach=@maSach

-----DELETE Sách------------------------------------------
create proc delete_Sach
@maSach varchar(20)
as
delete from SACH where [MaSach]=@maSach

---Tìm kiếm sách----
CREATE PROCEDURE TimKiemSachByID
	@maSach varchar(20)
AS
BEGIN
     SELECT *
     FROM SACH
     WHERE MaSach = @maSach
END

-------Bảng Phiếu mượn-----
insert into PHIEUMUON(MaPhieuMuon, MaNV, MaDG, NgayMuon, NgayHenTra)
values('PM011','NV05','DG101', '07/23/2017', '07/28/2017')
insert into PHIEUMUON(MaPhieuMuon, MaNV, MaDG, NgayMuon, NgayHenTra)
values('PM013','NV05','DG132', '04/30/2017', '05/02/2017')
insert into PHIEUMUON(MaPhieuMuon, MaNV, MaDG, NgayMuon, NgayHenTra)
values('PM014','NV02','DG102', '10/23/2017', '10/28/2017')
insert into PHIEUMUON(MaPhieuMuon, MaNV, MaDG, NgayMuon, NgayHenTra)
values('PM015','NV4','DG101', '10/29/2017', '11/02/2017')
insert into PHIEUMUON(MaPhieuMuon, MaNV, MaDG, NgayMuon, NgayHenTra)
values('PM018','NV01','DG121', '11/06/2017', '11/10/2017')
insert into PHIEUMUON(MaPhieuMuon, MaNV, MaDG, NgayMuon, NgayHenTra)
values('PM017','NV02','DG103', '10/25/2017', '10/28/2017')


---Kiểm tra mã Phiếu mượn trùng---
create proc KT_MaPhieuMuon
@maPhieuMuon varchar(20)
as
begin
select * from PHIEUMUON where MaPhieuMuon=@maPhieuMuon
end


---thêm độc Phiếu mượn----
create proc Them_PhieuMuon
			@maPhieuMuon        varchar(20) ,
            @maNV               varchar(20),
            @maDG               varchar(20),
			@ngayMuon           date,
			@ngayHenTra         date
as
begin
insert into PHIEUMUON(MaPhieuMuon, MaNV, MaDG, NgayMuon, NgayHenTra) 
values (@maPhieuMuon, @maNV, @maDG, @ngayMuon, @ngayHenTra)
end

exec Them_PhieuMuon 'PM01','NV01','DG102','4/10/2017','2/11/2017'

----update Phiếu mượn----
create proc update_PhieuMuon
			@maPhieuMuon        varchar(20) ,
            @maNV               varchar(20),
            @maDG               varchar(20),
			@ngayMuon           date,
			@ngayHenTra         date
as
update PHIEUMUON set  MaPhieuMuon = @maPhieuMuon, MaNV = @maNV, MaDG = @maDG, NgayMuon = @ngayMuon, NgayHenTra = @ngayHenTra
where MaPhieuMuon = @maPhieuMuon

-----DELETE Phiếu mượn------------------------------------------
create proc delete_Phieumuon
@maPhieuMuon varchar(20)
as
delete from PHIEUMUON where [MaPhieuMuon]=@maPhieuMuon

---Tìm kiếm Phiếu mượn----
CREATE PROCEDURE TimKiemPhieuMuonByID
	@maPhieuMuon varchar(20)
AS
BEGIN
     SELECT *
     FROM PHIEUMUON
     WHERE MaPhieuMuon = @maPhieuMuon
END


-----Bảng Phiếu trả---

insert into PHIEUTRA(MaPhieuTra, MaNV, MaDG, NgayTra, TinhTrang,MaPhieuMuon)
values('PT01','NV01','DG101', '07/27/2017', N'Tốt', 'PM011')
insert into PHIEUTRA(MaPhieuTra, MaNV, MaDG, NgayTra, TinhTrang,MaPhieuMuon)
values('PT02','NV03','DG132', '05/02/2017', N'Tốt', 'PM013')
insert into PHIEUTRA(MaPhieuTra, MaNV, MaDG, NgayTra, TinhTrang,MaPhieuMuon)
values('PT05','NV4','DG121', '11/10/2017', N'Rách bìa', 'PM018')
insert into PHIEUTRA(MaPhieuTra, MaNV, MaDG, NgayTra, TinhTrang,MaPhieuMuon)
values('PT07','NV03','DG102', '10/27/2017', N'Tốt', 'PM014')

---Kiểm tra mã Phiếu trả trùng---
create proc KT_MaPhieuTra
@maPhieuTra varchar(20)
as
begin
select * from PHIEUTRA where MaPhieuTra=@maPhieuTra
end

Exec KT_MaPhieuTra PT01

---thêm độc Phiếu trả----
create proc Them_PhieuTra
			@maPhieuTra        varchar(20) ,
            @maNV               varchar(20),
            @maDG               varchar(20),
			@ngayTra           date,
			@tinhTrang			nvarchar(30),
			@maPhieuMuon		varchar(20)
as
begin
insert into PHIEUTRA(MaPhieuTra, MaNV, MaDG, NgayTra, TinhTrang,MaPhieuMuon) 
values (@maPhieuTra, @maNV, @maDG, @ngayTra, @tinhTrang, @maPhieuMuon)
end

----update Phiếu trả----
create proc update_PhieuTra
			@maPhieuTra        varchar(20) ,
            @maNV               varchar(20),
            @maDG               varchar(20),
			@ngayTra           date,
			@tinhTrang			nvarchar(30),
			@maPhieuMuon		varchar(20)
as
update PHIEUTRA set  MaPhieuTra = @maPhieuTra, MaNV = @maNV, MaDG =@maDG, NgayTra = @ngayTra, TinhTrang = @tinhTrang,MaPhieuMuon = @maPhieuMuon
where MaPhieuTra = @maPhieuTra

-----DELETE Phiếu trả------------------------------------------
create proc delete_PhieuTra
@maPhieuTra varchar(20)
as
delete from PHIEUTRA where [MaPhieuTra]=@maPhieuTra

---Tìm kiếm Phiếu trả----
CREATE PROCEDURE TimKiemPhieuTraByID
	@maPhieuTra varchar(20)
AS
BEGIN
     SELECT *
     FROM PHIEUTRA
     WHERE MaPhieuTra = @maPhieuTra
END

-------Bảng Chi tiết Phiếu mượn-----
insert into CHITIETPHIEUMUON(MaPhieuMuon, MaSach, SoLuong)
values('PM011','KT011', '2')
insert into CHITIETPHIEUMUON(MaPhieuMuon, MaSach, SoLuong)
values('PM013','VH011', '1')
insert into CHITIETPHIEUMUON(MaPhieuMuon, MaSach, SoLuong)
values('PM017','VH015', '1')
insert into CHITIETPHIEUMUON(MaPhieuMuon, MaSach, SoLuong)
values('PM014','TN0113', '2')
 
 ---Kiểm tra mã CT phiếu mượn trùng---
create proc KT_CTMaPhieumuon
@maPhieumuon varchar(20),
@masach varchar(20)
as
begin
select * from PHIEUTRA where [MaPhieuMuon]=@maPhieumuon 
end


---thêm chi tiết Phiếu mượn----
create proc Them_CtPhieumuon
			@mapm varchar(20),
			@masach varchar(20),
			@soluong int
as
begin
insert into [dbo].[CHITIETPHIEUMUON]([MaPhieuMuon],[MaSach],[SoLuong])
values (@mapm,@masach,@soluong)
end

----update chi tiết Phiếu trả----
create proc update_CtPhieumuon
			@mapm varchar(20),
			@masach varchar(20),
			@soluong int
as
update [dbo].[CHITIETPHIEUMUON] set  [MaPhieuMuon]=@mapm,[MaSach]=@masach,[SoLuong]=@soluong
-----DELETE chi tiết Phiếu mượn------------------------------------------
create proc delete_CTPhieumuon
@maPhieumuon varchar(20)
as
delete from [dbo].[PHIEUMUON] where [MaPhieuMuon]=@maPhieumuon

-----Tìm kiếm chi tiết Phiếu trả----
--CREATE PROCEDURE TimKiemPhieuTraByID
--	@maPhieuTra varchar(20)
--AS
--BEGIN
--     SELECT *
--     FROM PHIEUTRA
--     WHERE MaPhieuTra = @maPhieuTra
--END

 -------Bảng Chi tiết Phiếu trả-----
insert into CHITIETPHIEUTRA(MaPhieuTra, MaSach, SoLuongTra)
values('PT01','VH011', '1')
insert into CHITIETPHIEUTRA(MaPhieuTra, MaSach, SoLuongTra)
values('PT02','TN0113', '2')
insert into CHITIETPHIEUTRA(MaPhieuTra, MaSach, SoLuongTra)
values('PT07','KT011', '2')

---thêm chi tiết Phiếu tra----
create proc Them_CtPhieutra
			@mapt varchar(20),
			@masach varchar(20),
			@soluong int
as
begin
insert into [dbo].[CHITIETPHIEUTRA]([MaPhieuTra],[MaSach],[SoLuongTra])
values (@mapt,@masach,@soluong)
end

----update chi tiết Phiếu trả----
create proc update_CtPhieutra
			@mapt varchar(20),
			@masach varchar(20),
			@soluong int
as
update [dbo].[CHITIETPHIEUTRA] set  [MaPhieuTra]=@mapt,[MaSach]=@masach,[SoLuongTra]=@soluong
-----DELETE chi tiết Phiếu mượn------------------------------------------
create proc delete_CTPhieutra
@maPhieumuon varchar(20)
as
delete from [dbo].[PHIEUMUON] where [MaPhieuMuon]=@maPhieumuon

--Tạo thủ tục thống kê tổng số lượt mượn của 1 quyển sách có mã bất kì
create proc proc_soluotmuon
@masach varchar(20)
as
	select sum([SoLuong]) as [Số lượt mượn] from CHITIETPHIEUMUON where [MaSach]=@masach

	exec proc_soluotmuon 'TN0113'

	--Tạo thủ tục thống kê tổng số lượt mượn của 1 quyển sách có mã bất kì
create view cv_soluotmuon
as
	select CHITIETPHIEUMUON.MaSach, sum([SoLuong]) as [Số lượt mượn] from CHITIETPHIEUMUON 
	group by MaSach

	
	--lấy ra tên nhân viên có lương cao nhất

create view cv_nhanvien_luong
as
select top 1 NHANVIEN.TenNV, Luong
from dbo.NHANVIEN
order by Luong desc


----lấy ra nhân viên lập phiếu mượn trong tháng 10
create view cv_nhanvien_thang10
as
select NHANVIEN.TenNV, PHIEUMUON.NgayMuon, PHIEUMUON.MaPhieuMuon
from NHANVIEN, PHIEUMUON
where NHANVIEN.MaNV=PHIEUMUON.MaNV and MONTH(NgayMuon) = 10


---lấy ra độc giả chưa trả và trả muộn
create view cv_sach_chuatra
 as
 select DOCGIA.TenDG, DOCGIA.MaDG
 from DOCGIA inner join PHIEUMUON on DOCGIA.MaDG = PHIEUMUON.MaDG inner join PHIEUTRA on DOCGIA.MaDG = PHIEUTRA.MaDG
 where (DATEDIFF (DAY,PHIEUMUON.NgayMuon,PHIEUTRA.NgayTra)>30)
 or (PHIEUTRA.MaPhieuTra is null)
 and DATEDIFF (DAY,PHIEUMUON.NgayMuon,GETDATE())>30.

 ------load combox nhân viên
 create proc cbo_NhanVien
as
select [MaNV],[TenNV] from [dbo].[NHANVIEN]

exec cbo_NhanVien
 ------load combox độc giả
create proc cbo_DocGia
as
select [MaDG],[TenDG] from [dbo].[DOCGIA]

 ------load combox phiếu mượn
create proc cbo_phieumuon
as
select [MaPhieuMuon] from [dbo].[PHIEUMUON]

exec cbo_phieumuon

 ------load combox phiếu trả
create proc cbo_phieutra
as
select [MaPhieuTra] from [dbo].[PHIEUTRA]

------load combox sách
create proc cbo_sach
as
select [MaSach] from [dbo].[SACH]


 ------lấy thông tin phiếu mượn
select [MaPhieuMuon],[TenNV],[TenDG],[NgayMuon],[NgayHenTra] from ([dbo].[PHIEUMUON] inner join [dbo].[NHANVIEN] on [dbo].[PHIEUMUON].[MaNV]=[dbo].[NHANVIEN].MaNV) 
inner join [dbo].[DOCGIA] on [dbo].[PHIEUMUON].MaDG=DOCGIA.MaDG
 ------lấy thông tin phiếu trả
 select [MaPhieuTra] ,[TenNV],[TenDG],[NgayTra],[TinhTrang],[dbo].[PHIEUMUON].[MaPhieuMuon]  from ([dbo].[PHIEUMUON] inner join [dbo].[NHANVIEN] on [dbo].[PHIEUMUON].[MaNV]=[dbo].[NHANVIEN].MaNV) 
inner join [dbo].[DOCGIA] on [dbo].[PHIEUMUON].MaDG=DOCGIA.MaDG inner join [dbo].[PHIEUTRA] on [dbo].[DOCGIA].MaDG =[dbo].[PHIEUTRA].MaDG

-----Thống kê----------
create proc pr_luonghon5tr
as
begin
select *
from NHANVIEN
where Luong>5000000
end

--lấy ra những nhân viên có lương trên 5 triệu
create view cv_luonghon5tr
as 
select *
from NHANVIEN
where Luong>5000000

----THỐNG KÊ SỐ LƯỢNG SÁCH MƯỢN TRONG NĂM THEO TỪNG QUÝ
--select sum(case when month([dNgaymuon]) in (1,2,3) then [iSL]
--else 0 end) as N'Quý 1',
--sum(case when month([dNgaymuon]) in (4,5,6) then [iSL] 
--else 0 end) as N'Quý 2', 
--sum(case when month([dNgaymuon]) in (7,8,9) then [iSL]
--else 0 end) as N'Quý 3', 
--sum(case when month([dNgaymuon]) in (10,11,12) then [iSL] 
--else 0 end) as N'Quý 4' 
--from [dbo].[PHIEUMUON] inner join [dbo].[chitietPM] on [dbo].[PHIEUMUON].iSoPM_pk=[dbo].[chitietPM].iSoPM_fk
--where YEAR([dNgaymuon])=2018

----tìm những độc giả 
-----------------------------------


----Thống kê xem mỗi thể loại có bao nhiêu đầu sách
--select [iMaloai_pk],[sTenloai],COUNT([iMaS_pk]) as sl
--from [dbo].[THELOAISACH] inner join [dbo].[SACH]
--on [iMaloai_fk]=[iMaloai_pk]
--group by [iMaloai_pk],[sTenloai]

----Thống kê những độc giả trả muộn so với ngày hẹn

--select [sTenDG],[dNgayhentra],[dNgaytra]
--from [dbo].[DOCGIA] inner join [dbo].[PHIEUMUON] on [dbo].[DOCGIA].sMaDG_pk=[dbo].[PHIEUMUON].sMaDG_fk
--inner join [dbo].[PHIEUTRA] on [dbo].[PHIEUTRA].iSoPM_fk=[dbo].[PHIEUMUON].iSoPM_pk
--where [dNgaytra]>[dNgayhentra]

----Thống kê xem thể loại sách nào được mượn nhiều nhất

--select top 1 [sTenloai],COUNT(chitietPM.iMaS_fk)as N'Số lần mượn'
--from [dbo].[THELOAISACH] inner join [dbo].[SACH] on THELOAISACH.iMaloai_pk=SACH.iMaloai_fk
--inner join chitietPM on SACH.iMaS_pk=chitietPM.iMaS_fk
--group by chitietPM.iMaS_fk,[sTenloai]
--order by COUNT(chitietPM.iMaS_fk) desc

----lấy ra chi tiết pt của độc giả có số phiếu trả là 2--

--select [sMaDG_pk],[sTenDG],
--from [dbo].[DOCGIA],[dbo].[PHIEUTRA],[dbo].[chitietPT]
--where [dbo].[DOCGIA].sMaDG_pk=[dbo].[PHIEUTRA].sMaDG_fk
--and [dbo].[chitietPT].iSoPT_fk=[dbo].[PHIEUTRA].iSoPT_pk
--and [dbo].[PHIEUTRA].iSoPT_pk=2

----tìm những sách chưa được mượn bao giờ

--select *from [dbo].[SACH]
--where [iMaS_pk] not in (select [iMaS_fk] from [dbo].[chitietPT])

----Thống kê số lượng độc giả theo giới tính để nhập sách cho phù hợp

--select 
--(select count([sMaDG_pk]) from DOCGIA where [bGioitinh]=1) as N'Số lượng DG nữ',
--(select count([sMaDG_pk]) from DOCGIA where [bGioitinh]=0) as N'Số lượng DG nam'

----Tìm những sách không được mượn trong tháng 3 nhưng đc mượn trong tháng 4
---
select [TenSach],[NgayMuon]
from [dbo].[SACH] inner join [dbo].[CHITIETPHIEUMUON] on [dbo].[SACH].MaSach=[dbo].[CHITIETPHIEUMUON].MaSach
inner join [dbo].[PHIEUMUON] on [dbo].[PHIEUMUON].MaPhieuMuon=[dbo].[CHITIETPHIEUMUON].MaPhieuMuon
where [TenSach] not in (select [TenSach]
from [dbo].[SACH] inner join [dbo].[CHITIETPHIEUMUON] on [dbo].[SACH].MaSach=[dbo].[CHITIETPHIEUMUON].MaSach
inner join [dbo].[PHIEUMUON] on [dbo].[PHIEUMUON].MaPhieuMuon=[dbo].[CHITIETPHIEUMUON].MaPhieuMuon
where MONTH([NgayMuon])=3 ) and MONTH([NgayMuon])=4 


create view cv_nhanvien1990
as
select * from [dbo].[NHANVIEN] where year([NgaySinh])=1990


create proc pr_NhanVien1990
as
begin 
select * from [dbo].[NHANVIEN] where year([NgaySinh])=1990
end

Alter table [dbo].[NHANVIEN] add CMT varchar(20);




---------------------------------------------------


 ---Kiểm tra CMT trùng---

 
create proc KT_CMT
@cmt varchar(20)
as
begin
select * from NHANVIEN where CMT=@cmt
end

exec KT_CMT 123345


create proc pr_Nhanvien
as
begin
select [MaNV],[TenNV],(2018-year([NgaySinh])) as'NgaySinh',[GioiTinh],[DiaChi], [DienThoai],[NgayVaoLam],[Luong],[CMT] from NHANVIEN
end
