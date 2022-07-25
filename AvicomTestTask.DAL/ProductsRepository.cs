using AvicomTestTask.DAL.Context;
using AvicomTestTask.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AvicomTestTask.DAL
{
    class ProductsRepository : DbRepository<Product>
    {
        public ProductsRepository(SoftTradeDB db) : base(db)
        {
        }

        public override IQueryable<Product> Items => base.Items
            .Include(item => item.ProductType)
            .Include(item => item.SubscriptionTime);
    }
}
