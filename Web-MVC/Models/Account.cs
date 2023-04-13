using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("TB_M_Accounts")]
    public class Account
    {
        [Key]
        [Column("employee_nik", TypeName = "char(5)")]
        public string EmployeeNik { get; set; } = string.Empty;

        [Column("password", TypeName = "varchar(255)")]
        public string Password { get; set; } = string.Empty;

        public Employee? Employee { get; set; }

        public ICollection<AccountRole>? AccountRoles { get; set; }
    }
}
