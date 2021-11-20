using System.Collections.Generic;
using System.Linq;

namespace BattleShipGame
{
    public static class ExtensionMethods
    {
        public static Cells At(this IList<Cells> panels, int row, int column)
        {
            return panels.Where(x => x.Coordinates.Row == row && x.Coordinates.Column == column).First();
        }

        public static List<Cells> Range(this IList<Cells> cells, int startRow, int startColumn, int endRow, int endColumn)
        {
            int rangeStartRow, rangeStartColumn, rangeEndRow, rangeEndColumn;

            if (endRow > startRow)
            {
                rangeStartRow = startRow;
                rangeEndRow = endRow;
            }
            else
            {
                rangeStartRow = endRow;
                rangeEndRow = startRow;
            }

            if (endColumn > startColumn)
            {
                rangeStartColumn = startColumn;
                rangeEndColumn = endColumn;
            }
            else
            {
                rangeStartColumn = endColumn;
                rangeEndColumn = startColumn;
            }

            return cells.Where(x => x.Coordinates.Row >= rangeStartRow
                                     && x.Coordinates.Column >= rangeStartColumn
                                     && x.Coordinates.Row <= rangeEndRow
                                     && x.Coordinates.Column <= rangeEndColumn).ToList();
        }
                 
    }
}
