using Microsoft.EntityFrameworkCore;
using Note_Taking_App_API.Models;

namespace Note_Taking_App_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Note> Notes => Set<Note>();
    }
}
