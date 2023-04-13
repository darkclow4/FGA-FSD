using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Index(nameof(Email), nameof(PhoneNumber), IsUnique = true)]
    [Table("TB_M_Employees")]
    public class Employee
    {
        [Key]
        [Column("nik", TypeName = "char(5)")]
        public string Nik { get; set; } = string.Empty;

        [Column("first_name", TypeName = "varchar(50)")]
        public string FirstName { get; set; } = string.Empty;

        [Column("last_name", TypeName = "varchar(50)")]
        public string? LastName { get; set; }

        [Column("birthdate", TypeName = "date")]
        public DateTime BirthDate { get; set; }

        //Gender enum
        [Column("gender")]
        public GenderEnum Gender { get; set; }

        [Column("hiring_date", TypeName = "date")]
        public DateTime HiringDate { get; set; }

        [Column("email", TypeName = "varchar(50)")]
        public string Email { get; set; } = string.Empty;

        [Column("phone_number", TypeName = "varchar(20)")]
        public string PhoneNumber { get; set; } = string.Empty;

        public Profiling? Profiling { get; set; }
        public Account? Account { get; set; }
    }

    public enum GenderEnum
    {
        Male,
        Female
    }
}
