using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongGame_WPF
{
    class PongGame
    {
        public GameSlide Player { get; set; }
        public GameSlide Bot { get; set; }
        public GameBall Ball { get; set; }
        public int PlayerScore { get; set; }
        public int BotScore { get; set; }
        private bool gameStart;

        public PongGame()
        {
            Player = new GameSlide();
            Bot = new GameSlide();
            Ball = new GameBall();
            gameStart = false;
            ResetGame();
        }

        public void ResetGame()
        {
            Player.ToMiddle();
            Ball.ToMiddle();
            Bot.ToMiddle();
            Ball.SetRandomDirection();
            PlayerScore = 0;
            BotScore = 0;
        }

        public void GameStart()
        {
            gameStart = true;
        }

        public void GameEnd()
        {
            gameStart = false;
        }

        public bool IsStart()
        {
            return gameStart;
        }

        public bool BallHitPlayer()
        {
            if (Ball.Top() >= Player.Top() && Ball.Bottom() <= Player.Bottom() && Ball.position.AtXMax())
                return true;
            return false;
        }

        public bool BallHitBot()
        {
            if (Ball.Top() >= Bot.Top() && Ball.Bottom() <= Bot.Bottom() && Ball.position.AtXMin())
                return true;
            return false;
        }
    }
}
