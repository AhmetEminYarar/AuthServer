using System.ComponentModel.DataAnnotations.Schema;

namespace AuthServer.Data.Entity
{
    [Table("Roles")]
    public class Role : Base_Entity
    {
        public string RoleName { get; set; } = string.Empty;
        public List<User> Users { get; set; } = new List<User>();
    }
}
