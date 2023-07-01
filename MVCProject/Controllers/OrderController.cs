using Microsoft.AspNetCore.Authorization;
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
using MVCProject.Repository.TraderRepo;
using MVCProject.ViewModel;
using System.Security.Claims;

namespace MVCProject.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        IOrderRepository _orderRepository;
        IBranchRepository _branchRepository;
        IOrderTypeRepository _orderTypeRepository;
        IDeliverTypeRepository _deliverTypeRepository;
        IPaymentMethodRepository _paymentMethodRepository;
        IGovernRepository _ghostRepository;
        ICityRepository _cityRepository;
        IOrderStateRepository _orderStateRepository;
        ITraderRepository _traderRepository;


        public OrderController(IOrderRepository orderRepository , 
            IBranchRepository branchRepository ,
            IOrderTypeRepository orderTypeRepository ,
            IDeliverTypeRepository deliverTypeRepository,
            IPaymentMethodRepository paymentMethodRepository,
            IGovernRepository governRepository,
            ICityRepository cityRepository,
            IOrderStateRepository orderStateRepository,
             ITraderRepository traderRepository
            )
        {
            _orderRepository = orderRepository;   
            _branchRepository = branchRepository;
            _orderTypeRepository = orderTypeRepository;
            _deliverTypeRepository = deliverTypeRepository;
            _paymentMethodRepository = paymentMethodRepository;
            _ghostRepository = governRepository;
            _cityRepository = cityRepository;
            _orderStateRepository = orderStateRepository;
            _traderRepository = traderRepository;

            
        }
        public IActionResult Index(string word)
        {
            List<Order> orders;
            if (User.IsInRole("Trader"))
            {
                Claim nameClaim = User.Claims.FirstOrDefault(c => c.Type == "Id");
                var TraderId = int.Parse(nameClaim.Value);

               orders = _orderRepository.GetAll();
                orders = orders.Where(o => o.TraderId == TraderId).ToList();

            }
            else
            {
            orders = _orderRepository.GetAll();

            }

            List<OrderReporttWithOrderByStatusDateViewModel> ordersViewModel = new List<OrderReporttWithOrderByStatusDateViewModel>();
            


            foreach (var item in orders)
            {
                City city = _cityRepository.GetById(item.ClientCityId);
                Governorate governorate = _ghostRepository.GetById(item.ClientGovernorateId);
                OrderState orderState = _orderStateRepository.GetById(item.OrderStateId);
                Trader trader = _traderRepository.GetById(item.TraderId);

                OrderReporttWithOrderByStatusDateViewModel ordersViewModelItem = new OrderReporttWithOrderByStatusDateViewModel();
                ordersViewModelItem.Id = item.Id;
                ordersViewModelItem.Date = item.creationDate;
                ordersViewModelItem.Client = item.ClientName;
                ordersViewModelItem.PhoneNumber = item.ClientPhone1;
                ordersViewModelItem.City = city.Name;
                ordersViewModelItem.Governorate = governorate.Name;
                ordersViewModelItem.ShippingPrice = item.ShippingPrice;
                ordersViewModelItem.Status = orderState.Name;
                ordersViewModelItem.Trader = trader.Name;



                ordersViewModel.Add(ordersViewModelItem);
            }
            ViewData["OrderStates"] = _orderStateRepository.GetAll();

            return View(ordersViewModel);
        }

        public IActionResult Details(int id)
        {

            Order order = _orderRepository.GetById(id);
            return View(order);
        }
        [Authorize(Roles = "Trader")]
        public IActionResult Create()
        {
            ViewData["DeliverTypes"] = _deliverTypeRepository.GetAll();
            ViewData["OrderTypes"] = _orderTypeRepository.GetAll();
            ViewData["PaymentMethods"] = _paymentMethodRepository.GetAll();
            ViewData["Branches"] = _branchRepository.GetAll();
            ViewData["Governorates"] = _ghostRepository.GetAll();
            return View();
        }
        [Authorize(Roles = "Trader")]
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
        [Authorize(Roles = "Trader")]

        public IActionResult Edit(int id)
        {
            ViewData["DeliverTypes"] = _deliverTypeRepository.GetAll();
            ViewData["OrderTypes"] = _orderTypeRepository.GetAll();
            ViewData["PaymentMethods"] = _paymentMethodRepository.GetAll();
            ViewData["Branches"] = _branchRepository.GetAll();
            ViewData["Governorates"] = _ghostRepository.GetAll();
            
            

            Order order = _orderRepository.GetById(id);

            City city = _cityRepository.GetById(order.ClientCityId);

            ViewData["City"] = city.Name;
            return View(order);
        }
        [Authorize(Roles = "Trader")]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Order order) {

            Claim nameClaim = User.Claims.FirstOrDefault(c => c.Type == "Id");
            order.TraderId = int.Parse(nameClaim.Value);
            if (ModelState.IsValid)
            {
                order.ShippingPrice = _orderRepository.CalculateTotalPrice(order);
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
        [Authorize(Roles = "Trader")]

        public IActionResult Delete(int id)
        {
            Order order = _orderRepository.GetById(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _orderRepository.Delete(id);
            _orderRepository.Save();
            return RedirectToAction("Index");
        }



        public IActionResult Status(int id)
        {
            Order order = _orderRepository.GetById(id);
            ViewData["OrderStatus"]=_orderStateRepository.GetAll(); 


            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Status(Order order)
        {
            ViewData["OrderStatus"] = _orderStateRepository.GetAll();
            Order orderFromDB = _orderRepository.GetById(order.Id);
            orderFromDB.OrderStateId = order.OrderStateId;
            _orderRepository.Save();

            return RedirectToAction("Index");
        }

        public IActionResult Representative()
        {
            Claim nameClaim = User.Claims.FirstOrDefault(c => c.Type == "Id");
            var RepresentativeId = int.Parse(nameClaim.Value);

            List<Order> orders = _orderRepository.GetByRepresentativeId(RepresentativeId);

            return View("Represnetative",orders);

        }

        public IActionResult GetFilteredOrders(int orderState)
        {
            List<OrderReporttWithOrderByStatusDateViewModel> filteredOrdersViewModel = new List<OrderReporttWithOrderByStatusDateViewModel>();

            List<Order> filteredOrders;
            if (User.IsInRole("Trader"))
            {
                Claim nameClaim = User.Claims.FirstOrDefault(c => c.Type == "Id");
                var TraderId = int.Parse(nameClaim.Value);

                filteredOrders = _orderRepository.GetAll();
                filteredOrders = filteredOrders.Where(o => o.TraderId == TraderId).ToList();

            }
            else
            {
                filteredOrders = _orderRepository.GetAll();
            }



            if (orderState == 0)
            {
            }
            else
            {
                filteredOrders = filteredOrders.Where(o=>o.OrderStateId == orderState).ToList();
            }


            foreach (var item in filteredOrders)
            {
                City city = _cityRepository.GetById(item.ClientCityId);
                Governorate governorate = _ghostRepository.GetById(item.ClientGovernorateId);
                OrderState orderState_ = _orderStateRepository.GetById(item.OrderStateId);
                Trader trader = _traderRepository.GetById(item.TraderId);

                OrderReporttWithOrderByStatusDateViewModel ordersViewModelItem = new OrderReporttWithOrderByStatusDateViewModel();
                ordersViewModelItem.Id = item.Id;
                ordersViewModelItem.Date = item.creationDate;
                ordersViewModelItem.Client = item.ClientName;
                ordersViewModelItem.PhoneNumber = item.ClientPhone1;
                ordersViewModelItem.City = city.Name;
                ordersViewModelItem.Governorate = governorate.Name;
                ordersViewModelItem.ShippingPrice = item.ShippingPrice;
                ordersViewModelItem.Status = orderState_.Name;
                ordersViewModelItem.Trader = trader.Name;

                filteredOrdersViewModel.Add(ordersViewModelItem);
            }



            return Json(filteredOrdersViewModel);
        }

    }
}
