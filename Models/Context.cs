using Microsoft.EntityFrameworkCore;

namespace products_categories.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
	    public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Associations> Associations {get;set;}

    }
}
