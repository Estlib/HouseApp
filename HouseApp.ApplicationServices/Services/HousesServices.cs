using HouseApp.Data;
using HouseApp.Core.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HouseApp.Core.Domain;
using HouseApp.Core.Dto;

namespace HouseApp.ApplicationServices.Services
{
    public class HousesServices : IHousesServices
    {
        private readonly HouseAppContext _context;

        public HousesServices (HouseAppContext context)
        {
            _context = context;
        }

        //reads houses
        public async Task<House> GetAsync(Guid id)
        {
            var result = await _context.Houses
                .FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
        //creates a new house object into db as data transfer object
        public async Task<House> Create(HouseDto dto)
        {
            House house = new House();

            house.Id = dto.Id;
            house.SquareMeters = dto.SquareMeters;
            house.HouseColours = dto.HouseColours;
            house.RoofType = dto.RoofType;
            house.TotalRoomCount = dto.TotalRoomCount;
            house.BathroomCount = dto.BathroomCount;
            house.BedroomCount = dto.BedroomCount;
            house.IsForRentOrSale = dto.IsForRentOrSale;
            house.Price = dto.Price;
            house.BuildingAge = dto.BuildingAge;
            house.BuiltAt = dto.BuiltAt;
            house.FloorCount = dto.FloorCount;
            house.FullAddress = dto.FullAddress;
            house.EntryCreatedAt = dto.EntryCreatedAt;
            house.EntryUpdatedAt = dto.EntryUpdatedAt;

            await _context.Houses.AddAsync(house);
            await _context.SaveChangesAsync();
            return house;
        }
        //updates an existing house object in db as data transfer object
        public async Task<House> Update(HouseDto dto)
        {
            var domain = new House()
            {
                Id = dto.Id,
                SquareMeters = dto.SquareMeters,
                HouseColours = dto.HouseColours,
                RoofType = dto.RoofType,
                TotalRoomCount = dto.TotalRoomCount,
                BathroomCount = dto.BathroomCount,
                BedroomCount = dto.BedroomCount,
                IsForRentOrSale = dto.IsForRentOrSale,
                Price = dto.Price,
                BuildingAge = dto.BuildingAge,
                BuiltAt = dto.BuiltAt,
                FloorCount = dto.FloorCount,
                FullAddress = dto.FullAddress,
                EntryCreatedAt = dto.EntryCreatedAt,
                EntryUpdatedAt = DateTime.Now
            };
            _context.Houses.Update(domain);
            await _context.SaveChangesAsync();
            return domain;
        }
    }
}
