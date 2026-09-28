using Kindergarden.Core.Dto;
using Kindergarden.Core.ServiceInterface;
using Kindergarden.Data;
using Kindergarden.Models.Kindergarten;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kindergarden.Controllers
{
    public class KindergardenController : Controller
    {
        private readonly IKindergardenServices _kindergardenServices;
        private readonly KindergardenContext _context;

        public KindergardenController
            (
            IKindergardenServices KindergardenServices,
            KindergardenContext context
            )
        {
            _kindergardenServices = KindergardenServices;
            _context = context;
        }
    }
}
