using MVCProject.Models;

namespace MVCProject.Repository.BranchRepo
{
    public interface IBranchRepository
    {
        List<Branch> GetAll();
        Branch GetById(int id);
        void Add(Branch branch);
        void Edit(Branch branch);
        void Delete(int id);
        void Save();
    }
}