using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Media;

namespace PongGame_WPF
{
    class GameBall : MoveableGameObject
    {
        public GameBall() : base()
        {
            Speed = 16;
            RectangleRepresentation.Height = 30;
            RectangleRepresentation.Width = 30;
            RectangleRepresentation.Fill = new SolidColorBrush(Colors.Red);
        }
    }
}
