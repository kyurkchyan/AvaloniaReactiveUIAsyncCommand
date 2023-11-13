using System.Reactive.Disposables;
using System.Reactive.Linq;
using ReactiveUI;
using ViewModels;

namespace Maui;

public partial class MainPage
{
    public MainPage()
    {
        InitializeComponent();
        this.BindingContext = new MainViewModel();
        this.WhenActivated(disposables =>
        {
            this.WhenAnyObservable(v => v.ViewModel!.LoadCommand.IsExecuting)
                .Select(isExecuting => isExecuting.ToString())
                .BindTo(this, v => v.LoadCommandIsBusyLabel.Text)
                .DisposeWith(disposables);
            this.WhenAnyObservable(v => v.ViewModel!.LoadCommand.CanExecute)
                .Select(isExecuting => isExecuting.ToString())
                .BindTo(this, v => v.LoadCommandIsExecutableLabel.Text)
                .DisposeWith(disposables);
            this.BindCommand(ViewModel, vm => vm.LoadCommand, v => v.LoadButton)
                .DisposeWith(disposables);
        });
    }
}