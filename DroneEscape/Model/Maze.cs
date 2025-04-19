using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneEscape.Model
{
    public class Maze
    {
        private readonly CellType[,] labyrinth;          //массив с лабиринтом
        public int Width
        {
            get { return labyrinth.GetLength(0); }

        }
                                                                           //размеры карты
        public int Height
        {
            get { return labyrinth.GetLength(1); }
        }
        public Maze(CellType[,] labyrinth)
        {
            this.labyrinth = labyrinth;               
        }
        public CellType GetCell(Position pos)
        {
            return labyrinth[pos.X, pos.Y];                  //узнать тип клетки 
        }
        public void SetCell(Position pos, CellType type)
        {
            labyrinth[pos.X, pos.Y] = type;                      //задать тип клетки 
        }
        public bool IsInside(Position pos)
        {
            return pos.X >= 0 && pos.X < Width && pos.Y >= 0 && pos.Y < Height;     //проверка позиции на выход за пределы
        }
        public bool IsWalkable(Position pos)
        {
            if (!IsInside(pos)) return false;           //проверка на возможность продвижения
            var type = GetCell(pos);
            return type == CellType.Empty || type == CellType.Key || type == CellType.Exit;
        }
    }
}
