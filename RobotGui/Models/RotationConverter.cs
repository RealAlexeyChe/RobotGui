using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace RobotGui.Models
{
    public static class RotationConverter
    {
        public static double RotationSpeed { get; set; } = 1.0;
        public static double MovementSpeed { get; set; } = 1.0;
        public struct Movement
        {
            public Vector2 Direction;
            public double angle;
        }

    }

    //    public static (int a, int b, int c) Convert(Vector3 gyro, Vector3 magnet, double compass)
    //    {
    //        Movement mov = CompensateError(gyro, magnet, compass);

    //        if(mov.angle != 0)
    //        {
    //            int a = (int) (RotationSpeed * mov.angle);
    //            return (a, a, a);
    //        } else
    //        {

    //        }

            

    //    }


    //    private static Movement CompensateError(Vector3 gyro, Vector3 magnet, double compass) {

    //        var ret = new Movement();  


                
    //        }


    //}
}
