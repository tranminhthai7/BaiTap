﻿using System;
using System.Collections.Generic;

namespace KoiFarmShop.Repositories.Entities;

public partial class Order
{
    public int OrderId { get; set; }

    public DateTime? OrderDate { get; set; }

    public bool? Status { get; set; }

    public bool? Delivered { get; set; }

    public DateTime? DeliveryDate { get; set; }

    public int? CustomerId { get; set; }

    public int? DisCount { get; set; }
}
