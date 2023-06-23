using Microsoft.AspNetCore.Mvc;
using MVCProject.Repository.OrderRepo;

namespace MVCProject.Controllers
{
    public class OrderController : Controller
    {
        IOrderRepository _orderRepository;
        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;   
        }
        public IActionResult Index()
        {
            
            return View();
        }
    }
}
