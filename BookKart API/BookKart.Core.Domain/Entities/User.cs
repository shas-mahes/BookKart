using BookKart.Core.Application.EntityBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BookKart.Core.Domain.Entities
{
    [Table("User")]
    public class User : BaseEntity<long>
    {
        [Required]
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        [Required]
        public virtual string EmailId { get; set; }
        [Required]
        public virtual string Password { get; set; }
        [Required]
        public virtual string Contact { get; set; }
        [Required]
        public virtual long RoleId { get; set; }
        [ForeignKey("RoleId")]
        public virtual UserRole? Role { get; set; }

        [JsonIgnore]
        public virtual Cart? Cart { get; set; }
        [JsonIgnore]
        public virtual ICollection<OrderDetails>? OrderDetails { get; set; }
    }
}
