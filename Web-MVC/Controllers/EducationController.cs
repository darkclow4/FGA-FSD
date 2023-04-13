using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Models;
using WebApplication1.Repository.Contracts;

namespace WebApplication1.Controllers
{
    public class EducationController : Controller
    {
        private readonly IEducationRepository _educationRepository;
        private readonly IUniversityRepository _universityRepository;
        public EducationController(IEducationRepository educationRepository, IUniversityRepository universityRepository)
        {
            _educationRepository = educationRepository;
            _universityRepository = universityRepository;
        }

        // GET
        public IActionResult Index()
        {
            var entities = _educationRepository.GetAll();
            return View(entities);
        }

        // GET - Create
        public IActionResult Create()
        {
            var universities = _universityRepository.GetAll();
            var selectListUniverities = universities.Select(u => new SelectListItem()
            {
                Text = u.Name,
                Value = u.Id.ToString(),
            });
            ViewBag.UniversityId = selectListUniverities;

            return View();
        }

        // POST - Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Education education)
        {
            _educationRepository.Insert(education);
            return RedirectToAction(nameof(Index));
        }

        // GET - Edit
        public IActionResult Edit(int id)
        {
            var universities = _universityRepository.GetAll();
            var selectListUniverities = universities.Select(u => new SelectListItem()
            {
                Text = u.Name,
                Value = u.Id.ToString(),
            });
            ViewBag.UniversityId = selectListUniverities;
            var entity = _educationRepository.GetById(id);
            return View(entity);
        }

        // POST - Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Education education)
        {
            _educationRepository.Update(education);
            return RedirectToAction(nameof(Index));
        }

        // GET - Delete
        public IActionResult Delete(int id)
        {
            var entity = _educationRepository.GetById(id);
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Remove(int id)
        {
            _educationRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        // GET - Details
        public IActionResult Details(int id)
        {
            var entity = _educationRepository.GetById(id);
            return View(entity);
        }
    }
}
