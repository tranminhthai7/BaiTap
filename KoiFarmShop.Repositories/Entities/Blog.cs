using System;
using System.Collections.Generic;

namespace KoiFarmShop.Repositories.Entities;

public partial class Blog
{
    public int BlogId { get; set; }

    public string? Title { get; set; }

    public string? Content { get; set; }

    public DateTime? PublishedDate { get; set; }

    public string? Author { get; set; }
}
