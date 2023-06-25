using MVCProject.Models;

namespace MVCProject.Repository.OrderReportRepo
{
    public interface IOrderReportRepository
    {
        List<Order> GetOrders();
        List<Order> GetOrdersByState(OrderState state);
    }
}
