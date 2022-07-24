using AvicomTestTask.DAL;
using AvicomTestTask.DAL.Entities;
using AvicomTestTask.Services;
using AvicomTestTask.Views;
using MathCore.ViewModels;
using MathCore.WPF.Commands;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AvicomTestTask.ViewModels
{
    class ClientsViewModel : ViewModel
    {
        private IRepository<Client> _ClientsRepository;
        private IRepository<Manager> _ManagerRepository;
        private IRepository<Status> _StatusRepository;

        private IUserDialog _UserDialog;

        #region Коллекция клиентов

        private ObservableCollection<Client> _Clients;
        private ObservableCollection<Manager> _Managers;
        private ObservableCollection<Status> _Statuses;

        public ObservableCollection<Client> Clients { 
            get => _Clients;
            set { 
                Set(ref _Clients, value);
                OnPropertyChanged(nameof(ClientsView));
            } 
        }

        public ObservableCollection<Manager> Managers
        {
            get => _Managers;
            set
            {
                Set(ref _Managers, value);
                OnPropertyChanged(nameof(ClientsView));
            }
        }
        public ObservableCollection<Status> Statuses
        {
            get => _Statuses;
            set
            {
                Set(ref _Statuses, value);
                OnPropertyChanged(nameof(ClientsView));
            }
        }

        #endregion


        public ClientsViewModel(IRepository<Client> ClientsRepository,  IRepository<Manager> ManagerRepository, IRepository<Status> StatusRepository, IUserDialog UserDialog)
        {
            _ClientsRepository = ClientsRepository;
            _ManagerRepository = ManagerRepository;
            _StatusRepository = StatusRepository;
            _UserDialog = UserDialog;
        }

        private Client _SelectedClient;

        public Client SelectedClient { get => _SelectedClient; set=>Set(ref _SelectedClient, value); }


        #region Команда для загрузки данных

        private ICommand _LoadDataCommand;

        public ICommand LoadDataCommand => _LoadDataCommand
            ??= new LambdaCommandAsync(OnLoadDataCommandExecuted, CanLoadDataCommandExecute);

        private bool CanLoadDataCommandExecute() => true;

        private async Task OnLoadDataCommandExecuted()
        {

            Clients = new ObservableCollection<Client>(await _ClientsRepository.Items.ToArrayAsync());
            Managers = new ObservableCollection<Manager>(await _ManagerRepository.Items.ToArrayAsync());
            Statuses = new ObservableCollection<Status>(await _StatusRepository.Items.ToArrayAsync());
        }



        #endregion



        #region Команда для добавления клиента

        private ICommand _AddClientCommand;

        public ICommand AddClientCommand => _AddClientCommand
            ??= new LambdaCommand(OnAddClientCommandExecuted, CanAddClientCommandExecute);

        private bool CanAddClientCommandExecute() => true;

        private void OnAddClientCommandExecuted()
        {
            var newClient = new Client();

           if (!_UserDialog.Edit(newClient, Clients, Managers, Statuses)) return;

            _Clients.Add(_ClientsRepository.Add(newClient));

            SelectedClient = newClient;
        }



        #endregion


        #region Команда для удаления клиента

        private ICommand _RemoveClientCommand;

        public ICommand RemoveClientCommand => _RemoveClientCommand
            ??= new LambdaCommand<Client>(OnRemoveClientCommandExecuted, CanRemoveClientCommandExecute);

        private bool CanRemoveClientCommandExecute(Client c) => c != null || SelectedClient != null;

        private void OnRemoveClientCommandExecuted(Client c)
        {
            var clientToRemove = c ?? SelectedClient;
            
        }



        #endregion
    }
}
