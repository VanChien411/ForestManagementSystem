﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace ForestManagementSystem.Models;

public partial class DonViHanhChinhXa
{
    public int MaXa { get; set; }

    public string TenXa { get; set; } = null!;

    public int? MaHuyen { get; set; }

    public virtual ICollection<BaoCaoThienTai> BaoCaoThienTai { get; set; } = new List<BaoCaoThienTai>();

    public virtual ICollection<DiemLuQuet> DiemLuQuet { get; set; } = new List<DiemLuQuet>();

    public virtual ICollection<DiemTruotLo> DiemTruotLo { get; set; } = new List<DiemTruotLo>();

    public virtual DonViHanhChinhHuyen? MaHuyenNavigation { get; set; }

    public virtual ICollection<NguoiDung> NguoiDung { get; set; } = new List<NguoiDung>();
}