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
    }
}
