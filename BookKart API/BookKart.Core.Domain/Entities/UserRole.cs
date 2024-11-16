using BookKart.Core.Application.EntityBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookKart.Core.Domain.Entities
{
    [Table("UserRole")]
    public class UserRole : BaseEntity<long>
    {
        [Required]
        public virtual string Role { get; set; }

        public virtual ICollection<User>? Users { get; set; }
    }
}
