using Aniverse.Application.Abstractions.UnitOfWork;
using Aniverse.Services.Abstractions;

namespace Aniverse.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
