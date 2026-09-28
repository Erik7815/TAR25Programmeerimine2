using System;
using System.Collections.Generic;
using System.Text;

namespace ShopTARpe25.Core.Dto
{
    public class FIleToApis
    {
        public Guid Id { get; set; }

        //see muutuja hakkab näitama kus asub meie fail
        public string? ExistingFilePath { get; set; }
        public Guid? SpaceshipId { get; set; }
    }
}
