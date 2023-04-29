namespace DTA_2022_23_Battleship.Model.Strategies {
    public abstract class PlayerStrategyBase {
        protected Board board;
        public PlayerStrategyBase(Board board) {
            this.board = board;
        }
        public abstract void Shot();
    }
}
