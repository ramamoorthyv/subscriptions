namespace Subscription.Models
{
    public class Plan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int PaymentFrequencyInDays { get; set; }
    }
}