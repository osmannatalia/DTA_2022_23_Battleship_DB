using DTA_2022_23_Battleship.Model.Ships;

namespace DTA_2022_23_Battleship.Model
{
    public class RandomBoardGenerator {
#if TESTING
        public Random Random { get; } = new Random(10);
#else
        public Random Random { get; } = new Random();
#endif
        public Board Generate(Board board, List<Ship> ships) {

            PlaceAll(ships, board);

            return board;
        }

        // Backtracking algorithm.
        private bool PlaceAll(List<Ship> ships, Board board) {
            // If list is empty then all ships have been placed.
            if (ships.Count == 0) {
                return true;
            }

            // "Popping" first ship. 
            Ship ship = ships.First();
            List<Ship> rest = new List<Ship>(ships.GetRange(1, ships.Count - 1));

            // Generating and randomizing possible placements.
            List<Placement> placements = new List<Placement>();
            placements.AddRange(GeneratePlacements(ship.Length, board, Orientation.Horizontal));
            placements.AddRange(GeneratePlacements(ship.Length, board, Orientation.Vertical));

            // No placements were found.
            if (placements.Count == 0) {
                return false;
            }

            ShuffleList(placements);

            foreach (Placement placement in placements) {
                // Placing the ship.
                ApplyPlacement(ship, board, placement, true);

                /* Using recursion to place the rest of the ships.
                 * If recursion returns true then all ships were placed successfully and we can return a value,
                 * otherwise we move on to revert the placement and try another possible placement. */
                if (PlaceAll(rest, board)) {
                    return true;
                }

                // Reverting placement.
                ApplyPlacement(ship, board, placement, false);
            }

            // If none of the recursive calls returned true then it is impossible to fit given amount of ships on the board.
            return false;
        }

        private void ApplyPlacement(Ship ship, Board board, Placement placement, bool placing) {
            if (placing) {
                board.AddShip(ship, placement.Coordinate, placement.Orientation);
            } else {
                board.RemoveShip(ship);
            }
        }

        private void ShuffleList<T>(List<T> list) {
            for (int i = 0; i < list.Count; i++) {
                int swapIndex = Random.Next(0, list.Count - 1);

                T temp = list[i];
                list[i] = list[swapIndex];
                list[swapIndex] = temp;
            }
        }

        /* Generates a list of coordinates that are not occupied (or in range) of another ship. */
        private List<Placement> GeneratePlacements(int length, Board board, Orientation type) {
            // Last possible index is board.Size - (length - 1).
            List<Placement> placements = new List<Placement>();
            int range = board.Size - (length - 1);

            for (int a = 0; a < range; a++) {
                for (int b = 0; b < 10; b++) {
                    bool unoccupied = true;

                    /* Fields around ship must be unoccupied as well, so we expand into every direction by 1, 
                     * the following conditions take care of edge cases (ship next to the boards start/end). */
                    int iStart = (a == 0) ? 0 : a - 1;
                    int iEnd = (a == range - 1) ? 9 : a + length;
                    int jStart = (b == 0) ? 0 : b - 1;
                    int jEnd = (b == 9) ? 9 : b + 1;

                    for (int i = iStart; i <= iEnd; i++) {
                        for (int j = jStart; j <= jEnd; j++) {
                            if (type == Orientation.Horizontal) {
                                if (board.HasShip(new Coordinate(i, j))) {
                                    unoccupied = false;
                                    break;
                                }
                            } else {
                                if (board.HasShip(new Coordinate(j, i))) {
                                    unoccupied = false;
                                    break;
                                }
                            }
                        }

                        // Breaking from the second loop.
                        if (!unoccupied) {
                            break;
                        }
                    }

                    if (unoccupied) {
                        if (type == Orientation.Horizontal) {
                            placements.Add(new Placement(type, new Coordinate(a, b)));
                        } else {
                            placements.Add(new Placement(type,new Coordinate(b, a)));
                        }
                    }
                }
            }

            return placements;
        }

        private struct Placement {
            public Orientation Orientation { get; }
            public Coordinate Coordinate { get; }

            public Placement(Orientation orientation, Coordinate coord) {
                Orientation = orientation;
                this.Coordinate = coord;
            }
        }
    }
}
