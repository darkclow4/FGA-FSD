using Microsoft.AspNetCore.Mvc;
using System.Net;
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

        // POST - Login
        [Route("login")]
        [HttpPost]
        public async Task<ActionResult<ResultFormat<string>>> PostLogin(LoginDM loginDM)
        {
            try
            {
                bool loginProcess = await _accountRepository.LoginAsync(loginDM);
                if (loginProcess)
                {
                    var result = new ResultFormat<string>
                    {
                        StatusCode = 200,
                        Status = "Ok",
                        Message = "Success"
                    };
                    return Ok(result);
                } else
                {
                    var result = new ResultFormat<string>
                    {
                        StatusCode = 400,
                        Status = "Failed",
                        Message = "Wrong email and password combination"
                    };
                    return BadRequest(result);
                }
                
            } catch (Exception ex)
            {
                var result = new ResultFormat<string>
                {
                    StatusCode = 400,
                    Status = "Failed",
                    Message = ex.Message
                };
                return result;
            }
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
            } catch (Exception ex)
            {
                var result = new ResultFormat<string>
                {
                    StatusCode = 400,
                    Status = "Failed",
                    Message = "Failed to add data. " + ex.Message
                };
                return result;
            }
            
        }
    }
}
