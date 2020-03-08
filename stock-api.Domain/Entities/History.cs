using System;
using System.ComponentModel.DataAnnotations;

namespace stock_api.Domain.Entities
{
    public class History : BaseEntity
    {
        [Required]
        [Display(Name = "Stock Id")]
        [Range(1, int.MaxValue, ErrorMessage = "This Id cannot be zero.")]
        public int IdStock { get; set; }

        [Required]
        [Display(Name = "Oppening value")]
        [Range(0, double.MaxValue, ErrorMessage = "This value cannot be negative.")]
        public double Opening { get; set; }

        [Required]
        [Display(Name = "Closing value")]
        [Range(0, double.MaxValue, ErrorMessage = "This value cannot be negative.")]
        public double Closing { get; set; }

        [Required]
        [Display(Name = "Minimum value")]
        [Range(0, double.MaxValue, ErrorMessage = "This value cannot be negative.")]
        public double Min { get; set; }

        [Required]
        [Display(Name = "Maximum value")]
        [Range(0, double.MaxValue, ErrorMessage = "This value cannot be negative.")]
        public double Max { get; set; }

        [Required]
        [Display(Name = "Time of history")]
        [StringLength(10, ErrorMessage = "Time format is invalid.")]
       public  String Timestamp { get; set; }
    }
}
