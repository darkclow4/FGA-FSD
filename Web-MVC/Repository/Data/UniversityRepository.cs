using Microsoft.EntityFrameworkCore;
using WebApplication1.Contexts;
using WebApplication1.Models;
using WebApplication1.Repository.Contracts;

namespace WebApplication1.Repository.Data
{
    public class UniversityRepository : GeneralRepository<University, int, SQLServerContext>, IUniversityRepository
    {
        public UniversityRepository(SQLServerContext context) : base(context) { }
    }
}
