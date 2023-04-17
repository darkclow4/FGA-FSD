using Web_API.Models;

namespace Web_API.Repository.Contracts
{
    public interface IEmployeeRepository : IGeneralRepository<Employee, string>
    {
        Task<IEnumerable<Employee>> GetAllWithRelationAsync();
    }
}
