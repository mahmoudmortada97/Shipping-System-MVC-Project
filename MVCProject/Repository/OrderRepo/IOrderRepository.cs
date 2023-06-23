using MVCProject.Models;

namespace MVCProject.Repository.OrderRepo
{
    public interface IOrderRepository
    {
        List<Order> GetAll();
        Order GetById(int id);
        void Add(Order order);
        void Edit(Order order);
        void Delete(int id);
        void Save();
        decimal CalculateTotalPrice(int id);
    }
}
