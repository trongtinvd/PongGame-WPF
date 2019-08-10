using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace PongGame_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PongGame pongGame = new PongGame();

        public MainWindow()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(ResponseToUserInput);




            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(40);
            timer.Tick += BallMove;
            timer.Tick += BotTakeAnAction;
            timer.Tick += DisplayGame;
            timer.Start();

        }

        private void Window_Load(object sender, RoutedEventArgs e)
        {
            pongGame.Player.AddYRange(0, PlayerSlideBar.ActualHeight);
            pongGame.Player.RectangleRepresentation.Width = PlayerSlideBar.ActualWidth;
            pongGame.Player.ToMiddle();

            pongGame.Ball.AddXRange(0, PlayingField.ActualWidth);
            pongGame.Ball.AddYRange(0, PlayingField.ActualHeight);
            pongGame.Ball.ToMiddle();
            pongGame.Ball.SetRandomDirection();

            pongGame.Bot.AddYRange(0, PlayerSlideBar.ActualHeight);
            pongGame.Bot.RectangleRepresentation.Width = BotSlideBar.ActualWidth;
            pongGame.Bot.ToMiddle();


            PlayerSlideBar.Children.Add(pongGame.Player.RectangleRepresentation);
            PlayingField.Children.Add(pongGame.Ball.RectangleRepresentation);
            BotSlideBar.Children.Add(pongGame.Bot.RectangleRepresentation);
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (pongGame.IsStart())
                pongGame.End();
            else
                pongGame.Start();
        }

        private void BallMove(object sender, EventArgs e)
        {
            if (pongGame.IsStart())
            {
                pongGame.Ball.Move();

                if (pongGame.Ball.IsStuck())
                {
                    pongGame.Ball.ChangDirection();
                }
            }
            else
            {
                pongGame.Ball.ToMiddle();
            }
        }

        private void BotTakeAnAction(object sender, EventArgs e)
        {
            if (pongGame.IsStart())
            {
                if (pongGame.Ball.YCenter() < pongGame.Bot.YCenter())
                    pongGame.Bot.MoveUp();
                else if (pongGame.Ball.YCenter() > pongGame.Bot.YCenter())
                    pongGame.Bot.MoveDown();
            }
        }

        private void DisplayGame(object sender, EventArgs e)
        {
            UpdateGameObjectPosition(pongGame.Player);
            UpdateGameObjectPosition(pongGame.Ball);
            UpdateGameObjectPosition(pongGame.Bot);
        }

        private void UpdateGameObjectPosition(MoveableGameObject anObject)
        {
            Canvas.SetTop(anObject.RectangleRepresentation, anObject.position.Y);
            Canvas.SetLeft(anObject.RectangleRepresentation, anObject.position.X);
        }

        private void ResponseToUserInput(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up)
            {
                pongGame.Player.MoveUp();
            }
            if (e.Key == Key.Down)
            {
                pongGame.Player.MoveDown();
            }
        }

    }
}
