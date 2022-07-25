using AvicomTestTask.DAL.Entities;
using AvicomTestTask.Views.Windows;
using MathCore.ViewModels;
using System.Collections.ObjectModel;

namespace AvicomTestTask.ViewModels
{
    internal class ClientEditorViewModel : ViewModel
    {

        private int _ClientId;

        public int ClientId { get; }

        private string _Name;

        public string Name { get => _Name; set => Set(ref _Name, value); }


        private Manager _Manager;
        public Manager Manager { get => _Manager; set => Set(ref _Manager, value); }

        private Status _Status;
        public Status Status { get => _Status; set => Set(ref _Status, value); }

        #region Коллекция клиентов

        private ObservableCollection<Client> _Clients;
        private ObservableCollection<Manager> _Managers;
        private ObservableCollection<Status> _Statuses;

        public ObservableCollection<Client> Clients
        {
            get => _Clients;
            set
            {
                Set(ref _Clients, value);
                OnPropertyChanged(nameof(ClientEditorWindow));
            }
        }

        public ObservableCollection<Manager> Managers
        {
            get => _Managers;
            set
            {
                Set(ref _Managers, value);
                OnPropertyChanged(nameof(ClientEditorWindow));
            }
        }
        public ObservableCollection<Status> Statuses
        {
            get => _Statuses;
            set
            {
                Set(ref _Statuses, value);
                OnPropertyChanged(nameof(ClientEditorWindow));
            }
        }

        #endregion

        public ClientEditorViewModel()
        {

        }

        public ClientEditorViewModel(Client client, ObservableCollection<Client> clients, ObservableCollection<Manager> managers, ObservableCollection<Status> statuses)
        {
            Clients = clients;
            Managers = managers;
            Statuses = statuses;

            ClientId = client.Id;
            Name = client.Name;
            Manager = client.Manager;
            Status = client.Status;

        }

    }
}
