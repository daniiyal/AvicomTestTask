using AvicomTestTask.DAL.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvicomTestTask.DAL
{
    public static class RepositoryRegistrator
    {
        public static IServiceCollection AddRepositoriesDB(this IServiceCollection services) => services
            .AddTransient<IRepository<Client>, ClientRepository>()
            .AddTransient<IRepository<Product>, ProductsRepository>()
            .AddTransient<IRepository<Manager>, DbRepository<Manager>>()
            .AddTransient<IRepository<Status>, DbRepository<Status>>()
            .AddTransient<IRepository<ProductType>, DbRepository<ProductType>>()
            .AddTransient<IRepository<SubscriptionTime>, DbRepository<SubscriptionTime>>()
            ;
    }
}
