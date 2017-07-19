using Assets.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Core.Rooms
{
    public interface IRoomManagerEvents : IEventHandler
    {
        void OnRoomAdded(Room room);
    }
}
