using Android.App;
using Android.Content.PM;
using Android.Health.Connect.DataTypes.Units;
using Android.Widget;
using Avalonia;
using Avalonia.Android;
using Java.Lang;
using Microsoft.Maui.Devices.Sensors;
using RobotGui.Models;
using System;
using Gyroscope = Microsoft.Maui.Devices.Sensors.Gyroscope;
using MyGyroscope = RobotGui.Models.Gyroscope;
namespace RobotGui.Android;

[Activity(
    Label = "RobotGui.Android",
    Theme = "@style/MyTheme.NoActionBar",
    Icon = "@drawable/icon",
    MainLauncher = true,
    ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize | ConfigChanges.UiMode)]
public class MainActivity : AvaloniaMainActivity<App>
{
    
    protected override AppBuilder CustomizeAppBuilder(AppBuilder builder)
    {
        InitGyro();
        var temp = base.CustomizeAppBuilder(builder)
            .WithInterFont();

        

        return temp;
    }



    public static void InitGyro()
    {
        var acc = Gyroscope.Default;
        var magnet = Magnetometer.Default;
        if (acc.IsSupported && magnet.IsSupported)
        {
            if (!acc.IsMonitoring)
            {
                acc.Start(SensorSpeed.Fastest);
            }
            if (!magnet.IsMonitoring)
            {
                magnet.Start(SensorSpeed.Fastest);
            }


            MyGyroscope gyro = new MyGyroscope();


            //magnet.ReadingChanged += (s, e) => gyro.MagnetometerChanged(e.Reading.MagneticField);
            magnet.ReadingChanged += ((object? sender, MagnetometerChangedEventArgs e) => gyro.AccelerationChanged(e.Reading.MagneticField));

           
            App.Gyroscope = gyro;
        }
    }

    private static void Magnet_ReadingChanged(object? sender, MagnetometerChangedEventArgs e)
    {
        throw new NotImplementedException();
    }

    public override void OnBackPressed()
    {
        var app = App.Current as App;
        app.Disconnect();
        base.OnBackPressed();
    }
}
