using BattleshipsRecrutation.Enlargements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

   /* 
    * Represents a collection of Squers to show where the player has fired shots, and whether those shots are hits or misses.
    */

namespace BattleshipsRecrutation.AppCore.Boards
{
    public class EnemyFoggedBoard : MyBoard
    {

        public List<Coords> EverySquerShot()
        {
            return Squers.Where(x => x.StatusOfSquer == StatusOfSquer.Empty && x.RandEnable).Select(x => x.Coords).ToList();
        }

        //We are taking the status of specified field and adding to list
        //Only condition is that the "last" shot made dmg to oponent.
        public List<Coords> CloseToGoodHit()
        {
            List<Squer> squers = new List<Squer>();
            var hits = Squers.Where(x => x.StatusOfSquer == StatusOfSquer.Damage);
            foreach (var hit in hits)
            {
                squers.AddRange(CloseToShot(hit.Coords).ToList());
            }

            return squers.Distinct().Where(x => x.StatusOfSquer == StatusOfSquer.Empty).Select(x => x.Coords).ToList();
        }

        //Adding coordinates to list of squers that are close to last AiPlayer shot
        public List<Squer> CloseToShot(Coords coordinates)
        {
            int row = coordinates.Row;
            int column = coordinates.Column;
            List<Squer> squers = new List<Squer>();
            if (column > 1)
            {
                squers.Add(Squers.At(row, column - 1));
            }
            if (row > 1)
            {
                squers.Add(Squers.At(row - 1, column));
            }
            if (row < 10)
            {
                squers.Add(Squers.At(row + 1, column));
            }
            if (column < 10)
            {
                squers.Add(Squers.At(row, column + 1));
            }
            return squers;
        }


        //Dev comment - This fragment can be usefull in making coord for HumanPlayer
        //Player loading coords for shot method

        /*
        public List<Squer> FireAtWill(Coords coordinates)
        {
            int row = coordinates.Row;
            int column = coordinates.Column;
            List<Squer> squers = new List<Squer>();
        }
        */
    }
}
