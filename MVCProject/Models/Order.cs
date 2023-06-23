using System.ComponentModel.DataAnnotations.Schema;

namespace MVCProject.Models
{
    public class Order
    {
        public int Id { get; set; }


        public OrderType OrderType { get; set; }

        public string ClientName { get; set; }

        public string ClientPhone1 { get; set; }

        public string ClientPhone2 { get; set; }

        public string ClientEmailAddress { get; set; }

        public Governorate ClientGovernorate { get; set; }

        public City ClientCity { get; set; }

        public bool DeliverToVillage { get; set; }

        [ForeignKey("DeliverType")]
        public int DeliveryTypeId { get; set; }
        public DeliverType DeliverType { get; set; }

        [ForeignKey("PaymentMethod")]
        public int PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        [ForeignKey("Branch")]
        public int BranchId { get; set; }
        public Branch Branch { get; set; }

        public DateTime creationDate { get; set; } = DateTime.Now;

        public List<Product> Products { get; set; } = new List<Product>();

        [ForeignKey("OrderState")]
        public int OrderStateId { get; set; }
        public OrderState OrderState { get; set; }

        [ForeignKey("Trader")]
        public int TraderId { get; set; }
        public Trader Trader { get; set; }

        public bool IsDeleted { get; set; }
    }
}
