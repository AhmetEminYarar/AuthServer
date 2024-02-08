using System.ComponentModel.DataAnnotations.Schema;

namespace AuthServer.Data.Entity
{
    [Table("Users")]
    public class User : Base_Entity
    {
        public string UserName { get; set; } = string.Empty;
        public string UserNameToLower { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string EmailToLower { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public long RoleId { get; set; }
        public Role Role { get; set; } = null!;
    }
}
