using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;
using MVCProject.Repository.OrderRepo;
using MVCProject.Repository.OrderReportRepo;
using MVCProject.Repository.OrderStateRepo;
using MVCProject.Repository.OrderTypeRepo;
using MVCProject.ViewModel;

namespace MVCProject.Controllers
{
    public class OrderReportController : Controller
    {
        IOrderReportRepository _orderReportRepository;
        IOrderStateRepository _orderStateRepository;

        public OrderReportController(IOrderReportRepository orderReportRepository, IOrderStateRepository orderStateRepository
)
        {
            _orderReportRepository = orderReportRepository;
            _orderStateRepository = orderStateRepository;

        }
        public IActionResult Index()
        {
            List<OrderReporttWithOrderByStatusDateViewModel> ordersViewModel = new List<OrderReporttWithOrderByStatusDateViewModel>();

            List<Order> orders = _orderReportRepository.GetOrders();


            foreach (var item in orders)
            {
                OrderReporttWithOrderByStatusDateViewModel ordersViewModelItem= new OrderReporttWithOrderByStatusDateViewModel();
                ordersViewModelItem.SerialNumber = item.Id;
                ordersViewModelItem.Status = item.OrderState.Name;
                ordersViewModelItem.Trader = item.Trader.Name;
                ordersViewModelItem.Client = item.ClientName;
                ordersViewModelItem.PhoneNumber = item.ClientPhone1;
                ordersViewModelItem.Governorate = item.ClientGovernorate.Name;
                ordersViewModelItem.City = item.ClientCity.Name;
                ordersViewModelItem.OrderPrice = item.OrderPrice;
                ordersViewModelItem.OrderPriceRecieved = item.OrderPriceRecieved;
                ordersViewModelItem.ShippingPrice = item.ShippingPrice;
                ordersViewModelItem.ShippingPriceRecived = item.ShippingPriceRecived;
                ordersViewModelItem.CompanyRate = (item.Representative.CompanyPercentageOfOrder   * ordersViewModelItem.ShippingPrice ) / 100;
                ordersViewModelItem.Date = item.creationDate;
                ordersViewModel.Add(ordersViewModelItem);

            }
            ViewData["OrderStates"] = _orderStateRepository.GetAll();
            return View(ordersViewModel);
        }
    }
}
