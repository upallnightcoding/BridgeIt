using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCell 
{
    private MazeCellType cellType = MazeCellType.UNVISITED;

    private MazeCell[] neighbors = new MazeCell[4];

    private enum MazeCellType
    {
        VISITED,
        UNVISITED
    }

    private enum MazeNeighbors
    {
        NORTH = 0,
        EAST = 1,
        SOUTH = 2,
        WEST = 3
    }
}
