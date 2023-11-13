using System.Reactive.Disposables;
using System.Reactive.Linq;
using Avalonia.ReactiveUI;
using AvaloniaReactiveUIAsyncCommand.ViewModels;
using ReactiveUI;

namespace AvaloniaReactiveUIAsyncCommand.Views;

public partial class MainView : ReactiveUserControl<MainViewModel>
{
    public MainView()
    {
        InitializeComponent();
        this.WhenActivated(disposables =>
        {
            this.WhenAnyObservable(v => v.ViewModel!.LoadCommand.IsExecuting)
                .Select(isExecuting => isExecuting.ToString())
                .BindTo(this, v => v.LoadCommandIsBusyTextBlock.Text)
                .DisposeWith(disposables);
            this.WhenAnyObservable(v => v.ViewModel!.LoadCommand.CanExecute)
                .Select(isExecuting => isExecuting.ToString())
                .BindTo(this, v => v.LoadCommandIsExecutableTextBlock.Text)
                .DisposeWith(disposables);
            this.BindCommand(ViewModel, vm => vm.LoadCommand, v => v.LoadButton)
                .DisposeWith(disposables);
        });
    }
}