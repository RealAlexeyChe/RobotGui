using Avalonia.Controls;
using Avalonia.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace RobotGui.Views;

public partial class MainView : UserControl
{
   

    
    public MainView()
    {
        
        InitializeComponent();
    }

    private void Slider_ValueChanged(object? sender, Avalonia.Controls.Primitives.RangeBaseValueChangedEventArgs e)
    {
        var vm = this.DataContext as ViewModels.MainViewModel;
        vm.RotationSpeed = (double)e.NewValue;

    }

    private void TextBox_KeyUp(object? sender, KeyEventArgs e)
    {
        if (e.Key != Key.Enter) return;
        var tb = sender as TextBox;
        CheckRotationValue(tb.Text);
        
    }
    private void TextBox_LostFocus(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        
        var tb = sender as TextBox;
        CheckRotationValue(tb.Text);
        var vm = this.DataContext as ViewModels.MainViewModel;
        tb.Text = vm.RotationString;
    }
    private void CheckRotationValue(string text)
    {
        var vm = this.DataContext as ViewModels.MainViewModel;
        RotSlider.Focus();
        double temp = 0;
        if (double.TryParse(text, out temp))
        {
            vm.RotationSpeed = temp;
            RotSlider.Value = vm.RotationSpeed;
        }
        
    }

}

