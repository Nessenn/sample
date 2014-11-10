namespace CustomerManager.Data
{
    using System.Data.Entity;

    public class NorthwindDbContext: DbContext
    {
        public NorthwindDbContext()
            : base("NorthwindContext")
        {
            
        }
        
        public DbSet<Customer> Conferences { get; set; }
    }
}
