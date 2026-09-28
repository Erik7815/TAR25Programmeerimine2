using Kindergarden.Core.Domain;
using Kindergarden.Core.Dto;
using Kindergarden.Core.Domain;


namespace Kindergarden.Core.ServiceInterface
{
    public interface IKindergardenServices
    {
        Task<KindergardenDomain> Create(KindergardenDto dto);
    }
}
