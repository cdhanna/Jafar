using Assets.Core.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Core.Rooms
{
    public class RoomException : Exception
    {
        public static RoomException NotBigEnough(int minSize, RoomType type, List<CellCoordinate> coords)
        {
            return new RoomException("The room was not big enough. It must have at least " + minSize + " tiles.", type, coords);
        }

        public RoomType RoomType { get; set; }
        public List<CellCoordinate> Coordinates { get; set; }
        public RoomException(string message, RoomType type, List<CellCoordinate> coords) : base(message)
        {
            RoomType = type;
            Coordinates = coords;
        }
    }
}
