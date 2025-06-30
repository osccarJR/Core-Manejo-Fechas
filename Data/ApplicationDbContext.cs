using Microsoft.EntityFrameworkCore;
using DateCoreApp.Models;

namespace DateCoreApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<DateLog> DateLogs { get; set; }
    }
}
