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

    private MazeCellType cellType = MazeCellType.UNVISITED;

    public void MarkVisited() => cellType = MazeCellType.VISITED;

    public bool IsUnVisited() => (cellType == MazeCellType.UNVISITED);

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