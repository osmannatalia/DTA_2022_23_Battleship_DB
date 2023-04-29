using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTA_2022_23_Battleship.Model.Strategies {
    public class GeniusPlayerStrategy : PlayerStrategyBase {
        private ShootingStateSquare[,] internalBoard;
        private int currentPriority = -1;
#if TESTING
        private Random random = new Random(10);
#else
        private Random random = new Random();
#endif
        public GeniusPlayerStrategy(Board board) : base(board) {
            this.internalBoard = new ShootingStateSquare[board.Size, board.Size];

            for (var r = 0; r < board.Size; r++) {
                for (var c = 0; c < board.Size; c++) {
                    this.internalBoard[r, c] = new ShootingStateSquare();
                }
            }

            board.AfterShot += Board_AfterShot;
        }
        private void Board_AfterShot(object? sender, AfterShotEventArgs e) {
            var shootingStateSquare = this.internalBoard[e.Coordinate.Y, e.Coordinate.X];
            shootingStateSquare.IsShot = true;
            if (e.ShotResponse == ShotResponse.IsHit) {
                shootingStateSquare.HasShipSquare = true;

                this.RemoveCoordinateForShooting(e.Coordinate.X - 1, e.Coordinate.Y - 1);
                this.RemoveCoordinateForShooting(e.Coordinate.X + 1, e.Coordinate.Y - 1);
                this.RemoveCoordinateForShooting(e.Coordinate.X - 1, e.Coordinate.Y + 1);
                this.RemoveCoordinateForShooting(e.Coordinate.X + 1, e.Coordinate.Y + 1);

                var ship = this.board.GetShipFromCoordinate(e.Coordinate);

                if (ship != null && ship.IsSunk) {
                    this.RemoveCoordinateForShooting(e.Coordinate.X - 1, e.Coordinate.Y);
                    this.RemoveCoordinateForShooting(e.Coordinate.X + 1, e.Coordinate.Y);
                    this.RemoveCoordinateForShooting(e.Coordinate.X, e.Coordinate.Y - 1);
                    this.RemoveCoordinateForShooting(e.Coordinate.X, e.Coordinate.Y + 1);
                    foreach (var coordinate in this.nextShootingCoordinates) {
                        this.RemoveCoordinateForShooting(coordinate.X, coordinate.Y);
                    }
                    this.nextShootingCoordinates.Clear();
                } else {
                    this.AddCoordinateForNextShot(e.Coordinate.X - 1, e.Coordinate.Y);
                    this.AddCoordinateForNextShot(e.Coordinate.X + 1, e.Coordinate.Y);
                    this.AddCoordinateForNextShot(e.Coordinate.X, e.Coordinate.Y - 1);
                    this.AddCoordinateForNextShot(e.Coordinate.X, e.Coordinate.Y + 1);

                    foreach (var coordinate in this.nextShootingCoordinates.ToList()) {
                        if (!this.internalBoard[coordinate.Y, coordinate.X].CanShot) {
                            this.nextShootingCoordinates.Remove(coordinate);
                        }
                    }
                }
            } else {
                this.nextShootingCoordinates.Remove(e.Coordinate);
            }
        }

        private void RemoveCoordinateForShooting(int x, int y) {
            if (x < 0 || x >= this.board.Size) { return; }
            if (y < 0 || y >= this.board.Size) { return; }
            this.internalBoard[y, x].RemoveForShooting = true;
        }

        private void AddCoordinateForNextShot(int x, int y) {
            if (x < 0 || x >= this.board.Size) { return; }
            if (y < 0 || y >= this.board.Size) { return; }

            var coord = new Coordinate(x, y);
            if (this.internalBoard[coord.Y, coord.X].CanShot) {
                this.nextShootingCoordinates.Add(coord);
            }
        }

        private List<Coordinate> nextShootingCoordinates = new List<Coordinate>();


        public async override void Shot() {
            // Player is thinking ...
            await Task.Delay(TimeSpan.FromSeconds(0.05));

            if (this.nextShootingCoordinates.Any()) {
                var nextIndex = this.random.Next(0, this.nextShootingCoordinates.Count - 1);
                this.board.Shot(this.nextShootingCoordinates[nextIndex]);
            } else {
                var coordinate = this.GetRandomCoordinate();
                this.board.Shot(coordinate);
            }
            
            this.PrintBoard();
        }

        private Coordinate GetRandomCoordinate() {
            var prioCnt = 0;
            var shortest = board.ShortestShipLength;
            for (var r = 0; r < board.Size; r++) {
                for (var c = 0; c < board.Size; c++) {
                    if (this.internalBoard[r, c].Priority <= currentPriority && this.internalBoard[r, c].CanShot) {
                        int blockedDirections = 0;
                        for (int i = r - shortest + 1; i < r; i++) {
                            if (i > board.Size - 1 || i < 0) {
                                blockedDirections++;
                                break;
                            } else {
                                if (!this.internalBoard[i, c].CanShot) {
                                    blockedDirections++;
                                    break;
                                }
                            }
                        }
                        for (int i = r + 1; i < r + shortest; i++) {
                            if (i > board.Size - 1 || i < 0) {
                                blockedDirections++;
                                break;
                            } else {
                                if (!this.internalBoard[i, c].CanShot) {
                                    blockedDirections++;
                                    break;
                                }
                            }
                        }
                        for (int i = c - shortest + 1; i < c; i++) {
                            if (i > board.Size - 1 || i < 0) {
                                blockedDirections++;
                                break;
                            } else {
                                if (!this.internalBoard[r, i].CanShot) {
                                    blockedDirections++;
                                    break;
                                }
                            }
                        }
                        for (int i = c + 1; i < c + shortest; i++) {
                            if (i > board.Size - 1 || i < 0) {
                                blockedDirections++;
                                break;
                            } else {
                                if (!this.internalBoard[r, i].CanShot) {
                                    blockedDirections++;
                                    break;
                                }
                            }
                        }
                        this.internalBoard[r, c].Priority = blockedDirections;
                        if ((r == 0 || r == board.Size - 1) ^ (c == 0 || c == board.Size - 1) && blockedDirections == 1) {
                            this.internalBoard[r, c].Priority = -1;
                        }
                        if (this.internalBoard[r, c].Priority <= currentPriority) {
                            prioCnt++;
                        } 
                    }
                }
            }
            if (prioCnt > 0) {
                var nextSquare = this.random.Next(1, prioCnt);
                prioCnt = 0;
                for (var r = 0; r < board.Size; r++) {
                    for (var c = 0; c < board.Size; c++) {
                        if (this.internalBoard[r, c].Priority <= currentPriority && this.internalBoard[r, c].CanShot) {
                            prioCnt++;
                        }
                        if (prioCnt == nextSquare) {
                            return new Coordinate(c, r);
                        }
                    }
                }
                return new Coordinate(0, 0);
            } else {
                currentPriority++;
                return GetRandomCoordinate();
            }

        }

        public void PrintBoard() {
            Debug.WriteLine("\n--------------------");
            for (int r = 0; r < this.board.Size; r++) {
                Debug.Write("|");
                for (int c = 0; c < this.board.Size; c++) {
                    if (this.internalBoard[r, c].CanShot) {
                        Debug.Write(this.internalBoard[r, c].Priority);
                    } else {
                        Debug.Write('X');
                    }
                    
                    Debug.Write("|");
                }
                Debug.WriteLine("\n--------------------");
            }

        }

        private class ShootingStateSquare {
            public bool IsShot { get; set; }
            public bool HasShipSquare { get; set; }
            public bool RemoveForShooting { get; set; }

            public bool CanShot {
                get {
                    return !this.IsShot && !this.HasShipSquare && !this.RemoveForShooting;
                }
            }
            public int Priority { get; set; } = -1;
        }
    }
}
