namespace Ardi.Domain.Shared;

public interface IUnitOfWork
{
    Task SaveAsync();
}