using MVCProject.Models;

namespace MVCProject.Repository.AccountRepo
{
    public interface IAccountRepository
    {
        Employee FindEmployee(string email,string password);
        Trader FindTrader(string email, string password);
        Representative FindRepresentative(string email, string password);

    }
}
