using MVCProject.Models;

namespace MVCProject.Repository.AccountRepo
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDbContext _context;
        public AccountRepository(AppDbContext context)
        {

            _context = context;

        }

        public Employee FindEmployee(string email, string password)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.Email == email && e.Password == password);
            return employee;
        }

        public Representative FindRepresentative(string email, string password)
        {
            var representative = _context.Representatives.FirstOrDefault(e => e.Email == email && e.Password == password);
            return representative;
        }

        public Trader FindTrader(string email, string password)
        {
            var trader = _context.Traders.FirstOrDefault(e => e.Email == email && e.Password == password);
            return trader;
        }
    }

}
