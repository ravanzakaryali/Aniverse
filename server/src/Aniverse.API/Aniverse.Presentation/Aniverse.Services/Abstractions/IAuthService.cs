﻿using Aniverse.Application.DTOs.Auth;
using Aniverse.Application.DTOs.User;

namespace Aniverse.Services.Abstractions
{
    public interface IAuthService
    {
        Task<CreateUserResponse> RegisterAsync(Register register);
        Task<Token> LoginAsync(Login login);
        Task<Token> RefreshTokenLoginAsync(TokenRequest tokenModel);
    }
}
