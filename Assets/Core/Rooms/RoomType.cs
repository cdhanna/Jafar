using Assets.Core.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Core.Rooms
{
    public class RoomType
    {
        public string Name { get; protected set; }

        public RoomType(string name)
        {
            Name = name;
        }

        public virtual bool ValidCoordinates(List<CellCoordinate> coordinates)
        {
            // check to make sure not null
            if (coordinates == null) throw new ArgumentNullException("coordinates");

            // check to make sure there are least 4 cells
            if (coordinates.Count < 4)
            {
                Debug.LogError("room invalid because it had less than 4 tiles");
                return false;
            }

            // check to make sure that the coordinates are all next to eachother. 
            var traversed = new List<CellCoordinate>();
            var toExplore = new Queue<CellCoordinate>();
            var startingPoint = coordinates[0];
            toExplore.Enqueue(startingPoint);
            while (toExplore.Count > 0)
            {
                var exploring = toExplore.Dequeue();
                if (traversed.Contains(exploring) == false && coordinates.Contains(exploring) == true)
                {
                    traversed.Add(exploring);
                    var neighbors = exploring.GetSideNeighbors();
                    foreach (var n in neighbors)
                    {
                        toExplore.Enqueue(n);
                    }
                }
            }
            if (traversed.Count != coordinates.Count)
            {
                Debug.LogError("room invalid because it wasn't continious");
                return false;
            }

            // check to make sure that the room is at least a 2x2 box 
            var uniqueXValues = coordinates.Select(c => c.X).Distinct().ToList();
            uniqueXValues.Sort();
            if (uniqueXValues.Count() < 2 || Math.Abs(uniqueXValues[ uniqueXValues.Count / 2 ] - uniqueXValues[-1 + uniqueXValues.Count / 2]) != 1)
            {
                Debug.LogError("Room invalid because it didnt have at least 2 tiles next to eachother on the x axis");
                return false;
            }
            var uniqueYValues = coordinates.Select(c => c.Y).Distinct().ToList();
            uniqueYValues.Sort();
            if (uniqueYValues.Count() < 2 || Math.Abs(uniqueYValues[uniqueYValues.Count / 2] - uniqueYValues[-1 + uniqueYValues.Count / 2]) != 1)
            {
                Debug.LogError("Room invalid because it didnt have at least 2 tiles next to eachother on the y axis");
                return false;
            }

            return true;
        }

        //TODO add allowable objects
        //TODO add min/max dimensions of room
        //TODO add positioning rules (aka, must be positioned on level X, or next to windows, or not next to anything) 
    }
}
