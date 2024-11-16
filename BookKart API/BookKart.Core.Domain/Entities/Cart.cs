using BookKart.Core.Application.EntityBase;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BookKart.Core.Domain.Entities
{
    [Table("Cart")]
    [Index(nameof(BookId), nameof(UserId), IsUnique = true)]
    public class Cart : BaseEntity<long>
    {
        [Required]
        public virtual long Quantity { get; set; }
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
