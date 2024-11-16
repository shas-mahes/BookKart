using BookKart.Core.Application.EntityBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BookKart.Core.Domain.Entities
{
    [Table("Book")]
    public class Book : BaseEntity<long>
    {
        [Required]
        public virtual string Title { get; set; }
        [Required]
        public virtual string Author { get; set; }
        [Required]
        public virtual long CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category? Category { get; set; }
        [Required]
        public virtual decimal Price { get; set; }
        public virtual string? CoverFileName { get; set; }
        public virtual long Count {  get; set; }
        public virtual bool IsAvailable { get; set; }

        [JsonIgnore]
        public virtual ICollection<Cart>? Carts { get; set; }
        [JsonIgnore]
        public virtual ICollection<OrderDetails>? OrderDetails { get; set; }
    }
}
