using System;
using System.Collections.Generic;

namespace KoiFarmShop.Repositories.Entities;

public partial class User
{
    public int Id { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public string? Image { get; set; }

    public bool? Status { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? UpdateBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public string? Role { get; set; }
}
