using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Threaded_38_Homework
{
    class SpaceShipEventArgs : EventArgs
    {
        public int LevelReached { get; set; }
        public int SpaceShipHP { get; set; }
    }
}
