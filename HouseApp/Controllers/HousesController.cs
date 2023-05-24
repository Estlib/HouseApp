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
    }
}
