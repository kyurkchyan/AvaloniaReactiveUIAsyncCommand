using System.Reactive;
using System.Reactive.Linq;
using ReactiveUI;

namespace ViewModels;

public class MainViewModel : ReactiveObject
{
    public ReactiveCommand<Unit, Unit> LoadCommand { get; } = ReactiveCommand.CreateFromObservable<Unit, Unit>(_ => Observable.StartAsync(LoadAsync));

    private static async Task LoadAsync(CancellationToken cancellationToken)
    {
        await Task.Delay(2000, cancellationToken);
    }
}