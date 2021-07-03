using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<TodoList> TodoLists { get; set; }

        protected override void OnModelCreating(ModelBuilder builder){
            base.OnModelCreating(builder);

            builder.Entity<TaskItem>()
                .HasOne(item => item.TodoList)
                .WithMany(list => list.tasks)
                .HasForeignKey(item => item.ListId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}