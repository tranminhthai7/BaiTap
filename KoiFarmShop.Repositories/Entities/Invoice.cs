using System;
using System.Collections.Generic;

namespace KoiFarmShop.Repositories.Entities;

public partial class Invoice
{
    public int InvoiceId { get; set; }

    public bool? Status { get; set; }

    public int? SupplierId { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdateBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? DeletedBy { get; set; }

    public DateTime? DeleteDate { get; set; }
}
