using AvicomTestTask.DAL.Context;
using AvicomTestTask.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AvicomTestTask.DAL
{
    public class ClientRepository : DbRepository<Client>

    {
        public ClientRepository(SoftTradeDB db) : base(db)
        {
        }

        public override IQueryable<Client> Items => base.Items
            .Include(item => item.Status)
            .Include(item => item.Manager)
            ;
    }
}
