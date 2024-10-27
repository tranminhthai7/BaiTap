using System;
using System.Collections.Generic;

namespace KoiFarmShop.Repositories.Entities;

public partial class TbReport
{
    public int ReportId { get; set; }

    public string? ReportName { get; set; }

    public DateTime? GeneratedDate { get; set; }

    public string? ReportData { get; set; }
}
