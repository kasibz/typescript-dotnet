using Microsoft.EntityFrameworkCore;
using Todov2.Models;

namespace Todov2.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        // adding the entities I wrote in the models
        public DbSet<User> User { get; set; }
        public DbSet<TodoItem> TodoItem { get; set; }

    }
}