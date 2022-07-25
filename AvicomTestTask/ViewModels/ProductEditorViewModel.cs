using AvicomTestTask.DAL.Entities;
using AvicomTestTask.Views.Windows;
using MathCore.ViewModels;
using System.Collections.ObjectModel;

namespace AvicomTestTask.ViewModels
{
    internal class ProductEditorViewModel : ViewModel
    {

        private int _ProductId;

        public int ProductId { get; }

        private string _Name;

        public string Name { get => _Name; set => Set(ref _Name, value); }


        private ProductType _ProductType;
        public ProductType ProductType { get => _ProductType; set => Set(ref _ProductType, value); }

        private SubscriptionTime _SubscriptionTime;
        public SubscriptionTime SubscriptionTime { get => _SubscriptionTime; set => Set(ref _SubscriptionTime, value); }

        #region Коллекция клиентов

        private ObservableCollection<Product> _Products;
        private ObservableCollection<ProductType> _ProductTypes;
        private ObservableCollection<SubscriptionTime> _SubscriptionTimes;


        public ObservableCollection<Product> Products
        {
            get => _Products;
            set
            {
                Set(ref _Products, value);
                OnPropertyChanged(nameof(ProductEditorWindow));
            }
        }

        public ObservableCollection<ProductType> ProductTypes
        {
            get => _ProductTypes;
            set
            {
                Set(ref _ProductTypes, value);
                OnPropertyChanged(nameof(ProductEditorWindow));
            }
        }
        public ObservableCollection<SubscriptionTime> SubscriptionTimes
        {
            get => _SubscriptionTimes;
            set
            {
                Set(ref _SubscriptionTimes, value);
                OnPropertyChanged(nameof(ProductEditorWindow));
            }
        }

        #endregion

        public ProductEditorViewModel(Product product, ObservableCollection<Product> products, ObservableCollection<ProductType> productTypes, ObservableCollection<SubscriptionTime> subscriptionTimes)
        {
            Products = products;
            ProductTypes = productTypes;
            SubscriptionTimes = subscriptionTimes;

            ProductId = product.Id;
            Name = product.Name;
            ProductType = product.ProductType;
            SubscriptionTime = product.SubscriptionTime;

        }

    }
}