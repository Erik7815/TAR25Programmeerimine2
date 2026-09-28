using Kindergarden.ApplicationServices;
using Kindergarden.Core;
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
        public KindergardenServices
        (
        KindergardenContext context
        )
        {
            _context = context;
        }

        public async Task<KindergardenDomain> Create(KindergardenDto dto)
        {
            KindergardenDomain domain = new();
            {
                domain.Id = dto.Id;
                domain.GroupName = dto.GroupName;
                domain.ChildrenCount = dto.ChildrenCount;
                domain.KindergartenName = dto.KindergartenName;
                domain.TeacherName = dto.TeacherName;
                domain.CreatedAt = DateTime.Now;
                domain.UpdatedAt = DateTime.Now;
            }
            ;
            _context.Kindergardens.Add(domain);
            await _context.SaveChangesAsync();
            return domain;
        }
        public async Task<KindergardenDomain> Details(Guid id)
        {
            var domain = await _context.Kindergardens.FindAsync(id);
            return domain;
        }
        public async Task<KindergardenDomain> Delete(Guid id)
        {

            var result = await _context.Kindergardens
                .FirstOrDefaultAsync(x => x.Id == id);
            if (result == null)
            {
                return null;
            }
            _context.Kindergardens.Remove(result);
            await _context.SaveChangesAsync();

            return result;
        }
        public async Task<KindergardenDomain> Update(KindergardenDto dto)
        {
            KindergardenDomain kindergarden = new();
            {
                kindergarden.Id = dto.Id;
                kindergarden.GroupName = dto.GroupName;
                kindergarden.ChildrenCount = dto.ChildrenCount;
                kindergarden.KindergartenName = dto.KindergartenName;
                kindergarden.TeacherName = dto.TeacherName;
                kindergarden.CreatedAt = dto.CreatedAt;
                kindergarden.UpdatedAt = DateTime.Now;
            }

            _context.Kindergardens.Update(kindergarden);
            await _context.SaveChangesAsync();

            return kindergarden;
        }
    }
}
