using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;
using MVCProject.Repository.EmployeeRepo;

namespace MVCProject.Controllers
{
    public class EmployeeController : Controller
    {
        IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public IActionResult Index(string word)
        {
            List<Employee> employees;
            if (string.IsNullOrEmpty(word))
            {
                employees = _employeeRepository.GetAll();
            }
            else
            {
                employees = _employeeRepository.GetAll().Where(
                                e=>e.Name.ToLower().Contains(word.ToLower())).ToList();
            }
            return View(employees);

        }

        public IActionResult Details(int id)
        {
            Employee employee = _employeeRepository.GetById(id);

            return View(employee);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeRepository.Add(employee);
                _employeeRepository.Save();
                return RedirectToAction("Index","Home");
            }
            
            return View(employee);
        }

        public IActionResult Edit(int id)
        {
            Employee employee = _employeeRepository.GetById(id);
            return View(employee);
        }
        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeRepository.Edit(employee);
                _employeeRepository.Save();
                return RedirectToAction("Index", "Home");
            }
            return View(employee);
        }

        public IActionResult Delete(int id)
        {
            _employeeRepository.Delete(id);
            _employeeRepository.Save();
            return View();
        }
    }
}
