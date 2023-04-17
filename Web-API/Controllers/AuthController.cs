using Microsoft.AspNetCore.Mvc;
using Web_API.DataModels;
using Web_API.Repository.Contracts;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        public AuthController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        // Post - Register
        [Route("register")]
        [HttpPost]
        public async Task<ActionResult<ResultFormat<string>>> PostRegister(RegisterDM registerDM)
        {
            try
            {
                await _accountRepository.Register(registerDM);
                var result = new ResultFormat<string>
                {
                    StatusCode = 201,
                    Status = "Ok",
                    Message = "Success"
                };
                return result;
            } catch
            {
                var result = new ResultFormat<string>
                {
                    StatusCode = 400,
                    Status = "Failed",
                    Message = "Failed to add data"
                };
                return result;
            }
            
        }
    }
}
