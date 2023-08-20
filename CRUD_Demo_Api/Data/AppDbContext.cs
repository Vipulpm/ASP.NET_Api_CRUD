using CRUD_Demo_Api.Model;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Demo_Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> option) : base (option)
        {
            
        }

        public DbSet <Product> Products { get; set; }
    }
}
