using Web_API.Contexts;
using Web_API.DataModels;
using Web_API.Models;
using Web_API.Handlers;
using Web_API.Repository.Contracts;

namespace Web_API.Repository.Data
{
    public class AccountRepository : GeneralRepository<Account, string, SQLServerContext>, IAccountRepository
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUniversityRepository _universityRepository;
        private readonly IEducationRepository _educationRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IProfilingRepository _profilingRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IAccountRoleRepository _accountRoleRepository;
        public AccountRepository(SQLServerContext context,
            IEmployeeRepository employeeRepository,
            IUniversityRepository universityRepository,
            IEducationRepository educationRepository,
            IAccountRepository accountRepository,
            IRoleRepository roleRepository,
            IProfilingRepository profilingRepository,
            IAccountRoleRepository accountRoleRepository
            ) : base(context)
        {
            _employeeRepository = employeeRepository;
            _universityRepository = universityRepository;
            _educationRepository = educationRepository;
            _accountRepository = accountRepository;
            _roleRepository = roleRepository;
            _profilingRepository = profilingRepository;
            _accountRoleRepository = accountRoleRepository;
        }

        public async Task<bool> LoginAsync(LoginDM loginDM)
        {
            var getEmployees = await _employeeRepository.GetAllWithRelationAsync();
            var getUserData = getEmployees.FirstOrDefault(e => e.Email == loginDM.Email);

            return getUserData is not null && Hashing.ValidatePassword(loginDM.Password, getUserData.Account.Password);
        }

        public async Task Register(RegisterDM registerDM)
        {
            University university;
            if (await _universityRepository.IsNameExist(registerDM.UniversityName))
            {
                var universityAsync = await _universityRepository.GetAllAsync();
                university = universityAsync.FirstOrDefault(u => u.Name == registerDM.UniversityName);
            }
            else
            {
                university = new University { Name = registerDM.UniversityName };
            }
            await _universityRepository.InsertAsync(university);

            var education = new Education
            {
                Major = registerDM.Major,
                Degree = registerDM.Degree,
                Gpa = (decimal)registerDM.GPA,
                UniversityId = university.Id,
            };
            await _educationRepository.InsertAsync(education);

            var employee = new Employee
            {
                Nik = registerDM.NIK,
                FirstName = registerDM.FirstName,
                LastName = registerDM.LastName,
                Birthdate = registerDM.BirthDate,
                Gender = (int)registerDM.Gender,
                PhoneNumber = registerDM.PhoneNumber,
                Email = registerDM.Email,
                HiringDate = DateTime.Today
            };
            await _employeeRepository.InsertAsync(employee);

            var account = new Account
            {
                EmployeeNik = registerDM.NIK,
                Password = Hashing.HashPassword(registerDM.Password),
            };
            await _accountRepository.InsertAsync(account);

            var profiling = new Profiling
            {
                EmployeeNik = registerDM.NIK,
                EducationId = education.Id,
            };
           await _profilingRepository.InsertAsync(profiling);

            var roleAsync = await _roleRepository.GetAllAsync();
            var roleAccount = new AccountRole
            {
                AccountNik = account.EmployeeNik,
                RoleId = roleAsync.FirstOrDefault(r => r.Name == "User").Id
            };
            await _accountRoleRepository.InsertAsync(roleAccount);

            await _context.SaveChangesAsync();
        }
    }
}
