using Assets.Core.Events;
using Assets.Core.Rooms;
using Assets.Core.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Core
{
    public class RoomRenderSystem : MonoBehaviour, IRoomManagerEvents
    {
        public EventManager Events;
        public GameObject WallPillarPrefab;


        private EventManagerHook<IRoomManagerEvents> _hook;

        public void Start()
        {
            _hook = Events.CreateHook<IRoomManagerEvents>(this);
        }

        public void Update()
        {
            _hook.CheckForEvents();
        }

        public void OnRoomAdded(Room room)
        {
            // need to identify the outskirts of the room, and build walls around it. 
            //room.Coordinates.ForEach(GenerateWall);
            foreach(var coord in room.Coordinates)
            {
                var neighborOnRight = room.Coordinates.Contains(new CellCoordinate(coord.X + 1, coord.Y, coord.Floor));
                var neighborOnLeft = room.Coordinates.Contains(new CellCoordinate(coord.X - 1, coord.Y, coord.Floor));
                var neighborOnTop = room.Coordinates.Contains(new CellCoordinate(coord.X, coord.Y - 1, coord.Floor));
                var neighborOnLow = room.Coordinates.Contains(new CellCoordinate(coord.X, coord.Y + 1, coord.Floor));
                GenerateWall(coord, !neighborOnRight, !neighborOnLeft, !neighborOnTop, !neighborOnLow);
            }
        }

        private void GenerateWall(CellCoordinate coord, bool right, bool left, bool top, bool low)
        {
            //var right = true;
            //var left = true;
            //var top = true;
            //var low = true;

            // clone the wall pillar
            if (right)
            {
                var wall = Instantiate(WallPillarPrefab, transform);
                wall.transform.localScale = new Vector3(.1f, 1, 2);
                wall.transform.localPosition = new Vector3(.95f + coord.X * 2, .5f + coord.Floor * 2, coord.Y * 2);
            }
            if (left)
            {
                var wall = Instantiate(WallPillarPrefab, transform);
                wall.transform.localScale = new Vector3(.1f, 1, 2);
                wall.transform.localPosition = new Vector3(-.95f + coord.X * 2, .5f + coord.Floor * 2, coord.Y * 2);
            }
            if (top)
            {
                var wall = Instantiate(WallPillarPrefab, transform);
                wall.transform.localScale = new Vector3(2, 1, .1f);
                wall.transform.localPosition = new Vector3(coord.X * 2, .5f + coord.Floor * 2, -.95f + coord.Y * 2);
            }
            if (low)
            {
                var wall = Instantiate(WallPillarPrefab, transform);
                wall.transform.localScale = new Vector3(2, 1, .1f);
                wall.transform.localPosition = new Vector3(coord.X * 2, .5f + coord.Floor * 2, .95f + coord.Y * 2);
            }
        }

    }
}
