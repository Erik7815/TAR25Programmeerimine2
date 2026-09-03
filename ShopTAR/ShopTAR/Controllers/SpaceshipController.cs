using Microsoft.AspNetCore.Mvc;

namespace ShopTAR.Controllers
{
    public class SpaceshipController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // teha Data projekti alla ShopTARContext nimega class
    }
}
