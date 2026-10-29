using Kindergarden.Core.Domain;
using Kindergarden.Core.Dto;
using Kindergarden.Core.ServiceInterface;
using Kindergarden.Data;
using Microsoft.EntityFrameworkCore;

namespace Kindergarden.ApplicationServices.Services
{
    public class KindergardenServices : IKindergardenServices
    {


        private readonly KindergardenContext _context;
        private readonly IFileServices _fileServices;
        public KindergardenServices
        (
        KindergardenContext context,
            IFileServices fileServices
        )
        {
            _context = context;
            _fileServices = fileServices;
        }

        public async Task<KindergardenDomain> Create(KindergardenDto dto)
        {
            KindergardenDomain domain = new();

            domain.Id = Guid.NewGuid();
                domain.GroupName = dto.GroupName;
                domain.ChildrenCount = dto.ChildrenCount;
                domain.KindergartenName = dto.KindergartenName;
                domain.TeacherName = dto.TeacherName;
                domain.CreatedAt = DateTime.Now;
                domain.UpdatedAt = DateTime.Now;
                _fileServices.FilesToApi(dto, domain);
            
            
             await _context.Kindergardens.AddAsync(domain);
            await _context.SaveChangesAsync();
            return domain;
        }
        public async Task<KindergardenDomain> Details(Guid id)
        {
            var result = await _context.Kindergardens
                .FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
        public async Task<KindergardenDomain> Delete(Guid id)
        {

            var result = await _context.Kindergardens
                .FirstOrDefaultAsync(x => x.Id == id);

            var images = await _context.FileToApis
                .Where(x => x.KindergardenId == id)
                .Select(y => new FileToApiDto
                {
                    Id = y.Id,
                    KindergardenId = y.KindergardenId,
                    ExistingFilePath = y.ExistingFilePath,
                }).ToArrayAsync();


            await _fileServices.RemoveImagesFromApi(images);
            _context.Kindergardens.Remove(result);
            await _context.SaveChangesAsync();

            return result;
        }
        public async Task<KindergardenDomain> Update(KindergardenDto dto)
        {
            KindergardenDomain kindergarden = new();
            
                kindergarden.Id = dto.Id;
                kindergarden.GroupName = dto.GroupName;
                kindergarden.ChildrenCount = dto.ChildrenCount;
                kindergarden.KindergartenName = dto.KindergartenName;
                kindergarden.TeacherName = dto.TeacherName;
                kindergarden.CreatedAt = dto.CreatedAt;
                kindergarden.UpdatedAt = DateTime.Now;
                _fileServices.FilesToApi(dto, kindergarden);
            

            _context.Kindergardens.Update(kindergarden);
            await _context.SaveChangesAsync();

            return kindergarden;
        }
       
    }
}
