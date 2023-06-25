using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCProject.Models;
using MVCProject.Repository.BranchRepo;
using MVCProject.Repository.EmployeeRepo;

namespace MVCProject.Controllers
{
    public class EmployeeController : Controller
    {
        IEmployeeRepository _employeeRepository;
        IBranchRepository _branchRepository;

        //Dependency Injection
        public EmployeeController(IEmployeeRepository employeeRepository, IBranchRepository branchRepository)
        {
            _employeeRepository = employeeRepository;
            _branchRepository = branchRepository;
        }

        // Display All Employees + Search
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

        // Display Card of only 1 Employee
        public IActionResult Details(int id)
        {
            Employee employee = _employeeRepository.GetById(id);

            return View(employee);
        }

        //Create Employee
        public IActionResult Create()
        {
            ViewBag.BranchList = _branchRepository.GetAll().Select(b => new SelectListItem
            {
                Value = b.Id.ToString(),
                Text = b.Name
            });

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {

            if (ModelState.IsValid)
            {

                try
                {
                    _employeeRepository.Create(employee);
                    _employeeRepository.Save();
                    return RedirectToAction("Index", "Employee");
                }
                catch
                {
                    ModelState.AddModelError("BranchId","Please Select Branch");
                }

            }
            ViewBag.BranchList = _branchRepository.GetAll().Select(b => new SelectListItem
            {
                Value = b.Id.ToString(),
                Text = b.Name
            });
            return View(employee);
        }

        //Edit Employee
        public IActionResult Edit(int id)
        {
            Employee employee = _employeeRepository.GetById(id);
            ViewBag.BranchList = new SelectList(_branchRepository.GetAll(), "Id", "Name");

            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _employeeRepository.Edit(employee);
                    _employeeRepository.Save();
                    return RedirectToAction("Index", "Employee");
                }
                   catch
                {
                    ModelState.AddModelError("BranchId", "Please Select Branch");
                }
            }
            ViewBag.BranchList = new SelectList(_branchRepository.GetAll(), "Id", "Name");
            return View(employee);
        }

        //Delete Employee
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
