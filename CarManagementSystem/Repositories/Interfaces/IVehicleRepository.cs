using CarManagementSystem.Models;

namespace CarManagementSystem.Repositories.Interfaces
{
    public interface IVehicleRepository
    {
        Task<IEnumerable<Vehicle>> GetAllVehiclesAsync();
        Task<Vehicle> GetVehicleByIdAsync(int id);
        Task<Vehicle> AddVehicleAsync(Vehicle vehicle);
        Task<Vehicle> UpdateVehicleAsync(Vehicle vehicle);
        Task DeleteVehicleAsync(int id);
        Task<IEnumerable<Vehicle>> GetVehiclesByNameAsync(string name);
        Task<IEnumerable<Vehicle>> GetVehiclesByModelAsync(string model);
        Task<IEnumerable<Vehicle>> GetVehiclesByBrandAsync(string brand);
        Task<IEnumerable<Vehicle>> GetVehiclesByYearAsync(int year);
    }
}
