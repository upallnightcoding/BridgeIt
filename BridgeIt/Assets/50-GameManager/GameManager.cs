using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameData gameData;
    [SerializeField] private UICntrl uiCntrl;

    public static GameManager Instance { get; private set; }

    // Lambda Functions
    public GameMazeMgr GetGameMazeMgr() => gameMazeMgr;

    public void AddToScore(int delta) => uiCntrl.AddToScore(delta);

    private GameMazeMgr gameMazeMgr;

    public void Start() 
    {
        if (Instance != null && Instance != this) 
        {
            Destroy(this);
        } 

        Instance = this;
    }

    public void ClearAbilitySlotFocus()
    {
        uiCntrl.ClearAbilitySlotFocus();
    }

    private void OnNewMaze()
    {
        Maze maze = new Maze(gameData);

        GameMazeDisplay gameMazeDisplay = new GameMazeDisplay(gameData, maze);

        gameMazeMgr = new GameMazeMgr(gameData, maze);

        uiCntrl.AddToScore(0);
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
