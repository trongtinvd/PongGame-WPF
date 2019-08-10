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
        public bool gameStart { get; private set; }

        public PongGame()
        {
            NewGame();
        }

        public void Start()
        {
            gameStart = true;
        }

        public void End()
        {
            gameStart = false;
        }

        public bool IsStart()
        {
            return gameStart;
        }

        private void NewGame()
        {
            Player = new GameSlide();
            Bot = new GameSlide();
            Ball = new GameBall();
            gameStart = false;
        }
    }
}
