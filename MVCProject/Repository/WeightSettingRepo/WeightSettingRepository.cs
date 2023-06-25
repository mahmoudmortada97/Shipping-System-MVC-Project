using MVCProject.Models;

namespace MVCProject.Repository.WeightSettingRepo
{
    public class WeightSettingRepository : IWeightSettingRepository
    {
        private readonly AppDbContext _context;

        public WeightSettingRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<WeightSetting> GetAll()
        {
            return _context.WeightSetting.ToList();
        }

        public WeightSetting GetById(int id)
        {
            return _context.WeightSetting.Find(id);
        }

        public void Update(WeightSetting weightSetting)
        {
            _context.WeightSetting.Update(weightSetting);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
