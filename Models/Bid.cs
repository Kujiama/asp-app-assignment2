namespace Assignment2.Models
{
    public class Bid
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string UserId { get; set; }
        public double BidAmount { get; set; }
        public DateTime Time { get; set; }

    }
}
