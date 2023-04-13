using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("TB_M_Roles")]
    public class Role
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name", TypeName = "varchar(50)")]
        public string Name { get; set; } = string.Empty;

        public ICollection<AccountRole> AccountRoles { get; set; } = new List<AccountRole>();
    }
}
