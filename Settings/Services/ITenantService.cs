using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiTenancy.Settings.Services
{
    public interface ITenantService
    {
        public string? GetDatabaseProvider();
        public string? GetConnectionString();
        public Tenant? GetCurrentTenant();

    }
}