using Microsoft.Extensions.DependencyInjection;

namespace AvicomTestTask.ViewModels
{
    class ViewModelLocator
    {
        public MainWindowViewModel MainWindowViewModel => App.Services.GetRequiredService<MainWindowViewModel>();
    }
}
