using Microsoft.EntityFrameworkCore;
using PCSProject.Domain;

namespace PCSProject.Database
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<QualificationList> QualificationLists { get; set; }
        public virtual DbSet<Emp_Qualification> Emp_Qualifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
