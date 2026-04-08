namespace Subscription.Models
{
    public class UserPlan
    {
        public int Id { get; set; }
        public Plan Plan { get; set; }
        public string Status { get; set; }
        public DateTime Expiry { get; set; } 
        public User User { get; set; } 

    }
}