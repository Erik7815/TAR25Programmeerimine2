using Microsoft.AspNetCore.Mvc;
using ShopTAR.Models.Spaceship;


namespace ShopTAR.Controllers
{
    public class SpaceshipController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // teha Data projekti alla ShopTARContext nimega class
        //kui kasutaja vajutab create nuppu, siis see meetod käivitatakse
        //tagatsab kasutajale vormi, kuhu saab sisestada andmeid
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        //kui oled teinud vormi, siis see meetod käivitatakse
        //saadab andmed serverisse, kus need salvestatakse andmebaasi
        [HttpPost]
        public async Task<IActionResult> Create(SpaceshipCreateViewModel vm)
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
