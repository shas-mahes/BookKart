using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using BookKart.Core.Application.Interface;

namespace BookKart.Core.Application.EntityBase
{
    public abstract class BaseEntity<TKey> : IBaseEntity<TKey>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual TKey Id { get; set; }

        [Required]
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime? ModifiedDate { get; set; }

        [Required]
        [MaxLength(200)]
        public virtual string CreatedBy { get; set; }

        [MaxLength(200)]
        [AllowNull]
        public virtual string? ModifiedBy { get; set; }
    }
}
