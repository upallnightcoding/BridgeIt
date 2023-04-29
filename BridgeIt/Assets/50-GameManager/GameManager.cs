using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameData gameData;

    public static GameManager Instance { get; private set; }

    private static GameMaze gameMaze = null;

    private void OnNewMaze()
    {
        Maze maze = new Maze(gameData.width, gameData.height);

        maze.Generate();

        GameMazeDisplay gameMazeDisplay = new GameMazeDisplay(gameData);

        gameMaze = gameMazeDisplay.DrawMaze(maze);
    }

    public void Start() 
    {
        if (Instance != null && Instance != this) 
        {
            Destroy(this);
        } 

        Instance = this;
    }

    public GameMaze GetGameMaze() 
    {
        return(gameMaze);
    }

    public GroundBase GetGroundBase(int col, int row)
    {
        return(gameMaze.GetGroundBase(col, row));
    }

    public GroundBase GetGroundBase(GroundBaseCntrl cntrl)
    {
        return(GetGroundBase(cntrl.col, cntrl.row));
    }

    private void OnEnable()
    {
        UICntrl.OnNewMaze += OnNewMaze;
    }

    private void OnDisable() 
    {
        UICntrl.OnNewMaze -= OnNewMaze;
    }
}
