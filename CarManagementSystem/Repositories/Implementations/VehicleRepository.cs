﻿using CarManagementSystem.Data;
using CarManagementSystem.DTOs;
using CarManagementSystem.Models;
using CarManagementSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace CarManagementSystem.Repositories.Implementations
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly ApplicationDbContext _context;

        public VehicleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddVehicleAsync(CreateVehicleDTO vehicleDto)
        {
            Vehicle requestBody = new Vehicle();

            requestBody.Brand = vehicleDto.Brand;
            requestBody.Model = vehicleDto.Model;
            requestBody.Year = vehicleDto.Year;
            requestBody.Price = vehicleDto.Price;
            

            _context.Vehicles.Add(requestBody);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteVehicleAsync(int id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);

            if (vehicle != null)
            {
                _context.Vehicles.Remove(vehicle);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Vehicle>> GetAllVehiclesAsync()
        {
            return await _context.Vehicles.ToListAsync();
        }

        public async Task<Vehicle> GetVehicleByIdAsync(int id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);

            return vehicle ?? new Vehicle();
        }

        public async Task<IEnumerable<Vehicle>> GetVehiclesByBrandAsync(string brand)
        {
            return await _context.Vehicles
                .Where(a => a.Brand == brand)
                .ToListAsync();
        }

        public async Task<IEnumerable<Vehicle>> GetVehiclesByModelAsync(string model)
        {
            return await _context.Vehicles
                .Where(a => a.Model == model)
                .ToListAsync();
        }


        public async Task<IEnumerable<Vehicle>> GetVehiclesByYearAsync(int year)
        {
            return await _context.Vehicles
                .Where(a => a.Year == year)
                .ToListAsync();
        }

        public async Task UpdateVehicleAsync(CreateVehicleDTO vehicleDto, int id)
        {
            var vehicles = await _context.Vehicles.FindAsync(id);

            if (vehicles != null)
            {
                vehicles.Brand = vehicleDto.Brand;
                vehicles.Model = vehicleDto.Model;
                vehicles.Year = vehicleDto.Year;
                vehicles.Price = vehicleDto.Price;

                _context.Entry(vehicles).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }
    }
}
