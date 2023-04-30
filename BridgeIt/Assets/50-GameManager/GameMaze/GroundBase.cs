using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBase 
{
    private static Vector3 NORTH_PORT = new Vector3(0.0f, 0.0f, 0.0f);
    private static Vector3 SOUTH_PORT = new Vector3(0.0f, 0.0f, 0.0f);
    private static Vector3 EAST_PORT = new Vector3(0.0f, 0.0f, 0.0f);
    private static Vector3 WEST_PORT = new Vector3(0.0f, 0.0f, 0.0f);

    public MazeCell Cell { get; private set; }
    public GameObject Ground { get; private set; }

    public GroundBase(MazeCell cell, GameObject ground) {
        this.Cell = cell;
        this.Ground = ground;
    }

    public Vector3 GetPortPosition(MazeLink mazeLink)
    {
        return(GetPortPosition(mazeLink.Direction));
    }

    public Vector3 GetOppPortPosition(MazeLink mazeLink)
    {
        return(GetPortPosition(mazeLink.FlipDirection()));
    }

    public Vector3 GetPortPosition(MazeDirection direction) 
    {
        Vector3 position = Vector3.zero;

        switch(direction) {
            case MazeDirection.NORTH:
                position = GetPosition() + NORTH_PORT;
                break;
            case MazeDirection.SOUTH:
                position = GetPosition() + SOUTH_PORT;
                break;
            case MazeDirection.EAST:
                position = GetPosition() + EAST_PORT;
                break;
            case MazeDirection.WEST:
                position = GetPosition() + WEST_PORT;
                break;

        }

        return(position);
    }

    public Vector3 GetPosition()
    {
        return(Ground.transform.position);
    }

    public MazeLink IsNeighbor(GroundBase ground)
    {
        return(Cell.IsNeighbor(ground.Cell));
    }
}
