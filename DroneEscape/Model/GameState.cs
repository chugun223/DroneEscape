using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneEscape.Model
{
    public class GameState
    {
        public Maze Maze { get; }       //наш лабиринт
        public Drone Drone { get; }     //наш дрон

        public bool IsGameWon => Maze.GetCell(Drone.Position) == CellType.Exit && Drone.HasKey;     //проверка на окончание уровня

        public GameState(Maze maze, Drone drone)
        {
            Maze = maze;
            Drone = drone;
        }
    }
}
