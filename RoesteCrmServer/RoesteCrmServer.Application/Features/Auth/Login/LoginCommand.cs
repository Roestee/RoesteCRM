using RoesteCrmServer.Application.Utilities.Results;
using MediatR;

namespace RoesteCrmServer.Application.Features.Auth.Login;

public sealed record LoginCommand(
    string EmailOrUsername,
    string Password) : IRequest<Result<LoginCommandResponse>>;