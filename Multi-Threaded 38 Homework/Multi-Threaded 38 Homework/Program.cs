using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multi_Threaded_38_Homework
{
    class Program
    {
        private static bool _isGameOver = false;
        static void Main(string[] args)
        {
            SpaceQuestGameManager spaceInvadersLogic = new SpaceQuestGameManager(200, 500, 100, 80);
            GameViewer spaceInvadersGui = new GameViewer();

            spaceInvadersLogic.GoodSpaceShipHPChanged += spaceInvadersGui.GoodSpaceShipHPChangedEventHandler;
            spaceInvadersLogic.GoodSpaceShipLocationChanged += spaceInvadersGui.GoodSpaceShipLocationChangedEventHandler;
            spaceInvadersLogic.GoodSpaceShipDestroyed += spaceInvadersGui.GoodSpaceShipDestroyedEventHandler;
            spaceInvadersLogic.BadShipsExploded += spaceInvadersGui.BadShipsExplodedEventHandler;
            spaceInvadersLogic.LevelUpReached += spaceInvadersGui.LevelUpReachedEventHandler;

            spaceInvadersLogic.GameIsOver += GameOverEventHandler;

            Random rng = new Random();
            int action = 0;
            while(_isGameOver == false)
            {
                Thread.Sleep(1000);
                action = rng.Next(1, 5);
                switch (action)
                {
                    case 1: spaceInvadersLogic.EnemyShipsDestroyed(15); break;
                    case 2: spaceInvadersLogic.GoodSpaceShipGotDamaged(25); break;
                    case 3: spaceInvadersLogic.GoodSpaceShipGotExtraHP(10); break;
                    case 4: spaceInvadersLogic.MoveSpaceShip(rng.Next(100,1001), rng.Next(100, 1001)); break;
                }
            }
        }

        static void GameOverEventHandler(object sender, SpaceShipEventArgs s)
        {
            _isGameOver = true;
            if (s.LevelReached >= 3)
                Console.WriteLine("CONGRATULATIONS!");
            if(s.SpaceShipHP <= 0)
                Console.WriteLine("GAME OVER!");
        }
    }
}
