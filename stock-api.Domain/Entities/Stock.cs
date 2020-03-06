using System.ComponentModel.DataAnnotations;

namespace stock_api.Domain.Entities
{
    public class Stock : BaseEntity
    {
        [Required]
        [Display(Name = "Stock Code")]
        [StringLength(6, ErrorMessage = "Code format is invalid.")]
        public string Code { get; set; }

        [Required]
        [Display(Name = "Stock Name")]
        [StringLength(100, ErrorMessage = "Stock name cannot be larger than 100 caracters.")]
        public string Name { get; set; }
    }
}
