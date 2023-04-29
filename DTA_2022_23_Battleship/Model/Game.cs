using DTA_2022_23_Battleship.Model.Ships;
using DTA_2022_23_Battleship.Model.Strategies;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTA_2022_23_Battleship.Model
{
    public class Game {
        private Board boardPlayer1 = new Board(10);
        private Board boardPlayer2 = new Board(10);

        public void StartNewGame() {
            var randomBoardGenerator = new RandomBoardGenerator();

            var shipsPlayer1 = this.GenerateShips();
            randomBoardGenerator.Generate(boardPlayer1, shipsPlayer1);

            var shipsPlayer2 = this.GenerateShips();
            randomBoardGenerator.Generate(boardPlayer2, shipsPlayer2);

            boardPlayer1.AfterShot += (sender, eventArgs) => {
                if (eventArgs.ShotResponse != ShotResponse.IsHit) {
                    boardPlayer1.IsYourTurn = false;
                    boardPlayer2.IsYourTurn = true;
                } else {
                    boardPlayer1.IsYourTurn = true;
                }
            };

            boardPlayer2.AfterShot += (sender, eventArgs) => {
                if (eventArgs.ShotResponse != ShotResponse.IsHit) {
                    boardPlayer1.IsYourTurn = true;
                    boardPlayer2.IsYourTurn = false;
                } else {
                    boardPlayer2.IsYourTurn = true;
                }
            };

            
            boardPlayer1.IsYourTurnChanged += (sender, eventArgs) => {
                if (this.boardPlayer1.IsYourTurn) {
                    this.Player2Strategy.Shot();
                }
            };
            boardPlayer2.IsYourTurnChanged += (sender, eventArgs) => {
                if (this.boardPlayer2.IsYourTurn) {
                    this.Player1Strategy.Shot();
                }
            };

            boardPlayer1.GameEnd += (sender, eventArgs) => {
                boardPlayer1.IsYourTurn = false;
                boardPlayer2.IsYourTurn = false;
            };
            boardPlayer2.GameEnd += (sender, eventArgs) => {
                boardPlayer1.IsYourTurn = false;
                boardPlayer2.IsYourTurn = false;
            };

            this.SetPlayer1Strategy(PlayerStrategy.Manual);
            this.SetPlayer2Strategy(PlayerStrategy.Expert);
            boardPlayer1.IsYourTurn = true;
        }

        public void SetPlayer1Strategy(PlayerStrategy playerStrategy) {
            this.Player1Strategy = PlayerStrategyFactory.Create(playerStrategy, this.BoardPlayer2);
        }

        public void SetPlayer2Strategy(PlayerStrategy playerStrategy) {
            this.Player2Strategy = PlayerStrategyFactory.Create(playerStrategy, this.BoardPlayer1);
        }

        private PlayerStrategyBase Player1Strategy { get; set; } = null!;
        private PlayerStrategyBase Player2Strategy { get; set; } = null!;

        public Board BoardPlayer1 { get { return boardPlayer1; } }
        public Board BoardPlayer2 { get { return this.boardPlayer2; } }

        private List<Ship> GenerateShips() {
            var ships = new List<Ship>();

            for (var i = 0; i < 4; i++) {
                ships.Add(new Submarine());
            }
            for (var i = 0; i < 3; i++) {
                ships.Add(new Destroyer());
            }
            for (var i = 0; i < 2; i++) {
                ships.Add(new Cruzer());
            }
            ships.Add(new Battleship());

            return ships;
        }
    }
}
