using Microsoft.EntityFrameworkCore;
using MVCProject.Models;

namespace MVCProject.Repository.OrderReportRepo
{
    public class OrderReportRepository : IOrderReportRepository
    {
        AppDbContext _context;

        public OrderReportRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Order> GetOrders()
        {
            return _context.Orders.Include(o => o.OrderState)
                                .Include(o => o.Trader)
                                .Include(o => o.ClientGovernorate)
                                .Include(o => o.ClientCity)
                                .Include(o=>o.Representative)
                .ToList();
        }

        public List<Order> GetOrdersByState(OrderState state)
        {
            List<Order> orders = _context.Orders.Where(o=>o.OrderStateId == state.Id).Include(o=>o.OrderState)
                                                                                     .Include(o=>o.Trader)
                                                                                     .Include(o=>o.ClientGovernorate)
                                                                                     .Include(o=>o.ClientCity)
                                                                                      .Include(o => o.Representative)

                .ToList();
            return orders;
        }
    }
}
