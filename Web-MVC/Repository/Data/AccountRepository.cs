using Microsoft.EntityFrameworkCore;
using WebApplication1.Contexts;
using WebApplication1.Models;
using WebApplication1.Repository.Contracts;
using WebApplication1.ViewModels;

namespace WebApplication1.Repository.Data
{
    public class AccountRepository : GeneralRepository<Account, string, SQLServerContext>, IAccountRepository
    {
        public AccountRepository(SQLServerContext context) : base(context) { }

        public int Login(LoginVM loginVM)
        {
            var account = _context.Employees.Include(e => e.Account).FirstOrDefault(e => e.Email == loginVM.Email);
            if (account == null)
            {
                return 0;
            }
            if(account.Account.Password != loginVM.Password)
            {
                return 0;
            }
            return 1;
        }

        public int Register(RegisterVM registerVM)
        {
            // Validasi untuk input masing" entitas jika gagal lakukan rollback
            // Validasi apakah input university name ada di database/ tidak
            Role roleUser = _context.Roles.FirstOrDefault(role => role.Name == "User");

            University university;

            university = _context.Universities.FirstOrDefault(u => u.Name == registerVM.UniversityName);
            if (university == null)
            {
                university = new University
                {
                    Name = registerVM.UniversityName
                };
                _context.Universities.Add(university);
                _context.SaveChanges();
            }

            var education = new Education
            {
                Major = registerVM.Major,
                Degree = registerVM.Degree,
                Gpa = registerVM.GPA,
                UniversityId = university.Id,
            };
            _context.Educations.Add(education);
            _context.SaveChanges();

            var employee = new Employee
            {
                Nik = registerVM.NIK,
                FirstName = registerVM.FirstName,
                LastName = registerVM.LastName,
                BirthDate = registerVM.BirthDate,
                Gender = registerVM.Gender,
                PhoneNumber = registerVM.PhoneNumber,
                Email = registerVM.Email,
                HiringDate = DateTime.Today
            };
            _context.Employees.Add(employee);
            _context.SaveChanges();

            var account = new Account
            {
                EmployeeNik = registerVM.NIK,
                Password = registerVM.Password,
            };
            _context.Accounts.Add(account);
            _context.SaveChanges();

            var profiling = new Profiling
            {
                EmployeeNik = registerVM.NIK,
                EducationId = education.Id,
            };
            _context.Profilings.Add(profiling);
            _context.SaveChanges();

            var roleAccount = new AccountRole
            {
                AccountNik = account.EmployeeNik,
                RoleId = roleUser.Id
            };
            _context.AccountRoles.Add(roleAccount);
            return _context.SaveChanges();

        }
    }
}
