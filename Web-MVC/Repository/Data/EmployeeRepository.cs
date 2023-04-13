using Microsoft.EntityFrameworkCore;
using WebApplication1.Contexts;
using WebApplication1.Models;
using WebApplication1.Repository.Contracts;

namespace WebApplication1.Repository.Data
{
    public class EmployeeRepository : GeneralRepository<Employee, string, SQLServerContext>, IEmployeeRepository
    {
        public EmployeeRepository(SQLServerContext context) : base(context) { }
    }
}
