using Microsoft.AspNetCore.Mvc;
using ShopTARpe25.Models.Spaceship;
using ShopTARpe25.Core.Dto;
using AspNetCoreGeneratedDocument;
using ShopTARpe25.Core.ServiceInterface;

namespace ShopTARpe25.Controllers
{
    public class SpaceshipController : Controller
    {
        private readonly ISpaceshipServices _spaceshipService;
        public SpaceshipController(ISpaceshipServices spaceshipService)
        {
            _spaceshipService = spaceshipService;
        }
            
        public IActionResult Index()
        {
            return View();
        }

        //kui kasutaja klikib "Create" nuppu, siis see meetod käivitatakse
        //tagastab kasutajale vormi, kuhu saab sisestada andmed
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
            var dto = new SpaceshipDto
            {
                Name = vm.Name,
                Classification = vm.Classification,
                BuiltDate = vm.BuiltDate,
                Crew = vm.Crew,
                EnginePower = vm.EnginePower
            };
            var result = await _Spaceship_Create.Create(dto);
            return RedirectToAction(nameof(Index));
        }
        //luua vaheinstants mis sisaldab andmeid mis on saadud vormist
        //    need andmed tuleb edasi anda dto-ssse mis on mõeldud andmebaasi salvestamiseks

    } 
}
