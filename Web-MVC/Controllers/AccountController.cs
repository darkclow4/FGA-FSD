using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Repository.Contracts;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        // GET - Register
        public IActionResult Register()
        {
            var gender = new List<SelectListItem>(){
            new SelectListItem{
                Text = "Male",
                Value = "0",
            },
            new SelectListItem{
                Text = "Female",
                Value = "1",
        }};

            ViewBag.Gender = gender;

            return View();
        }

        // POST - Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterVM registerVM)
        {
            var result = _accountRepository.Register(registerVM);
            if (result > 0)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        // GET - Login
        public IActionResult Login()
        {
            return View();
        }

        // POST - Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginVM loginVM)
        {
            int result = _accountRepository.Login(loginVM);
            if (result > 0)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewData["failedLogin"] = "Wrong email and password combination";
            return View();
        }
    }
}
