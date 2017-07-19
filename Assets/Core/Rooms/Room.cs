using Assets.Core.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Core.Rooms
{
    public class Room
    {
        public RoomType RoomType { get; private set; }
        public List<CellCoordinate> Coordinates { get; private set; }

        public Room(RoomType type, List<CellCoordinate> coordinates)
        {
            if (type == null) throw new ArgumentNullException("type");
            if (type.ValidCoordinates(coordinates) == false) throw new InvalidOperationException("the room was invalid");

            Coordinates = coordinates;
            RoomType = type;
        }
    }
}
