
using System.Diagnostics;
using DTA_2022_23_Battleship.Model.Ships;

namespace DTA_2022_23_Battleship.Model
{
    public class Board {
        private SeaSquare[,] internalBoard;

        public Board(int size) {
            this.Size = size;
            this.internalBoard = new SeaSquare[size, size];
            for (int r = 0; r < size; r++) {
                for (int c = 0; c < size; c++) {
                    this.internalBoard[r, c] = new SeaSquare();
                }
            }
        }
        public bool Defeat {
            get {
                foreach (Ship ship in ships) {
                    if (!ship.IsSunk) return false;
                }
                return true;
            }
        }
        public int ShortestShipLength
        {
            get {
                int shortest = Size;
                foreach (Ship ship in ships)
                {
                    if (!ship.IsSunk)
                    {
                        if (ship.Length < shortest)
                        {
                            shortest = ship.Length;
                        }
                    }
                }
                return shortest;
            }
        }

        public SeaSquare GetSeaSquare(Coordinate coordinate) {
            return this.internalBoard[coordinate.X, coordinate.Y];
        }

        private List<Ship> ships = new List<Ship>();
        public void AddShip(Ship ship, Coordinate coordinate, Orientation orientation) {
            this.ships.Add(ship);
            
            if(orientation == Orientation.Horizontal) {
                var x = coordinate.X;
                foreach(var shipSquare in ship.ShipSquares) {
                    shipSquare.Coordinate = new Coordinate(x, coordinate.Y);
                    this.internalBoard[x, coordinate.Y].LinkShipSquare(shipSquare);
                    x++;
                }
            } else {
                var y = coordinate.Y;
                foreach (var shipSquare in ship.ShipSquares) {
                    shipSquare.Coordinate = new Coordinate(coordinate.X, y);
                    this.internalBoard[coordinate.X, y].LinkShipSquare(shipSquare);
                    y++;
                }
            }
        }

        public void RemoveShip(Ship ship) {
            foreach (var shipSquare in ship.ShipSquares) {
                this.internalBoard[shipSquare.Coordinate!.X, shipSquare.Coordinate.Y].UnlinkShipSquare();

            }
        }
        public int Size { get; private set; }

        public bool HasShip(Coordinate coordinate) {
            var seaSquare = this.internalBoard[coordinate.X, coordinate.Y];
            return seaSquare.HasShip;
        }

        public int Score { get; private set; }
        public void Shot(Coordinate coordinate) {
            if(!this.IsYourTurn || this.Defeat) {
                return;
            }
            ShotResponse response;
            var seaSquare = this.internalBoard[coordinate.X, coordinate.Y];
            if (seaSquare.IsShot) {
                response = ShotResponse.IsAlreadShot;
            } else {
                if(seaSquare.HasShip) {
                    response = ShotResponse.IsHit;
                    seaSquare.ShipSquare!.IsHit = true;
                } else {
                    response = ShotResponse.IsMiss;
                }
                seaSquare.IsShot = true;
                // TODO: Prüfung, ist komplettes Schiff versenkt und Mark in Ship.IsSunk
                //       Diese Info ggf. im ShotResponse erweitern
            }
            if(response != ShotResponse.IsHit) {
                this.Score++;
            }
            if(this.AfterShot!= null) {
                this.AfterShot(this, new AfterShotEventArgs { Coordinate = coordinate, ShotResponse = response}); // Event wird ausgelöst
                // d.h. alle registrierten Views werden informiert.
            }
        }

        public Ship? GetShipFromCoordinate(Coordinate coordinate) {
            var shipSquare = this.internalBoard[coordinate.X, coordinate.Y].ShipSquare;
            if(shipSquare == null) {
                return null;
            }
            return shipSquare.Ship;
        }

        private bool isYourTurn;
        public bool IsYourTurn {
            get {
                return this.isYourTurn;
            }
            set {
                this.isYourTurn = value;
                if(this.IsYourTurnChanged != null && !this.Defeat) {
                    this.IsYourTurnChanged(this, EventArgs.Empty);
                }
            }
        }

        public bool HasSunkenShip(Coordinate coordinate) {
            var seaSquare = this.GetSeaSquare(coordinate);
            if (this.Defeat) {
                Debug.Write("end");
                this.GameEnd(this, EventArgs.Empty);
            }
            return seaSquare.HasShip && seaSquare.ShipSquare!.Ship.IsSunk;
        }

        public bool HasShotShip(Coordinate coordinate) {
            var seaSquare = this.GetSeaSquare(coordinate);
            return seaSquare.HasShip && seaSquare.IsShot;
        }

        public bool HasShot(Coordinate coordinate) {
            var seaSquare = this.GetSeaSquare(coordinate);
            return seaSquare.IsShot;
        }

        public event EventHandler? IsYourTurnChanged;
        public event EventHandler<AfterShotEventArgs>? AfterShot;
        public event EventHandler GameEnd;

        /*public void PrintBoard() {
            Debug.WriteLine("\n--------------------");
            for (int r = 0; r < this.Size; r++) {
                Debug.Write("|");
                for (int c = 0; c < this.Size; c++) {
                    if (this.internalBoard[r, c].HasShip) {
                        Debug.Write("X");
                    } else {
                        Debug.Write(" ");
                    }
                    Debug.Write("|");
                }
                Debug.WriteLine("\n--------------------");
            }

        }*/
    }
}
