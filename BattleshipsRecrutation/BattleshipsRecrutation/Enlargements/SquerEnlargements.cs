using BattleshipsRecrutation.AppCore.Boards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipsRecrutation.Enlargements
{
    public static class SquerEnlargements
    {
        public static Squer At(this List<Squer> squers, int row, int column)
        {
            return squers.Where(x => x.Coords.Row == row && x.Coords.Column == column).FirstOrDefault();
        }

        //Range just gives all the panels which are in the square defined by the passed-in row and column coordinates (and is inclusive of those panels).
        public static List<Squer> Range(this List<Squer> squers, int startRow, int startColumn, int endRow, int endColumn)
        {
            return squers.Where(x => x.Coords.Row >= startRow
                                     && x.Coords.Column >= startColumn
                                     && x.Coords.Row <= endRow
                                     && x.Coords.Column <= endColumn).ToList();
        }
    }
}
