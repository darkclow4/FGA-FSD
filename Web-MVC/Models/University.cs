using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("TB_M_Universities")]
    public class University
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name", TypeName = "varchar(100)")]
        public string Name { get; set; } = string.Empty;

        public ICollection<Education> Educations { get; set; } = new List<Education>();
    }
}
