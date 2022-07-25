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
    class ProductsViewModel : ViewModel
    {

        private IRepository<Product> _ProductsRepository;
        private IRepository<ProductType> _ProductTypesRepository;
        private IRepository<SubscriptionTime> _SubscriptionTimesRepository;

        private ObservableCollection<Product> _Products;
        private ObservableCollection<ProductType> _ProductTypes;
        private ObservableCollection<SubscriptionTime> _SubscriptionTimes;

        private IUserDialog _UserDialog;

        public ObservableCollection<Product> Products
        {
            get => _Products;
            set
            {
                Set(ref _Products, value);
                OnPropertyChanged(nameof(ProductsView));
            }
        }

        public ObservableCollection<ProductType> ProductTypes
        {
            get => _ProductTypes;
            set
            {
                Set(ref _ProductTypes, value);
                OnPropertyChanged(nameof(ProductsView));
            }
        }

        public ObservableCollection<SubscriptionTime> SubscriptionTimes
        {
            get => _SubscriptionTimes;
            set
            {
                Set(ref _SubscriptionTimes, value);
                OnPropertyChanged(nameof(ProductsView));
            }
        }




        public ProductsViewModel(IRepository<Product> ProductsRepository, IRepository<ProductType> ProductTypesRepository, IRepository<SubscriptionTime> SubscriptionTimesRepository, IUserDialog UserDialog)
        {
            _ProductsRepository = ProductsRepository;
            _ProductTypesRepository = ProductTypesRepository;
            _SubscriptionTimesRepository = SubscriptionTimesRepository;
            _UserDialog = UserDialog;
        }





        private Product _SelectedProduct;

        public Product SelectedProduct { get => _SelectedProduct; set => Set(ref _SelectedProduct, value); }


        #region Команда для загрузки данных

        private ICommand _LoadDataCommand;

        public ICommand LoadDataCommand => _LoadDataCommand
            ??= new LambdaCommandAsync(OnLoadDataCommandExecuted, CanLoadDataCommandExecute);

        private bool CanLoadDataCommandExecute() => true;

        private async Task OnLoadDataCommandExecuted()
        {
            Products = new ObservableCollection<Product>(await _ProductsRepository.Items.ToArrayAsync());
            ProductTypes = new ObservableCollection<ProductType>(await _ProductTypesRepository.Items.ToArrayAsync());
            SubscriptionTimes = new ObservableCollection<SubscriptionTime>(await _SubscriptionTimesRepository.Items.ToArrayAsync());
        }

        #endregion


        #region Команда для добавления клиента

        private ICommand _AddProductCommand;

        public ICommand AddProductCommand => _AddProductCommand
            ??= new LambdaCommand(OnAddProductCommandExecuted, CanAddProductCommandExecute);

        private bool CanAddProductCommandExecute() => true;

        private void OnAddProductCommandExecuted()
        {
            var newProduct = new Product();

            if (!_UserDialog.EditProduct(newProduct, Products, ProductTypes, SubscriptionTimes)) return;

            _Products.Add(_ProductsRepository.Add(newProduct));

            SelectedProduct = newProduct;
        }



        #endregion


        #region Команда для удаления клиента

        private ICommand _RemoveProductCommand;

        public ICommand RemoveProductCommand => _RemoveProductCommand
            ??= new LambdaCommand<Product>(OnRemoveProductCommandExecuted, CanRemoveProductCommandExecute);

        private bool CanRemoveProductCommandExecute(Product p) => p != null || SelectedProduct != null;

        private void OnRemoveProductCommandExecuted(Product p)
        {
            var productToRemove = p ?? SelectedProduct;

            if (!_UserDialog.ConfirmWarning($"Вы хотите удалить продукт {productToRemove.Name}?", "Удаление продукта"))
                return;

            _ProductsRepository.Remove(productToRemove.Id);

            Products.Remove(productToRemove);
            if (ReferenceEquals(SelectedProduct, productToRemove))
                SelectedProduct = null;

        }



        #endregion


    }
}
