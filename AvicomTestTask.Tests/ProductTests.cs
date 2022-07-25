using AvicomTestTask.DAL;
using AvicomTestTask.DAL.Context;
using AvicomTestTask.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace AvicomTestTask.Tests
{
    public class ProducttTests
    {
        private SoftTradeDB softTradeDB;
        private IRepository<Product> _Products;


        private SoftTradeDB GetDBContext()
        {
            var dbOptions = new DbContextOptionsBuilder<SoftTradeDB>()
                    .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                    .Options;


            var softTradeDB = new SoftTradeDB(dbOptions);
            return softTradeDB;
        }

        [Fact]
        public void ProductAdd()
        {
            softTradeDB = GetDBContext();

            _Products = new DbRepository<Product>(softTradeDB);
            
            var newProduct = new Product();
            newProduct.Id = 1;
            newProduct.Name = "TEST";
            newProduct.Price = 1000;
            newProduct.ProductType = new ProductType();
            newProduct.SubscriptionTime = new SubscriptionTime();

            _Products.Add(newProduct);

            softTradeDB.SaveChanges();

        }

        [Fact]
        public void ProductEdit()
        {
            softTradeDB = GetDBContext();

            _Products = new DbRepository<Product>(softTradeDB);

            var newProduct = new Product();
            newProduct.Id = 1;
            newProduct.Name = "TEST";
            newProduct.Price = 1000;
            newProduct.ProductType = new ProductType();
            newProduct.SubscriptionTime = new SubscriptionTime();
            _Products.Add(newProduct);

            newProduct.Price = 1200;

            _Products.Update(newProduct);

            softTradeDB.SaveChanges();

        }

        [Fact]
        public void ProductDelete()
        {
            softTradeDB = GetDBContext();

            _Products = new DbRepository<Product>(softTradeDB);

            var newProduct = new Product();
            newProduct.Id = 1;
            newProduct.Name = "TEST";
            newProduct.Price = 1000;
            newProduct.ProductType = new ProductType();
            newProduct.SubscriptionTime = new SubscriptionTime();

            _Products.Add(newProduct);


            _Products.Remove(newProduct.Id);

            softTradeDB.SaveChanges();

        }
    }
}