namespace Ardi.Domain.Shared;

public interface IBaseEntity<TKey>
{
    TKey Id { get; set; }
}