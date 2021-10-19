using BattleshipsRecrutation.Enlargements;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipsRecrutation.AppCore.Boards
{
    /* 
     * The basic class for this modelling practice.  Represents a single square on the game board.
     */
    public class Squer
    {
        //Properties of every squer
        public StatusOfSquer StatusOfSquer { get; set; }
        public Coords Coords { get; set; }

        //Setting squer status to .Empty - drawing O on board
        public Squer(int row, int column)
        {
            Coords = new Coords(row, column);
            StatusOfSquer = StatusOfSquer.Empty;
        }

        public string Status
        {
            get
            {
                return StatusOfSquer.GetAttributeOfType<DescriptionAttribute>().Description;
            }
        }


        //Method is responsible for setting status of squers
        public bool IsDisable
        {
            get
            {
                return StatusOfSquer == StatusOfSquer.Battleship
                    || StatusOfSquer == StatusOfSquer.Destroyer
                    || StatusOfSquer == StatusOfSquer.Cruiser
                    || StatusOfSquer == StatusOfSquer.Submarine
                    || StatusOfSquer == StatusOfSquer.Carrier;
            }
        }


        public bool RandEnable
        {
            get
            {        
                //checking if squers are even or odd
                return (Coords.Row % 2 == 0 && Coords.Column % 2 == 0)
                    || (Coords.Row % 2 == 1 && Coords.Column % 2 == 1);
            }
        }
    }
}