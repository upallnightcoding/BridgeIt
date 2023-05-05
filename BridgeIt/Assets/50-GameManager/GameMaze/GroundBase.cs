using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBase 
{
    public MazeCell Cell { get; private set; }
    public GameObject Ground { get; private set; }
    public GamePawnSO gamePawn;

    // Return the position of the Ground Base
    public Vector3 GetPosition() => Ground.transform.position;

    public GroundBase(MazeCell cell, GameObject ground) {
        this.Cell = cell;
        this.Ground = ground;
    }

    public MazeLink IsNeighbor(GroundBase ground)
    {
        return(Cell.IsNeighbor(ground.Cell));
    }

    public void CreatePawn(GamePawnSO gamePawn)
    {
        this.gamePawn = gamePawn;

        gamePawn.CreatePawn(GetPosition());
    }
}
