using System;
using System.Collections.Generic;

namespace KoiFarmShop.Repositories.Entities;

public partial class TbProductComment
{
    public int CommentId { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Detail { get; set; }

    public bool? Status { get; set; }

    public int? ProductId { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdateBy { get; set; }

    public DateTime? UpdateDate { get; set; }
}
