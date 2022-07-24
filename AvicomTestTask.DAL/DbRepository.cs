using AvicomTestTask.DAL.Context;
using AvicomTestTask.DAL.Entities;
using AvicomTestTask.DAL.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AvicomTestTask.DAL
{
    class DbRepository<T> : IRepository<T> where T : Entity, new()
    {
        private readonly SoftTradeDB _db;

        private readonly DbSet<T> _Set;

        public DbRepository(SoftTradeDB db)
        {

            _db = db;
            _Set = db.Set<T>();
        }
        public virtual IQueryable<T> Items => _Set;

        public T Add(T item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            _db.Entry(item).State = EntityState.Added;
            _db.SaveChanges();
            return item;
        }

        public async Task<T> AddAsync(T item, CancellationToken Cancel = default)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            _db.Entry(item).State = EntityState.Added;
            await _db.SaveChangesAsync(Cancel).ConfigureAwait(false);
            return item;
        }

        public T Get(int id) => Items.SingleOrDefault(item => item.Id == id);

        public async Task<T> GetAsync(int id, CancellationToken Cancel = default) => await Items
            .SingleOrDefaultAsync(item => item.Id == id)
            .ConfigureAwait(false);

        public void Remove(int id)
        {
            _db.Remove(new T { Id = id });
            _db.SaveChanges();
        }

        public async Task RemoveAsync(int id, CancellationToken Cancel = default)
        {
            _db.Remove(new T { Id = id });
            await _db.SaveChangesAsync(Cancel).ConfigureAwait(false);
        }

        public void Update(T item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();

        }

        public async Task UpdateAsync(T item, CancellationToken Cancel = default)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            _db.Entry(item).State = EntityState.Modified;
            await _db.SaveChangesAsync(Cancel).ConfigureAwait(false);
        }
    }
    
    class ProductsRepository : DbRepository<Product>
    {
        public ProductsRepository(SoftTradeDB db) : base(db)
        {
        }

        public override IQueryable<Product> Items => base.Items
            .Include(item => item.ProductType)
            .Include(item => item.SubscriptionTime);
    }

    class ClientRepository : DbRepository<Client>
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
