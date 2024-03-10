﻿using DAL.Models.Flags;

namespace DAL.Models;

internal class Country : BaseEntity
{
    public string Name { get; set; } = null!;
    public string CapitalName { get; set; } = null!;
    public string? Description { get; set; }

    public Flag Flag { get; set; } = null!;
}
