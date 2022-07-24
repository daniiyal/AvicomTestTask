using AvicomTestTask.DAL.Entities;
using MathCore.ViewModels;
using System.Collections;
using System.Collections.ObjectModel;

namespace AvicomTestTask.ViewModels
{
    internal class ClientEditorViewModel : ViewModel
    {

        private int _ClientId;

        public int ClientId { get; }

        private string _Name;

        public string Name { get => _Name; set => Set(ref _Name, value); }

        private ObservableCollection<Client> Clients;
        private ObservableCollection<Manager> Managers;
        private ObservableCollection<Status> Statuses;

        private Manager _Manager;
        public Manager Manager { get => _Manager; set => Set(ref _Manager, value); }

        private Status _Status;
        public Status Status { get => _Status; set => Set(ref _Status, value); }


        //public ClientEditorViewModel() : this(new Client { Id = 1, Name="Михаил"}, clients)
        //{
            
        //}

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
