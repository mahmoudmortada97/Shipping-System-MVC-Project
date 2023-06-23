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

        public DeliverType DeliverType { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public Branch Branch { get; set; }

        public DateTime creationDate { get; set; } = DateTime.Now;
    }
}
