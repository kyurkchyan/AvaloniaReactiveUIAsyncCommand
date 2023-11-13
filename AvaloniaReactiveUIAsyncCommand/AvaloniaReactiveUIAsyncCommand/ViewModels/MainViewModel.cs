using System.Reactive;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using ReactiveUI;

namespace AvaloniaReactiveUIAsyncCommand.ViewModels;

public class MainViewModel : ReactiveObject
{
    public MainViewModel()
    {
        LoadCommand = ReactiveCommand.CreateFromObservable<Unit, Unit>(_ => Observable.StartAsync(LoadAsync));
    }

    public ReactiveCommand<Unit, Unit> LoadCommand { get; }

    private async Task LoadAsync(CancellationToken cancellationToken)
    {
        await Task.Delay(2000, cancellationToken);
    }
}