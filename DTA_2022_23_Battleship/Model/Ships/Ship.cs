using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTA_2022_23_Battleship.Model.Ships
{
    public class Ship
    {
        private LinkedList<ShipSquare> internalList = new LinkedList<ShipSquare>();

        public Ship(int length)
        {
            for (var i = 0; i < length; i++)
            {
                internalList.AddLast(new ShipSquare(this));
            }
        }

        public int Length
        {
            get
            {
                return internalList.Count;
            }
        }

        private LinkedList<ShipSquare> InternalList
        {
            get
            {
                return internalList;
            }
        }



        public IEnumerable<ShipSquare> ShipSquares
        {
            get
            {
                foreach (var square in internalList)
                {
                    yield return square;
                }
            }
        }

        public bool IsSunk
        {
            get
            {
                foreach (var square in internalList)
                {
                    if (!square.IsHit)
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}
