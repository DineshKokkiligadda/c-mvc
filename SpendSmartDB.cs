using Microsoft.EntityFrameworkCore;
namespace Web.Models
{
    public class SpendSmartDB : DbContext
    {
        public DbSet<Expence> Expence { get; set; }
        public SpendSmartDB(DbContextOptions<SpendSmartDB> options) : base(options) { }
    }
}
