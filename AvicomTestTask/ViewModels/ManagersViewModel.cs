using AvicomTestTask.DAL;
using AvicomTestTask.DAL.Entities;
using AvicomTestTask.Services;
using AvicomTestTask.Views;
using MathCore.ViewModels;
using MathCore.WPF.Commands;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AvicomTestTask.ViewModels
{
    class ManagersViewModel : ViewModel
    {

        private IRepository<Manager> _ManagersRepository;

        private ObservableCollection<Manager> _Managers;

        private IUserDialog _UserDialog;

        public ManagersViewModel(IRepository<Manager> ManagersRepository, IUserDialog UserDialog)
        {
            _ManagersRepository = ManagersRepository;
            _UserDialog = UserDialog;
        }

        public ObservableCollection<Manager> Managers
        {
            get => _Managers;
            set
            {
                Set(ref _Managers, value);
                OnPropertyChanged(nameof(ManagersView));
            }
        }

        #region Команда для загрузки данных

        private ICommand _LoadDataCommand;

        public ICommand LoadDataCommand => _LoadDataCommand
            ??= new LambdaCommandAsync(OnLoadDataCommandExecuted, CanLoadDataCommandExecute);

        private bool CanLoadDataCommandExecute() => true;

        private async Task OnLoadDataCommandExecuted()
        {
            Managers = new ObservableCollection<Manager>(await _ManagersRepository.Items.ToArrayAsync());

        }



        #endregion


        private Manager _SelectedManager;

        public Manager SelectedManager { get => _SelectedManager; set => Set(ref _SelectedManager, value); }



        #region Команда для добавления менеджера

        private ICommand _AddManagerCommand;

        public ICommand AddManagerCommand => _AddManagerCommand
            ??= new LambdaCommand(OnAddManagerCommandExecuted, CanAddManagerCommandExecute);

        private bool CanAddManagerCommandExecute() => true;

        private void OnAddManagerCommandExecuted()
        {
            var newManager = new Manager();

            if (!_UserDialog.EditManager(newManager)) return;

            _Managers.Add(_ManagersRepository.Add(newManager));

            SelectedManager = newManager;
        }



        #endregion


        #region Команда для редактирования менеджера

        private ICommand _EditManagerCommand;

        public ICommand EditManagerCommand => _EditManagerCommand
            ??= new LambdaCommand<Manager>(OnEditManagerCommandExecuted, CanEditManagerCommandExecute);

        private bool CanEditManagerCommandExecute(Manager m) => m != null || SelectedManager != null;

        private void OnEditManagerCommandExecuted(Manager m)
        {
            var managerToEdit = m ?? SelectedManager;

            if (!_UserDialog.EditManager(managerToEdit)) return;

            _ManagersRepository.Update(managerToEdit);
        }



        #endregion

        #region Команда для удаления менеджера

        private ICommand _RemoveManagerCommand;

        public ICommand RemoveManagerCommand => _RemoveManagerCommand
            ??= new LambdaCommand<Manager>(OnRemoveManagerCommandExecuted, CanRemoveManagerCommandExecute);

        private bool CanRemoveManagerCommandExecute(Manager m) => m != null || SelectedManager != null;

        private void OnRemoveManagerCommandExecuted(Manager m)
        {
            var managerToRemove = m ?? SelectedManager;

            if (!_UserDialog.ConfirmWarning($"Вы хотите удалить менеджера {managerToRemove.Name}?", "Удаление менеджера"))
                return;

            _ManagersRepository.Remove(managerToRemove.Id);

            Managers.Remove(managerToRemove);
            if (ReferenceEquals(SelectedManager, managerToRemove))
                SelectedManager = null;
        }



        #endregion
    }
}

