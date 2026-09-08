using ShopTAR25.Core.Domain;
using ShopTAR25.Core.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopTAR25.Core.ServiceInterface
{
    public interface ISpaceshipServices
    {
        Task<Spaceship> Create(SpaceshipDto dto);
    }
}
