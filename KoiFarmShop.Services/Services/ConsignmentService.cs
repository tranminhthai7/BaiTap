using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;
using KoiFarmShop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarmShop.Services.Services
{
    public class ConsignmentService : IConsignmentService
    {
        private readonly IConsignmentRepository _consignmentRepository;

        public ConsignmentService(IConsignmentRepository consignmentRepository)
        {
            _consignmentRepository = consignmentRepository;
        }

        public Task<bool> AddConsignment(Consignment consignment)
        {
            return _consignmentRepository.AddConsignment(consignment);
        }

        public Task<bool> DeleteConsignmentAsync(int consignmentId)
        {
            return _consignmentRepository.DeleteConsignmentAsync(consignmentId);
        }

        public async Task<List<Consignment>> GetConsignments()
        {
            return await _consignmentRepository.GetConsignments();
        }

        public Task<bool> UpdateConsignment(Consignment consignment)
        {
            return _consignmentRepository.UpdateConsignment(consignment);
        }

        public Task<bool> RemoveConsignmentAsync(Consignment consignment)
        {
            return _consignmentRepository.RemoveConsignmentAsync(consignment);
        }
    }
}
