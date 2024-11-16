namespace BookKart.Core.Application.Interface;

public interface IBaseEntity<TKey>
{
    public TKey Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public string CreatedBy { get; set; }
    public string ModifiedBy { get; set; }
}
