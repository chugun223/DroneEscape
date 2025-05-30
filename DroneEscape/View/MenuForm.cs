using System;
using System.Drawing;
using System.Windows.Forms;
using DroneEscape.Model;

namespace DroneEscape.View
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
            CreateLevelButtons();
            this.FormClosing += (s, e) =>
            {
                Application.Exit();
            };
        }


        private void CreateLevelButtons()
        {
            this.Text = "Меню уровней";
            this.ClientSize = new Size(400, 300);

            for (int i = 1; i <= 5; i++)
            {
                var button = new Button
                {
                    Text = $"Уровень {i}",
                    Location = new Point(150, 30 + (i - 1) * 45),
                    Size = new Size(100, 40),
                    Tag = i
                };
                button.Click += LevelButton_Click;
                this.Controls.Add(button);
            }
        }

        private void LevelButton_Click(object? sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is int levelNum)
            {
                CellType[,] level = levelNum switch
                {
                    1 => CreateLevel1(),
                    2 => CreateLevel2(),
                    3 => CreateLevel3(),
                    4 => CreateLevel4(),
                    5 => CreateLevel5(),
                    _ => throw new InvalidOperationException("Неизвестный уровень")
                };

                Position start = new Position(1, 1);
                var gameForm = new GameForm(level, start, this);
                gameForm.Show();
                this.Hide();
            }
        }

        #region
        private CellType[,] CreateLevel1()
        {
            var level = new CellType[10, 10];


            for (int x = 0; x < 10; x++)
            {
                level[x, 0] = CellType.Wall;
                level[x, 9] = CellType.Wall;
                level[0, x] = CellType.Wall;
                level[9, x] = CellType.Wall;
            }

            level[5, 1] = CellType.Wall;
            level[5, 2] = CellType.Wall;
            level[5, 3] = CellType.Wall;
            level[1, 5] = CellType.Wall;
            level[2, 5] = CellType.Wall;
            level[3, 5] = CellType.Wall;
            level[3, 6] = CellType.Wall;
            level[5, 6] = CellType.Wall;
            level[5, 7] = CellType.Wall;
            level[5, 8] = CellType.Wall;

            level[2, 6] = CellType.Key;
            level[7, 7] = CellType.Exit;

            return level;
        }

        private CellType[,] CreateLevel2()
        {
            var level = CreateEmptyLevel(10, 10);
            FillBorders(level);
            level[2, 1] = CellType.Wall;
            level[2, 2] = CellType.Wall;
            level[2, 3] = CellType.Wall;
            level[2, 4] = CellType.Wall;
            level[2, 5] = CellType.Wall;
            level[2, 6] = CellType.Wall;
            level[2, 7] = CellType.Wall;
            level[3, 7] = CellType.Wall;
            level[4, 7] = CellType.Wall;
            level[5, 7] = CellType.Wall;
            level[5, 6] = CellType.Wall;
            level[5, 5] = CellType.Wall;
            level[5, 4] = CellType.Wall;
            level[5, 3] = CellType.Wall;
            level[7, 2] = CellType.Wall;
            level[7, 3] = CellType.Wall;
            level[7, 4] = CellType.Wall;
            level[7, 5] = CellType.Wall;
            level[7, 6] = CellType.Wall;
            level[7, 7] = CellType.Wall;
            level[7, 8] = CellType.Wall;

            level[3, 6] = CellType.Key;
            level[8, 8] = CellType.Exit;

            return level;
        }

        private CellType[,] CreateLevel3()
        {
            var level = CreateEmptyLevel(10, 10);
            FillBorders(level);

            level[1, 6] = CellType.Wall;
            level[2, 1] = CellType.Wall;
            level[2, 2] = CellType.Wall;
            level[2, 3] = CellType.Wall;
            level[2, 4] = CellType.Wall;
            level[2, 7] = CellType.Wall;
            level[3, 3] = CellType.Wall;
            level[3, 5] = CellType.Wall;
            level[3, 7] = CellType.Wall;
            level[4, 2] = CellType.Wall;
            level[4, 3] = CellType.Wall;
            level[4, 5] = CellType.Wall;
            level[5, 2] = CellType.Wall;
            level[5, 5] = CellType.Wall;
            level[5, 7] = CellType.Wall;
            level[6, 2] = CellType.Wall;
            level[6, 7] = CellType.Wall;
            level[7, 2] = CellType.Wall;
            level[7, 3] = CellType.Wall;
            level[7, 4] = CellType.Wall;
            level[7, 5] = CellType.Wall;
            level[7, 6] = CellType.Wall;
            level[7, 7] = CellType.Wall;

            level[1, 7] = CellType.Key;
            level[3, 2] = CellType.Exit;

            return level;
        }

        private CellType[,] CreateLevel4()
        {
            var level = CreateEmptyLevel(10, 10);
            FillBorders(level);

            for (int x = 1; x <= 7; x++)
                level[x, 2] = CellType.Wall;
            for (int x = 2; x <= 7; x++)
                level[x, 4] = CellType.Wall;
            for (int x = 2; x <= 7; x++)
                level[x, 6] = CellType.Wall;
            level[7, 3] = CellType.Wall;
            level[2, 5] = CellType.Wall;
            level[7, 7] = CellType.Wall;

            level[3, 5] = CellType.Key;
            level[6, 3] = CellType.Exit;

            return level;
        }

        private CellType[,] CreateLevel5()
        {
            var level = CreateEmptyLevel(10, 10);
            FillBorders(level);

            level[1, 3] = CellType.Wall;
            level[1, 4] = CellType.Wall;
            level[2, 2] = CellType.Wall;
            level[2, 5] = CellType.Wall;
            level[2, 7] = CellType.Wall;
            level[3, 2] = CellType.Wall;
            level[3, 6] = CellType.Wall;
            level[4, 2] = CellType.Wall;
            level[4, 4] = CellType.Wall;
            level[4, 8] = CellType.Wall;
            level[5, 5] = CellType.Wall;
            level[5, 6] = CellType.Wall;
            level[5, 7] = CellType.Wall;
            level[6, 2] = CellType.Wall;
            level[6, 3] = CellType.Wall;
            level[6, 6] = CellType.Wall;
            level[7, 5] = CellType.Wall;
            level[7, 4] = CellType.Wall;
            level[7, 7] = CellType.Wall;

            level[2, 7] = CellType.Key;
            level[6, 7] = CellType.Exit;

            return level;
        }
        #endregion

        private static CellType[,] CreateEmptyLevel(int width, int height)
        {
            return new CellType[width, height];
        }

        private static void FillBorders(CellType[,] level)
        {
            int w = level.GetLength(0);
            int h = level.GetLength(1);
            for (int x = 0; x < w; x++)
            {
                level[x, 0] = CellType.Wall;
                level[x, h - 1] = CellType.Wall;
            }
            for (int y = 0; y < h; y++)
            {
                level[0, y] = CellType.Wall;
                level[w - 1, y] = CellType.Wall;
            }
        }
    }
}