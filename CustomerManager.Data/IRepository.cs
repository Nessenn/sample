namespace CustomerManager.Data
{
    using System;
    using System.Linq;

    public interface IRepository : IDisposable
    {
        IQueryable<T> Query<T>() where T : class;
        T Get<T>(params object[] keyValues) where T : class;
        T Add<T>(T entity) where T : class;
        T Update<T>(T entity) where T : class;
        void Remove<T>(params object[] keyValues) where T : class;
        void SaveChanges();
    }
}