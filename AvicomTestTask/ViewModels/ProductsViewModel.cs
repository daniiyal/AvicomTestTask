using AvicomTestTask.DAL;
using AvicomTestTask.DAL.Entities;
using MathCore.ViewModels;

namespace AvicomTestTask.ViewModels
{
    class ProductsViewModel : ViewModel
    {
        private IRepository<Product> _ProductsRepository;

        public ProductsViewModel(IRepository<Product> ProductsRepository)
        {
            _ProductsRepository = ProductsRepository;
        }
    }
}
