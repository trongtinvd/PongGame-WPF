using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongGame_WPF
{
    /// <summary>
    /// indicate object moving direction, X and Y value imply scale in vector, not how fast they move
    /// </summary>
    class MovingDirection
    {
        public double VectorX { get; set; }
        public double VectorY { get; set; }

        public MovingDirection() : this(0, 0)
        {

        }

        public MovingDirection(double vectorX, double vectorY)
        {
            SetDirection(vectorX, vectorY);
        }

        internal void SetDirection(double vectorX, double vectorY)
        {
            CorrectRation(ref vectorX, ref vectorY);
            VectorX = vectorX;
            VectorY = vectorY;
        }

        private void CorrectRation(ref double x, ref double y)
        {
            double tempX = x, tempY = y;

            double a = 1;
            double b = x / y;
            x = a * b / Math.Sqrt(b * b + 1);
            y = a / Math.Sqrt(b * b + 1);

            if (tempX * x < 0)
                x = -x;
            if (tempY * y < 0)
                y = -y;
        }

        internal void ReverseX()
        {
            VectorX = -VectorX;
        }

        internal void ReverseY()
        {
            VectorY = -VectorY;
        }
    }
}
