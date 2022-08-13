namespace Aniverse.Services.Abstractions.UnitOfWork
{
    public interface IUnitOfWorkService
    {
        IAnimalService AnimalService { get; }
        IAuthService AuthService { get; }
        IUserService UserService { get;}
        IPostService PostService { get; }
    }
}
