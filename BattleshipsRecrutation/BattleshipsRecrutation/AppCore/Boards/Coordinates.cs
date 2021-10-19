using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * File responsible for seting attributes of coordinates for :
 *      Squers
 *      Shots
 *      Results
 */


namespace BattleshipsRecrutation.AppCore.Boards
{
    public class Coords
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public Coords(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}
