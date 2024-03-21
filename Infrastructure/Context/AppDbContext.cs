using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TodoGroup> TodoGroups { get; set; }
        public DbSet<TodoList> TodoLists { get; set; }
        public DbSet<Todo> Todos { get; set; }
    }
}
