using Aniverse.Services.Abstractions.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Aniverse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly IUnitOfWorkService _unitOfWorkService;

        public AnimalsController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }
    }
}
