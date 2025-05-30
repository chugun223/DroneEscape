using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneEscape.Model
{
    public class GameState
    {
        public Maze Maze { get; }
        public Drone Drone { get; private set; }

        public Position DroneStartPos { get; }

        public GameState(Maze maze, Drone drone)
        {
            Maze = maze;
            Drone = drone;
            DroneStartPos = drone.Position;
        }

        public bool IsGameWon =>
            Drone.HasKey && Maze.GetCell(Drone.Position) == CellType.Exit;
    }
}
