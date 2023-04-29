using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTA_2022_23_Battleship.Model {
    public class AfterShotEventArgs {
        public Coordinate Coordinate { get; set; }
        public ShotResponse ShotResponse { get; set; }
    }
}
