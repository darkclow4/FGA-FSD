using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Repository.Contracts
{
    public interface IAccountRepository : IGeneralRepository<Account, string>
    {
        int Register(RegisterVM registerVM);
        int Login(LoginVM loginVM);
    }
}
