using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repository.Contracts;

namespace WebApplication1.Controllers
{
    public class UniversityController : Controller
    {
        private readonly IUniversityRepository _universityRepository;
        public UniversityController(IUniversityRepository universityRepository)
        {
            _universityRepository = universityRepository;
        }

        // GET: UniversityController
        public ActionResult Index()
        {
            var entities = _universityRepository.GetAll();
            return View(entities);
        }

        // GET: UniversityController/Details/5
        public ActionResult Details(int id)
        {
            var entity = _universityRepository.GetById(id);
            return View(entity);
        }

        // GET: UniversityController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UniversityController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(University university)
        {
            _universityRepository.Insert(university);
            return RedirectToAction("Index");
        }

        // GET: UniversityController/Edit/5
        public ActionResult Edit(int id)
        {
            var entity = _universityRepository.GetById(id);
            return View(entity);
        }

        // POST: UniversityController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(University university)
        {
            _universityRepository.Update(university);
            return RedirectToAction("Index");
        }

        // GET: UniversityController/Delete/5
        public ActionResult Delete(int id)
        {
            var entity = _universityRepository.GetById(id);
            return View(entity);
        }

        // POST: UniversityController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRecord(int id)
        {
            _universityRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
