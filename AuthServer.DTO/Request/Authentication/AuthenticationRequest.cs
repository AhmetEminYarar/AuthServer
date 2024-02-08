using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.DTO.Request.Authentication
{
    public class AuthenticationRequest
    {
        public string userName { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;

    }
    public class AuthenticationLoginRequestValidator : AbstractValidator<AuthenticationRequest>
    {
        public AuthenticationLoginRequestValidator()
        {
            RuleFor(x => x.userName)
                .NotNull().NotEmpty().WithMessage("userName gereklidir.")
                .MaximumLength(20).WithMessage("userName 20 karakteri geçmemelidir.");

            RuleFor(x => x.password)
                .NotNull().NotEmpty().WithMessage("Şifre gereklidir.")
                .MinimumLength(8).WithMessage("Şifre 8 karakterden az olmamalıdır.")
                .MaximumLength(50).WithMessage("Şifre 50 karakteri geçmemelidir.");
        }
    }
}
