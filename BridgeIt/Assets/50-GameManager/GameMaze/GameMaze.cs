using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaze 
{
    private GroundBase[,] gameMaze = null;

    public GameMaze(int width, int heigth) {

        gameMaze = new GroundBase[width, heigth];

    }

    public void Set(int col, int row, GroundBase groundBase)
    {
        gameMaze[col, row] = groundBase;
    }

    public GroundBase GetGroundBase(int col, int row)
    {
        return(gameMaze[col, row]);
    }

    public GroundBase GetGroundBase(GroundBaseCntrl cntrl) 
    {
        return(GetGroundBase(cntrl.col, cntrl.row));
    }

   
}
