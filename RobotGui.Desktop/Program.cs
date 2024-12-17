using System;

using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;

namespace RobotGui.Desktop;

class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args)
    {
        BuildAvaloniaApp()
        .StartWithClassicDesktopLifetime(args);

        var lifetime = Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime;
        lifetime.ShutdownRequested += Lifetime_ShutdownRequested;
    }

    private static void Lifetime_ShutdownRequested(object? sender, ShutdownRequestedEventArgs e)
    {
        var app = Application.Current as App;
        app.Disconnect();
    }

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace();

}
