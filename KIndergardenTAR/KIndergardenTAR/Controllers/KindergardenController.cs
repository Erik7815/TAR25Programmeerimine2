using Kindergarden.Core.Dto;
using Kindergarden.Core.ServiceInterface;
using Kindergarden.Data;
using Kindergarden.Models.Kindergarden;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kindergarden.Controllers
{
    public class KindergardenController : Controller
    {
        private readonly IKindergardenServices _kindergardenServices;
        private readonly KindergardenContext _context;

        public KindergardenController
            (
            IKindergardenServices KindergardenServices,
            KindergardenContext context
            )
        {
            _kindergardenServices = KindergardenServices;
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var result = _context.Kindergardens
            .Select(x => new KindergardenIndexViewModel
            {
                Id = x.Id,
                GroupName = x.GroupName,
                ChildrenCount = x.ChildrenCount,
                KindergartenName = x.KindergartenName,
                TeacherName = x.TeacherName,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt

            });



            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(KindergardenCreateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var dto = new KindergardenDto
                {
                    Id = vm.Id,
                    GroupName = vm.GroupName,
                    ChildrenCount = vm.ChildrenCount,
                    KindergartenName = vm.KindergartenName,
                    TeacherName = vm.TeacherName,
                    CreatedAt = vm.CreatedAt,
                    UpdatedAt = vm.UpdatedAt
                };


                var result = await _kindergardenServices.Create(dto);

                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }
        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _kindergardenServices.Details(id);
            if (result == null)
            {
                return NotFound();
            }
            var vm = new KindergardenDetailsViewModel
            {
                Id = result.Id,
                GroupName = result.GroupName,
                ChildrenCount = result.ChildrenCount,
                KindergartenName = result.KindergartenName,
                TeacherName = result.TeacherName,
                CreatedAt = result.CreatedAt,
                UpdatedAt = result.UpdatedAt
            };
            return View(vm);
        }
    }
}
