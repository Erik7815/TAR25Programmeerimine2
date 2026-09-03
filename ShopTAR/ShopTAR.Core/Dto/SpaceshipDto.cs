using System;
using System.Collections.Generic;
using System.Text;

namespace ShopTAR25.Core.Dto
{
    //Dto vahendab andmeid rcontrolleri ja service classide vahel.
    internal class SpaceshipDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Classification { get; set; } = string.Empty;
        public DateTime? BuiltTime { get; set; }
        public int? Crew { get; set; }
        public int? EnginePower { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
