using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotGui.Models
{
    public class Robot
    {
        public void Rotate(double angle) { }
        public void Move(double x, double y) { }

        Gyroscope? Gyroscope { get; set; }

        public Robot(Gyroscope? gyroscope) {
            
            if(gyroscope != null) {  Gyroscope = gyroscope; 
            gyroscope.PropertyChanged += Gyroscope_PropertyChanged;
            Gyroscope = gyroscope;
            }
        }

        private void Gyroscope_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Rotation")
            {
                //Gyroscope.Rotation.X
            
            }

        }





    }
}
