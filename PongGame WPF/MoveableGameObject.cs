using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PongGame_WPF
{
    class MoveableGameObject
    {
        public double Speed { get; set; }
        public Position position { get; set; }
        public MovingDirection Direction { get; set; }
        public Rectangle RectangleRepresentation { get; set; }

        public MoveableGameObject()
        {
            Speed = 0;
            position = new Position();
            Direction = new MovingDirection();
            RectangleRepresentation = new Rectangle();
        }

        public void ToMiddle()
        {
            if (position.RestrictX != null)
                position.X = (position.RestrictX.Min + position.RestrictX.Max) / 2;
            if (position.RestrictY != null)
                position.Y = (position.RestrictY.Min + position.RestrictY.Max) / 2;
        }



        public void Move()
        {
            position.X += Direction.VectorX * Speed;
            position.Y += Direction.VectorY * Speed;
        }

        internal void SetRandomDirection()
        {
            Random r = new Random();

            double XDirection = r.NextDouble() * 2 - 1;
            double YDirection = r.NextDouble() * 2 - 1;


            Direction.SetDirection(XDirection, YDirection);
        }

        public void AddXRange(int min, double max)
        {
            position.AddXRestrict(min, max - RectangleRepresentation.Width);
        }

        public void AddYRange(int min, double max)
        {
            position.AddYRestrict(min, max - RectangleRepresentation.Height);
        }


        public void MoveUp()
        {
            position.Y -= Speed;
        }

        public void MoveDown()
        {
            position.Y += Speed;
        }


        internal void ChangDirection()
        {
            if (position.AtXMin() || position.AtXMax())
                Direction.ReverseX();
            if (position.AtYMin() || position.AtYMax())
                Direction.ReverseY();
        }

        internal bool IsStuck()
        {
            if (position.AtTheEdge())
                return true;
            return false;
        }

        public double YCenter()
        {
            return position.Y + RectangleRepresentation.Height / 2;
        }

        public double XCenter()
        {
            return position.X + RectangleRepresentation.Width / 2;
        }
    }
}
