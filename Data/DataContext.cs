using Microsoft.EntityFrameworkCore;

namespace _11_04_2022_1750.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public  DbSet<Recipe> Recipes { get; set; }
    }
}
