using AvicomTestTask.DAL.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace AvicomTestTask.DAL.Entities
{
    public class Product : NamedEntity
    {
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public ProductType ProductType { get; set; }
        public SubscriptionTime? SubscriptionTime { get; set; }
    }
}
