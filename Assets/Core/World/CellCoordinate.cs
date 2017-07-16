using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Core.World
{
    public struct CellCoordinate
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Floor { get; set; }

        public CellCoordinate(int x, int y, int floor=0)
        {
            X = x;
            Y = y;
            Floor = floor;
        }

        public override bool Equals(object obj)
        {
            if (obj is CellCoordinate)
            {
                var other = (CellCoordinate)obj;
                return other.X == X
                    && other.Y == Y
                    && other.Floor == Floor;
            } else
            {
                return false;
            }
        }
    }
}
