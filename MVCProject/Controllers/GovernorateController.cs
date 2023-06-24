using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;
using MVCProject.Repository.CityRepo;
using MVCProject.Repository.GovernorateRepo;
using MVCProject.ViewModel;

namespace MVCProject.Controllers
{
    public class GovernorateController : Controller
    {
        IGovernRepository _governRepository;
        ICityRepository _cityRepository;
        public GovernorateController(IGovernRepository governRepository,ICityRepository cityRepository)
        {
            _governRepository = governRepository;
            _cityRepository = cityRepository;

        }
        public IActionResult Index(string word)
        {
            List<Governorate> governorates;
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
            var cites = _cityRepository.GetAllCitiesByGovId(id);
            ViewData["GovName"]=_governRepository.GetById(id).Name;
            return View(cites);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Governorate governorate)
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
            Governorate governorate = _governRepository.GetById(id);
            return View(governorate);
        }
        [HttpPost]
        public IActionResult Edit(Governorate governorate)
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
