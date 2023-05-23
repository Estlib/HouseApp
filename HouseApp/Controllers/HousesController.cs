using Microsoft.AspNetCore.Mvc;

namespace HouseApp.Controllers
{
    public class HousesController : Controller
    {
        //constructor
        public HousesController(HouseApp context, IHousesServices housesServices)
        {
            _context = context;
            _housesServices = housesServices;
        }

        //indexview
        public IActionResult Index()
        {
            var result = _context.Houses
            return View(result);
        }
    }
}
