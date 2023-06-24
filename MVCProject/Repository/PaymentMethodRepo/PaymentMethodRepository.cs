using MVCProject.Models;
using MVCProject.Repository.OrderTypeRepo;

namespace MVCProject.Repository.PaymentMethodRepo
{
    public class PaymentMethodRepository : IPaymentMethodRepository
    {
            AppDbContext _context;

            public PaymentMethodRepository(AppDbContext context)
            {
                _context = context;
            }

            public List<PaymentMethod> GetAll()
            {
                return _context.PaymentMethods.ToList();
        }
    }
}
