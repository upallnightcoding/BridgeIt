using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGen 
{
    private int width;
    private int height;

    private Maze maze = null;

    public MazeGen(int width, int height) 
    {
        this.width = width;
        this.height = height;

        maze = new Maze(width, height);
    }
}
