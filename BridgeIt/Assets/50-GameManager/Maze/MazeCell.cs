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

    public int GetMazeIndex() {
        int index = 0;

        if (IsNorth()) index += 8;
        if (IsSouth()) index += 4;
        if (IsEast()) index += 2;
        if (IsWest()) index += 1;

        return(index);
    }

    public MazeCell(int col, int row) 
    {
        this.Col = col;
        this.Row = row;
    }

    private enum MazeCellType
    {
        VISITED,
        UNVISITED
    }
}