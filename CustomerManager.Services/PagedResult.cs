namespace CustomerManager.Services
{
    using System.Linq;

    public class PagedResult<TData>
    {
        public int Total { get; set; }

        public IQueryable<TData> Data { get; set; }
    }
}