using DTA_2022_23_Battleship.Model;
using DTA_2022_23_Battleship.Model.DataBase;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DTA_2022_23_Battleship
{
    public partial class BattleshipGame : Form
    {
        private Game game;   // Model
        private User _activeUser;
        public BattleshipGame(Game game, User user)
        {
            this.game = game;
            _activeUser = user;
            InitializeComponent();
            if (_activeUser.IsAdministration)
            {
                button4.Visible = true;
            }

            game.BoardPlayer1.AfterShot += BoardPlayer1_AfterShot;
            game.BoardPlayer2.AfterShot += BoardPlayer2_AfterShot;

            game.BoardPlayer1.IsYourTurnChanged += (sender, args) =>
            {
                if (this.game.BoardPlayer1.IsYourTurn)
                {
                    this.label2.Text = "Your turn";
                    this.label3.Text = "Wait";
                }
            };
            game.BoardPlayer2.IsYourTurnChanged += (sender, args) =>
            {
                if (this.game.BoardPlayer2.IsYourTurn)
                {
                    this.label3.Text = "Your turn";
                    this.label2.Text = "Wait";
                }
            };

            game.BoardPlayer1.GameEnd += (sender, args) =>
            {
                Debug.WriteLine("1end");
                var statistic =  DataBaseService.DataBaseContext.Statistics
                .Where(s => s.PlayerId == _activeUser.Id).FirstOrDefault();
                if (statistic is null)
                {
                    statistic = new Statistic();
                    statistic.Player2Score = game.BoardPlayer2.Score;
                    statistic.Winer = "Player2";
                    statistic.CountOfRounds = 1;
                    statistic.IsVisible = true;
                    statistic.PlayerId = _activeUser.Id;
                    DataBaseService.DataBaseContext.Statistics.Add(statistic);
                }
                else
                {
                    statistic.Winer += ";Player2";
                    ++statistic.CountOfRounds;
                    DataBaseService.DataBaseContext.Entry(statistic).State = EntityState.Modified;
                }
                DataBaseService.DataBaseContext.SaveChanges();
                this.label2.Text = "Player2 has won the game";
                this.label3.Text = "Player1 has lost the game";
            };
            game.BoardPlayer2.GameEnd += (sender, args) =>
            {
                Debug.WriteLine("2end");
                var statistic = DataBaseService.DataBaseContext.Statistics
                .Where(s => s.PlayerId == _activeUser.Id).FirstOrDefault();
                if (statistic is null)
                {
                    statistic = new Statistic();
                    statistic.Player1Score = game.BoardPlayer1.Score;
                    statistic.Winer = "Player1";
                    statistic.CountOfRounds = 1;
                    statistic.IsVisible = true;
                    statistic.PlayerId = _activeUser.Id;
                    DataBaseService.DataBaseContext.Statistics.Add(statistic);
                }
                else
                {
                    statistic.Player1Score += game.BoardPlayer1.Score;
                    statistic.Winer += ";Player1";
                    ++statistic.CountOfRounds;
                    DataBaseService.DataBaseContext.Entry(statistic).State = EntityState.Modified;
                }
                DataBaseService.DataBaseContext.SaveChanges();
                this.label3.Text = "Player1 has won the game";
                this.label2.Text = "Player2 has lost the game";
            };

            game.StartNewGame();

            this.battleshipBoardPlayer1.SetBoard(game.BoardPlayer1, true);
            this.battleshipBoardPlayer2.SetBoard(game.BoardPlayer2, true);

            // View:
            // BattleshipGame (=this)
            // this.battleshipBoardPlayer1
            // this.battleshipBoardPlayer2


            // TODO:
            // Hier sind die Boards (=Model) mit den Schiffen erzeugt.
            // game.BoardPlayer1 mit this.battleshipBoardPlayer1 visualisieren
            // D.h. game.BoardPlayer1 an this.battleshipBoardPlayer1 übergeben und
            // in BattleshipBoard die Logik für die Visualisierung umsetzen.
        }

        private void BoardPlayer1_AfterShot(object? sender, AfterShotEventArgs e)
        {
            this.battleshipBoardPlayer1.EvaluateShipState(e.Coordinate);
            this.label5.Text = game.BoardPlayer1.Score.ToString();
        }

        private void BoardPlayer2_AfterShot(object? sender, AfterShotEventArgs e)
        {
            this.battleshipBoardPlayer2.EvaluateShipState(e.Coordinate);
            this.label4.Text = game.BoardPlayer2.Score.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.battleshipBoardPlayer1.ShowShips = !this.battleshipBoardPlayer1.ShowShips;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.battleshipBoardPlayer2.ShowShips = !this.battleshipBoardPlayer2.ShowShips;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton1.Checked)
            {
                this.game.SetPlayer1Strategy(Model.Strategies.PlayerStrategy.Manual);
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton2.Checked)
            {
                this.game.SetPlayer1Strategy(Model.Strategies.PlayerStrategy.Stupid);
            }

        }

        private void ToAdmonistratorForm(object sender, EventArgs e)
        {
            var form = new AdministratorForm(_activeUser);
            Hide();
            form.ShowDialog();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new RegistrationForm();
            Hide();
            form.ShowDialog();
            Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}