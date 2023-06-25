using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;
using MVCProject.Repository.BranchRepo;
using MVCProject.Repository.CityRepo;
using MVCProject.Repository.DeliverTypeRepo;
using MVCProject.Repository.GovernorateRepo;
using MVCProject.Repository.OrderRepo;
using MVCProject.Repository.OrderStateRepo;
using MVCProject.Repository.OrderTypeRepo;
using MVCProject.Repository.PaymentMethodRepo;
using System.Security.Claims;

namespace MVCProject.Controllers
{
    public class OrderController : Controller
    {
        IOrderRepository _orderRepository;
        IBranchRepository _branchRepository;
        IOrderTypeRepository _orderTypeRepository;
        IDeliverTypeRepository _deliverTypeRepository;
        IPaymentMethodRepository _paymentMethodRepository;
        IGovernRepository _ghostRepository;
        ICityRepository _cityRepository;

        public OrderController(IOrderRepository orderRepository , 
            IBranchRepository branchRepository ,
            IOrderTypeRepository orderTypeRepository ,
            IDeliverTypeRepository deliverTypeRepository,
            IPaymentMethodRepository paymentMethodRepository,
            IGovernRepository governRepository,
            ICityRepository cityRepository
            )
        {
            _orderRepository = orderRepository;   
            _branchRepository = branchRepository;
            _orderTypeRepository = orderTypeRepository;
            _deliverTypeRepository = deliverTypeRepository;
            _paymentMethodRepository = paymentMethodRepository;
            _ghostRepository = governRepository;
            _cityRepository = cityRepository;
            
        }
        public IActionResult Index(string word)
        {

            
           List<Order> orders = _orderRepository.GetAll();
            return View(orders);
        }

        public IActionResult Details(int id)
        {

            Order order = _orderRepository.GetById(id);
            return View(order);
        }
        public IActionResult Create()
        {
            ViewData["DeliverTypes"] = _deliverTypeRepository.GetAll();
            ViewData["OrderTypes"] = _orderTypeRepository.GetAll();
            ViewData["PaymentMethods"] = _paymentMethodRepository.GetAll();
            ViewData["Branches"] = _branchRepository.GetAll();
            ViewData["Governorates"] = _ghostRepository.GetAll();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Order order)
        {
            Claim nameClaim = User.Claims.FirstOrDefault(c => c.Type == "Id");
            order.TraderId = int.Parse(nameClaim.Value);
            if (ModelState.IsValid)
            {
                order.ShippingPrice = _orderRepository.CalculateTotalPrice(order);
                _orderRepository.Add(order);
                _orderRepository.Save();
                return RedirectToAction("Index");
            }
            return View(order);
        }
        public IActionResult getCitesByGovernrate(int govId) 
        {
            List<City> cities = _cityRepository.GetAllCitiesByGovId(govId);
            return Json(cities);
        }

        public IActionResult Edit(int id)
        {
            ViewData["DeliverTypes"] = _deliverTypeRepository.GetAll();
            ViewData["OrderTypes"] = _orderTypeRepository.GetAll();
            ViewData["PaymentMethods"] = _paymentMethodRepository.GetAll();
            ViewData["Branches"] = _branchRepository.GetAll();
            ViewData["Governorates"] = _ghostRepository.GetAll();

            Order order = _orderRepository.GetById(id);
            return View(order);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Order order) { 
        
        if (ModelState.IsValid)
            {
                _orderRepository.Edit(order);
                _orderRepository.Save();
                return RedirectToAction("Index");
            }
            ViewData["DeliverTypes"] = _deliverTypeRepository.GetAll();
            ViewData["OrderTypes"] = _orderTypeRepository.GetAll();
            ViewData["PaymentMethods"] = _paymentMethodRepository.GetAll();
            ViewData["Branches"] = _branchRepository.GetAll();
            ViewData["Governorates"] = _ghostRepository.GetAll();
            return View(order);
        }
    }
}
