using Microsoft.AspNetCore.Mvc;

namespace HouseApp.Controllers
{
    public class HousesController : Controller
    {
        //constructor
        public HousesController()
        {
        }

        //indexview
        public IActionResult Index()
        {
            return View();
        }
    }
}
