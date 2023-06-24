using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
                                e => e.Name.ToLower().Contains(word.ToLower())).ToList();
            }
            return View(employees);

        }

        public IActionResult Details(int id)
        {
            Employee employee = _employeeRepository.GetById(id);

            return View(employee);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {

            if (ModelState.IsValid)
            {

                _employeeRepository.Create(employee);
                _employeeRepository.Save();
                return RedirectToAction("Index", "Employee");

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
                return RedirectToAction("Index", "Employee");
            }
            return View(employee);
        }

        public IActionResult Delete(int id)
        {
            Employee employee = _employeeRepository.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _employeeRepository.Delete(id);
            return RedirectToAction("Index");
        }



    }
}
