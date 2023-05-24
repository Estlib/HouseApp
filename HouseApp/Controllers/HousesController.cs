using HouseApp.Core.Dto;
using HouseApp.Core.ServiceInterface;
using HouseApp.Data;
using HouseApp.Models.House;
using Microsoft.AspNetCore.Mvc;

namespace HouseApp.Controllers
{
    public class HousesController : Controller
    {
        private readonly HouseAppContext _context;

        private readonly IHousesServices _housesServices;
        //constructor
        public HousesController(HouseAppContext context, IHousesServices housesServices)
        {
            _context = context;
            _housesServices = housesServices;
        }

        //indexview
        [HttpGet]
        public IActionResult Index()
        {
            var result = _context.Houses
                .OrderBy(x => x.EntryCreatedAt)
                .Select(x => new HouseIndexViewModel
                {
                    Id = x.Id,
                    BathroomCount = x.BathroomCount,
                    BedroomCount = x.BedroomCount,
                    IsForRentOrSale = x.IsForRentOrSale,
                    Price = x.Price,
                    BuildingAge = x.BuildingAge,
                }
                );
            return View(result);
        }
        //gets the view for create
        [HttpGet]
        public IActionResult Create() 
        {
            HouseCreateUpdateViewModel house = new HouseCreateUpdateViewModel();
            return View("CreateUpdate", house);
        }

        //posts info from the create form
        [HttpPost]
        public async Task<IActionResult> Create(HouseCreateUpdateViewModel viewmodel)
        {
            var dto = new HouseDto()
            {
                Id = viewmodel.Id,
                SquareMeters = viewmodel.SquareMeters,
                HouseColours = viewmodel.HouseColours,
                RoofType = viewmodel.RoofType,
                TotalRoomCount = viewmodel.TotalRoomCount,
                BathroomCount = viewmodel.BathroomCount,
                BedroomCount = viewmodel.BedroomCount,
                IsForRentOrSale = viewmodel.IsForRentOrSale,
                Price = viewmodel.Price,
                BuildingAge = viewmodel.BuildingAge,
                BuiltAt = viewmodel.BuiltAt,
                FloorCount = viewmodel.FloorCount,
                FullAddress = viewmodel.FullAddress,
                //db - creation is called, modification is called
                EntryCreatedAt = viewmodel.EntryCreatedAt,
                EntryUpdatedAt = viewmodel.EntryUpdatedAt,
            };
            var result = await _housesServices.Create(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index), viewmodel);
        }
    }
}
