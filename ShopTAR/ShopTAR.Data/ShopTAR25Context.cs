using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ShopTAR.Data
{
    //teha sellest classist dbcontext, et saaks andmebaasi kasutada
    public class ShopTAR25Context : DbContext
    {
        public ShopTAR25Context(DbContextOptions<ShopTAR25Context> options) : base(options)
        { }
        //teha Dbset, et saaks andmebaasi kasutada
        //teha Core projekti alla Domain nimega kaust ja sinna class nimega scpaceship

    }
}
