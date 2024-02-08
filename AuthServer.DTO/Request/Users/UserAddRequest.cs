using AuthServer.Data.Entity;
using AuthServer.DTO.Request.Roles;
using FluentValidation;

namespace AuthServer.DTO.Request.Users
{
    public class UserAddRequest
    {
        public string userName { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string phoneNumber { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public User Map(UserAddRequest users)
        {
            User newUser = new User()
            {
               UserName = users.userName,
               Email = users.email,
               PhoneNumber = users.phoneNumber,
               PasswordHash = users.password,
            };
            return newUser;
        }
    }
    public class UserAddRequestValidator : AbstractValidator<UserAddRequest>
    {
        public UserAddRequestValidator()
        {
            RuleFor(x => x.userName)
                .NotNull().NotEmpty().WithMessage("Kullanıcı adı gereklidir.")
                .MaximumLength(50).WithMessage("Kullanıcı adı 50 karakteri geçmemelidir.");
            RuleFor(x => x.email)
                .NotNull().NotEmpty().WithMessage("E-posta gereklidir.")
                .MaximumLength(50).WithMessage("E-posta 50 karakteri geçmemelidir.")
                .EmailAddress().WithMessage("Geçerli bir e-posta gereklidir.");
            RuleFor(x => x.phoneNumber)
                .NotNull().NotEmpty().WithMessage("Telefon numarası gereklidir.")
                .MinimumLength(10).WithMessage("Telefon numarası 10 karakterden az olmamalıdır.")
                .MaximumLength(11).WithMessage("Telefon numarası 11 karakteri geçmemelidir.");
            RuleFor(x => x.password)
                .NotNull().NotEmpty().WithMessage("Şifre gereklidir.")
                .MinimumLength(8).WithMessage("Şifre 8 karakterden az olmamalıdır.")
                .MaximumLength(50).WithMessage("Şifre 50 karakteri geçmemelidir.");
        }
    }
}
