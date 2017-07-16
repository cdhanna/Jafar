using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Core.World
{
    public class Cell
    {
        public CellStatus Status { get; private set; }
        public CellType Type { get; private set; }

        public Cell(CellStatus status, CellType type)
        {
            Status = status;
            Type = type;
        }

    }
}
