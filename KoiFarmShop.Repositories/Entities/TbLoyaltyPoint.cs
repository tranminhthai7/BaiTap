using System;
using System.Collections.Generic;

namespace KoiFarmShop.Repositories.Entities;

public partial class TbLoyaltyPoint
{
    public int LoyaltyPointId { get; set; }

    public int? CustomerId { get; set; }

    public int? Points { get; set; }

    public DateTime? EarnedDate { get; set; }
}
