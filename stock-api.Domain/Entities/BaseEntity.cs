using System.ComponentModel.DataAnnotations;

namespace stock_api.Domain.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        [Display(Name = "Id")]
        public virtual int Id { get; set; }
    }
}
