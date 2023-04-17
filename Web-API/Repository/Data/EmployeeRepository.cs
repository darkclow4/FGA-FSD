using Web_API.Contexts;
using Web_API.Models;
using Web_API.Repository.Contracts;

namespace Web_API.Repository.Data
{
    public class EmployeeRepository : GeneralRepository<Employee, string, SQLServerContext>, IEmployeeRepository
    {
        public EmployeeRepository(SQLServerContext context) : base(context) { }
    }
}
