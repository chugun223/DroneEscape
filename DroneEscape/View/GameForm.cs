using DroneEscape.Controller;
using DroneEscape.Model;

namespace DroneEscape
{
    public partial class GameForm : Form
    {
        private const int CellSize = 40;

        private GameController controller = null!;

        public GameForm()
        {
            InitializeComponent();
            InitGame();
            this.DoubleBuffered = true; // Убираем мерцание при отрисовке
            this.KeyDown += GameForm_KeyDown;
            this.ClientSize = new Size(400, 400); // Подгоним размер под уровень
        }

        private void InitGame()
        {
            // Простой уровень 10x10
            var level = new CellType[10, 10];

            // Стены по краям
            for (int x = 0; x < 10; x++)
            {
                level[x, 0] = CellType.Wall;
                level[x, 9] = CellType.Wall;
                level[0, x] = CellType.Wall;
                level[9, x] = CellType.Wall;
            }

            // Внутренняя стенка
            level[5, 1] = CellType.Wall;
            level[5, 2] = CellType.Wall;
            level[5, 3] = CellType.Wall;

            // Ключ и выход
            level[2, 2] = CellType.Key;
            level[7, 7] = CellType.Exit;

            var startPos = new Position(1, 1);
            var gameState = new GameState(new Maze(level), new Drone(startPos));

            controller = new GameController(gameState);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;

            var state = controller.State;
            for (int x = 0; x < state.Maze.Width; x++)
            {
                for (int y = 0; y < state.Maze.Height; y++)
                {
                    var cell = state.Maze.GetCell(new Position(x, y));
                    Brush brush = Brushes.White;

                    switch (cell)
                    {
                        case CellType.Wall: brush = Brushes.Black; break;
                        case CellType.Key: brush = Brushes.Orange; break;
                        case CellType.Exit: brush = Brushes.Yellow; break;
                        case CellType.Empty: brush = Brushes.White; break;
                    }

                    g.FillRectangle(brush, x * CellSize, y * CellSize, CellSize, CellSize);
                    g.DrawRectangle(Pens.Gray, x * CellSize, y * CellSize, CellSize, CellSize);
                }
            }

            // Дрон
            var pos = state.Drone.Position;
            g.FillEllipse(Brushes.Blue, pos.X * CellSize + 5, pos.Y * CellSize + 5, CellSize - 10, CellSize - 10);
        }

        private void GameForm_KeyDown(object? sender, KeyEventArgs e)
        {
            Direction? dir = e.KeyCode switch
            {
                Keys.Up => Direction.Up,
                Keys.Down => Direction.Down,
                Keys.Left => Direction.Left,
                Keys.Right => Direction.Right,
                _ => null
            };

            if (dir != null)
            {
                controller.Move(dir.Value);
                Invalidate();

                if (controller.State.IsGameWon)
                    MessageBox.Show("Победа!");
            }
        }
    }
}