namespace MultiTenancy.Models
{
    public class Product:ITenant
    {
        public int Id { get; set; }
        public string Name { get; set; }=null;
        public string Description { get; set; }=null ;
        public int Rate { get; set; }
        public int MyProperty { get; set; }
        public string TenantId { get; set; }=null!;
    }
}