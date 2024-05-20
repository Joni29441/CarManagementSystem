using AutoMapper;
using CarManagementSystem.DTOs;
using CarManagementSystem.Models;

namespace CarManagementSystem.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Vehicle, VehicleDTO>();
            CreateMap<CreateVehicleDTO, Vehicle>();
            CreateMap<Transaction, TransactionDTO>();
        }
    }
}
