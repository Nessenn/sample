namespace CustomerManager.Services
{
    public class PagedRequest
    {
        public int Page { get; private set; }

        public int PageSize { get; private set; }
        
        public PagedRequest(int page, int pageSize){
            this.Page = page > 0 ? page - 1 : page;
            this.PageSize = pageSize;
        }
    }
}