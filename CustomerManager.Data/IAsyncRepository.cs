﻿namespace CustomerManager.Data
{
    using System.Threading;
    using System.Threading.Tasks;

    public interface IAsyncRepository : IRepository
    {
        Task<T> GetAsync<T>(params object[] keyValues) where T : class;
        Task<T> GetAsync<T>(CancellationToken cancellationToken, params object[] keyValues) where T : class;
        Task SaveChangesAsync();
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
