using MVCProject.Models;

namespace MVCProject.Repository.OrderStateRepo
{
    public class OrderStateRepository : IOrderStateRepository
    {
        AppDbContext _context;

        public OrderStateRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<OrderState> GetAll()
        {
            return _context.OrderStates.ToList();
        }
        public OrderState GetById(int id)
        {
            return _context.OrderStates.FirstOrDefault(e => e.Id == id )!;
        }
    }
}
