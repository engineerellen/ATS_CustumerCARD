using ATS.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ATS.Infra.Context
{
    public class AppDbContext : DbContext
    {
         public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<CustomerCard> CustomerCard { get; set; }
    }
}