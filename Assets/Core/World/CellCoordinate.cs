using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Core.World
{
    public struct CellCoordinate
    {
        public static CellCoordinate New(int x, int y, int floor = 0)
        {
            return new CellCoordinate(x, y, floor);
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int Floor { get; set; }

        public CellCoordinate(int x, int y, int floor=0)
        {
            X = x;
            Y = y;
            Floor = floor;
        }

        public List<CellCoordinate> GetAllNeighbors()
        {
            return new List<CellCoordinate>(new CellCoordinate[]
            {
                new CellCoordinate(X + 1, Y, Floor),
                new CellCoordinate(X + 1, Y + 1, Floor),
                new CellCoordinate(X , Y + 1, Floor),
                new CellCoordinate(X - 1, Y + 1, Floor),
                new CellCoordinate(X - 1, Y, Floor),
                new CellCoordinate(X - 1, Y - 1, Floor),
                new CellCoordinate(X , Y - 1, Floor),
                new CellCoordinate(X + 1, Y - 1, Floor),
            });
        }
        public List<CellCoordinate> GetSideNeighbors()
        {
            return new List<CellCoordinate>(new CellCoordinate[]
            {
                new CellCoordinate(X + 1, Y, Floor),
                new CellCoordinate(X , Y + 1, Floor),
                new CellCoordinate(X - 1, Y, Floor),
                new CellCoordinate(X , Y - 1, Floor),
            });
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

        public override int GetHashCode()
        {
            return base.GetHashCode(); // TODO, make more complex hashcode? maybe?
        }
    }
}
