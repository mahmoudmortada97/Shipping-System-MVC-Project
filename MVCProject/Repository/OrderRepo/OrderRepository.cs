using Microsoft.EntityFrameworkCore;
using MVCProject.Models;

namespace MVCProject.Repository.OrderRepo
{
    public class OrderRepository:IOrderRepository
    {
        AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Order> GetAll()
        {
            return _context.Orders.Where(e => e.IsDeleted == false).ToList();
        }


        public Order GetById(int id)
        {
            return _context.Orders.FirstOrDefault(e => e.Id == id && e.IsDeleted == true)!;
        }

        public void Add(Order order)
        {
            _context.Orders.Add(order);
        }

        public void Edit(Order order)
        {
            _context.Orders.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Delete(int id)
        {
            Order order = _context.Orders.Find(id)!;
            order.IsDeleted = true;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public decimal CalculateTotalPrice(int id)
        {
            Order order = _context.Orders.Include(o => o.Products)
                                            .Include(o => o.ClientCity)
                                            .Include(o => o.OrderType)
                                            .Include(o=>o.Trader)
                                                .ThenInclude(t=>t.SpecialPriceForCities)
                                                .FirstOrDefault();

            decimal price = 0;
            decimal productsWeight = 0;


            //Special Price for Trader within Specific City 
            //foreach (var item in order.Trader.SpecialPriceForCities)
            //{
            //    if(item.City == order.ClientCity)
            //        {
            //            price += item.Shippingprice;
            //        break;
            //        }   
            //}

            price += order.OrderType.Price;


            if (order.OrderType.Name != "Normal")
            {
                price += order.ClientCity.ShippingCost;

            }


            if (order.DeliverToVillage == true)  //Static Delivery to Village
            {
                price += 30;
            }
            //Get Products Weight make it in another function
            foreach (var item in order.Products)
            {
                productsWeight += item.Weight;
            }
            if (productsWeight > _context.WeightSetting.Select(ws => ws.DefaultSize).FirstOrDefault()) {
                price += (productsWeight - _context.WeightSetting.Select(ws => ws.DefaultSize).FirstOrDefault())
                    *     _context.WeightSetting.Select(ws=>ws.PriceForEachExtraKilo).FirstOrDefault();
            } 

            return price;
        }
    }
}
