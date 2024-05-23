using AutoMapper;
using CarManagementSystem.DTOs;
using CarManagementSystem.Models;
using CarManagementSystem.Repositories.Interfaces;
using CarManagementSystem.Services.Interfaces;

namespace CarManagementSystem.Services.Implementations
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;

        public VehicleService(IVehicleRepository vehicleRepository, IMapper mapper)
        {
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
        }

        public async Task AddVehicleAsync(CreateVehicleDTO createVehicleDTO)
        {
            await _vehicleRepository.AddVehicleAsync(createVehicleDTO);
        }

        public async Task DeleteVehicleAsync(int id)
        {
            await _vehicleRepository.DeleteVehicleAsync(id);
        }

        public async Task<IEnumerable<VehicleDTO>> GetAllVehiclesAsync()
        {
            var vehicles = await _vehicleRepository.GetAllVehiclesAsync();

            var response = vehicles?.Select(element =>
            {
                VehicleDTO vehicleDto = new VehicleDTO();

                return _mapper.Map(element, vehicleDto);
            });

            return response;
        }

        public async Task<VehicleDTO> GetVehicleByIdAsync(int id)
        {
            var vehicles = await _vehicleRepository.GetVehicleByIdAsync(id);

            VehicleDTO vehicleDto = new VehicleDTO();

            var response = _mapper.Map(vehicles, vehicleDto);

            return response;
        }

        public async Task<IEnumerable<VehicleDTO>> GetVehiclesByBrandAsync(string brand)
        {
            //return await _vehicleRepository.GetVehiclesByBrandAsync(brand);      ASK THE PROFESSOR
            throw new NotImplementedException();

        }

        public Task<IEnumerable<VehicleDTO>> GetVehiclesByModelAsync(string model)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<VehicleDTO>> GetVehiclesByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<VehicleDTO>> GetVehiclesByYearAsync(int year)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateVehicleAsync(CreateVehicleDTO createVehicleDTO, int id)
        {
            await _vehicleRepository.UpdateVehicleAsync(createVehicleDTO, id);
        }
    }
}
