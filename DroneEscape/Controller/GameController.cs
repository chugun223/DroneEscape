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

        public void Move(Direction dir)
        {
            (int, int) delta = dir switch
            {
                Direction.Up => (0, -1),
                Direction.Down => (0, 1),
                Direction.Left => (-1, 0),          //передвижение
                Direction.Right => (1, 0),
                _ => (0, 0)
            };

            var newPos = State.Drone.Position.Move(delta.Item1, delta.Item2);

            if (!State.Maze.IsWalkable(newPos)) return; //проверка модно ли пройти
            State.Drone.Move(newPos);  //движение
            if (State.Maze.GetCell(newPos) == CellType.Key)
            {
                State.Drone.PickUpKey();                            //подбок ключа при его наличии
                State.Maze.SetCell(newPos, CellType.Empty);
            }
        }

        public void LoadLevel(CellType[,] grid, Position droneStart)
        {
            var maze = new Maze(grid);                                      //загрузка уровня
            var drone = new Drone(droneStart);
            State = new GameState(maze, drone);
        }

        public void Restart() => LoadLevel(State.Maze.CloneGrid(), State.DroneStartPos);  //перезагрузка уровня
    }
}