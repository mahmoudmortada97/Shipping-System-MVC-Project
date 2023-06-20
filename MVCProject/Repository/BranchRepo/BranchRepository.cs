using MVCProject.Models;

namespace MVCProject.Repository.BranchRepo
{
    public class BranchRepository:IBranchRepository
    {
        AppDbContext _context;


        public BranchRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Branch branch)
        {
            _context.Branches.Add(branch);
        }

        public void Delete(int id)
        {
            Branch branch = GetById(id);
            branch.IsDeleted = true;
        }

        public void Edit(Branch branch)
        {
            _context.Entry(branch).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public List<Branch> GetAll()
        {
            return _context.Branches.Where(b => b.IsDeleted == false).ToList();
        }

        public Branch GetById(int id)
        {
            return _context.Branches.FirstOrDefault(i => i.Id == id && i.IsDeleted == false)!;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
