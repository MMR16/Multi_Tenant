using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiTenancy.Settings
{
    public class TenantSettings
    {
        public Configuration Default { get; set; }=default;
        public List<Tenant>  Tenants { get; set; }=[];
    }
}