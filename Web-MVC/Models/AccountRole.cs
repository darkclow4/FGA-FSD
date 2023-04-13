using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("TB_TR_Account_Roles")]
    public class AccountRole
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("account_nik", TypeName = "char(5)")]
        public string AccountNik { get; set; } = string.Empty;

        [Column("role_id")]
        public int RoleId { get; set; }

        public Account? Account { get; set; }
        public Role? Role { get; set; }
    }
}
