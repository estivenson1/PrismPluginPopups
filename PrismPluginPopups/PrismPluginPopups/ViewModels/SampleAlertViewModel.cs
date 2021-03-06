using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismPluginPopups.ViewModels
{
    public class SampleAlertViewModel : BindableBase, IDialogAware
    {
        public SampleAlertViewModel()
        {
            CloseCommand = new DelegateCommand(() =>
            {
                var p = new DialogParameters
                {
                    { "callbackMessage", "Hello from the Dialog" }
                };
                RequestClose(p);
            });
        }

        public event Action<IDialogParameters> RequestClose;

        private string _message;
        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        public DelegateCommand CloseCommand { get; }

        public bool CanCloseDialog() => true;

        public void OnDialogClosed()
        {
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            // Taken care of by IAutoInitialize
        }
    }
}
