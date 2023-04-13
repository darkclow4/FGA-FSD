using WebApplication1.Models;

namespace WebApplication1.Repository.Contracts
{
    public interface IEmployeeRepository : IGeneralRepository<Employee, string>
    {
    }
}
