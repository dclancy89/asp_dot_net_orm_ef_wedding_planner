using System;
using System.ComponentModel.DataAnnotations;


namespace WeddingPlanner.Models
{
    public class WeddingViewModel
    {
        [Required]
        [Display(Name = "Wedder One")]
        public string WedderOne { get; set; }

        [Required]
        [Display(Name = "Wedder Two")]
        public string WedderTwo { get; set; }

      [Required]
        [Display(Name = "Wedding Date")]
        public DateTime WeddingDate { get; set; }

        [Required]
        [Display(Name = "Wedding Address")]
        public string WeddingAddress { get; set; }
    }
}