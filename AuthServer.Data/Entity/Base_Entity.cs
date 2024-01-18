using System.ComponentModel.DataAnnotations;

namespace AuthServer.Data.Entity
{
    public class Base_Entity
    {
        [Key]
        public int Id { get; set; }
    }
}
