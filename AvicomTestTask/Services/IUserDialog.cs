using AvicomTestTask.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvicomTestTask.Services
{
    internal interface IUserDialog
    {
        bool EditManager(Manager manager);

        bool EditClient(Client client, ObservableCollection<Client> clients, ObservableCollection<Manager> managers, ObservableCollection<Status> statuses);

        bool ConfirmInformation(string Information, string Caption);

        bool ConfirmWarning(string Warning, string Caption);

        bool ConfirmError(string Error, string Caption);
        bool EditProduct(Product newProduct, ObservableCollection<Product> products, ObservableCollection<ProductType> productTypes, ObservableCollection<SubscriptionTime> subscriptionTimes);
    }
}
