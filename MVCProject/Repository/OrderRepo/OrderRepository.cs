using Microsoft.EntityFrameworkCore;
using MVCProject.Models;
using Microsoft.EntityFrameworkCore;
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
            return _context.Orders.Where(e => e.IsDeleted == false).Include(o=>o.ClientGovernorate).Include(o=>o.ClientCity).ToList();
        }


        public Order GetById(int id)
        {
            return _context.Orders.FirstOrDefault(e => e.Id == id && e.IsDeleted == false)!;
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

        public decimal CalculateTotalPrice(Order order)
        {
            //Order order = _context..Include(o => o.Products)
            //                                .Include(o => o.ClientCity)
            //                                .Include(o => o.OrderType)
            //                                .Include(o=>o.Trader)
            //                                    .ThenInclude(t=>t.SpecialPriceForCities)
            //                                    .FirstOrDefault()!;


            //Special Price for Trader within Specific City 
            //foreach (var item in order.Trader.SpecialPriceForCities)
            //{
            //    if(item.City == order.ClientCity)
            //        {
            //            price += item.Shippingprice;
            //        break;
            //        }   
            //}
            decimal Price = 0;

            var CityId = order.ClientCityId;
            var DeliverTypeId = order.DeliveryTypeId;

            Price += CalculateCityPrice(CityId);     //City Price

            Price += CalculateOrderTypePrice(DeliverTypeId);  //Order Type Price

            Price += CalculatePriceIfShippingToVillage(order);  //Shipping To Village Price

            Price += CalculatePriceOfOrderTotalWeigth(GetOrderWeight(order)); //Total Size Weight

            return Price;
        }


        public decimal CalculateCityPrice(int  id)
        {
            City city = _context.Cities.Find(id);
            var cityPrice = city.ShippingCost;
            return cityPrice;
        }

        public decimal CalculateOrderTypePrice(int deliverTypeId)
        {
            DeliverType deliverType = _context.DeliverTypes.Find(deliverTypeId);
            var orderPrice = deliverType.Price;
            return orderPrice;
        }
        public decimal CalculatePriceIfShippingToVillage(Order order)
        {
            decimal shippingToVillagePrice;

            if (order.DeliverToVillage == true)
            {
                shippingToVillagePrice = 30;
            }
            else
            {
                shippingToVillagePrice = 0;
            }
            return shippingToVillagePrice;
        }

        public decimal GetOrderWeight(Order order)
        {
            decimal totalOrderWeigth = 0;
            foreach (var product in order.Products)
            {
                totalOrderWeigth += product.Weight * product.Quantity;
            }
            return totalOrderWeigth;
        }
        public decimal CalculatePriceOfOrderTotalWeigth(decimal totalWeight)
        {
            if (totalWeight > _context.WeightSetting.Select(ws => ws.DefaultSize).FirstOrDefault())
            {
                return (totalWeight - _context.WeightSetting.Select(ws => ws.DefaultSize).FirstOrDefault())
                    * _context.WeightSetting.Select(ws => ws.PriceForEachExtraKilo).FirstOrDefault();
            }
            return _context.WeightSetting.Select(ws => ws.DefaultSize).FirstOrDefault();
        }
    }
}