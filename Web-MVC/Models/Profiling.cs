using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("TB_TR_Profilings")]
    public class Profiling
    {
        [Key]
        [Column("employee_nik", TypeName = "char(5)")]
        public string EmployeeNik { get; set; } = string.Empty;

        [Column("education_id")]
        public int EducationId { get; set; }

        public Education? Education { get; set; }

        public Employee? Employee { get; set; }
    }
}
