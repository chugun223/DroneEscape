using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneEscape.Model
{
    public enum CellType        //тип клетки 
    {
        Empty,          //пустая клетка
        Wall,           //стена
        Key,            //клетка с ключом
        Exit            //клетка с выходом
    }
}
