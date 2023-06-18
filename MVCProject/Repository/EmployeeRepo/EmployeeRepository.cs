using MVCProject.Models;

namespace MVCProject.Repository.EmployeeRepo
{
    public class EmployeeRepository : IEmployeeRepository
    {
        AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Employee> GetAll()
        {
            return _context.Employees.Where(e=>e.IsDeleted == false).ToList();
        }


        public Employee GetById(int id)
        {
            return _context.Employees.FirstOrDefault(e => e.Id == id)!;
        }

        public void Add(Employee employee)
        {
            _context.Employees.Add(employee);
        }

        public void Edit(Employee employee)
        {
            _context.Employees.Entry(employee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Delete(int id)
        {
            Employee employee = _context.Employees.Find(id)!;
            employee.IsDeleted = true;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
