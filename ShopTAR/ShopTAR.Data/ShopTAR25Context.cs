using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ShopTAR25.Core.Domain;

namespace ShopTAR25.Data
{
    //teha sellest classist dbcontext, et saaks andmebaasi kasutada
    public class ShopTAR25Context : DbContext
    {
        public ShopTAR25Context(DbContextOptions<ShopTAR25Context> options) : base(options)
        { }
        //teha Dbset, et saaks andmebaasi kasutada
        // nimega scpaceship

        public DbSet<Spaceship> Spaceships { get; set; }
        
    }
}
