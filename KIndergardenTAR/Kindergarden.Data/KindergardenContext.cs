using Microsoft.EntityFrameworkCore;
using Kindergarden.Core.Domain;
namespace Kindergarden.Data

{
    public class KindergardenContext : DbContext
    {
        public KindergardenContext(DbContextOptions<KindergardenContext> options) : base(options)
        {

        }
        public DbSet<KindergardenDomain> Kindergardens { get; set; }
    }
}