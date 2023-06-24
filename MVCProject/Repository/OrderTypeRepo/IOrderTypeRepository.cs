using MVCProject.Models;

namespace MVCProject.Repository.OrderTypeRepo
{
    public interface IOrderTypeRepository
    {
        List<OrderType> GetAll();
    }
}
