using System;
using System.Collections.Generic;

namespace KoiFarmShop.Repositories.Entities;

public partial class Koi
{
    public int? KoiId { get; set; }

    public string? Name { get; set; }

    public string? Breed { get; set; }

    public string? Gender { get; set; }

    public int? Age { get; set; }

    public decimal? Size { get; set; }

    public string? Origin { get; set; }

    public string Character { get; set; } = null!;

    public int? FeedlingAmount { get; set; }

    public decimal? ScreenRate { get; set; }

    public string? HealthStatus { get; set; }
}
