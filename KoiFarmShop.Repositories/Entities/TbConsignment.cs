using System;
using System.Collections.Generic;

namespace KoiFarmShop.Repositories.Entities;

public partial class TbConsignment
{
    public int ConsignmentId { get; set; }

    public int? CustomerId { get; set; }

    public int? KoiId { get; set; }

    public DateTime? ConsignmentDate { get; set; }

    public string Status { get; set; } = null!;
}
