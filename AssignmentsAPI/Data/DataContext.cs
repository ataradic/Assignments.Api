
using AssignmentsAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace AssignmentsAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Type> AssignmentsTypes { get; set; }
       
    }
}