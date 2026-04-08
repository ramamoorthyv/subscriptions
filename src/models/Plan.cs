namespace Subscription.Models
{
    public class Plan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public bool IsActive { get; set; } = true;

        public int PaymentFrequencyInDays { get; set; }
    }
}