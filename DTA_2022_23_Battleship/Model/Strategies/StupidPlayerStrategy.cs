namespace DTA_2022_23_Battleship.Model.Strategies {
    public class StupidPlayerStrategy : PlayerStrategyBase {
#if TESTING
        private Random random = new Random(10);
#else
        private Random random = new Random();
#endif
        private List<Coordinate> coordinates;
        public StupidPlayerStrategy(Board board) : base(board) {
            this.coordinates = new List<Coordinate>(this.board.Size * this.board.Size);
            for (var r = 0; r < this.board.Size; r++) {
                for (var c = 0; c < this.board.Size; c++) {
                    coordinates.Add(new Coordinate(r, c));
                }
            }
        }

        public async override void Shot() {
            // Player is thinking ...
            await Task.Delay(TimeSpan.FromSeconds(1.5));

            var index = random.Next(0, this.coordinates.Count - 1);
            var coordinate = coordinates[index];
            this.coordinates.RemoveAt(index);
            this.board.Shot(coordinate);
        }
    }
}
