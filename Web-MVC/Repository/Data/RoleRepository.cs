using WebApplication1.Contexts;
using WebApplication1.Models;
using WebApplication1.Repository.Contracts;

namespace WebApplication1.Repository.Data
{
    public class RoleRepository : GeneralRepository<Role, int, SQLServerContext>, IRoleRepository
    {
        public RoleRepository(SQLServerContext context) : base(context) { }
    }
}
