namespace Models.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class NhaHangDbContext : DbContext
    {
        public NhaHangDbContext()
            : base("name=NhaHangDbContext")
        {
        }

        public virtual DbSet<CaLam> CaLams { get; set; }
        public virtual DbSet<ChiTietComBo> ChiTietComBoes { get; set; }
        public virtual DbSet<ChiTietComBoTU> ChiTietComBoTUs { get; set; }
        public virtual DbSet<ChiTietDatComBo> ChiTietDatComBoes { get; set; }
        public virtual DbSet<ChiTietDatMonAn> ChiTietDatMonAns { get; set; }
        public virtual DbSet<ChiTietDatThucUong> ChiTietDatThucUongs { get; set; }
        public virtual DbSet<ChiTietDDNL> ChiTietDDNLs { get; set; }
        public virtual DbSet<ChiTietHDComBo> ChiTietHDComBoes { get; set; }
        public virtual DbSet<ChiTietMonAn> ChiTietMonAns { get; set; }
        public virtual DbSet<ChiTietPhieuNhapNL> ChiTietPhieuNhapNLs { get; set; }
        public virtual DbSet<ChiTietThucUong> ChiTietThucUongs { get; set; }
        public virtual DbSet<ComBo> ComBoes { get; set; }
        public virtual DbSet<DonDatNL> DonDatNLs { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<KhuVuc> KhuVucs { get; set; }
        public virtual DbSet<KhuyenMaiKH> KhuyenMaiKHs { get; set; }
        public virtual DbSet<KMGiamGiaHD> KMGiamGiaHDs { get; set; }
        public virtual DbSet<LoaiKhuVuc> LoaiKhuVucs { get; set; }
        public virtual DbSet<LoaiMonAn> LoaiMonAns { get; set; }
        public virtual DbSet<LoaiNguyenLieu> LoaiNguyenLieux { get; set; }
        public virtual DbSet<LoaiNhanVien> LoaiNhanViens { get; set; }
        public virtual DbSet<LoaiThucUong> LoaiThucUongs { get; set; }
        public virtual DbSet<MonAn> MonAns { get; set; }
        public virtual DbSet<NguyenLieu> NguyenLieux { get; set; }
        public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<PhieuDatBan> PhieuDatBans { get; set; }
        public virtual DbSet<PhieuNhapNL> PhieuNhapNLs { get; set; }
        public virtual DbSet<PhuThuViTri> PhuThuViTris { get; set; }
        public virtual DbSet<PhuTrach> PhuTraches { get; set; }
        public virtual DbSet<ThanhPhanMonAn> ThanhPhanMonAns { get; set; }
        public virtual DbSet<ThanhPhanThucUong> ThanhPhanThucUongs { get; set; }
        public virtual DbSet<ThongTinDKCa> ThongTinDKCas { get; set; }
        public virtual DbSet<ThucUong> ThucUongs { get; set; }
        public virtual DbSet<ViTri> ViTris { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CaLam>()
                .Property(e => e.MaCaLam)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietComBo>()
                .Property(e => e.MaComBo)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietComBo>()
                .Property(e => e.MaMonAn)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietComBoTU>()
                .Property(e => e.MaComBo)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietComBoTU>()
                .Property(e => e.MaThucUong)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietDatComBo>()
                .Property(e => e.MaPhieuDat)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietDatComBo>()
                .Property(e => e.MaComBo)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietDatMonAn>()
                .Property(e => e.MaPhieuDat)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietDatMonAn>()
                .Property(e => e.MaMonAn)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietDatThucUong>()
                .Property(e => e.MaPhieuDat)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietDatThucUong>()
                .Property(e => e.MaThucUong)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietDDNL>()
                .Property(e => e.MaNguyenLieu)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietDDNL>()
                .Property(e => e.MaDDatNL)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietHDComBo>()
                .Property(e => e.MaHD)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietHDComBo>()
                .Property(e => e.MaComBo)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietMonAn>()
                .Property(e => e.MaHD)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietMonAn>()
                .Property(e => e.MaMonAn)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietPhieuNhapNL>()
                .Property(e => e.MaNguyenLieu)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietPhieuNhapNL>()
                .Property(e => e.MaPN)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietThucUong>()
                .Property(e => e.MaHD)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietThucUong>()
                .Property(e => e.MaThucUong)
                .IsUnicode(false);

            modelBuilder.Entity<ComBo>()
                .Property(e => e.MaComBo)
                .IsUnicode(false);

            modelBuilder.Entity<ComBo>()
                .HasMany(e => e.ChiTietComBoes)
                .WithRequired(e => e.ComBo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ComBo>()
                .HasMany(e => e.ChiTietComBoTUs)
                .WithRequired(e => e.ComBo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ComBo>()
                .HasMany(e => e.ChiTietDatComBoes)
                .WithRequired(e => e.ComBo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ComBo>()
                .HasMany(e => e.ChiTietHDComBoes)
                .WithRequired(e => e.ComBo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DonDatNL>()
                .Property(e => e.MaDDatNL)
                .IsUnicode(false);

            modelBuilder.Entity<DonDatNL>()
                .Property(e => e.MaNV)
                .IsUnicode(false);

            modelBuilder.Entity<DonDatNL>()
                .Property(e => e.MANCC)
                .IsUnicode(false);

            modelBuilder.Entity<DonDatNL>()
                .HasMany(e => e.ChiTietDDNLs)
                .WithRequired(e => e.DonDatNL)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.MaHD)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.MaKH)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.MaKMHD)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.MaNV)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.MaViTri)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.MaPhieuDat)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .HasMany(e => e.ChiTietHDComBoes)
                .WithRequired(e => e.HoaDon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HoaDon>()
                .HasMany(e => e.ChiTietMonAns)
                .WithRequired(e => e.HoaDon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HoaDon>()
                .HasMany(e => e.ChiTietThucUongs)
                .WithRequired(e => e.HoaDon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.MaKH)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.CMND)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.MaKMKH)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.PASSWORD)
                .IsUnicode(false);

            modelBuilder.Entity<KhuVuc>()
                .Property(e => e.MaKhuVuc)
                .IsUnicode(false);

            modelBuilder.Entity<KhuVuc>()
                .Property(e => e.MaLoaiKhuVuc)
                .IsUnicode(false);

            modelBuilder.Entity<KhuyenMaiKH>()
                .Property(e => e.MaKMKH)
                .IsUnicode(false);

            modelBuilder.Entity<KMGiamGiaHD>()
                .Property(e => e.MaKMHD)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiKhuVuc>()
                .Property(e => e.MaLoaiKhuVuc)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiKhuVuc>()
                .Property(e => e.KiHieu)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiMonAn>()
                .Property(e => e.MaLoaiMonAn)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiNguyenLieu>()
                .Property(e => e.MaLoaiNguyenLieu)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiNhanVien>()
                .Property(e => e.MaLoaiNV)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiThucUong>()
                .Property(e => e.MaLoaiThucUong)
                .IsUnicode(false);

            modelBuilder.Entity<MonAn>()
                .Property(e => e.MaMonAn)
                .IsUnicode(false);

            modelBuilder.Entity<MonAn>()
                .Property(e => e.MaLoaiMonAn)
                .IsUnicode(false);

            modelBuilder.Entity<MonAn>()
                .HasMany(e => e.ChiTietComBoes)
                .WithRequired(e => e.MonAn)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MonAn>()
                .HasMany(e => e.ChiTietDatMonAns)
                .WithRequired(e => e.MonAn)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MonAn>()
                .HasMany(e => e.ChiTietMonAns)
                .WithRequired(e => e.MonAn)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MonAn>()
                .HasMany(e => e.ThanhPhanMonAns)
                .WithRequired(e => e.MonAn)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NguyenLieu>()
                .Property(e => e.MaNguyenLieu)
                .IsUnicode(false);

            modelBuilder.Entity<NguyenLieu>()
                .Property(e => e.MaLoaiNguyenLieu)
                .IsUnicode(false);

            modelBuilder.Entity<NguyenLieu>()
                .HasMany(e => e.ChiTietDDNLs)
                .WithRequired(e => e.NguyenLieu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NguyenLieu>()
                .HasMany(e => e.ThanhPhanMonAns)
                .WithRequired(e => e.NguyenLieu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NguyenLieu>()
                .HasMany(e => e.ThanhPhanThucUongs)
                .WithRequired(e => e.NguyenLieu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhaCungCap>()
                .Property(e => e.MaNCC)
                .IsUnicode(false);

            modelBuilder.Entity<NhaCungCap>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MaNV)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.CMND)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MaLoaiNV)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuDatBan>()
                .Property(e => e.MaPhieuDat)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuDatBan>()
                .Property(e => e.MaKH)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuDatBan>()
                .Property(e => e.MaViTri)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuDatBan>()
                .HasMany(e => e.ChiTietDatComBoes)
                .WithRequired(e => e.PhieuDatBan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhieuDatBan>()
                .HasMany(e => e.ChiTietDatMonAns)
                .WithRequired(e => e.PhieuDatBan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhieuDatBan>()
                .HasMany(e => e.ChiTietDatThucUongs)
                .WithRequired(e => e.PhieuDatBan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhieuNhapNL>()
                .Property(e => e.MaPN)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuNhapNL>()
                .Property(e => e.MaDDatNL)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuNhapNL>()
                .HasMany(e => e.ChiTietPhieuNhapNLs)
                .WithRequired(e => e.PhieuNhapNL)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhuThuViTri>()
                .Property(e => e.MaPhuThu)
                .IsUnicode(false);

            modelBuilder.Entity<PhuTrach>()
                .Property(e => e.MaViTri)
                .IsUnicode(false);

            modelBuilder.Entity<PhuTrach>()
                .Property(e => e.MaDKCa)
                .IsUnicode(false);

            modelBuilder.Entity<ThanhPhanMonAn>()
                .Property(e => e.MaMonAn)
                .IsUnicode(false);

            modelBuilder.Entity<ThanhPhanMonAn>()
                .Property(e => e.MaNguyenLieu)
                .IsUnicode(false);

            modelBuilder.Entity<ThanhPhanThucUong>()
                .Property(e => e.MaThucUong)
                .IsUnicode(false);

            modelBuilder.Entity<ThanhPhanThucUong>()
                .Property(e => e.MaNguyenLieu)
                .IsUnicode(false);

            modelBuilder.Entity<ThongTinDKCa>()
                .Property(e => e.MaDKCa)
                .IsUnicode(false);

            modelBuilder.Entity<ThongTinDKCa>()
                .Property(e => e.MaNV)
                .IsUnicode(false);

            modelBuilder.Entity<ThongTinDKCa>()
                .Property(e => e.MaCaLam)
                .IsUnicode(false);

            modelBuilder.Entity<ThongTinDKCa>()
                .HasMany(e => e.PhuTraches)
                .WithRequired(e => e.ThongTinDKCa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ThucUong>()
                .Property(e => e.MaThucUong)
                .IsUnicode(false);

            modelBuilder.Entity<ThucUong>()
                .Property(e => e.MaLoaiThucUong)
                .IsUnicode(false);

            modelBuilder.Entity<ThucUong>()
                .HasMany(e => e.ChiTietComBoTUs)
                .WithRequired(e => e.ThucUong)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ThucUong>()
                .HasMany(e => e.ChiTietDatThucUongs)
                .WithRequired(e => e.ThucUong)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ThucUong>()
                .HasMany(e => e.ChiTietThucUongs)
                .WithRequired(e => e.ThucUong)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ThucUong>()
                .HasMany(e => e.ThanhPhanThucUongs)
                .WithRequired(e => e.ThucUong)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ViTri>()
                .Property(e => e.MaViTri)
                .IsUnicode(false);

            modelBuilder.Entity<ViTri>()
                .Property(e => e.MaPhuThu)
                .IsUnicode(false);

            modelBuilder.Entity<ViTri>()
                .Property(e => e.MaKhuVuc)
                .IsUnicode(false);

            modelBuilder.Entity<ViTri>()
                .HasMany(e => e.PhuTraches)
                .WithRequired(e => e.ViTri)
                .WillCascadeOnDelete(false);
        }
    }
}
