using Microsoft.EntityFrameworkCore;

namespace MultiTenancy.Settings.Data
{
    public class ApplicationDbContext : DbContext
    {
        public string TenantId { get; set; }
        private readonly ITenantService _tenantService;

        public ApplicationDbContext(DbContextOptions o, ITenantService tenantService) : base(o)
        {
            _tenantService = tenantService;
            TenantId = _tenantService.GetCurrentTenant()!.TId;
        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>().HasQueryFilter(e => e.TenantId == TenantId);

        }

    }


}