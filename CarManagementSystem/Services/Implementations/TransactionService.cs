using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CarManagementSystem.DTOs;
using CarManagementSystem.Models;
using CarManagementSystem.Repositories.Interfaces;
using CarManagementSystem.Services.Interfaces;

namespace CarManagementSystem.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;

        public TransactionService(ITransactionRepository transactionRepository, IVehicleRepository vehicleRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TransactionDTO>> GetAllTransactionsAsync()
        {
            var transactions = await _transactionRepository.GetAllTransactionsAsync();
            return _mapper.Map<IEnumerable<TransactionDTO>>(transactions);
        }

        public async Task<TransactionDTO> GetTransactionByIdAsync(int id)
        {
            var transaction = await _transactionRepository.GetTransactionByIdAsync(id);
            return _mapper.Map<TransactionDTO>(transaction);
        }

        public async Task AddTransactionAsync(CreateTransactionDTO createTransactionDTO)
        {
            var vehicle = await _vehicleRepository.GetVehicleByIdAsync(createTransactionDTO.VehicleId);
            if (vehicle == null || vehicle.Status == VehicleStatus.Sold)
            {
                throw new Exception("Vehicle not available");
            }

            var transaction = _mapper.Map<Transaction>(createTransactionDTO);
            transaction.TransactionDate = DateTime.UtcNow;

            await _transactionRepository.AddTransactionAsync(transaction);

            // Update the status of the vehicle to Sold
            vehicle.Status = VehicleStatus.Sold;
            await _vehicleRepository.UpdateVehicleAsync(vehicle, vehicle.Id);
        }
    }
}
