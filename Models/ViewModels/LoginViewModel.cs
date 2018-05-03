using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Login Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Login Password")]
        public string Password { get; set; }
    }
}
