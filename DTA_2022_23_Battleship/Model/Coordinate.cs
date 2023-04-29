using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTA_2022_23_Battleship.Model {
    public class Coordinate {
        public Coordinate(int x, int y) {
            this.X = x;
            this.Y = y;
        }
        public int X { get;  }
        public int Y { get;  }
    }
}
