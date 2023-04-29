using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTA_2022_23_Battleship.Model.Ships;

namespace DTA_2022_23_Battleship.Model
{
    public class SeaSquare {
        public ShipSquare? ShipSquare { get; private set; }

        //public Ship? Ship {
        //    get {
        //        return this.ShipSquare ;
        //    }
        //}

        public bool HasShip {
            get { return this.ShipSquare != null; }
        }
        public void LinkShipSquare(ShipSquare shipSquare) {
            if (shipSquare == null) {
                throw new ArgumentNullException(nameof(shipSquare));
            }

            this.ShipSquare = shipSquare;
        }

        public void UnlinkShipSquare() {
            this.ShipSquare = null;
        }

        public bool IsShot { get; set; }
    }
}
