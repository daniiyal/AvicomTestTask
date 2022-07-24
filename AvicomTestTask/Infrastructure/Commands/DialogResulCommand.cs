using System;
using System.Windows.Input;

namespace AvicomTestTask.Infrastructure.Commands
{
    class DialogResulCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool? DialogResult { get; set; }

        public bool CanExecute(object? parameter) => App.ActiveWindow != null;

        public void Execute(object parameter)
        {
            if (!CanExecute(parameter)) return;


            var dialogResult = DialogResult;

            if (parameter != null)
                dialogResult = Convert.ToBoolean(parameter);


            var window = App.CurrentWindow;
            window.DialogResult = dialogResult;
            window.Close();
        }
    }
}
