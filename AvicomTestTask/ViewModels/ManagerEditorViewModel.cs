using AvicomTestTask.DAL.Entities;
using MathCore.ViewModels;

namespace AvicomTestTask.ViewModels
{
    internal class ManagerEditorViewModel : ViewModel
    {
        public int ManagerId { get; }

        private string _Name;

        /// <summary>Название книги</summary>
        public string Name
        {
            get => _Name; set => Set(ref _Name, value);
        }

        public ManagerEditorViewModel()
        {

        }
        public ManagerEditorViewModel(Manager manager)
        {
            ManagerId = manager.Id;
            Name = manager.Name;
        }

    }
}