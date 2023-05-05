using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameData gameData;

    public static GameManager Instance { get; private set; }

    // Lambda Functions
    public GameMazeMgr GetGameMazeMgr() => gameMazeMgr;

    private GameMazeMgr gameMazeMgr;

    private void OnNewMaze()
    {
        Maze maze = new Maze(gameData);

        GameMazeDisplay gameMazeDisplay = new GameMazeDisplay(gameData, maze);

        gameMazeMgr = new GameMazeMgr(gameData, maze);
    }

    public void Start() 
    {
        if (Instance != null && Instance != this) 
        {
            Destroy(this);
        } 

        Instance = this;
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
