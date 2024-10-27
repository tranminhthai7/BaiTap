using System;
using System.Collections.Generic;

namespace KoiFarmShop.Repositories.Entities;

public partial class TbRating
{
    public int RatingId { get; set; }

    public int? CustomerId { get; set; }

    public int? KoiId { get; set; }

    public int? RatingValue { get; set; }

    public string? Feedback { get; set; }

    public DateTime? RatingDate { get; set; }
}
