using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Core.World
{
    public class CellCoordException : Exception
    {
        public static CellCoordException Invalid(CellCoordinate coord)
        {
            return new CellCoordException("The coordinate is invalid", coord);
        }
        public static CellCoordException NoData(CellCoordinate coord)
        {
            return new CellCoordException("There is no data for the coordinate", coord);
        }

        public CellCoordinate Coordinate { get; set; }

        public CellCoordException(string message, CellCoordinate coord) 
            : base(message)
        {
            Coordinate = coord;
        }
    }
}
