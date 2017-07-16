using Assets.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Core.World
{
    public interface IWorldEventHandler : IEventHandler
    {
        void OnWorldCreated(WorldGrid world);
        void OnCellChanged(CellCoordinate coord, Cell old, Cell next);
    }
}
