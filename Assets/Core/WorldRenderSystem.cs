using Assets.Core.World;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Assets.Core.Events;

public class WorldRenderSystem : MonoBehaviour, IWorldEventHandler {

    public EventManager Events;
    public GameObject OpenPrefab;
    public GameObject FilledPrefab;

    private EventManagerHook< IWorldEventHandler> _hook;

    private Dictionary<CellCoordinate, GameObject> _objects = new Dictionary<CellCoordinate, GameObject>();

	// Use this for initialization
	void Start () {

        _hook = Events.CreateHook<IWorldEventHandler>(this); 
	}
	
	// Update is called once per frame
	void Update () {

        _hook.CheckForEvents();
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
        Debug.Log("World created");
        world.ForAllValidCoords(coord =>
       {
           var cell = world.GetCell(coord);
           var gameObject = GenerateCell(cell.Status == CellStatus.OPEN, coord);
           if (_objects.ContainsKey(coord) == false)
           {
               _objects.Add(coord, gameObject);
           } else
           {
               _objects[coord] = gameObject;
           } 

       });
        
    }

    public void GenericMethod()
    {
        //throw new NotImplementedException();
    }

    public void OnCellChanged(WorldGrid world, CellCoordinate coord, Cell old, Cell next)
    {
        //Debug.Log("Need to change " + coord.X + " , " + coord.Y + " to " + next.Status);
        //throw new NotImplementedException();

        if (_objects.ContainsKey(coord))
        {

            // destroy old object
            var oldGameObject = _objects[coord];
            Destroy(oldGameObject);

            // add the new one 
            var nextGameObject = GenerateCell(next.Status == CellStatus.OPEN, coord);
            _objects[coord] = nextGameObject;
        } else
        {
            var nextGameObject = GenerateCell(next.Status == CellStatus.OPEN, coord);
            _objects.Add(coord, nextGameObject);
        }


    }
}
