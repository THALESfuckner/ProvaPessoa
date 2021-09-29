using provagui.Models;
using Microsoft.EntityFrameworkCore;

namespace provagui.Data
{
    public class DataContext : DbContext
    {
        
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Pessoa> Pessoa { get; set; }
        
    }
}

