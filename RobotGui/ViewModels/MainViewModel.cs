using CommunityToolkit.Mvvm.ComponentModel;
using RobotGui.Models;
using System.Numerics;

namespace RobotGui.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    public string Greeting => "Welcome to Avalonia!";
    public Robot Robot { get; init; }
    public Gyroscope? Gyroscope { get; init; }

    private double _rotationSpeed;
    
    public double RotationSpeed
    {
        get
        {
            return _rotationSpeed;
        }
        set
        {
            if (value >= 0 && value <= 2)
            {

                _rotationSpeed = value;
                RotationString = string.Format("{0:N2}", _rotationSpeed);
                RotationSpeedWrong = false;
            } else
            {
                RotationString = string.Format("{0:N2}", _rotationSpeed);
                RotationSpeedWrong = true;
            }
            
        }   
    }

    [ObservableProperty]
    public bool rotationSpeedWrong;
    [ObservableProperty]
    public string rotationString;
   

    public MainViewModel()
    {
        RotationSpeed = 1.0;
        Gyroscope = App.Gyroscope;
    }

    public string X { get {return "X: " + Gyroscope.X; } } 
    public string Y { get { return "Y: " + Gyroscope.Y; } }

    public string Z { get { return "Z: " + Gyroscope.Z; } }


}
