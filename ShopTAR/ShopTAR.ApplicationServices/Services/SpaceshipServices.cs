using ShopTAR25.Core.Domain;
using ShopTAR25.Core.Dto;
using ShopTAR25.Data;
using ShopTAR25.Core.ServiceInterface;

namespace ShopTAR25.ApplicationServices.Services
{

    public class SpaceshipServices : ISpaceshipServices
    {
        private readonly ShopTAR25Context _context;
        public SpaceshipServices
            (
            ShopTAR25Context context
            )
        {
            _context = context;
        }
    
        public async Task<Spaceship> Create(SpaceshipDto dto)
        {
            Spaceship domain = new();
            domain.Id = dto.Id;
            domain.Name = dto.Name;
            domain.Classification = dto.Classification;
            domain.BuiltTime = dto.BuiltTime;
            domain.Crew = dto.Crew;
            domain.EnginePower = dto.EnginePower;
            domain.CreatedAt = dto.CreatedAt;
            domain.ModifiedAt = dto.ModifiedAt;

            await _context.Spaceships.AddAsync(domain);
            await _context.SaveChangesAsync();

            return domain;
        }
    }
}
