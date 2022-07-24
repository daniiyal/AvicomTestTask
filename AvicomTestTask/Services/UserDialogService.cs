using AvicomTestTask.DAL.Entities;
using AvicomTestTask.ViewModels;
using AvicomTestTask.Views.Windows;
using System.Collections.ObjectModel;

namespace AvicomTestTask.Services
{
    internal class UserDialogService : IUserDialog
    {
        public bool Edit(Client client, ObservableCollection<Client> clients, ObservableCollection<Manager> managers, ObservableCollection<Status> statuses)
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
    }
}
