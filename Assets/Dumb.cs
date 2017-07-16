using Assets.Core.World;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dumb : MonoBehaviour {


    public WorldGrid WorldGrid;

    public CellCoordinate[] CoordsToToggle = new CellCoordinate[] {
        new CellCoordinate(5, 5),
        new CellCoordinate(6, 5),
        new CellCoordinate(5, 6),
        new CellCoordinate(20, 5),
        new CellCoordinate(21, 5),
        new CellCoordinate(20, 6),
        new CellCoordinate(21, 6),
        new CellCoordinate(5, 15),
        new CellCoordinate(6, 16),
        new CellCoordinate(7, 17),
        new CellCoordinate(8, 18),
        new CellCoordinate(9, 19),
        new CellCoordinate(10, 19),
        new CellCoordinate(9, 19),
        new CellCoordinate(17, 19),
        new CellCoordinate(18, 17),
        new CellCoordinate(19, 16),
        new CellCoordinate(20, 15),
    };

    public float IntervalTime = 1;

    private float _nextTime = 0;
    private int _index = 0;
	// Use this for initialization
	void Start () {
        _nextTime = Time.time + IntervalTime;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > _nextTime)
        {
            _nextTime = Time.time + IntervalTime;

            var coord = CoordsToToggle[_index];

            var cell = WorldGrid.GetCell(coord);
            var next = new Cell(cell.Status == CellStatus.OPEN ? CellStatus.FILLED : CellStatus.OPEN, cell.Type);
            WorldGrid.SetCell(coord, next);

            _index = (_index + 1) % CoordsToToggle.Length; // increment index and wrap it around array size. 
        }
	}
}
