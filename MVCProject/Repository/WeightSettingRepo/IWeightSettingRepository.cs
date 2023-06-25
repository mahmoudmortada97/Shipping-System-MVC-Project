using MVCProject.Models;

namespace MVCProject.Repository.WeightSettingRepo
{
    public interface IWeightSettingRepository
    {
        IEnumerable<WeightSetting> GetAll();
        WeightSetting GetById(int id);
        void Update(WeightSetting weightSetting);
        void Save();
    }
}
