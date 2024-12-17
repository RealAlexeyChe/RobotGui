using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Avalonia.Platform;
using RobotGui.Models;
using RobotGui.ViewModels;
using RobotGui.Views;
using System;


namespace RobotGui;

public partial class App : Application
{
    public static Gyroscope? Gyroscope { get; set; } 

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        // Line below is needed to remove Avalonia data validation.
        // Without this line you will get duplicate validations from both Avalonia and CT

       // RuntimePlatformInfo? runtimeInfo = AvaloniaLocator.GetService<IRuntimePlatform>()?.GetRuntimeInfo();
        
       


        BindingPlugins.DataValidators.RemoveAt(0);

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainViewModel()
            };
            
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView
            {
                DataContext = new MainViewModel()
            };
           
        }

        

        base.OnFrameworkInitializationCompleted();
    }

    public void Disconnect()
    {

    }

   



}
