using Web_API.Contexts;
using Web_API.Models;
using Web_API.Repository.Contracts;

namespace Web_API.Repository.Data
{
    public class AccountRoleRepository : GeneralRepository<AccountRole, int, SQLServerContext>, IAccountRoleRepository
    {
        public AccountRoleRepository(SQLServerContext context) : base(context) { }
    }
}
