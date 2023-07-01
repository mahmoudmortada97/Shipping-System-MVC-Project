using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCProject.Models;
using MVCProject.Repository.BranchRepo;
using MVCProject.Repository.EmployeeRepo;
using MVCProject.Repository.OrderRepo;
using MVCProject.Repository.OrderStateRepo;
using MVCProject.ViewModel;

namespace MVCProject.Controllers
{
    [Authorize(Roles = "Employee, Admin")]
    public class EmployeeController : Controller
    {
        IEmployeeRepository _employeeRepository;
        IBranchRepository _branchRepository;
        IOrderRepository _orderRepository;
        IOrderStateRepository _orderStateRepository;

        //Dependency Injection
        public EmployeeController(IOrderStateRepository orderStateRepository, IOrderRepository orderRepository,IEmployeeRepository employeeRepository, IBranchRepository branchRepository)
        {
            _employeeRepository = employeeRepository;
            _branchRepository = branchRepository;
            _orderRepository = orderRepository;
            _orderStateRepository = orderStateRepository;
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
                    ModelState.AddModelError("BranchId", "Please Select Branch");
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
        // Get All Status of All orders for Employee
        public IActionResult Home()
        {
            var allOrders = (from O in _orderRepository.GetAll()
                             join OS in _orderStateRepository.GetAll()
                             on O.OrderStateId equals OS.Id
                             select new
                             {
                                 OrderStateName = OS.Name
                             }).ToList();

            OrderStatusViewModel orderStatusViewModel = new OrderStatusViewModel();

            orderStatusViewModel.NewCount = allOrders.Where(O => O.OrderStateName == "New").Count();
            orderStatusViewModel.pendingCount = allOrders.Where(O => O.OrderStateName == "pending").Count();
            orderStatusViewModel.The_order_has_been_deliveredCount = allOrders.Where(O => O.OrderStateName == "The order has been delivered").Count();
            orderStatusViewModel.sent_delivered_handedCount = allOrders.Where(O => O.OrderStateName == "sent delivered handed").Count();
            orderStatusViewModel.Can_not_reachCount = allOrders.Where(O => O.OrderStateName == "Can not reach").Count();
            orderStatusViewModel.postponedCount = allOrders.Where(O => O.OrderStateName == "postponed").Count();
            orderStatusViewModel.Partially_deliveredCount = allOrders.Where(O => O.OrderStateName == "Partially delivered").Count();
            orderStatusViewModel.Canceled_by_ClientCount = allOrders.Where(O => O.OrderStateName == "Canceled by Client").Count();
            orderStatusViewModel.Refused_with_paymentCount = allOrders.Where(O => O.OrderStateName == "Refused with payment").Count();
            orderStatusViewModel.Refused_with_part_paymentCount = allOrders.Where(O => O.OrderStateName == "Refused with part payment").Count();
            orderStatusViewModel.Rejected_and_not_paidCount = allOrders.Where(O => O.OrderStateName == "Rejected and not payment").Count();


            return View(orderStatusViewModel);

        }
    }
}
