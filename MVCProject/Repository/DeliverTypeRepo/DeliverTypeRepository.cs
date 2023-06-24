using MVCProject.Models;

namespace MVCProject.Repository.DeliverTypeRepo
{
    public class DeliverTypeRepository : IDeliverTypeRepository
    {

        AppDbContext _context;

        public DeliverTypeRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<DeliverType> GetAll()
        {
            return _context.DeliverTypes.ToList();
        }
    }
}
