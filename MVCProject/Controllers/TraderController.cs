using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCProject.Models;
using MVCProject.Repository.OrderTypeRepo;
using MVCProject.Repository.BranchRepo;
using MVCProject.Repository.CityRepo;
using MVCProject.Repository.GovernorateRepo;
using MVCProject.Repository.TraderRepo;
using MVCProject.Repository.OrderRepo;
using System.Security.Claims;
using MVCProject.ViewModel;

namespace MVCProject.Controllers
{

    public class TraderController : Controller
    {
        ITraderRepository _traderRepository;
        IGovernRepository _governRepository;
        ICityRepository _cityRepository;
        IBranchRepository _branchRepository;
        IOrderRepository _orderRepository;

        // Dependency Injection
        public TraderController(IOrderRepository orderRepository,ITraderRepository traderRepository, IGovernRepository governRepository, ICityRepository cityRepository, IBranchRepository branchRepository)
        {
            _traderRepository = traderRepository;
            _governRepository = governRepository;
            _cityRepository = cityRepository;
            _branchRepository = branchRepository;
            _orderRepository = orderRepository;
        }

        // Display All Traders + Search
        public IActionResult Index(string word)
        {
            List<Trader> traders;
            if (string.IsNullOrEmpty(word))
            {
                traders = _traderRepository.GetAll();
            }
            else
            {
                traders = _traderRepository.GetAll().Where(
                                e => e.Name.ToLower().Contains(word.ToLower())).ToList();
            }
            return View(traders);
        }

        // Display Card of only 1 Trader
        public IActionResult Details(int id)
        {
            Trader trader = _traderRepository.GetById(id);

            return View(trader);
        }

        // Create Trader
        public IActionResult Create()
        {
            ViewBag.GovernList = _governRepository.GetAll().Select(g => new SelectListItem
            {
                Value = g.Id.ToString(),
                Text = g.Name
            });
            ViewBag.CityList = _cityRepository.GetAll().Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            });
            ViewBag.BranchList = _branchRepository.GetAll().Select(b => new SelectListItem
            {
                Value = b.Id.ToString(),
                Text = b.Name
            });
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Trader trader)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _traderRepository.Create(trader);
                    _traderRepository.Save();
                    return RedirectToAction("Index", "Trader");
                }
                catch
                {
                    ModelState.AddModelError("GoverId", "Please Select Governorate");
                    ModelState.AddModelError("BranchId", "Please Select Branch");
                    ModelState.AddModelError("CityId", "Please Select City");
                }
            }
            ViewBag.GovernList = _governRepository.GetAll().Select(g => new SelectListItem
            {
                Value = g.Id.ToString(),
                Text = g.Name
            });
            ViewBag.CityList = _cityRepository.GetAll().Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            });
            ViewBag.BranchList = _branchRepository.GetAll().Select(b => new SelectListItem
            {
                Value = b.Id.ToString(),
                Text = b.Name
            });
            return View(trader);
        }

        // Edit Trader
        public IActionResult Edit(int id)
        {
            Trader trader = _traderRepository.GetById(id);
            ViewBag.GovernList = new SelectList(_governRepository.GetAll(), "Id", "Name");
            ViewBag.CityList = new SelectList(_cityRepository.GetAll(), "Id", "Name");
            ViewBag.BranchList = new SelectList(_branchRepository.GetAll(), "Id", "Name");

            return View(trader);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Trader trader)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _traderRepository.Edit(trader);
                    _traderRepository.Save();
                    return RedirectToAction("Index", "Trader");
                }
                catch
                {
                    ModelState.AddModelError("GoverId", "Please Select Governorate");
                    ModelState.AddModelError("BranchId", "Please Select Branch");
                    ModelState.AddModelError("CityId", "Please Select City");
                }
            }
            ViewBag.GovernList = new SelectList(_governRepository.GetAll(), "Id", "Name");
            ViewBag.CityList = new SelectList(_cityRepository.GetAll(), "Id", "Name");
            ViewBag.BranchList = new SelectList(_branchRepository.GetAll(), "Id", "Name");

            return View(trader);
        }

        public IActionResult getCitesByGovernrate(int govId)
        {
            List<City> cities = _cityRepository.GetAllCitiesByGovId(govId);
            return Json(cities);
        }
        //Delete Trader
        public IActionResult Delete(int id)
        {
            Trader trader = _traderRepository.GetById(id);
            if (trader == null)
            {
                return NotFound();
            }
            return View(trader);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _traderRepository.Delete(id);
            return RedirectToAction("Index");
        }

        //home 
        public IActionResult Home()
        {
            Claim nameClaim = User.Claims.FirstOrDefault(c => c.Type == "Id");
             var TraderId = int.Parse(nameClaim.Value);

            List<Order> orders = _orderRepository.GetAll().Where(o => o.TraderId == TraderId).ToList();

            OrderStatusViewModel orderStatusViewModel = new OrderStatusViewModel();

            orderStatusViewModel.NewCount = orders.Where(O => O.OrderStateId == 1).Count();
            orderStatusViewModel.pendingCount = orders.Where(O => O.OrderStateId == 2).Count();
            orderStatusViewModel.The_order_has_been_deliveredCount = orders.Where(O => O.OrderStateId == 3).Count();
            orderStatusViewModel.sent_delivered_handedCount = orders.Where(O => O.OrderStateId == 4).Count();
            orderStatusViewModel.Can_not_reachCount = orders.Where(O => O.OrderStateId == 5).Count();
            orderStatusViewModel.postponedCount = orders.Where(O => O.OrderStateId == 6).Count();
            orderStatusViewModel.Partially_deliveredCount = orders.Where(O => O.OrderStateId == 7).Count();
            orderStatusViewModel.Canceled_by_ClientCount = orders.Where(O => O.OrderStateId == 8).Count();
            orderStatusViewModel.Refused_with_paymentCount = orders.Where(O => O.OrderStateId == 9).Count();
            orderStatusViewModel.Refused_with_part_paymentCount = orders.Where(O => O.OrderStateId == 10).Count();
            orderStatusViewModel.Rejected_and_not_paidCount = orders.Where(O => O.OrderStateId == 11).Count();

            return View(orderStatusViewModel);


        }
    }
}
