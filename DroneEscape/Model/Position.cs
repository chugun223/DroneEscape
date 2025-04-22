using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneEscape.Model
{
    public struct Position
    {
        public int X { get; }
                                            //координаты клетки
        public int Y { get; }
        public Position(int x, int y)
        {
            X = x;   //конструктор создания позиции
            Y = y;
        }
        public Position Move(int dx, int dy)
        {
            return new Position(X + dx, Y + dy);        //возвращение новой позиции
        }
        public override bool Equals(object? obj)
        {
            return obj is Position other && other.X == X && other.Y == Y;
        }                                                                               //переопределение equals gethashcode и == и != для сравнения позиций
        public override int GetHashCode()
        {
            return (X, Y).GetHashCode();
        }
        public static bool operator ==(Position a, Position b) => a.X == b.X && a.Y == b.Y;
        public static bool operator !=(Position a, Position b) => !(a == b);
    }
}
