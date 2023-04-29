namespace DTA_2022_23_Battleship.Model.Strategies {
    public static class PlayerStrategyFactory {
        public static PlayerStrategyBase Create(PlayerStrategy strategy, Board board) {
            switch (strategy) {
                case PlayerStrategy.Manual:
                    return new ManualPlayerStrategy(board);
                case PlayerStrategy.Stupid:
                    return new StupidPlayerStrategy(board);
                case PlayerStrategy.Smart:
                    return new SmartPlayerStrategy(board);
                case PlayerStrategy.Genius:
                    return new GeniusPlayerStrategy(board);
                case PlayerStrategy.Expert:
                    return new ExpertPlayerStrategy(board);
                default:
                    throw new UnknownPlayerStrategyException();
            }
        }
    }
}
