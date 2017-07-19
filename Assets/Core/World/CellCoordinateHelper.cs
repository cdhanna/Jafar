using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Core.World
{
    public static class CellCoordinateHelper
    {
        //public static void SearchBySides(this List<CellCoordinate> coords, Action<CellCoordinate> exploringNewCoord)
        //{
        //    if (coords == null) throw new ArgumentNullException("coords");
        //    if (coords.Count() == 0) return; 

        //    var traversed = new List<CellCoordinate>();
        //    var toDiscover = new Queue<CellCoordinate>();
        //    toDiscover.Enqueue(coords[0]);
        //    while (toDiscover.Count() > 0)
        //    {
        //        var discovered = toDiscover.Dequeue();
        //        exploringNewCoord(discovered);
        //        var neighbors = discovered.GetSideNeighbors();
        //    }
        //}
    }
}
