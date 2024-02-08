using System.ComponentModel.DataAnnotations;

namespace AuthServer.Data.Entity
{
    public class Base_Entity
    {
        [Key]
        public long Id { get; set; }
    }
}
