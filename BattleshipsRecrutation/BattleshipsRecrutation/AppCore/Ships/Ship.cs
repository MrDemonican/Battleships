using BattleshipsRecrutation.AppCore.Boards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipsRecrutation.AppCore
{

    // Represents a player's ship as placed on their Game Board.

    public abstract class Ship
    {
        //Each kind of ship properties
        public string Name { get; set; }
        public int Width { get; set; }
        public int Damaged { get; set; }
        public StatusOfSquer StatusOfSquer { get; set; }
        public bool IsSunk
        {
            get
            {
                return Damaged >= Width;
            }
        }
    }

    //Defining values in each Ship properties - name, width, status etc...
    public class Submarine : Ship
    {
        public Submarine()
        {
            Name = "Submarine";
            Width = 3;
            StatusOfSquer = StatusOfSquer.Submarine;
        }
    }
    public class Destroyer : Ship
    {
        public Destroyer()
        {
            Name = "Destroyer";
            Width = 2;
            StatusOfSquer = StatusOfSquer.Destroyer;
        }
    }
    public class Cruiser : Ship
    {
        public Cruiser()
        {
            Name = "Cruiser";
            Width = 3;
            StatusOfSquer = StatusOfSquer.Cruiser;
        }
    }
    public class Carrier : Ship
    {
        public Carrier()
        {
            Name = "Aircraft Carrier";
            Width = 5;
            StatusOfSquer = StatusOfSquer.Carrier;
        }
    }
    public class Battleship : Ship
    {
        public Battleship()
        {
            Name = "Battleship";
            Width = 4;
            StatusOfSquer = StatusOfSquer.Battleship;
        }
    }
}

