using Kindergarden.Core.Domain;
using Kindergarden.Core.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kindergarden.Core.ServiceInterface
{
    public interface IKindergardenServices
    {
        Task<KindergardenDomain> Create(KindergardenDto dto);
        Task<KindergardenDomain> Details(Guid id);
        Task<KindergardenDomain> Delete(Guid id);
        Task<KindergardenDomain> Update(KindergardenDto dto);
    }
}
