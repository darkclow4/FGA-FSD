using Microsoft.EntityFrameworkCore;
using WebApplication1.Contexts;
using WebApplication1.Models;
using WebApplication1.Repository.Contracts;

namespace WebApplication1.Repository.Data
{
    public class EducationRepository : GeneralRepository<Education, int, SQLServerContext>, IEducationRepository
    {
        public EducationRepository(SQLServerContext context) : base(context) { }

        public override IEnumerable<Education> GetAll()
        {
            return _context.Educations.Include(e => e.University).ToList();
        }

        public virtual Education? GetById(int key)
        {
            return _context.Educations.Include(e => e.University).FirstOrDefault(e => e.Id == key);
        }
    }
}
