using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("TB_M_Educations")]
    public class Education
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("major", TypeName = "varchar(100)")]
        public string Major { get; set; } = string.Empty;

        [Column("degree", TypeName = "varchar(10)")]
        public string Degree { get; set; } = string.Empty;

        [Column("gpa", TypeName = "decimal(3, 2)")]
        public double Gpa { get; set; } = double.NaN;

        [Column("university_id")]
        public int UniversityId { get; set; }

        public University University { get; set; }
        public Profiling? Profiling { get; set; }
    }
}
