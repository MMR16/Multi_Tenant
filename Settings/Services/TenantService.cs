using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace MultiTenancy.Settings.Services
{
    public class TenantService : ITenantService
    {
        private Tenant _currentTenant;
        private readonly HttpContext? _httpContext;
        private readonly TenantSettings _tenantSettings;

        // private Tenant? _CurrentTenant;
        public TenantService(Tenant tenant, IHttpContextAccessor contextAccessor,
        IOptions<TenantSettings> tenantSettings)
        {
            _httpContext = contextAccessor.HttpContext;
            _tenantSettings = tenantSettings.Value;
            if (_httpContext is not null)
            {
                if (_httpContext.Request.Headers.TryGetValue("tenant", out var tenantId))
                {
                    SetCurrentTenant(tenantId!);
                }
                else
                {
                    throw new Exception($"{nameof(Tenant)} is not Found.");
                }
            }
        }
        public Tenant? GetCurrentTenant()
        {
            return _currentTenant;
        }

        public string? GetConnectionString()
        {
            var currentConnectionString = _currentTenant is null ?
            _tenantSettings.Default.ConnectionString :
            _currentTenant.ConnectionString;

            return currentConnectionString;
        }

        public string? GetDatabaseProvider()
        {
            return _tenantSettings.Default.DbProvider;
        }



        private void SetCurrentTenant(string tenantId)
        {
            _currentTenant = _tenantSettings.Tenants.FirstOrDefault(e => e.TId == tenantId);
            if (_currentTenant is null)
            {
                throw new Exception($"Invalid Tenant Id.");
            }
            if (string.IsNullOrEmpty(_currentTenant.ConnectionString))
            {
                _currentTenant.ConnectionString = _tenantSettings.Default.ConnectionString;

            }

        }

    }
}