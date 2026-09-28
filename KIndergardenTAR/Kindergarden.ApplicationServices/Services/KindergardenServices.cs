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
    }
}
