using BookKart.Core.Application.EntityBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BookKart.Core.Domain.Entities
{
    [Table("Category")]
    public class Category : BaseEntity<long>
    {
        [Required]
        public virtual string Categories { get; set; }

        [JsonIgnore]
        public virtual ICollection<Book>? Books { get; set; }
    }
}
