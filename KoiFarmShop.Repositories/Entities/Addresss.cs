using System;
using System.Collections.Generic;

namespace KoiFarmShop.Repositories.Entities;

public partial class Addresss
{
	public int AddressId { get; set; }

	public int? UserID { get; set; }

	public string? Company { get; set; }

	public string? Address { get; set; }

	public string? Zip { get; set; }

	public bool? IsDefault { get; set; }
	public int? CreatedBy { get; set; }

	public DateTime? CreatedDate { get; set; }

	public int? UpdateBy { get; set; }

	public DateTime? UpdateDate { get; set; }
	public int UserId { get; set; } // Thêm UserId để liên kết với User
	public User User { get; set; }   // Quan hệ với bảng User

}
