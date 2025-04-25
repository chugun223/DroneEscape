using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneEscape.Model
{
    public class Maze
    {
        private CellType[,] grid;       //массив с лабиринтом
        public int Width { get; private set; }
        public int Height { get; private set; }
        public Maze(CellType[,] grid)
        {
            this.grid = grid;
            Width = grid.GetLength(0);
            Height = grid.GetLength(1);
        }
        public CellType GetCell(Position pos)
        {
            return grid[pos.X, pos.Y];                  //узнать тип клетки 
        }
        public void SetCell(Position pos, CellType type)
        {
            grid[pos.X, pos.Y] = type;                      //задать тип клетки 
        }
        public bool IsInside(Position pos)
        {
            return pos.X >= 0 && pos.X < Width && pos.Y >= 0 && pos.Y < Height;   //проверка позиции на выход за пределы
        }
        public bool IsWalkable(Position pos)
        {
            if (!IsInside(pos)) return false;           //проверка на возможность продвижения
            var type = GetCell(pos);
            return type == CellType.Empty || type == CellType.Key || type == CellType.Exit;
        }
        public CellType[,] CloneGrid()
        {
            var clone = new CellType[Width, Height];
            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Height; y++)
                    clone[x, y] = grid[x, y];
            return clone;
        }
    }
}
