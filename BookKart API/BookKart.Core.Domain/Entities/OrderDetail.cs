using BookKart.Core.Application.EntityBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookKart.Core.Domain.Entities
{
    [Table("OrderDetails")]
    public class OrderDetails : BaseEntity<long>
    {
        [Required]
        public virtual string ShippingId { get; set; }
        [Required]
        public virtual string ShippingAddress { get; set; }
        public virtual string? Landmark { get; set; }
        [Required]
        public virtual string City { get; set; }
        [Required]
        public virtual string State { get; set; }
        [Required]
        public virtual int Pincode { get; set; }
        [Required]
        public virtual long BookId { get; set; }
        [Required]
        public virtual long UserId { get; set; }

        [ForeignKey("BookId")]
        public virtual Book? Books { get; set; }

        [ForeignKey("UserId")]
        public virtual User? Users { get; set; }
    }
}
