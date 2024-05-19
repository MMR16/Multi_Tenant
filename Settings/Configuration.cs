using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiTenancy.Settings
{
    public class Configuration
    {
        public string DbProvider { get; set; }=null!;
        public string ConnectionString { get; set; }=null!;
    }
}