using Assets.Core.Events;
using Assets.Core.Rooms.RoomTypes;
using Assets.Core.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Core.Rooms
{
    public class RoomManager : MonoBehaviour, IWorldEventHandler
    {
        //public WorldGrid World;
        public EventManager Events;

        private EventManagerHook<IWorldEventHandler> _hook;
        private List<RoomType> _roomTypes;
        private List<Room> _rooms;

        public void Start()
        {
            _roomTypes = new List<RoomType>();
            _rooms = new List<Room>();

            _roomTypes.Add(new Library()); // TODO have a file detailing all the different kinds of rooms?

            _hook = Events.CreateHook<IWorldEventHandler>(this);
        }

        public void Update()
        {
            _hook.CheckForEvents();
        }

        public void AddRoom(Room room)
        {
            _rooms.Add(room);
            Events.Emit<IRoomManagerEvents>(m => m.OnRoomAdded(room));
        }

        public void OnCellChanged(WorldGrid world, CellCoordinate coord, Cell old, Cell next)
        {
            //throw new NotImplementedException();
        }

        public void OnWorldCreated(WorldGrid world)
        {
            world.SetCell(CellCoordinate.New(9, 9), new Cell(CellStatus.OPEN, CellType.DUNGEON));
            world.SetCell(CellCoordinate.New(10, 9), new Cell(CellStatus.OPEN, CellType.DUNGEON));
            world.SetCell(CellCoordinate.New(11, 9), new Cell(CellStatus.OPEN, CellType.DUNGEON));
            world.SetCell(CellCoordinate.New(12, 9), new Cell(CellStatus.OPEN, CellType.DUNGEON));

            world.SetCell(CellCoordinate.New(9, 10), new Cell(CellStatus.OPEN, CellType.DUNGEON));
            world.SetCell(CellCoordinate.New(10, 10), new Cell(CellStatus.OPEN, CellType.DUNGEON));
            world.SetCell(CellCoordinate.New(11, 10), new Cell(CellStatus.OPEN, CellType.DUNGEON));
            world.SetCell(CellCoordinate.New(12, 10), new Cell(CellStatus.OPEN, CellType.DUNGEON));

            world.SetCell(CellCoordinate.New(9, 11), new Cell(CellStatus.OPEN, CellType.DUNGEON));
            world.SetCell(CellCoordinate.New(10, 11), new Cell(CellStatus.OPEN, CellType.DUNGEON));
            world.SetCell(CellCoordinate.New(11, 11), new Cell(CellStatus.OPEN, CellType.DUNGEON));
            world.SetCell(CellCoordinate.New(12, 11), new Cell(CellStatus.OPEN, CellType.DUNGEON));

            world.SetCell(CellCoordinate.New(9, 12), new Cell(CellStatus.OPEN, CellType.DUNGEON));
            world.SetCell(CellCoordinate.New(10, 12), new Cell(CellStatus.OPEN, CellType.DUNGEON));
            world.SetCell(CellCoordinate.New(11, 12), new Cell(CellStatus.OPEN, CellType.DUNGEON));
            world.SetCell(CellCoordinate.New(12, 12), new Cell(CellStatus.OPEN, CellType.DUNGEON));

            Debug.Log("Creating room");
            var room = new Room(_roomTypes[0], new CellCoordinate[]
            {
                CellCoordinate.New(10, 10),
                CellCoordinate.New(11, 10),
                CellCoordinate.New(10, 11),
                CellCoordinate.New(11, 11),
                CellCoordinate.New(12, 11),
            }.ToList());
            AddRoom(room);

            world.SetCell(CellCoordinate.New(8, 12), new Cell(CellStatus.OPEN, CellType.DUNGEON));
            //world.SetCell(CellCoordinate.New(9, 8), new Cell(CellStatus.OPEN, CellType.DUNGEON));

            var room2 = new Room(_roomTypes[0], new CellCoordinate[]
            {
                CellCoordinate.New(5, 11),
                CellCoordinate.New(5, 12),
                CellCoordinate.New(6, 11),
                CellCoordinate.New(6, 12),
                CellCoordinate.New(7, 11),
                CellCoordinate.New(7, 12),
            }.ToList());
            room2.Coordinates.ForEach(c => world.SetCell(c, new Cell(CellStatus.OPEN, CellType.DUNGEON)));
            AddRoom(room2);
            //throw new NotImplementedException();
        }


    }
}
