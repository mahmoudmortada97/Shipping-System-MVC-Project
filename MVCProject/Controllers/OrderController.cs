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
using MVCProject.ViewModel;
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
        IOrderStateRepository _orderStateRepository;


        public OrderController(IOrderRepository orderRepository , 
            IBranchRepository branchRepository ,
            IOrderTypeRepository orderTypeRepository ,
            IDeliverTypeRepository deliverTypeRepository,
            IPaymentMethodRepository paymentMethodRepository,
            IGovernRepository governRepository,
            ICityRepository cityRepository,
            IOrderStateRepository orderStateRepository
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
            
        }
        public IActionResult Index(string word)
        {

        List<Order> orders = _orderRepository.GetAll();

        List<OrderReporttWithOrderByStatusDateViewModel> ordersViewModel = new List<OrderReporttWithOrderByStatusDateViewModel>();
            


            foreach (var item in orders)
            {
                City city = _cityRepository.GetById(item.ClientCityId);
                Governorate governorate = _ghostRepository.GetById(item.ClientGovernorateId);

                OrderReporttWithOrderByStatusDateViewModel ordersViewModelItem = new OrderReporttWithOrderByStatusDateViewModel();
                ordersViewModelItem.Id = item.Id;
                ordersViewModelItem.Date = item.creationDate;
                ordersViewModelItem.Client = item.ClientName;
                ordersViewModelItem.PhoneNumber = item.ClientPhone1;
                ordersViewModelItem.City = city.Name;
                ordersViewModelItem.Governorate = governorate.Name;
                ordersViewModelItem.ShippingPrice = item.ShippingPrice;


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

            City city = _cityRepository.GetById(order.ClientCityId);

            ViewData["City"] = city.Name;
            return View(order);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Order order) {

            Claim nameClaim = User.Claims.FirstOrDefault(c => c.Type == "Id");
            order.TraderId = int.Parse(nameClaim.Value);
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

        public IActionResult GetFilteredOrders(int orderState)
        {
            List<OrderReporttWithOrderByStatusDateViewModel> filteredOrdersViewModel = new List<OrderReporttWithOrderByStatusDateViewModel>();



            List<Order> filteredOrders;

            if (orderState == 0)
            {
                filteredOrders = _orderRepository.GetAll();
            }
            else
            {
                filteredOrders = _orderRepository.GetByOrderState(orderState);
            }


            foreach (var item in filteredOrders)
            {
                City city = _cityRepository.GetById(item.ClientCityId);
                Governorate governorate = _ghostRepository.GetById(item.ClientGovernorateId);

                OrderReporttWithOrderByStatusDateViewModel ordersViewModelItem = new OrderReporttWithOrderByStatusDateViewModel();
                ordersViewModelItem.Id = item.Id;
                ordersViewModelItem.Date = item.creationDate;
                ordersViewModelItem.Client = item.ClientName;
                ordersViewModelItem.PhoneNumber = item.ClientPhone1;
                ordersViewModelItem.City = city.Name;
                ordersViewModelItem.Governorate = governorate.Name;
                ordersViewModelItem.ShippingPrice = item.ShippingPrice;

                filteredOrdersViewModel.Add(ordersViewModelItem);
            }



            return Json(filteredOrdersViewModel);
        }

    }
}
