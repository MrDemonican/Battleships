using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * File responsible for storing descriptions of Status for each field
 * Can change mark of every squer just by editing [Description("mark")]
 */

namespace BattleshipsRecrutation
{
    public enum StatusOfSquer
    {
        [Description("o")]
        Empty,

        [Description("B")]
        Battleship,

        [Description("C")]
        Cruiser,

        [Description("D")]
        Destroyer,

        [Description("S")]
        Submarine,

        [Description("A")]
        Carrier,

        [Description("#")]
        Damage,

        [Description("-")]
        Miss
    }

    //Status that are used by result shot functions

    public enum ResultOfShot
    {
        Miss,
        Damage
    }
}
