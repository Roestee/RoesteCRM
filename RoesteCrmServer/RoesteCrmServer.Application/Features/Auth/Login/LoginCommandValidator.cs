using FluentValidation;

namespace RoesteCrmServer.Application.Features.Auth.Login;

public sealed class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator() {
        RuleFor(p => p.EmailOrUsername)
       .MinimumLength(3)
       .WithMessage("Kullanıcı adı ya da mail bilgisi en az 3 karakter olmalıdır");
        RuleFor(p => p.Password)
            .MinimumLength(8)
            .WithMessage("Şifre en az 8 karakter olmalıdır");
    }
}
