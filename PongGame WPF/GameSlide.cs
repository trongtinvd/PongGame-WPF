using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PongGame_WPF
{
    class GameSlide : MoveableGameObject
    {
        public GameSlide() : base()
        {
            Speed = 5;
            RectangleRepresentation.Height = 150;
            RectangleRepresentation.Width = 30;
            RectangleRepresentation.Fill = new SolidColorBrush(System.Windows.Media.Colors.Aqua);
        }

    }
}
