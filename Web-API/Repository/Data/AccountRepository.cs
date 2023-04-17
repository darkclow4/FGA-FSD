using Web_API.Contexts;
using Web_API.Models;
using Web_API.Repository.Contracts;

namespace Web_API.Repository.Data
{
    public class AccountRepository : GeneralRepository<Account, string, SQLServerContext>, IAccountRepository
    {
        public AccountRepository(SQLServerContext context) : base(context) { }
    }
}
