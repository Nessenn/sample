namespace CustomerManager.Data
{
    using System.Data.Entity;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class GenericRepository<TContext> : IAsyncRepository where TContext : DbContext, new()
    {
        public IQueryable<T> Query<T>() where T : class
        {
            return this._context.Set<T>();
        }

        public T Get<T>(params object[] keyValues) where T : class
        {
            return this.Context.Set<T>().Find(keyValues);
        }

        public async Task<T> GetAsync<T>(params object[] keyValues) where T : class
        {
            return await this._context.Set<T>().FindAsync(keyValues);
        }

        public async Task<T> GetAsync<T>(CancellationToken cancellationToken, params object[] keyValues) where T : class
        {
            return await this._context.Set<T>().FindAsync(cancellationToken, keyValues);
        }

        public T Add<T>(T entity) where T : class
        {
            this.Context.Set<T>().Add(entity);
            return entity;
        }

        public T Update<T>(T entity) where T : class
        {
            
            this.Context.Set<T>().Attach(entity);    
            this.Context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public void Remove<T>(params object[] keyValues) where T : class
        {
            var entity = this.Get<T>(keyValues);
            this.Context.Set<T>().Remove(entity);
        }

        public void SaveChanges()
        {
            this.Context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await this._context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await this._context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            this._context.Dispose();
        }

        protected TContext Context { get { return this._context; }}

        public GenericRepository()
        {
            this._context = new TContext();
        }

        private readonly TContext _context;

        public Database Database
        {
            get
            {
                return this._context.Database;
            }
        }
    }
}