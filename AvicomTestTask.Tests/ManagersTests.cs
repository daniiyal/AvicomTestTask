using AvicomTestTask.DAL;
using AvicomTestTask.DAL.Context;
using AvicomTestTask.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace AvicomTestTask.Tests
{
    public class ManagerTests
    {
        private SoftTradeDB softTradeDB;
        private IRepository<Manager> _Manager;


        private SoftTradeDB GetDBContext()
        {
            var dbOptions = new DbContextOptionsBuilder<SoftTradeDB>()
                    .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                    .Options;


            var softTradeDB = new SoftTradeDB(dbOptions);
            return softTradeDB;
        }

        [Fact]
        public void ManagerAdd()
        {
            softTradeDB = GetDBContext();

            _Manager = new DbRepository<Manager>(softTradeDB);
            
            var newManager = new Manager();
            newManager.Id = 1;
            newManager.Name = "TEST";


            _Manager.Add(newManager);

            softTradeDB.SaveChanges();

        }

        [Fact]
        public void ManagerEdit()
        {
            softTradeDB = GetDBContext();

            _Manager = new DbRepository<Manager>(softTradeDB);

            var newManager = new Manager();
            newManager.Id = 1;
            newManager.Name = "TEST";

            _Manager.Add(newManager);

            newManager.Name = "TestUpd";

            _Manager.Update(newManager);

            softTradeDB.SaveChanges();

        }

        [Fact]
        public void ManagerDelete()
        {
            softTradeDB = GetDBContext();

            _Manager = new DbRepository<Manager>(softTradeDB);

            var newManager = new Manager();
            newManager.Id = 1;
            newManager.Name = "TEST";


            _Manager.Add(newManager);


            _Manager.Remove(newManager.Id);

            softTradeDB.SaveChanges();

        }
    }
}