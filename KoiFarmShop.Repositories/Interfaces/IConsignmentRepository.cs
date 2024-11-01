using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Repositories.Interfaces
{
    public interface IConsignmentRepository
    {
        Task<List<Consignment>> GetConsignments();
        Task<bool> AddConsignment(Consignment consignment);
        Task<bool> RemoveConsignmentAsync(Consignment consignment);
        Task<bool> DeleteConsignmentAsync(int consignmentId);
        Task<bool> UpdateConsignment(Consignment consignment);
    }
}
