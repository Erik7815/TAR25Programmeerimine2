﻿using Kindergarden.ApplicationServices.Services;
using Kindergarden.Core.Dto;
using Kindergarden.Core.ServiceInterface;
using Kindergarden.Data;
using KindergardenTAR.Models.Kindergarden;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KindergardenTAR.Controllers
{
    public class KindergardenController : Controller
    {
        private readonly IKindergardenServices _kindergardenServices;
        private readonly KindergardenContext _context;
        private readonly IFileService _fileService;

        public KindergardenController
            (
            IKindergardenServices KindergardenServices,
            KindergardenContext context,
            IFileService fileService
            )
        {
            _kindergardenServices = KindergardenServices;
            _context = context;
            _fileService = fileService;
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
                    UpdatedAt = vm.UpdatedAt,
                    Files = vm.Files,
                    FileToApiDtos = vm.Image
                    .Select(file => new FileToApiDto
                    {
                        Id = file.ImageId,
                        ExistingFilePath = file.FilePath,
                        SpaceshipId = file.KindergardenId
                    }).ToArray()
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
            var images = await _context.FileToApis
                .Where(x => x.KindergardenId == id)
                .Select(y => new ImageViewModel
                {
                    FilePath = /*"~/multipleFileUpload/" +*/ y.ExistingFilePath,
                    ImageId = y.Id,
                    KindergardenId = y.KindergardenId
                }).ToArrayAsync();
            var vm = new KindergardenDetailsViewModel
            {
                Id = result.Id,
                GroupName = result.GroupName,
                ChildrenCount = result.ChildrenCount,
                KindergartenName = result.KindergartenName,
                TeacherName = result.TeacherName,
                CreatedAt = result.CreatedAt,
                UpdatedAt = result.UpdatedAt,
                vm.Images.AddRange(images);
            };
            return View(vm);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _kindergardenServices.Details(id);

            if (result == null)
            {
                return NotFound();
            }
            var images = await _context.FileToApis
                .Where(x => x.KindergadenId == id)
                .Select(y => new ImageViewModel
                {
                    FilePath = y.ExistingFilePath,
                    ImageId = y.Id,
                    KindergardenId = y.KindergardenId
                }).ToArrayAsync();

            var vm = new KindergardenDeleteViewModel
            {
                Id = result.Id,
                GroupName = result.GroupName,
                ChildrenCount = result.ChildrenCount,
                KindergartenName = result.KindergartenName,
                TeacherName = result.TeacherName,
                CreatedAt = result.CreatedAt,
                UpdatedAt = result.UpdatedAt,
                vm.Image.AddRange(images);
            

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(Guid id)
        {
            await _kindergardenServices.Delete(id);

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var kindergarden = await _kindergardenServices.Details(id);

            if (kindergarden == null)
            {
                return NotFound();
            }

            var vm = new KindergardenUpdateViewModel();
            {
                vm.Id = kindergarden.Id;
                vm.GroupName = kindergarden.GroupName;
                vm.ChildrenCount = kindergarden.ChildrenCount;
                vm.KindergartenName = kindergarden.KindergartenName;
                vm.TeacherName = kindergarden.TeacherName;
                vm.CreatedAt = kindergarden.CreatedAt;
                vm.UpdatedAt = kindergarden.UpdatedAt;

                return View(vm);
            }



        }
        [HttpPost]

        public async Task<IActionResult> Update(KindergardenUpdateViewModel vm)
        {
            var dto = new KindergardenDto();
            {
                dto.Id = vm.Id;
                dto.GroupName = vm.GroupName;
                dto.ChildrenCount = vm.ChildrenCount;
                dto.KindergartenName = vm.KindergartenName;
                dto.TeacherName = vm.TeacherName;
                dto.CreatedAt = vm.CreatedAt;
                dto.UpdatedAt = DateTime.Now;
            }
            var result = await _kindergardenServices.Update(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}