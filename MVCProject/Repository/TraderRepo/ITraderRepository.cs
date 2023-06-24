using System.Collections.Generic;
using MVCProject.Models;

namespace MVCProject.Repository.TraderRepo
{
    public interface ITraderRepository
    {
        List<Trader> GetAll();
        Trader GetById(int id);
        //Trader GetByName(string name);
        void Create(Trader trader);
        void Edit(Trader trader);
        void Delete(int id);
        void Save();
    }
}
