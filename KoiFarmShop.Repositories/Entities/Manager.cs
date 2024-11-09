using System;
using System.Collections.Generic;


namespace KoiFarmShop.Repositories.Entities
{
    public partial class Manager
    {
        public int ManagerID { get; set; }
        public string? ManagerName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}