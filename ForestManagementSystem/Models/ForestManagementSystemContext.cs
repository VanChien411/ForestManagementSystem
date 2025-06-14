﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ForestManagementSystem.Models;

public partial class ForestManagementSystemContext : DbContext
{
    public ForestManagementSystemContext(DbContextOptions<ForestManagementSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BaoCao> BaoCao { get; set; }

    public virtual DbSet<BaoCaoThienTai> BaoCaoThienTai { get; set; }

    public virtual DbSet<BienDongRung> BienDongRung { get; set; }

    public virtual DbSet<DiemLuQuet> DiemLuQuet { get; set; }

    public virtual DbSet<DiemTruotLo> DiemTruotLo { get; set; }

    public virtual DbSet<DienTichChuaCoRung> DienTichChuaCoRung { get; set; }

    public virtual DbSet<DieuKienLapDia> DieuKienLapDia { get; set; }

    public virtual DbSet<DonViHanhChinhHuyen> DonViHanhChinhHuyen { get; set; }

    public virtual DbSet<DonViHanhChinhTinh> DonViHanhChinhTinh { get; set; }

    public virtual DbSet<DonViHanhChinhXa> DonViHanhChinhXa { get; set; }

    public virtual DbSet<HuongDanSuDung> HuongDanSuDung { get; set; }

    public virtual DbSet<KhuRung> KhuRung { get; set; }

    public virtual DbSet<LichSuTacDong> LichSuTacDong { get; set; }

    public virtual DbSet<LichSuTruyCap> LichSuTruyCap { get; set; }

    public virtual DbSet<LoDatRung> LoDatRung { get; set; }

    public virtual DbSet<LoaiCay> LoaiCay { get; set; }

    public virtual DbSet<LoaiRung> LoaiRung { get; set; }

    public virtual DbSet<Menu> Menu { get; set; }

    public virtual DbSet<NguoiDung> NguoiDung { get; set; }

    public virtual DbSet<NguoiDung_Nhom> NguoiDung_Nhom { get; set; }

    public virtual DbSet<NguonGocRung> NguonGocRung { get; set; }

    public virtual DbSet<NhomNguoiDung> NhomNguoiDung { get; set; }

    public virtual DbSet<PhanQuyenNguoiDung> PhanQuyenNguoiDung { get; set; }

    public virtual DbSet<PhanQuyenNhom> PhanQuyenNhom { get; set; }

    public virtual DbSet<QuyHoachRung> QuyHoachRung { get; set; }

    public virtual DbSet<TrangThai> TrangThai { get; set; }

    public virtual DbSet<TruLuong> TruLuong { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BaoCao>(entity =>
        {
            entity.HasKey(e => e.MaBaoCao).HasName("PK__BaoCao__25A9188C9D9357FA");

            entity.Property(e => e.LoaiBaoCao)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NgayBaoCao).HasColumnType("datetime");
            entity.Property(e => e.NoiDung).HasColumnType("text");

            entity.HasOne(d => d.MaNguoiDungNavigation).WithMany(p => p.BaoCao)
                .HasForeignKey(d => d.MaNguoiDung)
                .HasConstraintName("FK__BaoCao__MaNguoiD__60A75C0F");
        });

        modelBuilder.Entity<BaoCaoThienTai>(entity =>
        {
            entity.HasKey(e => e.MaBaoCaoThienTai).HasName("PK__BaoCaoTh__9CC685A8FA90A2AB");

            entity.Property(e => e.LoaiThienTai)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NgayCapNhat)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NoiDung).HasColumnType("text");
            entity.Property(e => e.TieuDe)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.MaLuQuetNavigation).WithMany(p => p.BaoCaoThienTai)
                .HasForeignKey(d => d.MaLuQuet)
                .HasConstraintName("FK__BaoCaoThi__MaLuQ__245D67DE");

            entity.HasOne(d => d.MaNguoiTaoNavigation).WithMany(p => p.BaoCaoThienTai)
                .HasForeignKey(d => d.MaNguoiTao)
                .HasConstraintName("FK__BaoCaoThi__MaNgu__2645B050");

            entity.HasOne(d => d.MaTrangThaiNavigation).WithMany(p => p.BaoCaoThienTai)
                .HasForeignKey(d => d.MaTrangThai)
                .HasConstraintName("FK__BaoCaoThi__MaTra__2739D489");

