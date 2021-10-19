using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 * Not in use - need to work on coordinates 
 */

//Dev comment - can't change ints for coord using Ai logic.
//Probably I need to think about other metod of calculating position of squers
namespace BattleshipsRecrutation.AppCore.Boards
{
    public class HumanCoords
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public HumanCoords(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}