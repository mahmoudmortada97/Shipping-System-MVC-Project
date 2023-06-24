﻿using MVCProject.Models;
using MVCProject.Repository.TraderRepo;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace MVCProject.Repository.TraderRepo
{
    public class TraderRepository : ITraderRepository
    {
        AppDbContext _context;


>>>>>>> aaf6d917aed8a49390cb37fa016f1db0c536f0f1
        public TraderRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Trader> GetAll()
        {
            return _context.Traders.Where(e => e.IsDeleted == false).ToList(); //uncommented
        }

        public Trader GetById(int id)
        {

            return _context.Traders.FirstOrDefault(e => e.Id == id && e.IsDeleted == false)!;//uncommented

        }

        public void Create(Trader trader) //changed from (Add --> Create) in all places 
        {
            _context.Traders.Add(trader); //uncommented
        }

        public void Edit(Trader trader)
        {
            _context.Traders.Entry(trader).State = Microsoft.EntityFrameworkCore.EntityState.Modified; //uncommented
        }

        public void Delete(int id)
        {
            Trader trader = _context.Traders.Find(id)!; //uncommented
            trader.IsDeleted = true; //uncommented
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}