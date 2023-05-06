using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBase 
{
    // Maze Linkage Information
    public MazeCell Cell { get; private set; }

    // Ground Platform 1, 2, 3, or 4 connections
    public GameObject Ground { get; private set; }

    // Optional game pawn
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
        
        GameObject pawn = gamePawn.CreatePawn(GetPosition());
        PawnCntrl pawnCntrl = pawn.GetComponent<PawnCntrl>();
        pawnCntrl.Set(gamePawn);
    }
}
