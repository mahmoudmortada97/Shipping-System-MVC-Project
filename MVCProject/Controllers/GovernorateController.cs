using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;
using MVCProject.Repository.GovernorateRepo;
using MVCProject.ViewModel;

namespace MVCProject.Controllers
{
    public class GovernorateController : Controller
    {
        IGovernRepository _governRepository;
        public GovernorateController(IGovernRepository governRepository)
        {
            _governRepository = governRepository;
            
        }
        public IActionResult Index(string word)
        {
            List<Government> governorates;
            if (string.IsNullOrEmpty(word))
            {
                governorates = _governRepository.GetAll();
            }
            else
            {
                governorates = _governRepository.GetAll().Where(
                                e => e.Name.ToLower().Contains(word.ToLower())).ToList();
            }
            return View(governorates);
        }
        public IActionResult Details(int id)
        {
            var gov = _governRepository.GetById(id);
            return View(gov);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Government governorate)
        {
            if (ModelState.IsValid)
            {
                _governRepository.Add(governorate);
                _governRepository.Save();
                return RedirectToAction("Index");
            }
            return View(governorate);
        }
        public IActionResult Edit(int id)
        {
            Government governorate = _governRepository.GetById(id);
            return View(governorate);
        }
        [HttpPost]
        public IActionResult Edit(Government governorate)
        {
            if (ModelState.IsValid)
            {
                _governRepository.Edit(governorate);
                _governRepository.Save();
                return RedirectToAction("Index");
            }
            return View(governorate);
        }
        public IActionResult Delete(int id)
        {
            _governRepository.Delete(id);
            _governRepository.Save();
            return Content("sucsses");
        }
    }
}
