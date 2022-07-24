using AvicomTestTask.DAL;
using AvicomTestTask.DAL.Entities;
using MathCore.ViewModels;

namespace AvicomTestTask.ViewModels
{
    class ManagersViewModel : ViewModel
    {

        private IRepository<Manager> _ManagersRepository;

        public ManagersViewModel(IRepository<Manager> ManagersRepository)
        {
            _ManagersRepository = ManagersRepository;
        }
    }
}
