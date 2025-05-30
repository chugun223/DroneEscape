using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneEscape.Model
{
    public class Drone
    {
        public Position Position { get; private set; }          //координаты дрона
        public bool HasKey { get; private set; }        //флаг подобран ли ключ

        public Drone(Position startPosition)
        {
            Position = startPosition;
            HasKey = false;
        }

        public void Move(Position newPosition)
        {
            Position = newPosition;                 //перемещение дрона по лабиринту
        }

        public void PickUpKey()
        {
            HasKey = true;          //ключ взят
        }
    }
}
