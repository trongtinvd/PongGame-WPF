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
            this.KeyDown += new KeyEventHandler(UpdatePlayerSlide);


            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(40);
            timer.Tick += UpdateGame;
            timer.Tick += DisplayGame;
            timer.Start();

        }

        private void Window_Load(object sender, RoutedEventArgs e)
        {
            pongGame.Player.AddYRange(0, PlayerSlideBar.ActualHeight);
            pongGame.Ball.AddXRange(0, PlayingField.ActualWidth);
            pongGame.Ball.AddYRange(0, PlayingField.ActualHeight);
            pongGame.Ball.ToMiddle();
            pongGame.Ball.SetRandomDirection();


            PlayerSlideBar.Children.Add(pongGame.Player.Slide);
            PlayingField.Children.Add(pongGame.Ball.PlayingBall);
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (pongGame.IsStart())
                pongGame.End();
            else
                pongGame.Start();
        }

        private void UpdateGame(object sender, EventArgs e)
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

        private void DisplayGame(object sender, EventArgs e)
        {
            UpdateGameSlide(PlayerSlideBar, pongGame.Player);
            UpdateGameBall(PlayingField, pongGame.Ball);
        }

        private void UpdateGameBall(Canvas playingField, GameBall ball)
        {
            Canvas.SetTop(ball.PlayingBall, ball.BallPosition.Y);
            Canvas.SetLeft(ball.PlayingBall, ball.BallPosition.X);
        }

        private void UpdateGameSlide(Canvas container, GameSlide slide)
        {
            Canvas.SetTop(slide.Slide, slide.position.Y);
            Canvas.SetLeft(slide.Slide, slide.position.X);
        }

        private void UpdatePlayerSlide(object sender, KeyEventArgs e)
        {
            if (e.Key==Key.Up)
            {
                pongGame.Player.position.Y -= 10;
            }
            if(e.Key==Key.Down)
            {
                pongGame.Player.position.Y += 10;
            }
        }
        
    }
}
