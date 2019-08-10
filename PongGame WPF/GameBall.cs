using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Media;

namespace PongGame_WPF
{
    class GameBall
    {
        public double Height { get; set; }
        public double Width { get; set; }
        public double Speed { get; set; }
        public MovingDirection Direction { get;set; }
        public Position BallPosition { get; set; }
        public Rectangle PlayingBall { get; set; }

        public GameBall()
        {
            Direction = new MovingDirection();
            BallPosition = new Position();
            PlayingBall = new Rectangle();
            PlayingBall.Height = 30;
            PlayingBall.Width = 30;
            PlayingBall.Fill = new SolidColorBrush(Colors.Red);
            Speed = 16;
        }

        public GameBall(double gameBoardWidth, double gameBoardHeight) : this()
        {
            BallPosition = new Position(new ValueRestricted(0, gameBoardWidth - PlayingBall.Width), new ValueRestricted(0, gameBoardHeight - PlayingBall.Height));
        }

        public void Move()
        {
            BallPosition.X += Direction.VectorX * Speed;
            BallPosition.Y += Direction.VectorY * Speed;
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
            BallPosition.AddXRestrict(min, max - PlayingBall.Width);
        }

        public void AddYRange(int min, double max)
        {
            BallPosition.AddYRestrict(min, max - PlayingBall.Height);
        }

        public void ToMiddle()
        {
            BallPosition.X = (BallPosition.RestrictX.Min + BallPosition.RestrictX.Max) / 2;
            BallPosition.Y = (BallPosition.RestrictY.Min + BallPosition.RestrictY.Max) / 2;
        }

        internal void ChangDirection()
        {
            if (BallPosition.AtXMin() || BallPosition.AtXMax())
                Direction.ReverseX();
            if (BallPosition.AtYMin() || BallPosition.AtYMax())
                Direction.ReverseY();
        }

        internal bool IsStuck()
        {
            if (BallPosition.AtTheEdge())
                return true;
            return false;
        }
    }
}
