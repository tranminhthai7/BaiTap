﻿using System;
using System.Collections.Generic;

namespace KoiFarmShop.Repositories.Entities;

public partial class Promotion
{
    public int PromotionId { get; set; }

    public string? PromotionName { get; set; }

    public string? Description { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public double? DiscountPercentage { get; set; }
}