            entity.HasOne(d => d.MaTruotLoNavigation).WithMany(p => p.BaoCaoThienTai)
                .HasForeignKey(d => d.MaTruotLo)
                .HasConstraintName("FK__BaoCaoThi__MaTru__236943A5");

            entity.HasOne(d => d.MaXaNavigation).WithMany(p => p.BaoCaoThienTai)
                .HasForeignKey(d => d.MaXa)
                .HasConstraintName("FK__BaoCaoThie__MaXa__25518C17");
        });

        modelBuilder.Entity<BienDongRung>(entity =>
        {
            entity.HasKey(e => e.MaBienDong).HasName("PK__BienDong__1BB1521F47E15F89");

            entity.Property(e => e.DienTichBienDong).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.LoaiBienDong)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MoTa).HasColumnType("text");
            entity.Property(e => e.NgayBienDong).HasColumnType("datetime");

            entity.HasOne(d => d.MaLoDatNavigation).WithMany(p => p.BienDongRung)
                .HasForeignKey(d => d.MaLoDat)
                .HasConstraintName("FK__BienDongR__MaLoD__75A278F5");
        });

        modelBuilder.Entity<DiemLuQuet>(entity =>
        {
            entity.HasKey(e => e.MaLuQuet).HasName("PK__DiemLuQu__84C9915E515F8D6B");

            entity.Property(e => e.MucDoNghiemTrong)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NgayCapNhat)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NguyenNhan).HasColumnType("text");
            entity.Property(e => e.TenDiem)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ThietHai).HasColumnType("text");
            entity.Property(e => e.ToaDo)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.MaNguoiCapNhatNavigation).WithMany(p => p.DiemLuQuet)
                .HasForeignKey(d => d.MaNguoiCapNhat)
                .HasConstraintName("FK__DiemLuQue__MaNgu__1F98B2C1");

            entity.HasOne(d => d.MaTrangThaiNavigation).WithMany(p => p.DiemLuQuet)
                .HasForeignKey(d => d.MaTrangThai)
                .HasConstraintName("FK__DiemLuQue__MaTra__1EA48E88");

            entity.HasOne(d => d.MaXaNavigation).WithMany(p => p.DiemLuQuet)
                .HasForeignKey(d => d.MaXa)
                .HasConstraintName("FK__DiemLuQuet__MaXa__1DB06A4F");
        });

        modelBuilder.Entity<DiemTruotLo>(entity =>
        {
            entity.HasKey(e => e.MaTruotLo).HasName("PK__DiemTruo__38197F7913B38DCD");

            entity.Property(e => e.MucDoNghiemTrong)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NgayCapNhat)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NguyenNhan).HasColumnType("text");
            entity.Property(e => e.TenDiem)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ThietHai).HasColumnType("text");
            entity.Property(e => e.ToaDo)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.MaNguoiCapNhatNavigation).WithMany(p => p.DiemTruotLo)
                .HasForeignKey(d => d.MaNguoiCapNhat)
                .HasConstraintName("FK__DiemTruot__MaNgu__19DFD96B");

            entity.HasOne(d => d.MaTrangThaiNavigation).WithMany(p => p.DiemTruotLo)
                .HasForeignKey(d => d.MaTrangThai)
                .HasConstraintName("FK__DiemTruot__MaTra__18EBB532");

            entity.HasOne(d => d.MaXaNavigation).WithMany(p => p.DiemTruotLo)
                .HasForeignKey(d => d.MaXa)
                .HasConstraintName("FK__DiemTruotL__MaXa__17F790F9");
        });

        modelBuilder.Entity<DienTichChuaCoRung>(entity =>
        {
            entity.HasKey(e => e.MaChuaCoRung).HasName("PK__DienTich__5B3E3D354C4EBD8D");

            entity.Property(e => e.DienTich).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.KeHoachTrongRung).HasColumnType("text");

            entity.HasOne(d => d.MaLapDiaNavigation).WithMany(p => p.DienTichChuaCoRung)
                .HasForeignKey(d => d.MaLapDia)
                .HasConstraintName("FK__DienTichC__MaLap__797309D9");

            entity.HasOne(d => d.MaLoDatNavigation).WithMany(p => p.DienTichChuaCoRung)
                .HasForeignKey(d => d.MaLoDat)
                .HasConstraintName("FK__DienTichC__MaLoD__787EE5A0");
        });

        modelBuilder.Entity<DieuKienLapDia>(entity =>
        {
            entity.HasKey(e => e.MaLapDia).HasName("PK__DieuKien__3E46A489B3F994DB");

            entity.Property(e => e.DoAm).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.DoDoc).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.KhiHau)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LoaiDat)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MoTa).HasColumnType("text");
        });

        modelBuilder.Entity<DonViHanhChinhHuyen>(entity =>
        {
            entity.HasKey(e => e.MaHuyen).HasName("PK__DonViHan__0384275124B89D96");

            entity.Property(e => e.TenHuyen)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.MaTinhNavigation).WithMany(p => p.DonViHanhChinhHuyen)
                .HasForeignKey(d => d.MaTinh)
                .HasConstraintName("FK__DonViHanh__MaTin__3B75D760");
        });

        modelBuilder.Entity<DonViHanhChinhTinh>(entity =>
        {
            entity.HasKey(e => e.MaTinh).HasName("PK__DonViHan__4CC544803254DCC7");

            entity.Property(e => e.TenTinh)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DonViHanhChinhXa>(entity =>
        {
            entity.HasKey(e => e.MaXa).HasName("PK__DonViHan__272520C93BE81C0B");

            entity.Property(e => e.TenXa)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.MaHuyenNavigation).WithMany(p => p.DonViHanhChinhXa)
                .HasForeignKey(d => d.MaHuyen)
                .HasConstraintName("FK__DonViHanh__MaHuy__3E52440B");
        });

        modelBuilder.Entity<HuongDanSuDung>(entity =>
        {
            entity.HasKey(e => e.MaHuongDan).HasName("PK__HuongDan__3D465C4356BB1F5F");

            entity.Property(e => e.NgayCapNhat).HasColumnType("datetime");
            entity.Property(e => e.NoiDung).HasColumnType("text");
            entity.Property(e => e.TieuDe)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<KhuRung>(entity =>
        {
            entity.HasKey(e => e.MaKhuRung).HasName("PK__KhuRung__9A8EDB10979671F9");

            entity.Property(e => e.MoTa).HasColumnType("text");
            entity.Property(e => e.TenKhuRung)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.MaLapDiaNavigation).WithMany(p => p.KhuRung)
                .HasForeignKey(d => d.MaLapDia)
                .HasConstraintName("FK__KhuRung__MaLapDi__7E37BEF6");

            entity.HasOne(d => d.MaLoDatNavigation).WithMany(p => p.KhuRung)
                .HasForeignKey(d => d.MaLoDat)
                .HasConstraintName("FK__KhuRung__MaLoDat__7F2BE32F");

            entity.HasOne(d => d.MaLoaiRungNavigation).WithMany(p => p.KhuRung)
                .HasForeignKey(d => d.MaLoaiRung)
                .HasConstraintName("FK__KhuRung__MaLoaiR__7C4F7684");

            entity.HasOne(d => d.MaNguoiSoHuuNavigation).WithMany(p => p.KhuRung)
                .HasForeignKey(d => d.MaNguoiSoHuu)
                .HasConstraintName("FK__KhuRung__MaNguoi__00200768");

            entity.HasOne(d => d.MaNguonGocNavigation).WithMany(p => p.KhuRung)
                .HasForeignKey(d => d.MaNguonGoc)
                .HasConstraintName("FK__KhuRung__MaNguon__7D439ABD");
        });

        modelBuilder.Entity<LichSuTacDong>(entity =>
        {
            entity.HasKey(e => e.MaTacDong).HasName("PK__LichSuTa__63E49C55048B8D2C");

            entity.Property(e => e.HanhDong)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NoiDung).HasColumnType("text");
            entity.Property(e => e.ThoiGianTacDong)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.MaNguoiDungNavigation).WithMany(p => p.LichSuTacDong)
                .HasForeignKey(d => d.MaNguoiDung)
                .HasConstraintName("FK__LichSuTac__MaNgu__5DCAEF64");
        });

        modelBuilder.Entity<LichSuTruyCap>(entity =>
        {
            entity.HasKey(e => e.MaLichSu).HasName("PK__LichSuTr__C443222A6E1EFAF8");

            entity.Property(e => e.HanhDong)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IPAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ThoiGianTruyCap)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.MaNguoiDungNavigation).WithMany(p => p.LichSuTruyCap)
                .HasForeignKey(d => d.MaNguoiDung)
                .HasConstraintName("FK__LichSuTru__MaNgu__59FA5E80");
        });

        modelBuilder.Entity<LoDatRung>(entity =>
        {
            entity.HasKey(e => e.MaLoDat).HasName("PK__LoDatRun__C0D91E7FBB2CD49E");

            entity.Property(e => e.ChuSoHuu)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DienTich).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TenLoDat)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ToaDo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TrangThai)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.MaLapDiaNavigation).WithMany(p => p.LoDatRung)
                .HasForeignKey(d => d.MaLapDia)
                .HasConstraintName("FK__LoDatRung__MaLap__6EF57B66");

            entity.HasOne(d => d.MaLoaiRungNavigation).WithMany(p => p.LoDatRung)
                .HasForeignKey(d => d.MaLoaiRung)
                .HasConstraintName("FK__LoDatRung__MaLoa__6D0D32F4");

            entity.HasOne(d => d.MaNguonGocNavigation).WithMany(p => p.LoDatRung)
                .HasForeignKey(d => d.MaNguonGoc)
                .HasConstraintName("FK__LoDatRung__MaNgu__6E01572D");
        });

        modelBuilder.Entity<LoaiCay>(entity =>
        {
            entity.HasKey(e => e.MaLoaiCay).HasName("PK__LoaiCay__91531ADC19214580");

            entity.Property(e => e.MoTa).HasColumnType("text");
            entity.Property(e => e.TenKhoaHoc)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TenLoaiCay)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<LoaiRung>(entity =>
        {
            entity.HasKey(e => e.MaLoaiRung).HasName("PK__LoaiRung__3E97745EC762DA13");

            entity.Property(e => e.MoTa).HasColumnType("text");
            entity.Property(e => e.TenLoaiRung)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.MaMenu).HasName("PK__Menu__0EBABE42D1785DA4");

            entity.Property(e => e.DuongDan)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.TenMenu)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.MaTrangThaiNavigation).WithMany(p => p.Menu)
                .HasForeignKey(d => d.MaTrangThai)
                .HasConstraintName("FK__Menu__MaTrangTha__5629CD9C");
        });

        modelBuilder.Entity<NguoiDung>(entity =>
        {
            entity.HasKey(e => e.MaNguoiDung).HasName("PK__NguoiDun__C539D7621F680789");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.MatKhau)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TaiKhoan)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TenNguoiDung)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.MaTrangThaiNavigation).WithMany(p => p.NguoiDung)
                .HasForeignKey(d => d.MaTrangThai)
                .HasConstraintName("FK__NguoiDung__MaTra__4316F928");

            entity.HasOne(d => d.MaXaNavigation).WithMany(p => p.NguoiDung)
                .HasForeignKey(d => d.MaXa)
                .HasConstraintName("FK__NguoiDung__MaXa__4222D4EF");
        });

        modelBuilder.Entity<NguoiDung_Nhom>(entity =>
        {
            entity.HasKey(e => new { e.MaNguoiDung, e.MaNhom }).HasName("PK__NguoiDun__070D2E7ED979064B");

            entity.Property(e => e.NgayThamGia)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.MaNguoiDungNavigation).WithMany(p => p.NguoiDung_Nhom)
                .HasForeignKey(d => d.MaNguoiDung)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__NguoiDung__MaNgu__49C3F6B7");

            entity.HasOne(d => d.MaNhomNavigation).WithMany(p => p.NguoiDung_Nhom)
                .HasForeignKey(d => d.MaNhom)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__NguoiDung__MaNho__4AB81AF0");

            entity.HasOne(d => d.MaTrangThaiNavigation).WithMany(p => p.NguoiDung_Nhom)
                .HasForeignKey(d => d.MaTrangThai)
                .HasConstraintName("FK__NguoiDung__MaTra__4BAC3F29");
        });

        modelBuilder.Entity<NguonGocRung>(entity =>
        {
            entity.HasKey(e => e.MaNguonGoc).HasName("PK__NguonGoc__BD3EA836273936C8");

            entity.Property(e => e.TenNguonGoc)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<NhomNguoiDung>(entity =>
        {
            entity.HasKey(e => e.MaNhom).HasName("PK__NhomNguo__234F91CD62248B01");

            entity.Property(e => e.MoTa).HasColumnType("text");
            entity.Property(e => e.TenNhom)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.MaTrangThaiNavigation).WithMany(p => p.NhomNguoiDung)
                .HasForeignKey(d => d.MaTrangThai)
                .HasConstraintName("FK__NhomNguoi__MaTra__45F365D3");
        });

        modelBuilder.Entity<PhanQuyenNguoiDung>(entity =>
        {
            entity.HasKey(e => e.MaPhanQuyenNguoiDung).HasName("PK__PhanQuye__31EFE5672F21897F");

            entity.Property(e => e.MaQuyen)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.MaNguoiDungNavigation).WithMany(p => p.PhanQuyenNguoiDung)
                .HasForeignKey(d => d.MaNguoiDung)
                .HasConstraintName("FK__PhanQuyen__MaNgu__52593CB8");

            entity.HasOne(d => d.MaTrangThaiNavigation).WithMany(p => p.PhanQuyenNguoiDung)
                .HasForeignKey(d => d.MaTrangThai)
                .HasConstraintName("FK__PhanQuyen__MaTra__534D60F1");
        });

        modelBuilder.Entity<PhanQuyenNhom>(entity =>
        {
            entity.HasKey(e => e.MaPhanQuyenNhom).HasName("PK__PhanQuye__18BA14B695A9030D");

            entity.Property(e => e.MaQuyen)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.MaNhomNavigation).WithMany(p => p.PhanQuyenNhom)
                .HasForeignKey(d => d.MaNhom)
                .HasConstraintName("FK__PhanQuyen__MaNho__4E88ABD4");

            entity.HasOne(d => d.MaTrangThaiNavigation).WithMany(p => p.PhanQuyenNhom)
                .HasForeignKey(d => d.MaTrangThai)
                .HasConstraintName("FK__PhanQuyen__MaTra__4F7CD00D");
        });

        modelBuilder.Entity<QuyHoachRung>(entity =>
        {
            entity.HasKey(e => e.MaQuyHoach).HasName("PK__QuyHoach__FC471482D9DAF75A");

            entity.Property(e => e.DuongDanBanDo)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.KyQuyHoach)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NgayBatDau).HasColumnType("datetime");
            entity.Property(e => e.NgayKetThuc).HasColumnType("datetime");
            entity.Property(e => e.NoiDungBaoCao).HasColumnType("text");

            entity.HasOne(d => d.MaKhuRungNavigation).WithMany(p => p.QuyHoachRung)
                .HasForeignKey(d => d.MaKhuRung)
                .HasConstraintName("FK__QuyHoachR__MaKhu__02FC7413");

            entity.HasOne(d => d.MaNguoiDungNavigation).WithMany(p => p.QuyHoachRung)
                .HasForeignKey(d => d.MaNguoiDung)
                .HasConstraintName("FK__QuyHoachR__MaNgu__03F0984C");

            entity.HasOne(d => d.MaTrangThaiNavigation).WithMany(p => p.QuyHoachRung)
                .HasForeignKey(d => d.MaTrangThai)
                .HasConstraintName("FK__QuyHoachR__MaTra__04E4BC85");
        });

        modelBuilder.Entity<TrangThai>(entity =>
        {
            entity.HasKey(e => e.MaTrangThai).HasName("PK__TrangTha__AADE41381C952C3F");

            entity.Property(e => e.MoTa).HasColumnType("text");
            entity.Property(e => e.TenTrangThai)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TruLuong>(entity =>
        {
            entity.HasKey(e => e.MaTruLuong).HasName("PK__TruLuong__3309B7A0C065142D");

            entity.Property(e => e.NgayKiemKe).HasColumnType("datetime");
            entity.Property(e => e.TheTichGo).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.MaLoDatNavigation).WithMany(p => p.TruLuong)
                .HasForeignKey(d => d.MaLoDat)
                .HasConstraintName("FK__TruLuong__MaLoDa__71D1E811");

            entity.HasOne(d => d.MaLoaiCayNavigation).WithMany(p => p.TruLuong)
                .HasForeignKey(d => d.MaLoaiCay)
                .HasConstraintName("FK__TruLuong__MaLoai__72C60C4A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}