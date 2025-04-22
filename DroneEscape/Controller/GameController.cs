namespace DroneEscape.Controller
{
    using DroneEscape.Model;

    public enum Direction { Up, Down, Left, Right }

    public class GameController
    {
        public GameState State { get; private set; }

        public GameController(GameState initialState)
        {
            State = initialState;
        }

        /* ---------------- Движение ---------------- */

        public void Move(Direction dir)
        {
            var delta = dir switch
            {
                Direction.Up => (0, -1),
                Direction.Down => (0, 1),
                Direction.Left => (-1, 0),
                Direction.Right => (1, 0),
                _ => (0, 0)
            };

            var newPos = State.Drone.Position.Move(delta.Item1, delta.Item2);

            /* 1. Проверяем, внутри ли карты и можно ли ходить */
            if (!State.Maze.IsWalkable(newPos)) return;

            /* 2. Двигаем дрона */
            State.Drone.Move(newPos);

            /* 3. Если на клетке ключ — подбираем */
            if (State.Maze.GetCell(newPos) == CellType.Key)
            {
                State.Drone.PickUpKey();
                State.Maze.SetCell(newPos, CellType.Empty);
            }
        }

        /* ---------------- Загрузка и перезапуск ---------------- */

        public void LoadLevel(CellType[,] grid, Position droneStart)
        {
            var maze = new Maze(grid);
            var drone = new Drone(droneStart);
            State = new GameState(maze, drone);
        }

        public void Restart() => LoadLevel(State.Maze.CloneGrid(), State.DroneStartPos);
    }
}