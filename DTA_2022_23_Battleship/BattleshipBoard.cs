using DTA_2022_23_Battleship.Model;
using DTA_2022_23_Battleship.Model.Ships;

namespace DTA_2022_23_Battleship
{
    public partial class BattleshipBoard : UserControl
    {

        public BattleshipBoard()
        {
            InitializeComponent();
        }

        private Board board = null!;
        private bool showShips;
        public void SetBoard(Board board, bool showShips)
        {
            this.board = board;
            this.showShips = showShips;

            // TODO:
            // Create tableLayoutPanel based on size (rows and columns).
            // Insert a panel into each cell - this can then be colored.
            // In addition, the click event can be handled in the panel (for the shot by the human player)

            for (int r = 0; r < this.tableLayoutPanel1.RowCount; r++)
            {
                for (int c = 0; c < this.tableLayoutPanel1.ColumnCount; c++)
                {

                    var panel = new Panel();
                    panel.Dock = DockStyle.Fill;
                    panel.Click += this.panel1_Click;

                    this.tableLayoutPanel1.Controls.Add(panel, c, r);
                }
            }

            this.EvaluateShipStates();
        }

        public bool ShowShips
        {
            get
            {
                return this.showShips;
            }
            set
            {
                if (value != this.showShips)
                {
                    this.showShips = value;
                    this.EvaluateShipStates();
                }
            }
        }

        private void EvaluateShipStates()
        {
            for (int r = 0; r < this.tableLayoutPanel1.RowCount; r++)
            {
                for (int c = 0; c < this.tableLayoutPanel1.ColumnCount; c++)
                {
                    this.EvaluateShipState(new Coordinate(c, r));
                }
            }
        }

        public void EvaluateShipState(Coordinate coordinate)
        {
            var panel = (Panel)tableLayoutPanel1.GetControlFromPosition(coordinate.X, coordinate.Y);

            if (this.board.HasSunkenShip(coordinate))
            {
                var ship = this.board.GetShipFromCoordinate(coordinate)!;
                foreach (ShipSquare shipSquare in ship.ShipSquares)
                {
                    panel = (Panel)tableLayoutPanel1.GetControlFromPosition(shipSquare.Coordinate!.X, shipSquare.Coordinate.Y);
                    panel.BackColor = Color.Black;
                }
            }
            else if (this.board.HasShotShip(coordinate))
            {
                panel.BackColor = Color.Red;
            }
            else if (this.board.HasShip(coordinate) && showShips)
            {
                panel.BackColor = Color.Gray;
            }
            else if (this.board.HasShot(coordinate))
            {
                panel.BackColor = Color.Blue;
            }
            else
            {
                panel.BackColor = SystemColors.ControlLight;
            }
        }

        private void panel1_Click(object? sender, EventArgs e)
        {
            var panel = (Panel)sender!;

            var position = this.tableLayoutPanel1.GetPositionFromControl(panel);
            var coordinate = new Coordinate(position.Column, position.Row);
            board.Shot(coordinate);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
