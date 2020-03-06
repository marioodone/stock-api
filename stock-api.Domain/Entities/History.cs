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
        [Range(0, float.MaxValue, ErrorMessage = "This value cannot be negative.")]
        public float Openning { get; set; }

        [Required]
        [Display(Name = "Closing value")]
        [Range(0, float.MaxValue, ErrorMessage = "This value cannot be negative.")]
        public float Closing { get; set; }

        [Required]
        [Display(Name = "Minimum value")]
        [Range(0, float.MaxValue, ErrorMessage = "This value cannot be negative.")]
        public float Min { get; set; }

        [Required]
        [Display(Name = "Maximum value")]
        [Range(0, float.MaxValue, ErrorMessage = "This value cannot be negative.")]
        public float Max { get; set; }

        [Required]
        [Display(Name = "Time of history")]
        [StringLength(10, ErrorMessage = "Time format is invalid.")]
        String Timestamp { get; set; }
    }
}
