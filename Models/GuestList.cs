
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models
{
    public class GuestList
    {
        [Key]
        public int Id { get; set; }

       public User Guest { get; set; }

       public int UserId { get; set; }

       public int WeddingId { get; set; }
    }
}