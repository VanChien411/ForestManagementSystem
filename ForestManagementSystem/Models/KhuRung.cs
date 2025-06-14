﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace ForestManagementSystem.Models;

public partial class KhuRung
{
    public int MaKhuRung { get; set; }

    public string TenKhuRung { get; set; } = null!;

    public string? MoTa { get; set; }

    public int? MaLoaiRung { get; set; }

    public int? MaNguonGoc { get; set; }

    public int? MaLapDia { get; set; }

    public int? MaLoDat { get; set; }

    public int? MaNguoiSoHuu { get; set; }

    public virtual DieuKienLapDia? MaLapDiaNavigation { get; set; }

    public virtual LoDatRung? MaLoDatNavigation { get; set; }

    public virtual LoaiRung? MaLoaiRungNavigation { get; set; }

    public virtual NguoiDung? MaNguoiSoHuuNavigation { get; set; }

    public virtual NguonGocRung? MaNguonGocNavigation { get; set; }

    public virtual ICollection<QuyHoachRung> QuyHoachRung { get; set; } = new List<QuyHoachRung>();
}