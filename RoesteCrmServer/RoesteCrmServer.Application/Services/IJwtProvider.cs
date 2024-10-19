using RoesteCrmServer.Application.Features.Auth.Login;
using RoesteCrmServer.Domain.Entities;

namespace RoesteCrmServer.Application.Services;

public interface IJwtProvider
{
    Task<LoginCommandResponse> CreateToken(AppUser user);
}
