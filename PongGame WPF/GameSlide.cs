using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PongGame_WPF
{
    class GameSlide
    {
        //public double Height { get; set; }
        public double Speed { get; set; }
        public Position position { get; set; }
        public Rectangle Slide { get; set; }

        public GameSlide()
        {
            Speed = 5;
            Slide = new Rectangle();
            Slide.Height = 150;
            Slide.Width = 30;
            Slide.Fill=new SolidColorBrush(System.Windows.Media.Colors.Aqua);
            position = new Position();
        }

        public GameSlide(double barLength) : this()
        {
            position = new Position(new ValueRestricted(), new ValueRestricted(0, barLength-Slide.Height));
        }

        public void GoUp()
        {
            position.Y += Speed;
        }

        public void GoDown()
        {
            position.Y -= Speed;
        }

        internal void AddYRange(int min, double max)
        {
            position.AddYRestrict(min, max - Slide.Height);
        }
    }
}
