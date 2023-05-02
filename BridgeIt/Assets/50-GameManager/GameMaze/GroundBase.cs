using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBase 
{
    public MazeCell Cell { get; private set; }
    public GameObject Ground { get; private set; }
    public GameCollectableSO collectable;

    public GroundBase(MazeCell cell, GameObject ground) {
        this.Cell = cell;
        this.Ground = ground;
    }

    public Vector3 GetPosition()
    {
        return(Ground.transform.position);
    }

    public MazeLink IsNeighbor(GroundBase ground)
    {
        return(Cell.IsNeighbor(ground.Cell));
    }

    public void Set(GameCollectableSO collectable)
    {
        collectable.CreatePreFab(GetPosition());
    }
}
