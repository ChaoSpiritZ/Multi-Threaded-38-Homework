using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Threaded_38_Homework
{
    class GameViewer
    {
        public void GoodSpaceShipHPChangedEventHandler(object sender, PointsEventArgs p)
        {
            Console.WriteLine($"HitPoints: {p.HitPoints}");
        }

        public void GoodSpaceShipLocationChangedEventHandler(object sender, LocationEventArgs l)
        {
            Console.WriteLine($"Current X: {l.X} | Current Y: {l.Y}");
        }

        public void GoodSpaceShipDestroyedEventHandler(object sender, LocationEventArgs l)
        {
            Console.WriteLine($"BANG!");
        }

        public void BadShipsExplodedEventHandler(object sender, BadShipsExplodedEventArgs b)
        {
            Console.WriteLine($"Destroyed {b.NumberOfExplodedBadShips} ships! {b.NumberOfBadShipsAfterCasualties} ships remaining!");
        }

        public void LevelUpReachedEventHandler(object sender, LevelEventArgs l)
        {
            Console.WriteLine($"Current Level: {l.CurrentLevel}");
        }
    }
}
