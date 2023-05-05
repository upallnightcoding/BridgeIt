using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MazeGen : MonoBehaviour
{
    // THIS CLASS SHOULD BE DELETED ...
    
    [SerializeField] private GameData gameData;
    [SerializeField] private GameObject tileCrossPreFab;
    [SerializeField] private GameObject tileStraightPreFab;
    [SerializeField] private GameObject tileElbowPreFeb;
    [SerializeField] private GameObject tileTeePreFeb;
    [SerializeField] private GameObject tileEndPreFeb;
    [SerializeField] private GameObject bridgePreFab;
    [SerializeField] private GameObject waterPreFab;
    [SerializeField] private GameObject waterStripPreFab;

    [SerializeField] private int width;
    [SerializeField] private int height;

    [SerializeField] private int tileSize;
    [SerializeField] private int bridgeSize;

    //private Maze maze = null;

    private void Start() 
    {
        
    }

    // private GameMaze DrawMaze(Maze maze)
    // {
    //     GameMaze gameMaze = new GameMaze(width, height);

    //     for (int col = 0; col < width; col++) {
    //         for (int row = 0; row < height; row++) {
    //             Vector3 position = new Vector3();
    //             position.x = col * (tileSize + bridgeSize);
    //             position.y = 0.0f;
    //             position.z = row * (tileSize + bridgeSize);

    //             gameMaze.Set(col, row, CreateGrounds(col, row, position));

    //             CreateBridges(col, row, position);
    //         }
    //     }

    //     for (int col = 0; col < width-1; col++) {
    //         for (int row = 0; row < height-1; row++) {
    //             Vector3 position = new Vector3();
    //             position.x = col * (tileSize + bridgeSize);
    //             position.y = -1.0f;
    //             position.z = row * (tileSize + bridgeSize) + (tileSize/2.0f + 2.5f);

    //             Instantiate(waterStripPreFab, position, Quaternion.identity);

    //             position.x = col * (tileSize + bridgeSize) + (tileSize/2.0f + 2.5f);
    //             position.y = -1.0f;
    //             position.z = row * (tileSize + bridgeSize);

    //             GameObject go = Instantiate(waterStripPreFab, position, Quaternion.identity);
    //             go.transform.Rotate(new Vector3(0.0f, 90.0f, 0.0f));

    //             position.x = col * (tileSize + bridgeSize) + (tileSize/2.0f + 2.5f);
    //             position.y = -1.0f;
    //             position.z = row * (tileSize + bridgeSize) + (tileSize/2.0f + 2.5f);

    //             Instantiate(waterPreFab, position, Quaternion.identity);
    //         }
    //     }

    //     for (int col = width-1; col < width; col++) {
    //         for (int row = 0; row < height-1; row++) {
    //             Vector3 position = new Vector3();
    //             position.x = col * (tileSize + bridgeSize);
    //             position.y = -1.0f;
    //             position.z = row * (tileSize + bridgeSize) + (tileSize/2.0f + 2.5f);

    //             Instantiate(waterStripPreFab, position, Quaternion.identity);
    //         }
    //     }

    //     for (int col = 0; col < width-1; col++) {
    //         for (int row = height-1; row < height; row++) {
    //             Vector3 position = new Vector3();
    //             position.x = col * (tileSize + bridgeSize) + (tileSize/2.0f + 2.5f);
    //             position.y = -1.0f;
    //             position.z = row * (tileSize + bridgeSize);

    //             GameObject go = Instantiate(waterStripPreFab, position, Quaternion.identity);
    //             go.transform.Rotate(new Vector3(0.0f, 90.0f, 0.0f));
    //         }
    //     }

    //     return(gameMaze);
    // }

    // private void CreateBridges(int col, int row, Vector3 position)
    // {
    //     if (maze.IsLinkedNorth(col, row)) {
    //         Vector3 northPos = new Vector3();
    //         northPos.x = position.x;
    //         northPos.y = -0.30f;
    //         northPos.z = position.z + tileSize/2.0f + bridgeSize/2.0f;
    //         Instantiate(bridgePreFab, northPos, Quaternion.identity);
    //     }

    //     if (maze.IsLinkedEast(col, row)) {
    //         Vector3 eastPos = new Vector3();
    //         eastPos.x = position.x + tileSize/2.0f + bridgeSize/2.0f;
    //         eastPos.y = -0.30f;
    //         eastPos.z = position.z;
    //         GameObject bridge = Instantiate(bridgePreFab, eastPos, Quaternion.identity);
    //         bridge.transform.Rotate(new Vector3(0.0f, 90.0f, 0.0f));
    //     }
    // }

    // private GroundBase CreateGrounds(int col, int row, Vector3 position) 
    // {
    //     MazeCell mazeCell = maze.GetMazeCell(col, row);
    //     GameObject go = null;
    //     GroundBase groundBase = null;

    //     if (mazeCell != null) {
    //         int index = mazeCell.GetMazeIndex();

    //         switch(index) {
    //             // Straight PreFab
    //             case 3:
    //                 go = CreateGroundTile(tileStraightPreFab, position, 0.0f);
    //                 break;
    //             case 12:
    //                 go = CreateGroundTile(tileStraightPreFab, position, 90.0f);
    //                 break;

    //             // Elbow PreFab
    //             case 5:
    //                 go = CreateGroundTile(tileElbowPreFeb, position, 0.0f);
    //                 break;
    //             case 9:
    //                 go = CreateGroundTile(tileElbowPreFeb, position, 90.0f);
    //                 break;
    //             case 10:
    //                 go = CreateGroundTile(tileElbowPreFeb, position, 180.0f);
    //                 break;
    //             case 6:
    //                 go = CreateGroundTile(tileElbowPreFeb, position, 270.0f);
    //                 break;

    //             // Tee PreFab
    //             case 7:
    //                 go = CreateGroundTile(tileTeePreFeb, position, 0.0f);
    //                 break;
    //             case 13:
    //                 go = CreateGroundTile(tileTeePreFeb, position, 90.0f);
    //                 break;
    //             case 11:
    //                 go = CreateGroundTile(tileTeePreFeb, position, 180.0f);
    //                 break;
    //             case 14:
    //                 go = CreateGroundTile(tileTeePreFeb, position, 270.0f);
    //                 break;

    //             // End PreFab
    //             case 1:
    //                 go = CreateGroundTile(tileEndPreFeb, position, 0.0f);
    //                 break;
    //             case 8:
    //                 go = CreateGroundTile(tileEndPreFeb, position, 90.0f);
    //                 break;
    //             case 2:
    //                 go = CreateGroundTile(tileEndPreFeb, position, 180.0f);
    //                 break;
    //             case 4:
    //                 go = CreateGroundTile(tileEndPreFeb, position, 270.0f);
    //                 break;
    //         }

    //         if (go != null) {
    //             groundBase = CreateGroundBase(col, row, mazeCell, go);
    //         }
    //     }

    //     return(groundBase);
    // }

    // private GroundBase CreateGroundBase(int col, int row, MazeCell mazeCell, GameObject go) 
    // {
    //     go.name = $"({col},{row})";

    //     GroundBaseCntrl cntrl = go.GetComponent<GroundBaseCntrl>();
    //     cntrl.col = col;
    //     cntrl.row = row;

    //     return(new GroundBase(mazeCell, go));
    // }

    // private GameObject CreateGroundTile(GameObject preFab, Vector3 position, float rotation) 
    // {
    //     GameObject go = Instantiate(preFab, position, Quaternion.identity);
    //     go.transform.Rotate(0.0f, rotation, 0.0f);

    //     return(go);
    // }
}


