using HouseApp.Core.Domain;
using HouseApp.Core.Dto;
using HouseApp.Core.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HouseApp.HouseTest
{
    public class Test : TestBase
    {
        [Fact]
        public async Task Create_ValidHouse_ShouldBeCreated()
        {
            DateTime testBeginTime = DateTime.Now;
            HouseDto houseDto = CreateValidHouseObjectForTesting();
            var result = await Svc<IHousesServices>().Create(houseDto);

            Assert.NotNull(result); //so that the response actually contains something

            //checks for userfacing variables that the user can set
            AssertUserFacingVariables(houseDto, result);


            //checks if db variables are given to object by the service
            Assert.NotNull(houseDto.Id);
            Assert.True(testBeginTime < result.EntryCreatedAt);
            Assert.True(testBeginTime < result.EntryCreatedAt);

        }
        [Fact]
        public async Task GetAsync_InvalidId_ShouldBeFound()
        {
            Assert.Null(await Svc<IHousesServices>().GetAsync(Guid.NewGuid()));
        }
        [Fact]
        public async Task GetAsync_ValidId_ShouldBeFound()
        {
            HouseDto houseDto = CreateValidHouseObjectForTesting();
            var createdHouse = await Svc<IHousesServices>().Create(houseDto);
            var result = await Svc<IHousesServices>().GetAsync((Guid)createdHouse.Id);
            Assert.Equal(createdHouse, result);
        }
        [Fact]
        public async Task Delete_IsFoundById_ShouldBeDeleted()
        {
            HouseDto houseDto = CreateValidHouseObjectForTesting();
            var createdHouse = await Svc<IHousesServices>().Create(houseDto);
            var result = await Svc<IHousesServices>().Delete((Guid)createdHouse.Id);
            Assert.Equal(createdHouse, result);
        }
        [Fact]
        public async Task Update_ValidHouse_ShouldBeUpdated()
        {
            DateTime testBeginTime = DateTime.Now;
            HouseDto houseDto = CreateValidHouseObjectForTesting();
            var createdHouse = await Svc<IHousesServices>().Create(houseDto);
            HouseDto updatedHouseDto = UpdateValidHouseObjectForTesting(createdHouse);
            var result = await Svc<IHousesServices>().Update(updatedHouseDto);
            AssertUserFacingVariables(updatedHouseDto, result); 
            Assert.Equal(updatedHouseDto.EntryCreatedAt, result.EntryCreatedAt);
            Assert.True(updatedHouseDto.EntryUpdatedAt < result.EntryUpdatedAt);
            /*Assert.NotEqual(createdHouse, result);
            Assert.Equal(updatedHouseDto, result);*/
        }
        private HouseDto CreateValidHouseObjectForTesting()
        {
            HouseDto houseDto = new HouseDto()
            {
                SquareMeters = 69,
                RoofType = "ceramic tile",
                TotalRoomCount = 10,
                BathroomCount = 3,
                BedroomCount = 2,
                IsForRentOrSale = true,
                Price = 100000,
                BuildingAge = 10,
                BuiltAt = DateTime.Now,
                FloorCount = 1,
                FullAddress = "Persevahe tee 16, 11111, Tallinn, Estonia",
                
            };
            
            return houseDto;
        }
        private HouseDto UpdateValidHouseObjectForTesting(House createdHouse)
        {
            HouseDto houseDto = new HouseDto()
            {
                SquareMeters = 420,
                RoofType = "Reed",
                TotalRoomCount = 100,
                BathroomCount = 30,
                BedroomCount = 20,
                IsForRentOrSale = false,
                Price = 1,
                BuildingAge = 1000,
                BuiltAt = DateTime.Now,
                FloorCount = 100,
                FullAddress = "Persevahe tee 16, 11111, Tallinn, Estonia",
            };

            return houseDto;
        }
        private void AssertUserFacingVariables(HouseDto houseDtoExpected, House houseDtoReturned)
        {
            Assert.Equal(houseDtoExpected.SquareMeters, houseDtoReturned.SquareMeters);
            Assert.Equal(houseDtoExpected.RoofType, houseDtoReturned.RoofType);
            Assert.Equal(houseDtoExpected.TotalRoomCount, houseDtoReturned.TotalRoomCount);
            Assert.Equal(houseDtoExpected.BathroomCount, houseDtoReturned.BathroomCount);
            Assert.Equal(houseDtoExpected.BedroomCount, houseDtoReturned.BedroomCount);
            Assert.Equal(houseDtoExpected.IsForRentOrSale, houseDtoReturned.IsForRentOrSale);
            Assert.Equal(houseDtoExpected.Price, houseDtoReturned.Price);
            Assert.Equal(houseDtoExpected.BuildingAge, houseDtoReturned.BuildingAge);
            Assert.Equal(houseDtoExpected.BuiltAt, houseDtoReturned.BuiltAt);
            Assert.Equal(houseDtoExpected.FloorCount, houseDtoReturned.FloorCount);
            Assert.Equal(houseDtoExpected.FullAddress, houseDtoReturned.FullAddress);
        }
    }
}
