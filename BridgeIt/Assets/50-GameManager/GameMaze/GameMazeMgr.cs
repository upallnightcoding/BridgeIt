using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMazeMgr 
{
    private GroundBase[,] gameMaze = null;
    private GameData gameData;
    private Maze maze;

    private RandomGroundQueue randomGroundQueue = null;

    private int width;
    private int height;
    private int tileSize;
    private int bridgeSize;

    public GroundBase GetNextGroundBase() => randomGroundQueue.GetNextGroundBase();

    public GroundBase GetGroundBase(int col, int row) => gameMaze[col, row];
    
    public GroundBase GetGroundBase(GroundBaseCntrl cntrl) => GetGroundBase(cntrl.col, cntrl.row);

    public GameMazeMgr(GameData gameData, Maze maze) 
    {
        this.gameData = gameData;
        this.maze = maze;

        width = gameData.width;
        height = gameData.height;
        tileSize = gameData.tileSize;
        bridgeSize = gameData.bridgeSize;

        gameMaze = new GroundBase[width, height];

        PopulateGameMaze();

        randomGroundQueue = new RandomGroundQueue(this);
    }

    public void CreatePawn(GamePawnSO gamePawn)
    {
        GroundBase groundBase = GetNextGroundBase();

        groundBase.CreatePawn(gamePawn);
    }

    public void CreateGameEneny(GameObject gameEneny)
    {
        GroundBase groundBase = GetNextGroundBase();

        groundBase.CreateGameEnemy(gameEneny);
    }

    public GroundBase[] CreateArray()
    {
        GroundBase[] arrayList = new GroundBase[gameMaze.Length];
        int index = 0;

        foreach (GroundBase groundBase in gameMaze)
        {
            arrayList[index++] = groundBase;
        }

        return(arrayList);
    }

    private void PopulateGameMaze()
    {
        for (int col = 0; col < width; col++) {
            for (int row = 0; row < height; row++) {
                Vector3 position = new Vector3();
                position.x = col * (tileSize + bridgeSize);
                position.y = 0.0f;
                position.z = row * (tileSize + bridgeSize);

                GroundBase groundBase = CreateGrounds(maze, col, row, position);

                gameMaze[col, row] = groundBase;
            }
        }
    }

    private GroundBase CreateGrounds(Maze maze, int col, int row, Vector3 position) 
    {
        MazeCell mazeCell = maze.GetMazeCell(col, row);
        GameObject go = null;
        GroundBase groundBase = null;

        if (mazeCell != null) {
            int index = mazeCell.GetMazeIndex();

            switch(index) {
                // Straight PreFab
                case 3:
                    go = CreateGroundTile(gameData.tileStraightPreFab, position, 0.0f);
                    break;
                case 12:
                    go = CreateGroundTile(gameData.tileStraightPreFab, position, 90.0f);
                    break;

                // Elbow PreFab
                case 5:
                    go = CreateGroundTile(gameData.tileElbowPreFeb, position, 0.0f);
                    break;
                case 9:
                    go = CreateGroundTile(gameData.tileElbowPreFeb, position, 90.0f);
                    break;
                case 10:
                    go = CreateGroundTile(gameData.tileElbowPreFeb, position, 180.0f);
                    break;
                case 6:
                    go = CreateGroundTile(gameData.tileElbowPreFeb, position, 270.0f);
                    break;

                // Tee PreFab
                case 7:
                    go = CreateGroundTile(gameData.tileTeePreFeb, position, 0.0f);
                    break;
                case 13:
                    go = CreateGroundTile(gameData.tileTeePreFeb, position, 90.0f);
                    break;
                case 11:
                    go = CreateGroundTile(gameData.tileTeePreFeb, position, 180.0f);
                    break;
                case 14:
                    go = CreateGroundTile(gameData.tileTeePreFeb, position, 270.0f);
                    break;

                // End PreFab
                case 1:
                    go = CreateGroundTile(gameData.tileEndPreFeb, position, 0.0f);
                    break;
                case 8:
                    go = CreateGroundTile(gameData.tileEndPreFeb, position, 90.0f);
                    break;
                case 2:
                    go = CreateGroundTile(gameData.tileEndPreFeb, position, 180.0f);
                    break;
                case 4:
                    go = CreateGroundTile(gameData.tileEndPreFeb, position, 270.0f);
                    break;

                case 15:
                    go = CreateGroundTile(gameData.tileFourPreFab, position, 0.0f);
                    break;
            }

            if (go != null) {
                groundBase = CreateGroundBase(col, row, mazeCell, go);
            }
        }

        return(groundBase);
    }

    private GroundBase CreateGroundBase(int col, int row, MazeCell mazeCell, GameObject go) 
    {
        go.name = $"({col},{row})";

        GroundBaseCntrl cntrl = go.GetComponent<GroundBaseCntrl>();
        cntrl.col = col;
        cntrl.row = row;

        return(new GroundBase(mazeCell, go));
    }

    private GameObject CreateGroundTile(GameObject preFab, Vector3 position, float rotation) 
    {
        GameObject go = Object.Instantiate(preFab, position, Quaternion.identity);
        go.transform.Rotate(0.0f, rotation, 0.0f);

        return(go);
    }

    private class RandomGroundQueue 
    {
        private Queue<GroundBase> gameQueue = null;

        public RandomGroundQueue(GameMazeMgr gameMaze)
        {
            GroundBase[] groundBase = gameMaze.CreateArray();

            Randomize(groundBase);

            gameQueue = new Queue<GroundBase>(groundBase);
        }

        public GroundBase GetNextGroundBase()
        {
            return(gameQueue.Dequeue());
        }

        public void ReturnGroundBase(GroundBase groundBase)
        {
            gameQueue.Enqueue(groundBase);
        }

        private void Randomize(GroundBase[] groundBase) 
        {
            int size = groundBase.Length;

            for (int count = 0; count < size; count++)
            {
                int index1 = UnityEngine.Random.Range(0, size);
                int index2 = UnityEngine.Random.Range(0, size);

                if (index1 != index2) 
                {
                    GroundBase temp = groundBase[index1];
                    groundBase[index1] = groundBase[index2];
                    groundBase[index2] = temp;
                }
            }
        }
    }
}
