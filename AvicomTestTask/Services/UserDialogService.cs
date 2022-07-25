using AvicomTestTask.DAL.Entities;
using AvicomTestTask.ViewModels;
using AvicomTestTask.Views.Windows;
using System.Collections.ObjectModel;
using System.Windows;

namespace AvicomTestTask.Services
{
    internal class UserDialogService : IUserDialog
    {
        public bool EditClient(Client client, ObservableCollection<Client> clients, ObservableCollection<Manager> managers, ObservableCollection<Status> statuses)
        {
            var clientEditorModel = new ClientEditorViewModel(client, clients, managers, statuses);

            var clientEditorWindow = new ClientEditorWindow
            {
                DataContext = clientEditorModel
            };

            if(clientEditorWindow.ShowDialog() != true) return false;

            client.Name = clientEditorModel.Name;
            client.Manager = clientEditorModel.Manager;
            client.Status = clientEditorModel.Status;

            return true;
        }

        public bool EditManager(Manager manager)
        {
            var managerEditorModel = new ManagerEditorViewModel(manager);

            var managerEditorWindow = new ManagerEditorWindow
            {
                DataContext = managerEditorModel
            };

            if (managerEditorWindow.ShowDialog() != true) return false;

            manager.Name = managerEditorModel.Name;
           

            return true;
        }

        public bool ConfirmInformation(string Information, string Caption) => MessageBox
           .Show(
                Information, Caption,
                MessageBoxButton.YesNo,
                MessageBoxImage.Information)
                == MessageBoxResult.Yes;

        public bool ConfirmWarning(string Warning, string Caption) => MessageBox
           .Show(
                Warning, Caption,
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning)
                == MessageBoxResult.Yes;

        public bool ConfirmError(string Error, string Caption) => MessageBox
           .Show(
                Error, Caption,
                MessageBoxButton.YesNo,
                MessageBoxImage.Error)
                == MessageBoxResult.Yes;

        public bool EditProduct(Product product, ObservableCollection<Product> products, ObservableCollection<ProductType> productTypes, ObservableCollection<SubscriptionTime> subscriptionTimes)
        {

            var productEditorModel = new ProductEditorViewModel(product, products, productTypes, subscriptionTimes);

            var productEditorWindow = new ProductEditorWindow
            {
                DataContext = productEditorModel
            };

            if (productEditorWindow.ShowDialog() != true) return false;

            product.Name = productEditorModel.Name;
            product.ProductType = productEditorModel.ProductType;
            if (product.ProductType.Id == 2)
                product.SubscriptionTime = null;
            else
                product.SubscriptionTime = productEditorModel.SubscriptionTime;

            return true;
        }
    }
    
}
