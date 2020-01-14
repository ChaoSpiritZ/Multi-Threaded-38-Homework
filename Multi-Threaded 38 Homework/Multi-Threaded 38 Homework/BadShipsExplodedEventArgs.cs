using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Threaded_38_Homework
{
    class BadShipsExplodedEventArgs : EventArgs
    {
        public int NumberOfExplodedBadShips { get; set; }
        public int NumberOfBadShipsAfterCasualties { get; set; }
    }
}
