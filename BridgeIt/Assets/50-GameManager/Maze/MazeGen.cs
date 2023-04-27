using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGen : MonoBehaviour
{
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

    private Maze maze = null;

    private void Start() 
    {
        maze = new Maze(width, height);

        maze.Generate();

        DrawMaze(maze);
    }

    private void DrawMaze(Maze maze)
    {
        for (int col = 0; col < width; col++) {
            for (int row = 0; row < height; row++) {
                Vector3 position = new Vector3();
                position.x = col * (tileSize + bridgeSize);
                position.y = 0.0f;
                position.z = row * (tileSize + bridgeSize);

                CreateGrounds(col, row, position);

                CreateBridges(col, row, position);
            }
        }

        for (int col = 0; col < width-1; col++) {
            for (int row = 0; row < height-1; row++) {
                Vector3 position = new Vector3();
                position.x = col * (tileSize + bridgeSize);
                position.y = -1.0f;
                position.z = row * (tileSize + bridgeSize) + (tileSize/2.0f + 2.5f);

                Instantiate(waterStripPreFab, position, Quaternion.identity);

                position.x = col * (tileSize + bridgeSize) + (tileSize/2.0f + 2.5f);
                position.y = -1.0f;
                position.z = row * (tileSize + bridgeSize);

                GameObject go = Instantiate(waterStripPreFab, position, Quaternion.identity);
                go.transform.Rotate(new Vector3(0.0f, 90.0f, 0.0f));

                position.x = col * (tileSize + bridgeSize) + (tileSize/2.0f + 2.5f);
                position.y = -1.0f;
                position.z = row * (tileSize + bridgeSize) + (tileSize/2.0f + 2.5f);

                Instantiate(waterPreFab, position, Quaternion.identity);
            }
        }

        for (int col = width-1; col < width; col++) {
            for (int row = 0; row < height-1; row++) {
                Vector3 position = new Vector3();
                position.x = col * (tileSize + bridgeSize);
                position.y = -1.0f;
                position.z = row * (tileSize + bridgeSize) + (tileSize/2.0f + 2.5f);

                Instantiate(waterStripPreFab, position, Quaternion.identity);
            }
        }

        for (int col = 0; col < width-1; col++) {
            for (int row = height-1; row < height; row++) {
                Vector3 position = new Vector3();
                position.x = col * (tileSize + bridgeSize) + (tileSize/2.0f + 2.5f);
                position.y = -1.0f;
                position.z = row * (tileSize + bridgeSize);

                GameObject go = Instantiate(waterStripPreFab, position, Quaternion.identity);
                go.transform.Rotate(new Vector3(0.0f, 90.0f, 0.0f));
            }
        }
    }

    private void CreateBridges(int col, int row, Vector3 position)
    {
        if (maze.IsLinkedNorth(col, row)) {
            Vector3 northPos = new Vector3();
            northPos.x = position.x;
            northPos.y = -0.30f;
            northPos.z = position.z + tileSize/2.0f + bridgeSize/2.0f;
            Instantiate(bridgePreFab, northPos, Quaternion.identity);
        }

        if (maze.IsLinkedEast(col, row)) {
            Vector3 eastPos = new Vector3();
            eastPos.x = position.x + tileSize/2.0f + bridgeSize/2.0f;
            eastPos.y = -0.30f;
            eastPos.z = position.z;
            GameObject bridge = Instantiate(bridgePreFab, eastPos, Quaternion.identity);
            bridge.transform.Rotate(new Vector3(0.0f, 90.0f, 0.0f));
        }
    }

    private void CreateGrounds(int col, int row, Vector3 position) 
    {
        MazeCell mazeCell = maze.GetMazeCell(col, row);

        if (mazeCell != null) {
            int index = mazeCell.GetMazeIndex();

            switch(index) {
                // Straight PreFab
                case 3:
                    CreateGroundTile(mazeCell, tileStraightPreFab, position, 0.0f);
                    break;
                case 12:
                    CreateGroundTile(mazeCell, tileStraightPreFab, position, 90.0f);
                    break;

                // Elbow PreFab
                case 5:
                    CreateGroundTile(mazeCell, tileElbowPreFeb, position, 0.0f);
                    break;
                case 9:
                    CreateGroundTile(mazeCell, tileElbowPreFeb, position, 90.0f);
                    break;
                case 10:
                    CreateGroundTile(mazeCell, tileElbowPreFeb, position, 180.0f);
                    break;
                case 6:
                    CreateGroundTile(mazeCell, tileElbowPreFeb, position, 270.0f);
                    break;

                // Tee PreFab
                case 7:
                    CreateGroundTile(mazeCell, tileTeePreFeb, position, 0.0f);
                    break;
                case 13:
                    CreateGroundTile(mazeCell, tileTeePreFeb, position, 90.0f);
                    break;
                case 11:
                    CreateGroundTile(mazeCell, tileTeePreFeb, position, 180.0f);
                    break;
                case 14:
                    CreateGroundTile(mazeCell, tileTeePreFeb, position, 270.0f);
                    break;

                // End PreFab
                case 1:
                    CreateGroundTile(mazeCell, tileEndPreFeb, position, 0.0f);
                    break;
                case 8:
                    CreateGroundTile(mazeCell, tileEndPreFeb, position, 90.0f);
                    break;
                case 2:
                    CreateGroundTile(mazeCell, tileEndPreFeb, position, 180.0f);
                    break;
                case 4:
                    CreateGroundTile(mazeCell, tileEndPreFeb, position, 270.0f);
                    break;
            }
        }
    }

    private void CreateGroundTile(MazeCell mazeCell, GameObject preFab, Vector3 position, float rotation) 
    {
        GameObject go = Instantiate(preFab, position, Quaternion.identity);
        go.transform.Rotate(0.0f, rotation, 0.0f);

        GroundBaseCntrl cntrl = go.GetComponent<GroundBaseCntrl>();

        if (cntrl != null) {
            cntrl.mazeCell = mazeCell;
        }
    }
}


