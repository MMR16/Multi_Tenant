using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MultiTenancy.Settings
{
    public class Tenant
    {
        public string Name { get; set; }
        public string TId { get; set; }
        public string? ConnectionString { get; set; }

    }
}