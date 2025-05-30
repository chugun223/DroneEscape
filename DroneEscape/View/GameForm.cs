using DroneEscape.Controller;
using DroneEscape.Model;

namespace DroneEscape
{
    public partial class GameForm : Form
    {
        private Image droneImage;
        private Image keyImage;
        private Image exitImage;
        private const int CellSize = 40;
        private GameController controller;
        private Form menuForm;

        public GameForm(CellType[,] grid, Position startPos, Form menuForm)
        {
            InitializeComponent();
            this.menuForm = menuForm;
            this.DoubleBuffered = true;
            this.KeyDown += GameForm_KeyDown;
            this.ClientSize = new Size(400, 400);
            droneImage = Image.FromFile("Resources/drone.png");
            keyImage = Image.FromFile("Resources/key.png");
            exitImage = Image.FromFile("Resources/exit.png");
            var gameState = new GameState(new Maze(grid), new Drone(startPos));
            controller = new GameController(gameState);
        }
        //вид уровня
        

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


                    if (cell == CellType.Wall)
                    {
                        g.FillRectangle(Brushes.Black, x * CellSize, y * CellSize, CellSize, CellSize);
                    }
                    else
                    {
                        g.FillRectangle(Brushes.White, x * CellSize, y * CellSize, CellSize, CellSize);
                        g.DrawRectangle(Pens.Gray, x * CellSize, y * CellSize, CellSize, CellSize);

                        if (cell == CellType.Key)
                            g.DrawImage(keyImage, x * CellSize, y * CellSize, CellSize, CellSize);
                        else if (cell == CellType.Exit)
                            g.DrawImage(exitImage, x * CellSize, y * CellSize, CellSize, CellSize);
                    }
                }
            }

            //дрон
            var pos = state.Drone.Position;
            g.DrawImage(droneImage, pos.X * CellSize, pos.Y * CellSize, CellSize, CellSize);
        }

        private void GameForm_KeyDown(object? sender, KeyEventArgs e)
        {
            Direction? dir = e.KeyCode switch
            {
                Keys.W => Direction.Up,
                Keys.S => Direction.Down,
                Keys.A => Direction.Left,
                Keys.D => Direction.Right,
                _ => null
            };

            if (dir != null)
            {
                controller.Move(dir.Value);
                Invalidate();

                if (controller.State.IsGameWon)
                {
                    MessageBox.Show("Победа!");
                    this.Close();          // Закрываем игру
                    menuForm.Show();       // Показываем меню
                }
            }
        }
        private void GameForm_Load(object sender, EventArgs e)
        {
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            menuForm.Show();
        }
    }
}