using AuthServer.Data.Entity;
using AuthServer.DTO.Request.People;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.DTO.Request.Roles
{
    public class RoleAddRequest
    {
        public string roleName { get; set; } = string.Empty;
        public Role Map(RoleAddRequest role)
        {
            Role newRole = new Role()
            {
                RoleName = role.roleName,

            };
            return newRole;
        }
    }

    public class RoleAddRequestValidator : AbstractValidator<RoleAddRequest>
    {
        public RoleAddRequestValidator()
        {
            RuleFor(x => x.roleName)
                .NotNull().NotEmpty().WithMessage("Ad gereklidir.")
                .MaximumLength(50).WithMessage("Ad 50 karakteri geçmemelidir.");
        }
    }
}
