using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;
using KoiFarmShop.Services.Interfaces;

namespace KoiFarmShop.Services.Services
{
    public class ConsignmentService : IConsignmentService
    {
        private readonly IConsignmentRepository _consignmentRepository;

        public ConsignmentService(IConsignmentRepository consignmentRepository)
        {
            _consignmentRepository = consignmentRepository;
        }

        public Task<List<TbConsignment>> GetConsignmentsAsync()
        {
            return _consignmentRepository.GetConsignmentsAsync();
        }

        public Task<int> AddConsignmentAsync(TbConsignment consignment)
        {
            return _consignmentRepository.AddConsignmentAsync(consignment);
        }

        public Task<int> RemoveConsignmentAsync(int consignmentId)
        {
            return _consignmentRepository.RemoveConsignmentAsync(consignmentId);
        }

        public Task<bool> DeleteConsignmentAsync(int consignmentId)
        {
            return _consignmentRepository.DeleteConsignmentAsync(consignmentId);
        }

        public Task<int> UpdateConsignmentAsync(TbConsignment consignment)
        {
            return _consignmentRepository.UpdateConsignmentAsync(consignment);
        }
    }
}