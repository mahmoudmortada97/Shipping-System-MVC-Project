using MVCProject.Models;

namespace MVCProject.Repository.PaymentMethodRepo
{
    public interface IPaymentMethodRepository
    {
        List<PaymentMethod> GetAll();

    }
}
