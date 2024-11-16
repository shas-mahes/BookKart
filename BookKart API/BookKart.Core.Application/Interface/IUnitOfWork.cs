namespace BookKart.Core.Application.Interface;

public interface IUnitOfWork : IDisposable
{
    Task<int> CommitAsync();
    int Commit();
}
