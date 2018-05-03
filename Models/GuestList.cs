
namespace WeddingPlanner.Models
{
    public class GuestList
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }


        public int WeddingId { get; set; }
        public Wedding Wedding { get; set; }
    }
}