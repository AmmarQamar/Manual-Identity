using Manual_Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Design;
using Manual_Identity.ViewModels;

namespace Manual_Identity.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<StudentViewModel> Students { get; set; }
        public DbSet<CourseViewModel> Courses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Sales_Item> Sales_Items { get; set; }
        public DbSet<SalesMainModel> SalesMains { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<Manual_Identity.Models.RegisterViewModel> RegisterViewModel { get; set; }

    }
}
