using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;
using MVCProject.Repository.CityRepo;
using MVCProject.Repository.GovernorateRepo;
using MVCProject.ViewModel;

namespace MVCProject.Controllers
{
    public class CityController : Controller
    {
        ICityRepository _cityRepository;
        IGovernRepository _governRepository;
        public CityController(ICityRepository cityRepository,IGovernRepository governRepository)
        {
            _cityRepository = cityRepository;
            _governRepository = governRepository;
            
        }
        public IActionResult Index(string word)
        {
            List<City> cities;          
            cities= _cityRepository.GetAll();            
            return View(cities);
        }
        public IActionResult Details(int id)
        {
            var city = _cityRepository.GetById(id);
            return View(city);
        }
        public IActionResult Create(int id)
        {
            ViewData["GovList"] = _governRepository.GetAll();
            ViewData["gov_id"] = _governRepository.GetById(id).Id;
            return View();
        }

        [HttpPost]
        public IActionResult Create(City city,int id)
        {
            var gov = _governRepository.GetById(id).Id;
            if (ModelState.IsValid)
            {
                city.Id = default;
                _cityRepository.Add(city);
                _cityRepository.Save();
                return RedirectToAction("Index");
            }
            ViewData["GovList"] = _governRepository.GetAll();
            return View(city);
        }
        public IActionResult Edit(int id)
        {
            City city = _cityRepository.GetById(id);
            ViewData["GovList"] = _governRepository.GetAll();
            return View(city);
        }
        [HttpPost]
        public IActionResult Edit(City city)
        {
            if (ModelState.IsValid)
            {
                _cityRepository.Edit(city);
                _cityRepository.Save();
                return RedirectToAction("Index");
            }
            ViewData["GovList"] = _governRepository.GetAll();
            return View(city);
        }
        public IActionResult Delete(int id)
        {
            _cityRepository.Delete(id);
            _cityRepository.Save();
            return Content("sucsses");
        }
    }
}
