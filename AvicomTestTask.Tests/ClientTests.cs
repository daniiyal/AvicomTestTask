using AvicomTestTask.DAL;
using AvicomTestTask.DAL.Context;
using AvicomTestTask.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace AvicomTestTask.Tests
{
    public class ClientTests
    {
        private SoftTradeDB softTradeDB;
        private IRepository<Client> _Clients;


        private SoftTradeDB GetDBContext()
        {
            var dbOptions = new DbContextOptionsBuilder<SoftTradeDB>()
                    .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                    .Options;


            var softTradeDB = new SoftTradeDB(dbOptions);
            return softTradeDB;
        }

        [Fact]
        public void ClientAdd()
        {
            softTradeDB = GetDBContext();

            _Clients = new DbRepository<Client>(softTradeDB);
            
            var newClient = new Client();
            newClient.Id = 1;
            newClient.Name = "TEST";
            newClient.Manager = new Manager();
            newClient.Status = new Status();

            _Clients.Add(newClient);

            softTradeDB.SaveChanges();

        }

        [Fact]
        public void ClientEdit()
        {
            softTradeDB = GetDBContext();

            _Clients = new DbRepository<Client>(softTradeDB);

            var newClient = new Client();
            newClient.Id = 1;
            newClient.Name = "TEST";
            newClient.Manager = new Manager();
            newClient.Status = new Status();
            _Clients.Add(newClient);

            newClient.Name = "TestUpd";

            _Clients.Update(newClient);

            softTradeDB.SaveChanges();

        }

        [Fact]
        public void ClientDelete()
        {
            softTradeDB = GetDBContext();

            _Clients = new DbRepository<Client>(softTradeDB);

            var newClient = new Client();
            newClient.Id = 1;
            newClient.Name = "TEST";
            newClient.Manager = new Manager();
            newClient.Status = new Status();
            _Clients.Add(newClient);


            _Clients.Remove(newClient.Id);

            softTradeDB.SaveChanges();

        }
    }
}