using Assets.Core;
using Assets.Core.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Core.World {
    public class WorldGrid : MonoBehaviour {


        public int Width = 30;
        public int Height = 30;
        public EventManager Events;
        
        //public int Floors = 1;

        private Dictionary<CellCoordinate, Cell> _world;



        // Use this for initialization
        void Start() {


            // init the entire world to exist.
            _world = new Dictionary<CellCoordinate, Cell>();
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    var coord = new CellCoordinate(x, y);
                    _world.Add(coord, new Cell(CellStatus.FILLED, CellType.DUNGEON));
                }
            }

            // fire event 
            Events.Emit<IWorldEventHandler>(h => h.OnWorldCreated(this));
        }

        // Update is called once per frame
        void Update() {

        }
        
        public bool IsValidCoordinate(CellCoordinate coord)
        {
            return coord.X >= 0
                && coord.X < Width
                && coord.Y >= 0
                && coord.Y < Height
                && coord.Floor == 0;
        }

        public void ForAllValidCoords(Action<CellCoordinate> apply)
        {
            foreach (var coord in _world.Keys)
            {
                apply(coord);
            }
        }

        public Cell GetCell(CellCoordinate coord)
        {
            if (IsValidCoordinate(coord) == false)
            {
                throw CellCoordException.Invalid(coord);
            }

            Cell output = default(Cell);
            if (_world.TryGetValue(coord, out output) == false)
            {
                throw CellCoordException.NoData(coord);
            }

            return output;
        }

        public bool SetCell(CellCoordinate coord, Cell cell)
        {
            if (IsValidCoordinate(coord) == false)
            {
                throw CellCoordException.Invalid(coord);
            }
            var existingCell = default(Cell);
            if (_world.TryGetValue(coord, out existingCell) == false)
            {
                throw CellCoordException.NoData(coord);
            }

            // TODO perhaps validate the new cell?

            _world[coord] = cell;
            Events.Emit<IWorldEventHandler>(h => h.OnCellChanged(this, coord, existingCell, cell));
            return true;
        }

    }
}