using BattleshipsRecrutation.Enlargements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

        /*
         * Represents a collection of Squers to provide a Player with their Game Board (e.g. where their ships are placed).
         */   

namespace BattleshipsRecrutation.AppCore.Boards
{
    public class MyBoard
    {
        //Calling Squers
        public List<Squer> Squers { get; set; }
        //Adding squers to MyBoard(in console the left one)
        public MyBoard()
        {
            Squers = new List<Squer>();
            for (int i = 1; i <= 10; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    Squers.Add(new Squer(i, j));
                }
            }
        }
    }
}
