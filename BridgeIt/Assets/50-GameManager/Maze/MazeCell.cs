using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCell 
{
    public int count = 0;
    
    public int Col { get; private set; }
    public int Row { get; private set; }

    public MazeCell North { get; set; }
    public MazeCell South { get; set; }
    public MazeCell East { get; set; }
    public MazeCell West { get; set; }

    private bool IsNorth() => (North != null);
    private bool IsSouth() => (South != null);
    private bool IsEast() => (East != null);
    private bool IsWest() => (West != null);

    private MazeCellType cellType = MazeCellType.UNVISITED;

    public void MarkVisited() => cellType = MazeCellType.VISITED;

    public bool IsUnVisited() => (cellType == MazeCellType.UNVISITED);

    public MazeCell(int col, int row) 
    {
        this.Col = col;
        this.Row = row;
    }

    public int GetMazeIndex() {
        int index = 0;

        if (IsNorth()) index += 8;
        if (IsSouth()) index += 4;
        if (IsEast()) index += 2;
        if (IsWest()) index += 1;

        return(index);
    }

    public MazeLink IsNeighbor(MazeCell cell) 
    {
        return(IsNeighbor(cell.Col, cell.Row));
    }

    private MazeLink IsNeighbor(int col, int row)
    {
        bool neighbors = false;
        MazeDirection direction = MazeDirection.NORTH;

        if (Col == col) {
            neighbors = Mathf.Abs(Row - row) == 1;
            if (neighbors) {
                direction = (Row - row) == 1 ? MazeDirection.SOUTH : MazeDirection.NORTH;
            }
        } else if (Row == row) {
            neighbors = Mathf.Abs(Col - col) == 1;
            if (neighbors) {
                direction = (Col - col) == 1 ? MazeDirection.WEST : MazeDirection.EAST;
            }
        }

        Debug.Log($"Col, Row: ({Col},{col}) ({Row},{row})");

        bool isLinked = false;

        switch(direction) {
            case MazeDirection.NORTH:
                isLinked = IsNorth();
                break;
            case MazeDirection.SOUTH:
                isLinked = IsSouth();
                break;
            case MazeDirection.EAST:
                isLinked = IsEast();
                break;
            case MazeDirection.WEST:
                isLinked = IsWest();
                break;
        }

        return(neighbors ? new MazeLink(isLinked, direction) : null);
    }

    private enum MazeCellType
    {
        VISITED,
        UNVISITED
    }
}

public class MazeLink
{
    public bool IsLinked { get; private set; }
    public MazeDirection Direction { get; private set; }

    public MazeLink(bool isLinked, MazeDirection direction) 
    {
        IsLinked = isLinked;
        Direction = direction;    
    }

    public MazeDirection FlipDirection() 
    {
        MazeDirection flip = MazeDirection.NORTH;

        switch(Direction) {
            case MazeDirection.NORTH:
                flip = MazeDirection.SOUTH;
                break;
            case MazeDirection.SOUTH:
                flip = MazeDirection.NORTH;
                break;
            case MazeDirection.EAST:
                flip = MazeDirection.WEST;
                break;
            case MazeDirection.WEST:
                flip = MazeDirection.EAST;
                break;
        }

        return(flip);
    }
}

public enum MazeDirection 
{
    NORTH,
    SOUTH,
    EAST, 
    WEST
}