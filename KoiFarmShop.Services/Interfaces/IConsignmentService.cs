using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Services.Interfaces
{
    public interface IConsignmentService
    {
        Task<int> AddConsignmentAsync(IConsignment consignment);
        Task<int> UpdateConsignmentAsync(IConsignment consignment);
        Task<int> DeleteConsignmentAsync(int consignmentId);
        Task<IEnumerable<IConsignment>> GetAllConsignmentsAsync();
    }
}
