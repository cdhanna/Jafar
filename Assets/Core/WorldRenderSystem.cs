using Assets.Core.World;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Assets.Core.Events;

public class WorldRenderSystem : MonoBehaviour, IWorldEventHandler {

    public WorldGrid Grid;
    public EventManager Events;
    public GameObject OpenPrefab;
    public GameObject FilledPrefab;

    private EventManagerHook< IWorldEventHandler> _hook;

    private Dictionary<CellCoordinate, GameObject> _objects = new Dictionary<CellCoordinate, GameObject>();

	// Use this for initialization
	void Start () {

        _hook = Events.Watch<IWorldEventHandler>(this); 
	}
	
	// Update is called once per frame
	void Update () {

        _hook.Check();
	}

    public void GenerateWorld()
    {
        //Debug.Log("hello");
    }

    private GameObject GenerateCell(bool open, CellCoordinate coord)
    {
        var prefab = open == true ? OpenPrefab : FilledPrefab;
        var gameObject = Instantiate(prefab, transform);
        gameObject.transform.localPosition = new Vector3(coord.X * 2, coord.Floor * 2, coord.Y * 2);

        //gameObject.GetComponent<MeshRenderer>().material.color = open ? Color.red : Color.blue;

        return gameObject;
    }

    public void OnWorldCreated(WorldGrid world)
    {
        //Debug.Log("World created");
        world.ForAllValidCoords(coord =>
       {
           var cell = world.GetCell(coord);
           var gameObject = GenerateCell(cell.Status == CellStatus.OPEN, coord);
           _objects.Add(coord, gameObject);

       });
        
    }

    public void GenericMethod()
    {
        //throw new NotImplementedException();
    }

    public void OnCellChanged(CellCoordinate coord, Cell old, Cell next)
    {
        //Debug.Log("Need to change " + coord.X + " , " + coord.Y + " to " + next.Status);
        //throw new NotImplementedException();

        // destroy old object
        var oldGameObject = _objects[coord];
        Destroy(oldGameObject);

        // add the new one 
        var nextGameObject = GenerateCell(next.Status == CellStatus.OPEN, coord);
        _objects[coord] = nextGameObject;


    }
}
