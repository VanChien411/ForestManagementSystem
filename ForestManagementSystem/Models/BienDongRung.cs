﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace ForestManagementSystem.Models;

public partial class BienDongRung
{
    public int MaBienDong { get; set; }

    public int? MaLoDat { get; set; }

    public DateTime NgayBienDong { get; set; }

    public string LoaiBienDong { get; set; } = null!;

    public decimal? DienTichBienDong { get; set; }

    public string? MoTa { get; set; }

    public virtual LoDatRung? MaLoDatNavigation { get; set; }
}