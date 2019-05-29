namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmail : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CaLam",
                c => new
                    {
                        MaCaLam = c.String(nullable: false, maxLength: 10, unicode: false),
                        TenCaLam = c.String(maxLength: 100),
                        GioBD = c.Time(precision: 7),
                        GioKT = c.Time(precision: 7),
                        SoNVToiDa = c.Int(),
                    })
                .PrimaryKey(t => t.MaCaLam);
            
            CreateTable(
                "dbo.ThongTinDKCa",
                c => new
                    {
                        MaDKCa = c.String(nullable: false, maxLength: 10, unicode: false),
                        GioDK = c.DateTime(),
                        NgayLam = c.DateTime(storeType: "date"),
                        TrangThai = c.Int(),
                        MaNV = c.String(maxLength: 10, unicode: false),
                        MaCaLam = c.String(maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => t.MaDKCa)
                .ForeignKey("dbo.CaLam", t => t.MaCaLam)
                .ForeignKey("dbo.NhanVien", t => t.MaNV)
                .Index(t => t.MaNV)
                .Index(t => t.MaCaLam);
            
            CreateTable(
                "dbo.NhanVien",
                c => new
                    {
                        MaNV = c.String(nullable: false, maxLength: 10, unicode: false),
                        TenNV = c.String(maxLength: 100),
                        CMND = c.String(maxLength: 13, unicode: false),
                        SDT = c.String(maxLength: 11, unicode: false),
                        DiaChi = c.String(maxLength: 100),
                        MaLoaiNV = c.String(maxLength: 10, unicode: false),
                        TrangThai = c.Int(),
                        NgaySinh = c.DateTime(storeType: "date"),
                        GioiTinh = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.MaNV)
                .ForeignKey("dbo.LoaiNhanVien", t => t.MaLoaiNV)
                .Index(t => t.MaLoaiNV);
            
            CreateTable(
                "dbo.DonDatNL",
                c => new
                    {
                        MaDDatNL = c.String(nullable: false, maxLength: 10, unicode: false),
                        MaNV = c.String(maxLength: 10, unicode: false),
                        MANCC = c.String(maxLength: 10, unicode: false),
                        NgayDat = c.DateTime(),
                        TrangThai = c.Int(),
                    })
                .PrimaryKey(t => t.MaDDatNL)
                .ForeignKey("dbo.NhaCungCap", t => t.MANCC)
                .ForeignKey("dbo.NhanVien", t => t.MaNV)
                .Index(t => t.MaNV)
                .Index(t => t.MANCC);
            
            CreateTable(
                "dbo.ChiTietDDNL",
                c => new
                    {
                        MaNguyenLieu = c.String(nullable: false, maxLength: 10, unicode: false),
                        MaDDatNL = c.String(nullable: false, maxLength: 10, unicode: false),
                        SoLuongDat = c.Double(),
                    })
                .PrimaryKey(t => new { t.MaNguyenLieu, t.MaDDatNL })
                .ForeignKey("dbo.NguyenLieu", t => t.MaNguyenLieu)
                .ForeignKey("dbo.DonDatNL", t => t.MaDDatNL)
                .Index(t => t.MaNguyenLieu)
                .Index(t => t.MaDDatNL);
            
            CreateTable(
                "dbo.NguyenLieu",
                c => new
                    {
                        MaNguyenLieu = c.String(nullable: false, maxLength: 10, unicode: false),
                        TenNguyenLieu = c.String(maxLength: 100),
                        DonViTinhNL = c.String(maxLength: 20),
                        TonKho = c.Double(),
                        TonToiThieu = c.Double(),
                        MaLoaiNguyenLieu = c.String(maxLength: 10, unicode: false),
                        TrangThai = c.Int(),
                    })
                .PrimaryKey(t => t.MaNguyenLieu)
                .ForeignKey("dbo.LoaiNguyenLieu", t => t.MaLoaiNguyenLieu)
                .Index(t => t.MaLoaiNguyenLieu);
            
            CreateTable(
                "dbo.LoaiNguyenLieu",
                c => new
                    {
                        MaLoaiNguyenLieu = c.String(nullable: false, maxLength: 10, unicode: false),
                        TenLoaiNguyenLieu = c.String(maxLength: 100),
                        DienGiai = c.String(maxLength: 100),
                        TrangThai = c.Int(),
                    })
                .PrimaryKey(t => t.MaLoaiNguyenLieu);
            
            CreateTable(
                "dbo.ThanhPhanMonAn",
                c => new
                    {
                        MaMonAn = c.String(nullable: false, maxLength: 10, unicode: false),
                        MaNguyenLieu = c.String(nullable: false, maxLength: 10, unicode: false),
                        SoLuongNL = c.Double(),
                    })
                .PrimaryKey(t => new { t.MaMonAn, t.MaNguyenLieu })
                .ForeignKey("dbo.MonAn", t => t.MaMonAn)
                .ForeignKey("dbo.NguyenLieu", t => t.MaNguyenLieu)
                .Index(t => t.MaMonAn)
                .Index(t => t.MaNguyenLieu);
            
            CreateTable(
                "dbo.MonAn",
                c => new
                    {
                        MaMonAn = c.String(nullable: false, maxLength: 10, unicode: false),
                        TenMonAn = c.String(maxLength: 100),
                        DonViTinh = c.String(maxLength: 20),
                        SoLuongTon = c.Double(),
                        TrangThai = c.Int(),
                        HinhAnh = c.Binary(storeType: "image"),
                        MaLoaiMonAn = c.String(maxLength: 10, unicode: false),
                        GiaMon = c.Double(),
                    })
                .PrimaryKey(t => t.MaMonAn)
                .ForeignKey("dbo.LoaiMonAn", t => t.MaLoaiMonAn)
                .Index(t => t.MaLoaiMonAn);
            
            CreateTable(
                "dbo.ChiTietComBo",
                c => new
                    {
                        MaComBo = c.String(nullable: false, maxLength: 10, unicode: false),
                        MaMonAn = c.String(nullable: false, maxLength: 10, unicode: false),
                        SLMon = c.Int(),
                    })
                .PrimaryKey(t => new { t.MaComBo, t.MaMonAn })
                .ForeignKey("dbo.ComBo", t => t.MaComBo)
                .ForeignKey("dbo.MonAn", t => t.MaMonAn)
                .Index(t => t.MaComBo)
                .Index(t => t.MaMonAn);
            
            CreateTable(
                "dbo.ComBo",
                c => new
                    {
                        MaComBo = c.String(nullable: false, maxLength: 10, unicode: false),
                        TenComBo = c.String(maxLength: 100),
                        DienGiai = c.String(maxLength: 100),
                        PhanTramGiamGia = c.Double(),
                        TongTienGiam = c.Double(),
                        TongTienTraCB = c.Double(),
                        NgayApdung = c.DateTime(storeType: "date"),
                        NgayKetThuc = c.DateTime(storeType: "date"),
                        HinhAnh = c.Binary(storeType: "image"),
                        TrangThai = c.Int(),
                        TienGiam = c.Double(),
                    })
                .PrimaryKey(t => t.MaComBo);
            
            CreateTable(
                "dbo.ChiTietComBoTU",
                c => new
                    {
                        MaComBo = c.String(nullable: false, maxLength: 10, unicode: false),
                        MaThucUong = c.String(nullable: false, maxLength: 10, unicode: false),
                        SLThucUong = c.Int(),
                    })
                .PrimaryKey(t => new { t.MaComBo, t.MaThucUong })
                .ForeignKey("dbo.ThucUong", t => t.MaThucUong)
                .ForeignKey("dbo.ComBo", t => t.MaComBo)
                .Index(t => t.MaComBo)
                .Index(t => t.MaThucUong);
            
            CreateTable(
                "dbo.ThucUong",
                c => new
                    {
                        MaThucUong = c.String(nullable: false, maxLength: 10, unicode: false),
                        TenThucUong = c.String(maxLength: 100),
                        DonViTinh = c.String(maxLength: 20),
                        SoLuongTon = c.Double(),
                        TrangThai = c.Int(),
                        HinhAnh = c.Binary(storeType: "image"),
                        MaLoaiThucUong = c.String(maxLength: 10, unicode: false),
                        GiaThucUong = c.Double(),
                    })
                .PrimaryKey(t => t.MaThucUong)
                .ForeignKey("dbo.LoaiThucUong", t => t.MaLoaiThucUong)
                .Index(t => t.MaLoaiThucUong);
            
            CreateTable(
                "dbo.ChiTietDatThucUong",
                c => new
                    {
                        MaPhieuDat = c.String(nullable: false, maxLength: 10, unicode: false),
                        MaThucUong = c.String(nullable: false, maxLength: 10, unicode: false),
                        SoLuongDat = c.Int(),
                    })
                .PrimaryKey(t => new { t.MaPhieuDat, t.MaThucUong })
                .ForeignKey("dbo.PhieuDatBan", t => t.MaPhieuDat)
                .ForeignKey("dbo.ThucUong", t => t.MaThucUong)
                .Index(t => t.MaPhieuDat)
                .Index(t => t.MaThucUong);
            
            CreateTable(
                "dbo.PhieuDatBan",
                c => new
                    {
                        MaPhieuDat = c.String(nullable: false, maxLength: 10, unicode: false),
                        NgayGioDat = c.DateTime(),
                        NgayGioNhan = c.DateTime(),
                        SoLuongNguoi = c.Int(),
                        DatCoc = c.Double(),
                        TinhTrang = c.Int(),
                        MaKH = c.String(maxLength: 10, unicode: false),
                        MaViTri = c.String(maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => t.MaPhieuDat)
                .ForeignKey("dbo.KhachHang", t => t.MaKH)
                .ForeignKey("dbo.ViTri", t => t.MaViTri)
                .Index(t => t.MaKH)
                .Index(t => t.MaViTri);
            
            CreateTable(
                "dbo.ChiTietDatComBo",
                c => new
                    {
                        MaPhieuDat = c.String(nullable: false, maxLength: 10, unicode: false),
                        MaComBo = c.String(nullable: false, maxLength: 10, unicode: false),
                        SoLuongDat = c.Int(),
                    })
                .PrimaryKey(t => new { t.MaPhieuDat, t.MaComBo })
                .ForeignKey("dbo.PhieuDatBan", t => t.MaPhieuDat)
                .ForeignKey("dbo.ComBo", t => t.MaComBo)
                .Index(t => t.MaPhieuDat)
                .Index(t => t.MaComBo);
            
            CreateTable(
                "dbo.ChiTietDatMonAn",
                c => new
                    {
                        MaPhieuDat = c.String(nullable: false, maxLength: 10, unicode: false),
                        MaMonAn = c.String(nullable: false, maxLength: 10, unicode: false),
                        SoLuongDat = c.Int(),
                    })
                .PrimaryKey(t => new { t.MaPhieuDat, t.MaMonAn })
                .ForeignKey("dbo.PhieuDatBan", t => t.MaPhieuDat)
                .ForeignKey("dbo.MonAn", t => t.MaMonAn)
                .Index(t => t.MaPhieuDat)
                .Index(t => t.MaMonAn);
            
            CreateTable(
                "dbo.HoaDon",
                c => new
                    {
                        MaHD = c.String(nullable: false, maxLength: 10, unicode: false),
                        MaKH = c.String(maxLength: 10, unicode: false),
                        MaKMHD = c.String(maxLength: 10, unicode: false),
                        MaNV = c.String(maxLength: 10, unicode: false),
                        MaViTri = c.String(maxLength: 10, unicode: false),
                        MaPhieuDat = c.String(maxLength: 10, unicode: false),
                        GioLapHD = c.DateTime(),
                        GioThanhToan = c.DateTime(),
                        TongTien = c.Double(),
                        GiamGia = c.Double(),
                        ThanhTien = c.Double(),
                        TrangThai = c.Int(),
                    })
                .PrimaryKey(t => t.MaHD)
                .ForeignKey("dbo.KhachHang", t => t.MaKH)
                .ForeignKey("dbo.KMGiamGiaHD", t => t.MaKMHD)
                .ForeignKey("dbo.NhanVien", t => t.MaNV)
                .ForeignKey("dbo.PhieuDatBan", t => t.MaPhieuDat)
                .ForeignKey("dbo.ViTri", t => t.MaViTri)
                .Index(t => t.MaKH)
                .Index(t => t.MaKMHD)
                .Index(t => t.MaNV)
                .Index(t => t.MaViTri)
                .Index(t => t.MaPhieuDat);
            
            CreateTable(
                "dbo.ChiTietHDComBo",
                c => new
                    {
                        MaHD = c.String(nullable: false, maxLength: 10, unicode: false),
                        MaComBo = c.String(nullable: false, maxLength: 10, unicode: false),
                        SoLuongDat = c.Int(),
                    })
                .PrimaryKey(t => new { t.MaHD, t.MaComBo })
                .ForeignKey("dbo.HoaDon", t => t.MaHD)
                .ForeignKey("dbo.ComBo", t => t.MaComBo)
                .Index(t => t.MaHD)
                .Index(t => t.MaComBo);
            
            CreateTable(
                "dbo.ChiTietMonAn",
                c => new
                    {
                        MaHD = c.String(nullable: false, maxLength: 10, unicode: false),
                        MaMonAn = c.String(nullable: false, maxLength: 10, unicode: false),
                        SoLuongDat = c.Int(),
                    })
                .PrimaryKey(t => new { t.MaHD, t.MaMonAn })
                .ForeignKey("dbo.HoaDon", t => t.MaHD)
                .ForeignKey("dbo.MonAn", t => t.MaMonAn)
                .Index(t => t.MaHD)
                .Index(t => t.MaMonAn);
            
            CreateTable(
                "dbo.ChiTietThucUong",
                c => new
                    {
                        MaHD = c.String(nullable: false, maxLength: 10, unicode: false),
                        MaThucUong = c.String(nullable: false, maxLength: 10, unicode: false),
                        SoLuongDat = c.Int(),
                    })
                .PrimaryKey(t => new { t.MaHD, t.MaThucUong })
                .ForeignKey("dbo.HoaDon", t => t.MaHD)
                .ForeignKey("dbo.ThucUong", t => t.MaThucUong)
                .Index(t => t.MaHD)
                .Index(t => t.MaThucUong);
            
            CreateTable(
                "dbo.KhachHang",
                c => new
                    {
                        MaKH = c.String(nullable: false, maxLength: 10, unicode: false),
                        TenKH = c.String(maxLength: 100),
                        CMND = c.String(maxLength: 13, unicode: false),
                        SDT = c.String(maxLength: 11, unicode: false),
                        DiaChiKH = c.String(maxLength: 100),
                        TichLuy = c.Double(),
                        NgayTaoTT = c.DateTime(),
                        MaKMKH = c.String(maxLength: 10, unicode: false),
                        PASSWORD = c.String(maxLength: 32, unicode: false),
                        Email = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.MaKH)
                .ForeignKey("dbo.KhuyenMaiKH", t => t.MaKMKH)
                .Index(t => t.MaKMKH);
            
            CreateTable(
                "dbo.KhuyenMaiKH",
                c => new
                    {
                        MaKMKH = c.String(nullable: false, maxLength: 10, unicode: false),
                        TenKM = c.String(maxLength: 100),
                        GiamGia = c.Double(),
                        DinhMucSuDung = c.Double(),
                    })
                .PrimaryKey(t => t.MaKMKH);
            
            CreateTable(
                "dbo.KMGiamGiaHD",
                c => new
                    {
                        MaKMHD = c.String(nullable: false, maxLength: 10, unicode: false),
                        TenKM = c.String(maxLength: 100),
                        DienGiai = c.String(maxLength: 100),
                        ThoiGianBD = c.DateTime(storeType: "date"),
                        ThoiGianKT = c.DateTime(storeType: "date"),
                        PhanTramGiam = c.Double(),
                        TrangThai = c.Int(),
                    })
                .PrimaryKey(t => t.MaKMHD);
            
            CreateTable(
                "dbo.ViTri",
                c => new
                    {
                        MaViTri = c.String(nullable: false, maxLength: 10, unicode: false),
                        TenViTri = c.String(maxLength: 100),
                        DienGiai = c.String(maxLength: 100),
                        TrangThai = c.Int(),
                        SLNhanVienMax = c.Int(),
                        MaPhuThu = c.String(maxLength: 10, unicode: false),
                        MaKhuVuc = c.String(maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => t.MaViTri)
                .ForeignKey("dbo.KhuVuc", t => t.MaKhuVuc)
                .ForeignKey("dbo.PhuThuViTri", t => t.MaPhuThu)
                .Index(t => t.MaPhuThu)
                .Index(t => t.MaKhuVuc);
            
            CreateTable(
                "dbo.KhuVuc",
                c => new
                    {
                        MaKhuVuc = c.String(nullable: false, maxLength: 10, unicode: false),
                        TenKhuVuc = c.String(maxLength: 100),
                        MaLoaiKhuVuc = c.String(maxLength: 10, unicode: false),
                        SLKhachMax = c.Int(),
                        SLKhachMin = c.Int(),
                        SLViTriMax = c.Int(),
                        SLTrongHT = c.Int(),
                        TrangThai = c.Int(),
                        DienGiai = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.MaKhuVuc)
                .ForeignKey("dbo.LoaiKhuVuc", t => t.MaLoaiKhuVuc)
                .Index(t => t.MaLoaiKhuVuc);
            
            CreateTable(
                "dbo.LoaiKhuVuc",
                c => new
                    {
                        MaLoaiKhuVuc = c.String(nullable: false, maxLength: 10, unicode: false),
                        TenLoaiKhuVuc = c.String(maxLength: 100),
                        PhuThu = c.Double(),
                        KiHieu = c.String(maxLength: 5, unicode: false),
                    })
                .PrimaryKey(t => t.MaLoaiKhuVuc);
            
            CreateTable(
                "dbo.PhuThuViTri",
                c => new
                    {
                        MaPhuThu = c.String(nullable: false, maxLength: 10, unicode: false),
                        TenPhuThu = c.String(maxLength: 100),
                        PhuThu = c.Double(),
                    })
                .PrimaryKey(t => t.MaPhuThu);
            
            CreateTable(
                "dbo.PhuTrach",
                c => new
                    {
                        NgayLam = c.DateTime(nullable: false, storeType: "date"),
                        MaViTri = c.String(nullable: false, maxLength: 10, unicode: false),
                        MaDKCa = c.String(nullable: false, maxLength: 10, unicode: false),
                        SLViTri = c.Int(),
                        TuGio = c.Time(precision: 7),
                        DenGio = c.Time(precision: 7),
                    })
                .PrimaryKey(t => new { t.NgayLam, t.MaViTri, t.MaDKCa })
                .ForeignKey("dbo.ViTri", t => t.MaViTri)
                .ForeignKey("dbo.ThongTinDKCa", t => t.MaDKCa)
                .Index(t => t.MaViTri)
                .Index(t => t.MaDKCa);
            
            CreateTable(
                "dbo.LoaiThucUong",
                c => new
                    {
                        MaLoaiThucUong = c.String(nullable: false, maxLength: 10, unicode: false),
                        TenLoaiThucUong = c.String(maxLength: 100),
                        DienGiai = c.String(maxLength: 100),
                        TrangThai = c.Int(),
                    })
                .PrimaryKey(t => t.MaLoaiThucUong);
            
            CreateTable(
                "dbo.ThanhPhanThucUong",
                c => new
                    {
                        MaThucUong = c.String(nullable: false, maxLength: 10, unicode: false),
                        MaNguyenLieu = c.String(nullable: false, maxLength: 10, unicode: false),
                        SoLuongNL = c.Double(),
                    })
                .PrimaryKey(t => new { t.MaThucUong, t.MaNguyenLieu })
                .ForeignKey("dbo.ThucUong", t => t.MaThucUong)
                .ForeignKey("dbo.NguyenLieu", t => t.MaNguyenLieu)
                .Index(t => t.MaThucUong)
                .Index(t => t.MaNguyenLieu);
            
            CreateTable(
                "dbo.LoaiMonAn",
                c => new
                    {
                        MaLoaiMonAn = c.String(nullable: false, maxLength: 10, unicode: false),
                        TenLoaiMonAn = c.String(maxLength: 100),
                        DienGiai = c.String(maxLength: 100),
                        TrangThai = c.Int(),
                    })
                .PrimaryKey(t => t.MaLoaiMonAn);
            
            CreateTable(
                "dbo.NhaCungCap",
                c => new
                    {
                        MaNCC = c.String(nullable: false, maxLength: 10, unicode: false),
                        TenNCC = c.String(maxLength: 100),
                        DiaChi = c.String(maxLength: 100),
                        SDT = c.String(maxLength: 11, unicode: false),
                    })
                .PrimaryKey(t => t.MaNCC);
            
            CreateTable(
                "dbo.PhieuNhapNL",
                c => new
                    {
                        MaPN = c.String(nullable: false, maxLength: 10, unicode: false),
                        MaDDatNL = c.String(maxLength: 10, unicode: false),
                        NgayNhap = c.DateTime(storeType: "date"),
                        TongTien = c.Double(),
                    })
                .PrimaryKey(t => t.MaPN)
                .ForeignKey("dbo.DonDatNL", t => t.MaDDatNL)
                .Index(t => t.MaDDatNL);
            
            CreateTable(
                "dbo.ChiTietPhieuNhapNL",
                c => new
                    {
                        MaNguyenLieu = c.String(nullable: false, maxLength: 10, unicode: false),
                        MaPN = c.String(nullable: false, maxLength: 10, unicode: false),
                        SoLuongNhap = c.Double(),
                        Gia = c.Double(),
                    })
                .PrimaryKey(t => new { t.MaNguyenLieu, t.MaPN })
                .ForeignKey("dbo.PhieuNhapNL", t => t.MaPN)
                .Index(t => t.MaPN);
            
            CreateTable(
                "dbo.LoaiNhanVien",
                c => new
                    {
                        MaLoaiNV = c.String(nullable: false, maxLength: 10, unicode: false),
                        TenLoaiNV = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.MaLoaiNV);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhuTrach", "MaDKCa", "dbo.ThongTinDKCa");
            DropForeignKey("dbo.ThongTinDKCa", "MaNV", "dbo.NhanVien");
            DropForeignKey("dbo.NhanVien", "MaLoaiNV", "dbo.LoaiNhanVien");
            DropForeignKey("dbo.PhieuNhapNL", "MaDDatNL", "dbo.DonDatNL");
            DropForeignKey("dbo.ChiTietPhieuNhapNL", "MaPN", "dbo.PhieuNhapNL");
            DropForeignKey("dbo.DonDatNL", "MaNV", "dbo.NhanVien");
            DropForeignKey("dbo.DonDatNL", "MANCC", "dbo.NhaCungCap");
            DropForeignKey("dbo.ChiTietDDNL", "MaDDatNL", "dbo.DonDatNL");
            DropForeignKey("dbo.ThanhPhanThucUong", "MaNguyenLieu", "dbo.NguyenLieu");
            DropForeignKey("dbo.ThanhPhanMonAn", "MaNguyenLieu", "dbo.NguyenLieu");
            DropForeignKey("dbo.ThanhPhanMonAn", "MaMonAn", "dbo.MonAn");
            DropForeignKey("dbo.MonAn", "MaLoaiMonAn", "dbo.LoaiMonAn");
            DropForeignKey("dbo.ChiTietMonAn", "MaMonAn", "dbo.MonAn");
            DropForeignKey("dbo.ChiTietDatMonAn", "MaMonAn", "dbo.MonAn");
            DropForeignKey("dbo.ChiTietComBo", "MaMonAn", "dbo.MonAn");
            DropForeignKey("dbo.ChiTietHDComBo", "MaComBo", "dbo.ComBo");
            DropForeignKey("dbo.ChiTietDatComBo", "MaComBo", "dbo.ComBo");
            DropForeignKey("dbo.ChiTietComBoTU", "MaComBo", "dbo.ComBo");
            DropForeignKey("dbo.ThanhPhanThucUong", "MaThucUong", "dbo.ThucUong");
            DropForeignKey("dbo.ThucUong", "MaLoaiThucUong", "dbo.LoaiThucUong");
            DropForeignKey("dbo.ChiTietThucUong", "MaThucUong", "dbo.ThucUong");
            DropForeignKey("dbo.ChiTietDatThucUong", "MaThucUong", "dbo.ThucUong");
            DropForeignKey("dbo.PhuTrach", "MaViTri", "dbo.ViTri");
            DropForeignKey("dbo.ViTri", "MaPhuThu", "dbo.PhuThuViTri");
            DropForeignKey("dbo.PhieuDatBan", "MaViTri", "dbo.ViTri");
            DropForeignKey("dbo.ViTri", "MaKhuVuc", "dbo.KhuVuc");
            DropForeignKey("dbo.KhuVuc", "MaLoaiKhuVuc", "dbo.LoaiKhuVuc");
            DropForeignKey("dbo.HoaDon", "MaViTri", "dbo.ViTri");
            DropForeignKey("dbo.HoaDon", "MaPhieuDat", "dbo.PhieuDatBan");
            DropForeignKey("dbo.HoaDon", "MaNV", "dbo.NhanVien");
            DropForeignKey("dbo.HoaDon", "MaKMHD", "dbo.KMGiamGiaHD");
            DropForeignKey("dbo.PhieuDatBan", "MaKH", "dbo.KhachHang");
            DropForeignKey("dbo.KhachHang", "MaKMKH", "dbo.KhuyenMaiKH");
            DropForeignKey("dbo.HoaDon", "MaKH", "dbo.KhachHang");
            DropForeignKey("dbo.ChiTietThucUong", "MaHD", "dbo.HoaDon");
            DropForeignKey("dbo.ChiTietMonAn", "MaHD", "dbo.HoaDon");
            DropForeignKey("dbo.ChiTietHDComBo", "MaHD", "dbo.HoaDon");
            DropForeignKey("dbo.ChiTietDatThucUong", "MaPhieuDat", "dbo.PhieuDatBan");
            DropForeignKey("dbo.ChiTietDatMonAn", "MaPhieuDat", "dbo.PhieuDatBan");
            DropForeignKey("dbo.ChiTietDatComBo", "MaPhieuDat", "dbo.PhieuDatBan");
            DropForeignKey("dbo.ChiTietComBoTU", "MaThucUong", "dbo.ThucUong");
            DropForeignKey("dbo.ChiTietComBo", "MaComBo", "dbo.ComBo");
            DropForeignKey("dbo.NguyenLieu", "MaLoaiNguyenLieu", "dbo.LoaiNguyenLieu");
            DropForeignKey("dbo.ChiTietDDNL", "MaNguyenLieu", "dbo.NguyenLieu");
            DropForeignKey("dbo.ThongTinDKCa", "MaCaLam", "dbo.CaLam");
            DropIndex("dbo.ChiTietPhieuNhapNL", new[] { "MaPN" });
            DropIndex("dbo.PhieuNhapNL", new[] { "MaDDatNL" });
            DropIndex("dbo.ThanhPhanThucUong", new[] { "MaNguyenLieu" });
            DropIndex("dbo.ThanhPhanThucUong", new[] { "MaThucUong" });
            DropIndex("dbo.PhuTrach", new[] { "MaDKCa" });
            DropIndex("dbo.PhuTrach", new[] { "MaViTri" });
            DropIndex("dbo.KhuVuc", new[] { "MaLoaiKhuVuc" });
            DropIndex("dbo.ViTri", new[] { "MaKhuVuc" });
            DropIndex("dbo.ViTri", new[] { "MaPhuThu" });
            DropIndex("dbo.KhachHang", new[] { "MaKMKH" });
            DropIndex("dbo.ChiTietThucUong", new[] { "MaThucUong" });
            DropIndex("dbo.ChiTietThucUong", new[] { "MaHD" });
            DropIndex("dbo.ChiTietMonAn", new[] { "MaMonAn" });
            DropIndex("dbo.ChiTietMonAn", new[] { "MaHD" });
            DropIndex("dbo.ChiTietHDComBo", new[] { "MaComBo" });
            DropIndex("dbo.ChiTietHDComBo", new[] { "MaHD" });
            DropIndex("dbo.HoaDon", new[] { "MaPhieuDat" });
            DropIndex("dbo.HoaDon", new[] { "MaViTri" });
            DropIndex("dbo.HoaDon", new[] { "MaNV" });
            DropIndex("dbo.HoaDon", new[] { "MaKMHD" });
            DropIndex("dbo.HoaDon", new[] { "MaKH" });
            DropIndex("dbo.ChiTietDatMonAn", new[] { "MaMonAn" });
            DropIndex("dbo.ChiTietDatMonAn", new[] { "MaPhieuDat" });
            DropIndex("dbo.ChiTietDatComBo", new[] { "MaComBo" });
            DropIndex("dbo.ChiTietDatComBo", new[] { "MaPhieuDat" });
            DropIndex("dbo.PhieuDatBan", new[] { "MaViTri" });
            DropIndex("dbo.PhieuDatBan", new[] { "MaKH" });
            DropIndex("dbo.ChiTietDatThucUong", new[] { "MaThucUong" });
            DropIndex("dbo.ChiTietDatThucUong", new[] { "MaPhieuDat" });
            DropIndex("dbo.ThucUong", new[] { "MaLoaiThucUong" });
            DropIndex("dbo.ChiTietComBoTU", new[] { "MaThucUong" });
            DropIndex("dbo.ChiTietComBoTU", new[] { "MaComBo" });
            DropIndex("dbo.ChiTietComBo", new[] { "MaMonAn" });
            DropIndex("dbo.ChiTietComBo", new[] { "MaComBo" });
            DropIndex("dbo.MonAn", new[] { "MaLoaiMonAn" });
            DropIndex("dbo.ThanhPhanMonAn", new[] { "MaNguyenLieu" });
            DropIndex("dbo.ThanhPhanMonAn", new[] { "MaMonAn" });
            DropIndex("dbo.NguyenLieu", new[] { "MaLoaiNguyenLieu" });
            DropIndex("dbo.ChiTietDDNL", new[] { "MaDDatNL" });
            DropIndex("dbo.ChiTietDDNL", new[] { "MaNguyenLieu" });
            DropIndex("dbo.DonDatNL", new[] { "MANCC" });
            DropIndex("dbo.DonDatNL", new[] { "MaNV" });
            DropIndex("dbo.NhanVien", new[] { "MaLoaiNV" });
            DropIndex("dbo.ThongTinDKCa", new[] { "MaCaLam" });
            DropIndex("dbo.ThongTinDKCa", new[] { "MaNV" });
            DropTable("dbo.LoaiNhanVien");
            DropTable("dbo.ChiTietPhieuNhapNL");
            DropTable("dbo.PhieuNhapNL");
            DropTable("dbo.NhaCungCap");
            DropTable("dbo.LoaiMonAn");
            DropTable("dbo.ThanhPhanThucUong");
            DropTable("dbo.LoaiThucUong");
            DropTable("dbo.PhuTrach");
            DropTable("dbo.PhuThuViTri");
            DropTable("dbo.LoaiKhuVuc");
            DropTable("dbo.KhuVuc");
            DropTable("dbo.ViTri");
            DropTable("dbo.KMGiamGiaHD");
            DropTable("dbo.KhuyenMaiKH");
            DropTable("dbo.KhachHang");
            DropTable("dbo.ChiTietThucUong");
            DropTable("dbo.ChiTietMonAn");
            DropTable("dbo.ChiTietHDComBo");
            DropTable("dbo.HoaDon");
            DropTable("dbo.ChiTietDatMonAn");
            DropTable("dbo.ChiTietDatComBo");
            DropTable("dbo.PhieuDatBan");
            DropTable("dbo.ChiTietDatThucUong");
            DropTable("dbo.ThucUong");
            DropTable("dbo.ChiTietComBoTU");
            DropTable("dbo.ComBo");
            DropTable("dbo.ChiTietComBo");
            DropTable("dbo.MonAn");
            DropTable("dbo.ThanhPhanMonAn");
            DropTable("dbo.LoaiNguyenLieu");
            DropTable("dbo.NguyenLieu");
            DropTable("dbo.ChiTietDDNL");
            DropTable("dbo.DonDatNL");
            DropTable("dbo.NhanVien");
            DropTable("dbo.ThongTinDKCa");
            DropTable("dbo.CaLam");
        }
    }
}
