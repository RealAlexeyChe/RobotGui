using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotGui.Models
{
    [ObservableObject]
    public partial class Gyroscope
    {
        [ObservableProperty]
        private System.Numerics.Vector3 _rotation;
        [ObservableProperty]
        private int _x = 0;
        [ObservableProperty]
        private int _y = 0;
        [ObservableProperty]
        private int _z = 0;


        //[ObservableProperty]
        //private int _mx = 0;
        //[ObservableProperty]
        //private int _my = 0;
        //[ObservableProperty]
        //private int _mz = 0;


        private double? _rx = null;
        private double? _ry;
        private double? _rz;

        //public void MagnetometerChanged(System.Numerics.Vector3 vec)
        //{
        //    Mx = (int)vec.X;
        //    My = (int)vec.Y;
        //    Mz = (int)vec.Z;
        //}

        public void AccelerationChanged(System.Numerics.Vector3 vec)
        {
            Rotation = vec;

            if (_rx is null)
            {
                _rx = vec.X;
                _ry = vec.Y;
                _rz = vec.Z;
            }
            //if (diff(X, _rx)) X = (int)_rx;
            //if (diff(Y, _ry)) Y = (int)_ry;
            //if (diff(Z, _rz)) Z = (int)_rz;


            X = (int) (vec.X - _rx);
            Y = (int) (vec.Y - _ry);
            Z = (int) (vec.Z - _rz);

            //if (Math.Abs(X) < 10) X = 0;
            //if (Math.Abs(Y) < 10) Y = 0;
            //if (Math.Abs(Z) < 10) Z = 0;
        }

        private bool diff(int a, double b)
        {
            return (Math.Abs(a-b)) > 1;
        }
        
    }
}
