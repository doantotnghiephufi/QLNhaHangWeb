USE [QuanLyNhaHang]
GO
/****** Object:  StoredProcedure [dbo].[ViTriTrongClick]    Script Date: 5/20/2019 7:27:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[ViTriTrongClick]
(
	@MaHD VARCHAR(10),
	@MaNV VARCHAR(10),
	@MaVT VARCHAR(10),
	@MaMonAn VARCHAR(10),
	@MaThucUong VARCHAR(10),
	@MaCombo VARCHAR(10),
	@SLThem INT
)
AS
BEGIN
	--INSERT 1 HÓA ĐƠN
	INSERT INTO dbo.HoaDon
	        ( MaHD ,
	          MaNV ,
	          MaViTri ,
	          GioLapHD 
	        )
	VALUES  ( @MaHD , -- MaHD - varchar(10)
	          @MaNV , -- MaNV - varchar(10)
	          @MaVT , -- MaViTri - varchar(10)
	          GETDATE() -- GioLapHD - datetime        
	        )
	--insert món vào HĐ về thêm ChiTietMonAn ChiTietThucUong ChiTietHDComBo
	IF((@MaMonAn IN (SELECT MaMonAn FROM dbo.MonAn)) AND dbo.checkNguyenLieu(@MaMonAn,@SLThem)=0 ) --Cái @MaMonAn có trong MonAn và SLThêm đủ 
		BEGIN
			--Xử lý thêm Vào ChiTietMonAn
			INSERT INTO dbo.ChiTietMonAn
			        ( MaHD, MaMonAn, SoLuongDat )
			VALUES  ( @MaHD, -- MaHD - varchar(10)
			          @MaMonAn, -- MaMonAn - varchar(10)
			          @SLThem  -- SoLuongDat - int
			          )
		END
	ELSE
		BEGIN
			IF( (@MaThucUong IN (SELECT MaThucUong FROM dbo.ThucUong)) AND dbo.checkNguyenLieuThucUong(@MaThucUong,@SLThem)=0)-- Cái @MaThucUong có trong ThucUong và SLTHem vô đủ
				BEGIN
					--Xử lý thêm vào ChitietThucUong
					INSERT INTO dbo.ChiTietThucUong
					        ( MaHD, MaThucUong, SoLuongDat )
					VALUES  ( @MaHD, -- MaHD - varchar(10)
					          @MaThucUong, -- MaThucUong - varchar(10)
					          @SLThem  -- SoLuongDat - int
					          )
				END
			ELSE
				BEGIN
					IF(@MaCombo IN (SELECT MaComBo FROM dbo.ComBo WHERE TrangThai=1)) -- MaCombo có trong Combo còn hạn
						BEGIN
							--Xử lý thêm vào  ChiTietHDComBo
							INSERT INTO dbo.ChiTietHDComBo
							        ( MaHD, MaComBo, SoLuongDat )
							VALUES  ( @MaHD, -- MaHD - varchar(10)
							          @MaCombo, -- MaComBo - varchar(10)
							          @SLThem  -- SoLuongDat - int
							          )
							
						END
					ELSE -- NẾu k có thỏa all IF
						BEGIN
							RAISERROR('Thêm không thành công',16,1)
							DELETE dbo.HoaDon WHERE MaHD=@MaHD
							RETURN
						END
				END
		END 
	IF(@@ROWCOUNT>0)
		BEGIN
	-- update vị trí bàn vừa nhấn
			UPDATE dbo.ViTri SET TrangThai = 1 WHERE MaViTri = @MaVT
		END
END