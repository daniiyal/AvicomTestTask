using AvicomTestTask.DAL;
using AvicomTestTask.DAL.Entities;
using AvicomTestTask.Services;
using MathCore.ViewModels;
using MathCore.WPF.Commands;
using System.Linq;
using System.Windows.Input;

namespace AvicomTestTask.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        private readonly IUserDialog _UserDialog;
        private readonly IRepository<Client> _Clients;
        private readonly IRepository<Product> _Products;
        private readonly IRepository<Status> _Statuses;
        private readonly IRepository<Manager> _Managers;
        private readonly IRepository<ProductType> _ProductTypes;
        private readonly IRepository<SubscriptionTime> _SubscriptionTimes;
      
        private string _Title = "OOO SoftTradePlus";

        public string Title { get=> _Title; set => Set(ref _Title, value); }


        public MainWindowViewModel(
            IUserDialog UserDialog,
            IRepository<Client> Clients,
            IRepository<Manager> Managers,
            IRepository<Product> Products,
            IRepository<Status> Statuses,
            IRepository<ProductType> ProductTypes,
            IRepository<SubscriptionTime> SubscriptionTimes)
        {
            _UserDialog = UserDialog;
            _Clients = Clients;
            _Managers = Managers;
            _Products = Products;
            _Statuses = Statuses;
            _ProductTypes = ProductTypes;
            _SubscriptionTimes = SubscriptionTimes;
        }

        #region Текущая модель-представление

        private ViewModel _CurrentModel;

        public ViewModel CurrentModel { get => _CurrentModel; private set => Set(ref _CurrentModel, value); }

        #endregion

        private ICommand _ShowClientsViewCommand;

        public ICommand ShowClientsViewCommand => _ShowClientsViewCommand
            ??= new LambdaCommand(OnShowClientsViewCommandExecuted, CanShowClientsViewCommandExecute);

        private bool CanShowClientsViewCommandExecute() => true;

        private void OnShowClientsViewCommandExecuted()
        {
            CurrentModel = new ClientsViewModel(_Clients, _Managers, _Statuses, _UserDialog);
        }


        private ICommand _ShowProductsViewCommand;

        public ICommand ShowProductsViewCommand => _ShowProductsViewCommand
            ??= new LambdaCommand(OnShowProductsViewCommandExecuted, CanShowProductsViewCommandExecutedExecute);

        private bool CanShowProductsViewCommandExecutedExecute() => true;

        private void OnShowProductsViewCommandExecuted()
        {
            CurrentModel = new ProductsViewModel(_Products, _ProductTypes, _SubscriptionTimes, _UserDialog);
        }

        private ICommand _ShowManagersViewCommand;

        public ICommand ShowManagersViewCommand => _ShowManagersViewCommand
            ??= new LambdaCommand(OnShowManagersViewCommandExecuted, CanShowManagersViewCommandExecutedExecute);

        private bool CanShowManagersViewCommandExecutedExecute() => true;

        private void OnShowManagersViewCommandExecuted()
        {
            CurrentModel = new ManagersViewModel(_Managers, _UserDialog);
        }

    }
}
