using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze 
{
    private int width;
    private int height;

    private MazeCell[,] maze = null;

    private int RandNum(int n) => Random.Range(0, n);

    public Maze(int width, int height)
    {
        this.width = width;
        this.height = height;

        Initialize();
    }

    private void Generate()
    {
        int col = RandNum(width);
        int row = RandNum(height);

        int nCells = width * height;
        int cellCount = 0;

        while (cellCount < nCells) {
            List<MazeCell> neighbors = GetAllNeighbors(col, row);
        }
    }

    private List<MazeCell> GetAllNeighbors(int col, int row)
    {
        return(null);
    }

    private void Initialize() 
    {
        maze = new MazeCell[width, height];

        for (int col = 0; col < width; col++) {
            for (int row = 0; row < height; row++) {
                maze[col, row] = new MazeCell();
            }
        }
    }

    private MazeCell GetMazeCell(int col, int row) 
    {
        MazeCell cell = null;

        if ((col >= 0) && (row >= 0) && (col < width) && (row < height)) {
            cell = maze[col, row];
        }

        return(cell);
    }

    
}
