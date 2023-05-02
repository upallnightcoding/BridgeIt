using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMazeDisplay
{
    private GameData gameData;

    private int width;
    private int height;
    private int tileSize;
    private int bridgeSize;

    public GameMazeDisplay(GameData gameData) 
    {
        this.gameData = gameData;

        width = gameData.width;
        height = gameData.height;
        tileSize = gameData.tileSize;
        bridgeSize = gameData.bridgeSize;
    }

    public GameMaze DrawMaze(Maze maze)
    {
        GameMaze gameMaze = new GameMaze(width, height);

        for (int col = 0; col < width; col++) {
            for (int row = 0; row < height; row++) {
                Vector3 position = new Vector3();
                position.x = col * (tileSize + bridgeSize);
                position.y = 0.0f;
                position.z = row * (tileSize + bridgeSize);

                gameMaze.Set(col, row, CreateGrounds(maze, col, row, position));

                CreateBridges(maze, col, row, position);
            }
        }

        for (int col = 0; col < width-1; col++) {
            for (int row = 0; row < height-1; row++) {
                Vector3 position = new Vector3();
                position.x = col * (tileSize + bridgeSize);
                position.y = -1.0f;
                position.z = row * (tileSize + bridgeSize) + (tileSize/2.0f + 2.5f);

                Object.Instantiate(gameData.waterStripPreFab, position, Quaternion.identity);

                position.x = col * (tileSize + bridgeSize) + (tileSize/2.0f + 2.5f);
                position.y = -1.0f;
                position.z = row * (tileSize + bridgeSize);

                GameObject go = Object.Instantiate(gameData.waterStripPreFab, position, Quaternion.identity);
                go.transform.Rotate(new Vector3(0.0f, 90.0f, 0.0f));

                position.x = col * (tileSize + bridgeSize) + (tileSize/2.0f + 2.5f);
                position.y = -1.0f;
                position.z = row * (tileSize + bridgeSize) + (tileSize/2.0f + 2.5f);

                //Object.Instantiate(gameData.waterPreFab, position, Quaternion.identity);

                Framework framework = new Framework();

                framework
                    .Blueprint(gameData.waterPreFabFw)
                    .Assemble(gameData.waterPreFab, "Center")
                    .Decorate(gameData.waterFwPreFab, 30, 5.0f, 5.0f, 0.0f)
                    .Position(position)
                    .Build();
            }
        }

        for (int col = width-1; col < width; col++) {
            for (int row = 0; row < height-1; row++) {
                Vector3 position = new Vector3();
                position.x = col * (tileSize + bridgeSize);
                position.y = -1.0f;
                position.z = row * (tileSize + bridgeSize) + (tileSize/2.0f + 2.5f);

                Object.Instantiate(gameData.waterStripPreFab, position, Quaternion.identity);
            }
        }

        for (int col = 0; col < width-1; col++) {
            for (int row = height-1; row < height; row++) {
                Vector3 position = new Vector3();
                position.x = col * (tileSize + bridgeSize) + (tileSize/2.0f + 2.5f);
                position.y = -1.0f;
                position.z = row * (tileSize + bridgeSize);

                GameObject go = Object.Instantiate(gameData.waterStripPreFab, position, Quaternion.identity);
                go.transform.Rotate(new Vector3(0.0f, 90.0f, 0.0f));
            }
        }

        return(gameMaze);
    }

    private void DecorateWater() 
    {

    }

    private void CreateBridges(Maze maze, int col, int row, Vector3 position)
    {
        if (maze.IsLinkedNorth(col, row)) {
            Vector3 northPos = new Vector3();
            northPos.x = position.x;
            northPos.y = gameData.bridgeDepth;
            northPos.z = position.z + tileSize/2.0f + bridgeSize/2.0f;
            Object.Instantiate(gameData.bridgePreFab, northPos, Quaternion.identity);
        }

        if (maze.IsLinkedEast(col, row)) {
            Vector3 eastPos = new Vector3();
            eastPos.x = position.x + tileSize/2.0f + bridgeSize/2.0f;
            eastPos.y = gameData.bridgeDepth;
            eastPos.z = position.z;
            GameObject bridge = Object.Instantiate(gameData.bridgePreFab, eastPos, Quaternion.identity);
            bridge.transform.Rotate(new Vector3(0.0f, 90.0f, 0.0f));
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
}
