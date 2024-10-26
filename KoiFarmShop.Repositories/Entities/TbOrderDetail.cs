using System;
using System.Collections.Generic;

namespace KoiFarmShop.Repositories.Entities;

public partial class TbOrderDetail
{
    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public decimal? Price { get; set; }
}
